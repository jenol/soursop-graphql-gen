using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Shouldly;
using Soursop.GraphQL.Gen.Core.Introspection;
using Soursop.GraphQL.Gen.Core.Tests.Assets;
using Soursop.GraphQL.Gen.Core.Tests.Assets.Selections;

namespace Soursop.GraphQL.Gen.Core.Tests
{
    [TestFixture]
    public class SelectorBuildingTests
    {
        [Test, TestCaseSource(nameof(GetSelectorTestCases))]
        public void SelectorTests(string description, Selector selector, string[] expectedPropertyNames)
        {
            selector.SelectedProperties.Count().ShouldBe(expectedPropertyNames.Length);

            foreach (var pair in selector.SelectedProperties)
            {
                expectedPropertyNames.Any(p => p == pair.Value.JsonName).ShouldBeTrue();
            }
        }

        public static IEnumerable<object[]> GetSelectorTestCases()
        {
            object[] GetTestCase(string description, Selector selection, params string[] expectedPropertyNames)
            {
                return new object[] {description, selection, expectedPropertyNames};
            }

            yield return GetTestCase("empty", new PropertySelector());

            yield return GetTestCase("property #1", new PropertySelector().Select(p => p.Id), "id");

            yield return GetTestCase("property #2", new PropertySelector().Select(
                    p => p.FormerName,
                    p => p.ChainId,
                    p => p.Name),
                "formerName",
                "chainId",
                "name");

            yield return GetTestCase("property #3", new PropertySelector().Select(
                    p => p.FormerName,
                    p => p.ChainId,
                    p => p.Name,
                    p => p.ChainId),
                "formerName",
                "chainId",
                "name");

            yield return GetTestCase("property #4", new CountySelector().Select(
                    p => p.Id,
                    p => p.Name),
                "id",
                "name");

            yield return GetTestCase("property #5", new CountySelector().SelectAll(),
                "id",
                "name");
        }

        [Test]
        public void ToGraphQLResultTests()
        {
            
            var builder = new PropertyQueryBuilder();

            var propertySelection = builder.Property;

            propertySelection.Select(
                    p => p.Id,
                    p => p.Name,
                    p => p.ChainId)
                .Countries.Select(
                    c => c.Id,
                    c => c.Name);

            propertySelection.Cities.Select(v => v.Name).Areas.SelectAll();

            var gqle = builder.ToGraphQL();
            gqle.ShouldNotBeNullOrEmpty();

            // builder.Build(1).GetJsonRequest().Dump();	
            // builder.Build(2).GetJsonRequest().Dump(); 
            
            var b = new TypeQueryBuilder();

            b.Type.Select(t => t.Name, t => t.Description);

            b.Type.Fields.Select(f => f.Name);
            

            var gql = b.ToGraphQL();
            gql.ShouldNotBeNullOrEmpty();
        }

    }
}
