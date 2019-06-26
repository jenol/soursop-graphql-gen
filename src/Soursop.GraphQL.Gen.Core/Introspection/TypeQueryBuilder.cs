using System;
using System.Collections.Generic;
using Soursop.GraphQL.Gen.Core.Introspection.Selections;

namespace Soursop.GraphQL.Gen.Core.Introspection
{
    public class TypeQueryBuilder : OperationBuilderBase<TypeQuery>
    {
        public TypeQueryBuilder()
        {
            Type = new __TypeSelection();
        }

        public __TypeSelection Type { get; }


        protected override IEnumerable<Selection> Selections
        {
            get { yield return Type; }
        }

        protected override IEnumerable<InputValue> Variables 
        {
            get { yield return new InputValue{ Name = "name", TypeName = "Int!" }; }
        }
    }
}
