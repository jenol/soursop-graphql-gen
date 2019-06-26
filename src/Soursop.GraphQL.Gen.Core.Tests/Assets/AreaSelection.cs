using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Soursop.GraphQL.Gen.Core.Tests.Assets
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

        public int Id { get; internal set; }
        public string Name { get; internal set; }

        protected override string SelectionName => "Areas";
        protected override bool TryGetJsonPropertyName(string name, out string jsonName) => _mapping.TryGetValue(name, out jsonName);

        public new AreaSelection Select(params Expression<Func<IAreaSelection, object>>[] expressions) => (AreaSelection)base.Select(expressions);

        public AreaSelection SelectAll()
        {
            SelectedProperties.Clear();
            SelectedProperties.AddRange(_mapping.Values);
            return this;
        }
    }
}
