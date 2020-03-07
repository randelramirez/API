using API.Core;
using API.DataStore;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.GraphQL.GraphQL.Types
{
    public class SupplierType : ObjectGraphType<Supplier>
    {
        public SupplierType(ProductService productService)
        {
            Field(s => s.Id);
            Field(s => s.Name).Description("The name of the supplier");
            Field(s => s.Address).Description("The address of the supplier");
            Field<ListGraphType<ProductType>>(
                name: nameof(Supplier.Products),
                description: "Products of the supplier",
                resolve: context =>
                {
                    // for validations: https://graphql-dotnet.github.io/docs/getting-started/query-validation/
                    //context.Errors.Add(new ExecutionError("Error message because some validation failed")); //we need to uncomment otherwise the client won't be able to see data
                    return productService.GetBySupplierId(context.Source.Id);
                });

        }
    }
}
