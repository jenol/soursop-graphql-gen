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

        int IPropertySelection.Id { get; }
        string IPropertySelection.Name  { get; }
        string IPropertySelection.FormerName  { get; }
        int IPropertySelection.ChainId  { get; }
        float IPropertySelection.StarRating  { get; }

        public new PropertySelector Select(params Expression<Func<IPropertySelection, object>>[] expressions)  => (PropertySelector) base.Select(expressions);
    }
}
