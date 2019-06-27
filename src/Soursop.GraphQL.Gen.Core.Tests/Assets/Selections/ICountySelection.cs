namespace Soursop.GraphQL.Gen.Core.Tests.Assets.Selections
{
    public interface ICountySelection
    {	
        Selection<int> Id { get; }
        Selection<string> Name { get; }
    }
}
