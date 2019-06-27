using System;
using System.Linq.Expressions;
using Soursop.GraphQL.Gen.Core.Introspection.Models;

namespace Soursop.GraphQL.Gen.Core.Introspection.Selections
{
    public interface __IFieldsSelection
    {
        string Name { get; }
    }


    public class __FieldsSelector: Selector<__Field, __IFieldsSelection>, __IFieldsSelection
    {
        protected override string SelectionName => "fields";

        string __IFieldsSelection.Name { get; }

        public new __FieldsSelector Select(params Expression<Func<__IFieldsSelection, object>>[] expressions)  => (__FieldsSelector)base.Select(expressions);
    }
}
