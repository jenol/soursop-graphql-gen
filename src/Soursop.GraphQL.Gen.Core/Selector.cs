using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Soursop.GraphQL.Gen.Core;

namespace Soursop.GraphQL.Gen
{
    public abstract class Selector
    {
        private IEnumerable<Selector> _subSelections;
        private Dictionary<string, ISelection> _selections;

        protected Selector() 
        {
            SelectedProperties = new List<string>();
        }

        protected Dictionary<string, ISelection> Selections
        {
            get
            {
                if (_selections == null)
                {
                    _selections = new Dictionary<string, ISelection>();

                    var properies = GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly).ToArray();

                    var selectionProperties = properies
                        .Where(p => typeof(ISelection).IsAssignableFrom(p.PropertyType)).ToArray();

                    foreach (var selectionProperty in selectionProperties)
                    {
                        var parts = selectionProperty.Name.Split('.');
                        var name = parts[parts.Length - 1];
                        _selections.Add(name, new Selection());
                    }
                }

                return _selections;
            }
        }

        protected List<string> SelectedProperties { get; }	
        protected abstract string SelectionName { get; }
        protected abstract bool TryGetJsonPropertyName(string name, out string jsonName);
	
        protected virtual IEnumerable<Selector> SubSelections
        {
            get
            {
                if (_subSelections == null)
                {
                    _subSelections = GetType().GetProperties()
                        .Where(p => typeof(Selector).IsAssignableFrom(p.PropertyType))
                        .Select(p => p.GetGetMethod().Invoke(this, BindingFlags.Instance, null, null, null) as Selector)
                        .Where(s => s != null);
                }

                return _subSelections;
            }	
        }

        public IEnumerable<string> SelectedPropertyNames => SelectedProperties;
	
        protected virtual string ArgumentList => "";

        internal string ToGraphQL() 
        {
            var builder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(ArgumentList))
            {
                builder.AppendLine(SelectionName);
            }
            else
            {
                builder.AppendLine($"{SelectionName}({ArgumentList})");
            }
		
            builder.AppendLine("{");
		
            foreach (var name in SelectedProperties)
            {
                builder.AppendLine($"   {name}");
            }
		
            foreach (var subSelection in SubSelections)
            {
                builder.Append(subSelection.ToGraphQL());
            }

            builder.AppendLine("}");
		
            return builder.ToString();
        }
    }

    public abstract class Selector<TModel, TSelector>: Selector
    {
        private static readonly Dictionary<string, string> _propertyNamesLookup;

        static Selector()
        {
            var properties = typeof(TModel).GetProperties(BindingFlags.Instance | BindingFlags.Public).ToArray();
            _propertyNamesLookup = properties
                .ToDictionary(p => p.Name, p => GetJsonName(p));
        }

        private static string GetJsonName(PropertyInfo propertyInfo)
        {
            var jsonPropertyAttribute = propertyInfo.GetCustomAttribute<JsonPropertyAttribute>();

            if (jsonPropertyAttribute == null)
            {
                return propertyInfo.Name;
            }

            return jsonPropertyAttribute.PropertyName;
        }

        protected sealed override bool TryGetJsonPropertyName(string name, out string jsonName)
        {
            return _propertyNamesLookup.TryGetValue(name, out jsonName);
        }

        protected Selector<TModel, TSelector> Select(params Expression<Func<TSelector, object>>[] expressions)
        {
            foreach (var expression in expressions)
            {
                var member = (expression.Body as MemberExpression)?.Member;

                if (member == null)
                {
                    var unary = (expression.Body as UnaryExpression)?.Operand;
                    member = unary == null ? null : (unary as MemberExpression)?.Member;
                }		
			
                if (member == null)
                {
                    continue;
                }

                if (Selections.TryGetValue(member.Name, out var selection))
                {
                    selection.IsSelected = true;
                }
			
                string name = null;

                if (!TryGetJsonPropertyName(member.Name, out name))
                {
                    name = member.Name;
                }

                if (SelectedProperties.Contains(name)) 
                {
                    continue;	
                }
			
                SelectedProperties.Add(name);
            }			
		
            return this;
        }

        public Selector<TModel, TSelector> SelectAll() 
        {
            Clear().SelectedProperties.AddRange(_propertyNamesLookup.Values);
            return this;
        }

        public Selector<TModel, TSelector> Clear() 
        {
            SelectedProperties.Clear();
            return this;
        }
    }
}
