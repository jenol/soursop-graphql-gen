namespace Soursop.GraphQL.Gen.Core
{
    public interface ISelection
    {
        bool IsSelected { get; set; }
    }

    public class Selection: ISelection
    {
        bool ISelection.IsSelected { get; set; }
    }
}
