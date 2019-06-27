using Soursop.GraphQL.Gen.Core.Tests.Assets.Models;
using System;
using System.Linq.Expressions;

namespace Soursop.GraphQL.Gen.Core.Tests.Assets.Selections
{
    public class CitySelector : Selector<City, ICitySelection>, ICitySelection
    {
        public CitySelector() 
        {
            Areas = new AreaSelector();
        }

        public AreaSelector Areas { get; }
	
        protected override string SelectionName => "City";

        Selection<int> ICitySelection.Id  { get; }

        Selection<string> ICitySelection.Name  { get; }
	
        public new CitySelector Select(params Expression<Func<ICitySelection, object>>[] expressions)  => (CitySelector)base.Select(expressions);
    }
}
