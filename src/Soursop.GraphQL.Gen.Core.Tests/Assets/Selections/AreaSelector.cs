using System;
using System.Linq.Expressions;
using Soursop.GraphQL.Gen.Core.Tests.Assets.Models;

namespace Soursop.GraphQL.Gen.Core.Tests.Assets.Selections
{
    public class AreaSelector : Selector<Area, IAreaSelector>, IAreaSelector
    {
        public AreaSelector()
        {
        }

        protected override string SelectionName => "Areas";

        Selection IAreaSelector.Id => (Selection) Selections["Id"];
        Selection IAreaSelector.Name => (Selection) Selections["Name"];

        public new AreaSelector Select(params Expression<Func<IAreaSelector, object>>[] expressions) => (AreaSelector)base.Select(expressions);
    }
}
