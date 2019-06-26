namespace Soursop.GraphQL.Gen.Core
{
    public interface IOperationBuilder<T> where T : IOperation
    {
        string ToGraphQL();
    }
}
