using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Soursop.GraphQL.Gen.Core.Tests.Assets.Models;

namespace Soursop.GraphQL.Gen.Core.Tests.Assets.Selections
{
    public class AreaSelector : Selector<Area, IAreaSelection>, IAreaSelection
    {
        protected override string SelectionName => "Areas";

        int IAreaSelection.Id  { get; }

        string IAreaSelection.Name  { get; }

        public new AreaSelector Select(params Expression<Func<IAreaSelection, object>>[] expressions) => (AreaSelector)base.Select(expressions);
    }
}
