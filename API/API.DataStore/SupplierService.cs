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
            return await this.context.Suppliers.ToListAsync();
        }

        public async Task<Supplier> GetById(int id)
        {
            return await this.context.FindAsync<Supplier>(id);
        }
    }
}
