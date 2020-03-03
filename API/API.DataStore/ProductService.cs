using API.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace API.DataStore
{
    public class ProductService
    {
        private readonly ApiDataContext context;

        public ProductService(ApiDataContext context)
        {
            this.context = context;
        }

        public async Task<List<Product>> GetAll()
        {
            return await this.context.Products.AsNoTracking().ToListAsync();
        }

        public async Task<List<Product>> GetBySupplierId(int supplierId)
        {
            return await this.context.Products.Where(p => p.SupplierId == supplierId).ToListAsync();
        }


        public async Task<ILookup<int, Product>> GetBySupplierIds(IEnumerable<int> supplierIds)
        {
            var products = await this.context.Products.Where(p => supplierIds.Contains(p.SupplierId)).ToListAsync();
            return products.ToLookup(p => p.SupplierId);
        }
    }
}