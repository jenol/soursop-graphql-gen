﻿using System;
using System.Collections.Generic;
using Soursop.GraphQL.Gen.Core.Introspection.Selections;

namespace Soursop.GraphQL.Gen.Core.Introspection
{
    public class TypeQueryBuilder : OperationBuilderBase<TypeQuery>
    {
        public TypeQueryBuilder()
        {
            Type = new __TypeSelector();
        }

        public __TypeSelector Type { get; }


        protected override IEnumerable<Selector> Selections
        {
            get { yield return Type; }
        }

        protected override IEnumerable<Variable> Variables 
        {
            get { yield return new Variable{ Name = "name", Type = GraphQLTypes.String, IsRequired = true }; }
        }
    }
}
