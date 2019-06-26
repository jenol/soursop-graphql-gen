namespace Soursop.GraphQL.Gen.Core
{
    public interface IOperationBuilder 
    {
        string ToGraphQL();
    }

    public interface IOperationBuilder<T>: IOperationBuilder where T : IOperation 
    {
    }
}
