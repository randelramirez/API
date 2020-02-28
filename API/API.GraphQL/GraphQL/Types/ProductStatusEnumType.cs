using API.Core;
using GraphQL.Types;

namespace API.GraphQL.GraphQL.Types
{
    public class ProductStatusEnumType : EnumerationGraphType<ProductStatus>
    {
        public ProductStatusEnumType()
        {
            Name = nameof(Product.Status);
            Description = "The status of the product";
        }
    }
}