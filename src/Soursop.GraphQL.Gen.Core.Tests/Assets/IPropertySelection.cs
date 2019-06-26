using System;
using System.Collections.Generic;
using System.Text;

namespace Soursop.GraphQL.Gen.Core.Tests.Assets
{
    public interface IPropertySelection
    {
        int Id { get; }
        string Name { get; }
        string FormerName { get;}
        int ChainId { get; }
        float StarRating { get; }
    }
}
