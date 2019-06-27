using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Soursop.GraphQL.Gen.Core.Tests.Assets.Models;

namespace Soursop.GraphQL.Gen.Core.Tests.Assets.Selections
{
    public class CountySelector : Selector<Country, ICountySelection>, ICountySelection
    {
        protected override string SelectionName => "County";

        int ICountySelection.Id { get; }

        string ICountySelection.Name  { get; }
	
        public new CountySelector Select(params Expression<Func<ICountySelection, object>>[] expressions)  => (CountySelector)base.Select(expressions);
    }
}
