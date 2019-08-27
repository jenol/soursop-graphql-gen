using System.Collections.Generic;

namespace Soursop.GraphQL.Gen.Core
{
    public interface IOperation
    {
        string GetJsonRequest();
        IEnumerable<Variable> Variables { get; }
    }
}
