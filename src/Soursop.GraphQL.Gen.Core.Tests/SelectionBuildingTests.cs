using NUnit.Framework;
using Shouldly;
using Soursop.GraphQL.Gen.Core.Tests.Assets;

namespace Soursop.GraphQL.Gen.Core.Tests
{
    [TestFixture]
    public class SelectionBuildingTests
    {
        [Test]
        public void ToGraphQLResultTests()
        {
            var builder = new PropertyQueryBuilder();

            var propertySelection = builder.Property;

            propertySelection.Select(
                    p => p.Id,
                    p => p.Name,
                    p => p.ChainId)
                .County.Select(
                    c => c.Id,
                    c => c.Name);

            propertySelection.City.Select(v => v.Name).Areas.SelectAll();

            var gql = builder.ToGraphQL();
            gql.ShouldNotBeNullOrEmpty();

            // builder.Build(1).GetJsonRequest().Dump();	
            // builder.Build(2).GetJsonRequest().Dump();
        }

    }
}
