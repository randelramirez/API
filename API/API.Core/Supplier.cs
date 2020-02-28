using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core
{
    public class Supplier
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
