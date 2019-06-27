using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Soursop.GraphQL.Gen.Core.Tests.Assets.Selections
{
    public class CitySelection : Selection<ICitySelection>, ICitySelection
    {
        private readonly static Dictionary<string, string> _mapping;

        static CitySelection()
        {
            _mapping = new Dictionary<string, string>{
                { "Id", "id" },
                { "Name", "name" },			
            };
        }

        public CitySelection() 
        {
            Areas = new AreaSelection();
        }

        public AreaSelection Areas { get; }
	
        protected override string SelectionName => "City";

        int ICitySelection.Id  { get; }

        string ICitySelection.Name  { get; }

        protected override bool TryGetJsonPropertyName(string name, out string jsonName) => _mapping.TryGetValue(name, out jsonName);
	
        public new CitySelection Select(params Expression<Func<ICitySelection, object>>[] expressions)  => (CitySelection)base.Select(expressions);
    }
}
