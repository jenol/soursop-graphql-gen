using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Soursop.GraphQL.Gen.Core.Introspection.Selections
{
    public interface __ITypeSelection
    {
        object Kind { get; }
        string Name { get; }
        string Description { get; }
        object Fields { get; }
        object InputFields { get; }
        object OfType { get; }
    }

    public class __TypeSelection: Selection<__ITypeSelection>, __ITypeSelection
    {
        protected override string SelectionName => "__type";

        object __ITypeSelection.Kind  { get; }

        string __ITypeSelection.Name  { get; }

        string __ITypeSelection.Description { get; }

        object __ITypeSelection.Fields { get; }

        object __ITypeSelection.InputFields  { get; }

        object __ITypeSelection.OfType  { get; }

        public new __TypeSelection Select(params Expression<Func<__ITypeSelection, object>>[] expressions)  => (__TypeSelection)base.Select(expressions);

        protected override bool TryGetJsonPropertyName(string name, out string jsonName)
        {
            jsonName = "";
            return false;
        }
    }
}
