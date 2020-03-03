using API.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.DataStore.Extensions
{
    public static class DataInitializer
    {
        public static void SeedData(this ApiDataContext dataContext)
        {
            if (!dataContext.Suppliers.Any())
            {
                createSuppliers();
            }
            if (!dataContext.Products.Any())
            {
                createProducts();
            }

            void createSuppliers()
            {
                var suppliers = new List<Supplier>
                {
                    new Supplier { Name = "HP", Address = "Mckinley" },
                    new Supplier { Name = "Apple", Address = "Cupertino" },
                    new Supplier { Name = "Microsoft", Address = "Seattle" }
                };

                suppliers.ForEach(s => dataContext.Add(s));
                dataContext.SaveChanges();
            }

            void createProducts()
            {
                var products = new List<Product>();

                //HP Products
                var hp = dataContext.Suppliers.AsNoTracking().Single(s => s.Name == "HP");
                products.Add(new Product { Name = "Printer xxx-2020", Price = 300.50, Status = ProductStatus.Active, SupplierId = hp.Id });
                products.Add(new Product { Name = "Compaq Presario", Price = 500.80, Status = ProductStatus.Inactive, SupplierId = hp.Id });
                products.Add(new Product { Name = "HP-ENVY 15", Price = 800, Status = ProductStatus.Active, SupplierId = hp.Id });
                products.Add(new Product { Name = "HP-ENVY 17", Price = 1200.70, Status = ProductStatus.Active, SupplierId = hp.Id });
                products.Add(new Product { Name = "HP-PAVILION 14", Price = 550, Status = ProductStatus.Active, SupplierId = hp.Id });


                //APPLE Products
                var apple = dataContext.Suppliers.AsNoTracking().Single(s => s.Name == "Apple");
                products.Add(new Product { Name = "iPhone 8", Price = 800, Status = ProductStatus.Active, SupplierId = apple.Id });
                products.Add(new Product { Name = "iPhone X", Price = 900, Status = ProductStatus.Inactive, SupplierId = apple.Id });
                products.Add(new Product { Name = "iPhone 11 Pro", Price = 1100, Status = ProductStatus.Active, SupplierId = apple.Id });
                products.Add(new Product { Name = "iPhone 11 Max", Price = 1200.70, Status = ProductStatus.Active, SupplierId = apple.Id });
                products.Add(new Product { Name = "iPad Pro", Price = 900, Status = ProductStatus.Active, SupplierId = apple.Id });
                products.Add(new Product { Name = "iPod", Price = 300, Status = ProductStatus.Inactive, SupplierId = apple.Id });

                //Microsoft
                var microsoft = dataContext.Suppliers.AsNoTracking().Single(s => s.Name == "Microsoft");
                products.Add(new Product { Name = "Surface Pro 3", Price = 800, Status = ProductStatus.Active, SupplierId = microsoft.Id });
                products.Add(new Product { Name = "Surface Duo", Price = 1200, Status = ProductStatus.Inactive, SupplierId = microsoft.Id });
                products.Add(new Product { Name = "Surface Neo", Price = 1300, Status = ProductStatus.Active, SupplierId = microsoft.Id });
                products.Add(new Product { Name = "Zune", Price = 400.50, Status = ProductStatus.Discontinued, SupplierId = microsoft.Id });
                products.Add(new Product { Name = "Office 365", Price = 745.75, Status = ProductStatus.Active, SupplierId = microsoft.Id });
                products.Add(new Product { Name = "Visual Studio Enterprise", Price = 1100.85, Status = ProductStatus.Inactive, SupplierId = microsoft.Id });

                products.ForEach(p => dataContext.Add(p));
                dataContext.SaveChanges();
            }
        }
    }
}
