using GraphQL.Types;
using GraphQL.Utilities;

namespace API.GraphQL.GraphQL.Types
{
    public class ProductsGraphQLSchema : Schema
    {
        public ProductsGraphQLSchema(System.IServiceProvider resolver) : base(resolver)
        {
            Query = resolver.GetRequiredService<ProductsGraphQLQuery>();
        }
    }
}
