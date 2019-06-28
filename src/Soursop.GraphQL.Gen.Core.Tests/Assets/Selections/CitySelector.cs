using Soursop.GraphQL.Gen.Core.Tests.Assets.Models;
using System;
using System.Linq.Expressions;

namespace Soursop.GraphQL.Gen.Core.Tests.Assets.Selections
{
    public class CitySelector : Selector<City, ICitySelector>, ICitySelector
    {
        public CitySelector() 
        {
            Areas = new AreaSelector();
        }

        public AreaSelector Areas { get; }
	
        protected override string SelectionName => "City";

        Selection ICitySelector.Id => (Selection) Selections["Id"];
        Selection ICitySelector.Name => (Selection) Selections["Name"];
	
        public new CitySelector Select(params Expression<Func<ICitySelector, object>>[] expressions)  => (CitySelector)base.Select(expressions);
    }
}
