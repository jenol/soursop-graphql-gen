using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Soursop.GraphQL.Gen
{
    public abstract class Selection
    {
        protected Selection() 
        {
            SelectedProperties = new List<string>();
        }
	
        protected List<string> SelectedProperties { get; }	
        protected abstract string SelectionName { get; }
        protected abstract bool TryGetJsonPropertyName(string name, out string jsonName);
	
        protected virtual IEnumerable<Selection> SubSelections
        {
            get
            {
                yield break;
            }	
        }
	
        protected virtual string ArgumentList => "";

        public string ToGraphQL() 
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
			
                var name = member.Name;
                TryGetJsonPropertyName(member.Name, out name);

                if (SelectedProperties.Contains(name)) 
                {
                    continue;	
                }
			
                SelectedProperties.Add(name);
            }			
		
            return this;
        }
    }
}
