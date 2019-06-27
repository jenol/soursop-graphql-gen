using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Soursop.GraphQL.Gen.Core.Tests.Assets.Selections
{
    public class AreaSelection : Selection<IAreaSelection>, IAreaSelection
    {
        private readonly static Dictionary<string, string> _mapping;

        static AreaSelection()
        {
            _mapping = new Dictionary<string, string>{
                { "Id", "id" },
                { "Name", "name" },
            };
        }

        protected override string SelectionName => "Areas";

        int IAreaSelection.Id  { get; }

        string IAreaSelection.Name  { get; }

        protected override bool TryGetJsonPropertyName(string name, out string jsonName) => _mapping.TryGetValue(name, out jsonName);

        public new AreaSelection Select(params Expression<Func<IAreaSelection, object>>[] expressions) => (AreaSelection)base.Select(expressions);
    }
}
