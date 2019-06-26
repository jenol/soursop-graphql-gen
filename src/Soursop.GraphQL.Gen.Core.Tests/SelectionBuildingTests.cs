using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Shouldly;
using Soursop.GraphQL.Gen.Core.Introspection;
using Soursop.GraphQL.Gen.Core.Tests.Assets;

namespace Soursop.GraphQL.Gen.Core.Tests
{
    [TestFixture]
    public class SelectionBuildingTests
    {
        [Test, TestCaseSource(nameof(GetSelectionTestCases))]
        public void SelectionTests(string description, Selection selection, string[] expectedPropertyNames)
        {
            selection.SelectedPropertyNames.Count().ShouldBe(expectedPropertyNames.Length);

            var selectedNames = selection.SelectedPropertyNames.ToArray();
            for (int i = 0; i < selectedNames.Length; i++)
            {
                selectedNames[i].ShouldBe(expectedPropertyNames[i]);
            }
        }

        public static IEnumerable<object[]> GetSelectionTestCases()
        {
            object[] GetTestCase(string description, Selection selection, params string[] expectedPropertyNames)
            {
                return new object[] {description, selection, expectedPropertyNames};
            }

            yield return GetTestCase("empty", new PropertySelection());

            yield return GetTestCase("property #1", new PropertySelection().Select(p => p.Id), "id");

            yield return GetTestCase("property #2", new PropertySelection().Select(
                    p => p.FormerName,
                    p => p.ChainId,
                    p => p.Name),
                "formerName",
                "chainId",
                "name");

            yield return GetTestCase("property #3", new PropertySelection().Select(
                    p => p.FormerName,
                    p => p.ChainId,
                    p => p.Name,
                    p => p.ChainId),
                "formerName",
                "chainId",
                "name");

            yield return GetTestCase("property #4", new CountySelection().Select(
                    p => p.Id,
                    p => p.Name),
                "id",
                "name");

            yield return GetTestCase("property #5", new CountySelection().SelectAll(),
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
                .County.Select(
                    c => c.Id,
                    c => c.Name);

            propertySelection.City.Select(v => v.Name).Areas.SelectAll();

            var gqle = builder.ToGraphQL();
            gqle.ShouldNotBeNullOrEmpty();

            // builder.Build(1).GetJsonRequest().Dump();	
            // builder.Build(2).GetJsonRequest().Dump(); 

            var b = new TypeQueryBuilder();

            b.Type.Select(t => t.Name, t => t.Description);
            

            var gql = b.ToGraphQL();
            gql.ShouldNotBeNullOrEmpty();
        }

    }
}
