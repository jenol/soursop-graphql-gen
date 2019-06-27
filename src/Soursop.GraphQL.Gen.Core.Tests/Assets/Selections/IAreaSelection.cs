namespace Soursop.GraphQL.Gen.Core.Tests.Assets.Selections
{
    public interface IAreaSelection
    {
        Selection<int> Id { get; }
        Selection<string> Name { get; }
    }
}
