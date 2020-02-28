using API.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
            return await this.context.Products.ToListAsync();
        }
    }
}
