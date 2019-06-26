using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Soursop.GraphQL.Gen.Core.Tests.Assets
{
    public class CountySelection : Selection<ICountySelection>, ICountySelection
    {
        private readonly static Dictionary<string, string> _mapping;

        static CountySelection()
        {
            _mapping = new Dictionary<string, string>{
                { "Id", "id" },
                { "Name", "name" },			
            };
        }

        public int Id { get; internal set; }
        public string Name { get; internal set; }
	
        protected override string SelectionName => "County";	
        protected override bool TryGetJsonPropertyName(string name, out string jsonName) => _mapping.TryGetValue(name, out jsonName);
	
        public new CountySelection Select(params Expression<Func<ICountySelection, object>>[] expressions)  => (CountySelection)base.Select(expressions);
    }
}
