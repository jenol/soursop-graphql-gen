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
            SelectedProperties = new Dictionary<string, PropertyMappingInfo>();
        }

        protected abstract Dictionary<string, PropertyMappingInfo> PropertyInfoMapping { get; }

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

        public Dictionary<string, PropertyMappingInfo> SelectedProperties { get; }	
        protected abstract string SelectionName { get; }
        protected abstract bool TryGetJsonPropertyName(string name, out string jsonName);
	
        protected virtual IEnumerable<Selector> SubSelections
        {
            get
            {
                return _subSelections ?? (_subSelections = GetType().GetProperties()
                           .Where(p => typeof(Selector).IsAssignableFrom(p.PropertyType))
                           .Select(p =>
                               p.GetGetMethod().Invoke(this, BindingFlags.Instance, null, null, null) as Selector)
                           .Where(s => s != null));
            }	
        }

        protected virtual string ArgumentList => "";

        internal string ToGraphQL() 
        {
            var builder = new StringBuilder();

            builder.AppendLine(string.IsNullOrWhiteSpace(ArgumentList)
                ? SelectionName
                : $"{SelectionName}({ArgumentList})");

            builder.AppendLine("{");
		
            foreach (var property in SelectedProperties)
            {
                builder.AppendLine($"   {property.Value.JsonName}");
            }
		
            foreach (var subSelection in SubSelections)
            {
                builder.Append(subSelection.ToGraphQL());
            }

            builder.AppendLine("}");
		
            return builder.ToString();
        }
    }
}
