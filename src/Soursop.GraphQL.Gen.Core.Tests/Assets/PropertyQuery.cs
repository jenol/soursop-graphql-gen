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


        public override IEnumerable<Variable> Variables
        {
            get { yield return new Variable { Name = "propertyId", Type = GraphQLTypes.Int, IsRequired = true, Value = PropertyId}; }
        }
    }
}
