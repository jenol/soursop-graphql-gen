using System;
using System.Linq.Expressions;
using Soursop.GraphQL.Gen.Core.Tests.Assets.Models;

namespace Soursop.GraphQL.Gen.Core.Tests.Assets.Selections
{
    public class CountySelector : Selector<Country, ICountySelector>, ICountySelector
    {
        public CountySelector()
        {
        }

        protected override string SelectionName => "County";

        Selection ICountySelector.Id => (Selection) Selections["Id"];
        Selection ICountySelector.Name => (Selection) Selections["Name"];

        public new CountySelector Select(params Expression<Func<ICountySelector, object>>[] expressions)  => (CountySelector)base.Select(expressions);
    }
}
