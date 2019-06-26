using System.Collections.Generic;

namespace Soursop.GraphQL.Gen.Core.Introspection
{
    public class TypeQuery: OperationBase
    {
        internal TypeQuery(string graphQL, string name) : base(graphQL)
        {
            Name = name;
        }

        public TypeQuery(IOperationBuilder<TypeQuery> builder, string name) : base(builder)
        {
            Name = name;
        }	
	
        public string Name { get; }

        public override IEnumerable<InputValue> Variables
        {
            get { yield return new InputValue {Name = "name", TypeName = "String!", Value = Name }; }
        }
    }
}
