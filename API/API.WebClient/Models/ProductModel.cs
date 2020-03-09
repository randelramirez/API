using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.WebClient.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public ProductSupplierViewModel Supplier { get; set; }


    }
}
