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

        protected override IEnumerable<Variable> Variables
        {
            get { yield return new Variable {Name = "propertyId", Type = GraphQLTypes.Int, IsRequired = true }; }
        }

        protected override IEnumerable<Selector> Selections
        {
            get { yield return Property; }
        }
    }
}
