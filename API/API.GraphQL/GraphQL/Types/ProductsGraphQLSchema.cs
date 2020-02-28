using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.GraphQL.GraphQL.Types
{
    public class ProductsGraphQLSchema : Schema
    {
        public ProductsGraphQLSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<ProductsGraphQLQuery>();
        }
    }
}
