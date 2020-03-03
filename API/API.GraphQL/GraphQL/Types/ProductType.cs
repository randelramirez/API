using API.Core;
using API.DataStore;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.GraphQL.GraphQL.Types
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType(SupplierService supplierService)
        {
            Field(p => p.Id);
            Field(p => p.Name).Description("The name of the product");
            Field(p => p.Price).Description("The price of the product");
            Field<ProductStatusEnumType>(nameof(Product.Status), "The status of the product"); // not sure if we need description here since it's been set on the EnumType already

            Field<SupplierType>(
                name: nameof(Product.Supplier),
                resolve: context => supplierService.GetOneById(context.Source.SupplierId));
        }
    }
}
