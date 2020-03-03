using API.DataStore;
using API.GraphQL.GraphQL.Types;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

            Field<ProductType>(
               name: "product",
               arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
               resolve: context =>
               {
                   var user = (ClaimsPrincipal)context.UserContext;
                   // do user checking based on user claims (Authorization)

                   var id = context.GetArgument<int>("id");
                   return productService.GetOneById(id);
               }
           );

            Field<ListGraphType<SupplierType>>(
                name: "suppliers",
                resolve: context => supplierService.GetAll()
            );

            Field<SupplierType>(
               name: "supplier",
               arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
               resolve: context =>
               {
                   var user = (ClaimsPrincipal)context.UserContext;
                   // do user checking based on user claims (Authorization)

                   var id = context.GetArgument<int>("id");
                   return supplierService.GetOneById(id);
               }
           );
        }
    }
}
