using API.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.DataStore
{
    public class SupplierService
    {

        private readonly ApiDataContext context;

        public SupplierService(ApiDataContext context)
        {
            this.context = context;
        }

        public async Task<List<Supplier>> GetAll()
        {
            return await this.context.Suppliers.AsNoTracking().ToListAsync();
        }

        public async Task<Supplier> GetOneById(int id)
        {
            return await this.context.FindAsync<Supplier>(id);
        }

        public async Task<Supplier> GetByProductId(int id)
        {

            var product = await this.context.Products.Include(p => p.Supplier).AsNoTracking().FirstAsync(p => p.Id == id);
            return product.Supplier;
        }
    }
}
