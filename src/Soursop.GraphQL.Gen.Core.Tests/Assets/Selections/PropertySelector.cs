using System;
using System.Linq.Expressions;
using Soursop.GraphQL.Gen.Core.Tests.Assets.Models;
using Soursop.GraphQL.Gen.Core.Tests.Assets.Selections;

namespace Soursop.GraphQL.Gen.Core.Tests.Assets
{
    public class PropertySelector: Selector<Property, IPropertySelector>, IPropertySelector
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

        Selection IPropertySelector.Id => (Selection) Selections["Id"];
        Selection IPropertySelector.Name => (Selection) Selections["Name"];
        Selection IPropertySelector.FormerName => (Selection) Selections["FormerName"];
        Selection IPropertySelector.ChainId => (Selection) Selections["ChainId"];
        Selection IPropertySelector.StarRating => (Selection) Selections["StarRating"];

        public new PropertySelector Select(params Expression<Func<IPropertySelector, object>>[] expressions)  => (PropertySelector) base.Select(expressions);
    }
}
