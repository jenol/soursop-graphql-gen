namespace Soursop.GraphQL.Gen.Core.Tests.Assets.Selections
{
    public interface IPropertySelector
    {
        Selection Id { get; }
        Selection Name { get; }
        Selection FormerName { get; }
        Selection ChainId { get; }
        Selection StarRating { get; }
    }
}
