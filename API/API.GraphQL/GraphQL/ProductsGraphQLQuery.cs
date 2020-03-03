using API.DataStore;
using API.GraphQL.GraphQL.Types;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.GraphQL.GraphQL
{
    public class ProductsGraphQLQuery : ObjectGraphType
    {

        public ProductsGraphQLQuery(ProductService productService, SupplierService supplierService)
        {
            Field<ListGraphType<ProductType>>(
                name: "products",
                resolve: context => productService.GetAll()
            );

            Field<ListGraphType<SupplierType>>(
                name: "suppliers",
                resolve: context => supplierService.GetAll()
            );
        }
    }
}
