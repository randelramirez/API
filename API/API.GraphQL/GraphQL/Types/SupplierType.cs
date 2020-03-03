using API.Core;
using API.DataStore;
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
                resolve: context => productService.GetBySupplierId(context.Source.Id));

        }
    }
}
