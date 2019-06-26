using System.Collections.Generic;

namespace Soursop.GraphQL.Gen.Core
{
    public interface IOperation
    {
        string GetJsonRequest();
        IEnumerable<InputValue> Variables { get; }
    }

    public class InputValue
    {
        public string Name { get; set; }
        public string TypeName { get; set; }
        public object Value { get; set; }
    }
}
