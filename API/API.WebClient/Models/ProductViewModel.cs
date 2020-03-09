using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.WebClient.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public double Price { get; set; }

        public ProductSupplierViewModel Supplier { get; set; }


    }

    public class ProductSupplierViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}
