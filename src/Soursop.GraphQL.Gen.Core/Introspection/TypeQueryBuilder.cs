using System;
using Soursop.GraphQL.Gen.Core.Introspection.Selections;

namespace Soursop.GraphQL.Gen.Core.Introspection
{
    public class TypeQueryBuilder : IOperationBuilder<TypeQuery>
    {
        public TypeQueryBuilder()
        {
            Type = new __TypeSelection();
        }

        public __TypeSelection Type { get; }


        public string ToGraphQL()
        {
            throw new NotImplementedException();
        }
    }
}
