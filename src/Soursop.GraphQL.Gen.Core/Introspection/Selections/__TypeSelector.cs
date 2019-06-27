using System;
using System.Linq.Expressions;
using Soursop.GraphQL.Gen.Core.Introspection.Models;

namespace Soursop.GraphQL.Gen.Core.Introspection.Selections
{
    public interface __ITypeSelection
    {
        object Kind { get; }
        string Name { get; }
        string Description { get; }
        object InputFields { get; }
        object OfType { get; }
    }

    public class __TypeSelector: Selector<__Type, __ITypeSelection>, __ITypeSelection
    {
        public __TypeSelector()
        {
            Fields = new __FieldsSelector();
        }

        protected override string SelectionName => "__type";

        object __ITypeSelection.Kind  { get; }

        string __ITypeSelection.Name  { get; }

        string __ITypeSelection.Description { get; }

        object __ITypeSelection.InputFields  { get; }

        object __ITypeSelection.OfType  { get; }

        protected override string ArgumentList => "name: $name";

        public __FieldsSelector Fields { get; internal set; }

        public new __TypeSelector Select(params Expression<Func<__ITypeSelection, object>>[] expressions)  => (__TypeSelector)base.Select(expressions);
    }
}
