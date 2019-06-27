using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Soursop.GraphQL.Gen.Core.Tests.Assets.Selections;

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
	
        public CitySelection City { get; }
        public CountySelection County { get; }

        int IPropertySelection.Id { get; }
        string IPropertySelection.Name  { get; }
        string IPropertySelection.FormerName  { get; }
        int IPropertySelection.ChainId  { get; }
        float IPropertySelection.StarRating  { get; }

        public new PropertySelection Select(params Expression<Func<IPropertySelection, object>>[] expressions)  => (PropertySelection) base.Select(expressions);
    }
}
