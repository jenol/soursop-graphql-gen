using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Soursop.GraphQL.Gen.Core
{
    public abstract class OperationBuilderBase<T> : IOperationBuilder<T> where T : IOperation
    {
        public string ToGraphQL()
        {
            var builder = new StringBuilder();

            var variablesText = "";

            if (Variables != null && Variables.Any())
            {
                variablesText = $"({string.Join(" ,", Variables.Select(v => $"${v.Name}: {v.TypeName}"))})";
            }

            builder.AppendLine($"query {variablesText} {{ ");

            foreach (var selection in Selections)
            {
                builder.Append(selection.ToGraphQL());		
            }	

            builder.AppendLine("}");		
            return builder.ToString();
        }

        protected abstract IEnumerable<Selector> Selections { get; }
        protected abstract IEnumerable<InputValue> Variables { get; }
    }
}
