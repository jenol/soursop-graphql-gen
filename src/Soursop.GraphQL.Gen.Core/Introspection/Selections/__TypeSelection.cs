using System;
using System.Collections.Generic;
using System.Text;

namespace Soursop.GraphQL.Gen.Core.Introspection.Selections
{
    public interface __ITypeSelection
    {
        object Kind { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        object Fields { get; set; }
        object InputFields { get; set; }
        object OfType { get; set; }
    }

    public class __TypeSelection: Selection<__ITypeSelection>, __ITypeSelection
    {
        public object Kind { get; set; }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public object Fields { get; set; }
        public object InputFields { get; set; }
        public object OfType { get; set; }

        protected override string SelectionName => "__Type";

        protected override bool TryGetJsonPropertyName(string name, out string jsonName)
        {
            throw new NotImplementedException();
        }
    }
}
