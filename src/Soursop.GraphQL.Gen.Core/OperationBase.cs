using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Soursop.GraphQL.Gen.Core
{
    public abstract class OperationBase: IOperation
    {
        private readonly Lazy<string> _graphQL;

        protected OperationBase(string graphQL)
        {
            _graphQL = new Lazy<string>(() => graphQL);
        }

        public OperationBase(IOperationBuilder builder) 
        {
            _graphQL = new Lazy<string>(() => builder.ToGraphQL());
        }

        protected string GraphQL => _graphQL.Value;

        public abstract IEnumerable<InputValue> Variables { get; }

        public string GetJsonRequest()
        {
            return JsonConvert.SerializeObject(new
            {
                query = GraphQL,
                variables = Variables.ToDictionary(v => v.Name, v => v.Value)
            });
        }
    }
}
