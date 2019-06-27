using System;
using System.Linq.Expressions;
using Soursop.GraphQL.Gen.Core.Introspection.Models;

namespace Soursop.GraphQL.Gen.Core.Introspection.Selections
{
    public interface __ITypeSelection
    {
        Selection Kind { get; }
        Selection Name { get; }
        Selection Description { get; }
        Selection InputFields { get; }
        Selection OfType { get; }
    }

    public class __TypeSelector: Selector<__Type, __ITypeSelection>, __ITypeSelection
    {
        public __TypeSelector()
        {
            Fields = new __FieldsSelector();
        }

        protected override string SelectionName => "__type";

        Selection __ITypeSelection.Kind  { get; }

        Selection __ITypeSelection.Name  { get; }

        Selection __ITypeSelection.Description { get; }

        Selection __ITypeSelection.InputFields  { get; }

        Selection __ITypeSelection.OfType  { get; }

        protected override string ArgumentList => "name: $name";

        public __FieldsSelector Fields { get; internal set; }

        public new __TypeSelector Select(params Expression<Func<__ITypeSelection, object>>[] expressions)  => (__TypeSelector)base.Select(expressions);
    }
}
