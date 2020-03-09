using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.WebClient.Models
{
    public class SupplierViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public IEnumerable<SupplierProductViewModel> Products { get; set; }
    }

    public class SupplierProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public double Price { get; set; }
    }
}
