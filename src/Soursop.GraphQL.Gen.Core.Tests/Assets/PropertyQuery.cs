using System.Collections.Generic;

namespace Soursop.GraphQL.Gen.Core.Tests.Assets
{
    public class PropertyQuery: OperationBase
    {
        internal PropertyQuery(string graphQL, int propertyId) : base(graphQL)
        {
            PropertyId = propertyId;
        }

        public PropertyQuery(IOperationBuilder<PropertyQuery> builder, int propertyId) : base(builder)
        {
            PropertyId = propertyId;
        }	
	
        public int PropertyId { get; }


        public override IEnumerable<InputValue> Variables
        {
            get { yield return new InputValue {Name = "propertyId", TypeName = "Int!", Value = PropertyId}; }
        }
    }
}
