using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDomain
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public Collection<Product> Products { get; set; }
       public ICollection<ProductSupplier> ProductSuppliers { get; set; } // Many-to-Many relationship with Products
    }
}
