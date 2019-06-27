namespace Soursop.GraphQL.Gen.Core.Tests.Assets.Selections
{
    public interface IPropertySelection
    {
        Selection<int> Id { get; }
        Selection<string> Name { get; }
        Selection<string> FormerName { get; }
        Selection<int> ChainId { get; }
        Selection<float> StarRating { get; }
    }
}
