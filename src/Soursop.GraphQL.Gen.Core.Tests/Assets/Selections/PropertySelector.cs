using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Soursop.GraphQL.Gen.Core.Tests.Assets.Models;
using Soursop.GraphQL.Gen.Core.Tests.Assets.Selections;

namespace Soursop.GraphQL.Gen.Core.Tests.Assets
{
    public class PropertySelector: Selector<Property, IPropertySelection>, IPropertySelection
    {
        public PropertySelector() 
        {
            Cities = new CitySelector();	
            Countries = new CountySelector();
        }

        protected override string SelectionName => "Property";
        protected override string ArgumentList => "propertyId: $propertyId";
	
        public CitySelector Cities { get; }
        public CountySelector Countries { get; }

        Selection<int> IPropertySelection.Id { get; }
        Selection<string> IPropertySelection.Name  { get; }
        Selection<string> IPropertySelection.FormerName  { get; }
        Selection<int> IPropertySelection.ChainId  { get; }
        Selection<float> IPropertySelection.StarRating  { get; }

        public new PropertySelector Select(params Expression<Func<IPropertySelection, object>>[] expressions)  => (PropertySelector) base.Select(expressions);
    }
}
