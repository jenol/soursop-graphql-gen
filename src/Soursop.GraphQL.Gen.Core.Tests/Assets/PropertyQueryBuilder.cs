using System;
using System.Collections.Generic;
using System.Text;

namespace Soursop.GraphQL.Gen.Core.Tests.Assets
{
    public class PropertyQueryBuilder: IOperationBuilder<PropertyQuery>
    {
        public PropertyQueryBuilder() 
        {		
            Property = new PropertySelection();	
        }	
	
        public PropertySelection Property { get;}

        public string ToGraphQL() 
        {
            var builder = new StringBuilder();
            builder.AppendLine("query ($propertyId: Int!) { ");		
            builder.Append(Property.ToGraphQL());		
            builder.AppendLine("}");		
            return builder.ToString();
        }

        public PropertyQuery Build(int propertyId) 
        {
            return new PropertyQuery(ToGraphQL(), propertyId);
        }
    }
}
