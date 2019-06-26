using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Soursop.GraphQL.Gen.Core.Tests.Assets
{
    public class PropertySelection: Selection<IPropertySelection>, IPropertySelection
    {
        private readonly static Dictionary<string, string> _mapping;
	
        static PropertySelection()
        {
            _mapping = new Dictionary<string, string>{
                { "Id", "id" },
                { "Name", "name" },
                { "ChainId", "chainId" },
                { "FormerName", "formerName" },
                { "StarRating", "starRating" }
            };
        }
	
        public PropertySelection() 
        {
            City = new CitySelection();	
            County = new CountySelection();
        }

        protected override string SelectionName => "Property";
        protected override bool TryGetJsonPropertyName(string name, out string jsonName) => _mapping.TryGetValue(name, out jsonName);
        protected override string ArgumentList => "propertyId: $propertyId";
	
        protected override IEnumerable<Selection> SubSelections 
        {
            get 
            {
                yield return City;	
                yield return County;	
            }
        }

        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public string FormerName { get; internal set; }
        public int ChainId { get; internal set; }
        public float StarRating { get; internal set; }
	
        public CitySelection City { get; }
        public CountySelection County { get; }

        public new PropertySelection Select(params Expression<Func<IPropertySelection, object>>[] expressions)  => (PropertySelection) base.Select(expressions);
    }
}
