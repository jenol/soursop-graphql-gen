using System;
using System.Linq.Expressions;
using Soursop.GraphQL.Gen.Core.Introspection.Models;

namespace Soursop.GraphQL.Gen.Core.Introspection.Selections
{
    public interface __IFieldsSelection
    {
        Selection Name { get; }
    }


    public class __FieldsSelector: Selector<__Field, __IFieldsSelection>, __IFieldsSelection
    {
        protected override string SelectionName => "fields";

        Selection __IFieldsSelection.Name { get; }

        public new __FieldsSelector Select(params Expression<Func<__IFieldsSelection, object>>[] expressions)  => (__FieldsSelector)base.Select(expressions);
    }
}
