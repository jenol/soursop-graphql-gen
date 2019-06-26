using Newtonsoft.Json;
using System;

namespace Soursop.GraphQL.Gen.Core.Tests.Assets
{
    public class PropertyQuery: IOperation
    {
        private readonly Lazy<string> _graphQL;
	
        internal PropertyQuery(string graphQL, int propertyId)
        {
            _graphQL = new Lazy<string>(() => graphQL);
            PropertyId = propertyId;
        }
	
        public int PropertyId { get; }

        public PropertyQuery(IOperationBuilder<PropertyQuery> builder, int propertyId) 
        {
            _graphQL = new Lazy<string>(() => builder.ToGraphQL());
            PropertyId = propertyId;
        }	

        public string GetJsonRequest()
        {
            return JsonConvert.SerializeObject(new
            {
                query = _graphQL.Value,
                variables = new { propertyId = PropertyId}
            });
        }
    }
}
