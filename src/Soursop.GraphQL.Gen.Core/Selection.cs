using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Soursop.GraphQL.Gen
{
    public abstract class Selection
    {
        private IEnumerable<Selection> _subSelections;

        protected Selection() 
        {
            SelectedProperties = new List<string>();
        }
	
        protected List<string> SelectedProperties { get; }	
        protected abstract string SelectionName { get; }
        protected abstract bool TryGetJsonPropertyName(string name, out string jsonName);
	
        protected IEnumerable<Selection> SubSelections
        {
            get
            {
                if (_subSelections == null)
                {
                    _subSelections = GetType().GetProperties()
                        .Where(p => typeof(Selection).IsAssignableFrom(p.PropertyType))
                        .Select(p => p.GetGetMethod().Invoke(this, BindingFlags.Instance, null, null, null) as Selection)
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

    public abstract class Selection<TSelection>: Selection
    {
        public Selection()
        {
            AllNames = new Lazy<string[]>(typeof(TSelection).GetProperties()
                .Select(p => TryGetJsonPropertyName(p.Name, out var jsonName) ? jsonName : p.Name).ToArray());
        }

        protected Lazy<string[]> AllNames { get; }

        protected Selection<TSelection> Select(params Expression<Func<TSelection, object>>[] expressions)
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

        public Selection<TSelection> SelectAll() 
        {
            SelectedProperties.Clear();
            SelectedProperties.AddRange(AllNames.Value);
            return this;
        }
    }
}
