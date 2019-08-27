using System;
using System.Collections.Generic;
using System.Text;

namespace Soursop.GraphQL.Gen.Core
{
    public class Variable
    {
        public string Name { get; set; }
        public GraphQLTypes Type { get; set; }
        public bool IsRequired { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return $"{Type}{(IsRequired ? "!" : "")}";
        }
    }
}
