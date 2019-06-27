namespace Soursop.GraphQL.Gen.Core.Tests.Assets.Selections
{
    public interface ICitySelection
    {
        Selection<int> Id { get; }
        Selection<string> Name { get; }
    }

}
