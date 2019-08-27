using System;
using System.Collections.Generic;
using System.Text;

namespace Soursop.GraphQL.Gen.Core
{
    public class PropertyMappingInfo
    {
        public string Name { get; set; }
        public string JsonName { get; set; }
        public GraphQLTypes GraphQLType { get; set; }
    }
}
