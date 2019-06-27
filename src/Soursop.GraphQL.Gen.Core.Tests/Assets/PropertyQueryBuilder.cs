using System.Collections.Generic;
using System.Text;

namespace Soursop.GraphQL.Gen.Core.Tests.Assets
{
    public class PropertyQueryBuilder: OperationBuilderBase<PropertyQuery>
    {
        public PropertyQueryBuilder() 
        {		
            Property = new PropertySelector();	
        }	
	
        public PropertySelector Property { get;}

        public PropertyQuery Build(int propertyId) 
        {
            return new PropertyQuery(ToGraphQL(), propertyId);
        }

        protected override IEnumerable<InputValue> Variables
        {
            get { yield return new InputValue {Name = "propertyId", TypeName = "Int!" }; }
        }

        protected override IEnumerable<Selector> Selections
        {
            get { yield return Property; }
        }
    }
}
