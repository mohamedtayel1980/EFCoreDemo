using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductDomain
{
    public class Product
    {
        public int Id { get; set; }
        [Required] // Ensures the Name is required
        [MaxLength(100)] // Limits the Name length to 100 characters
        public string Name { get; set; }

        [Range(0, 10000)] // Limits the price to a range
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")] // Defines a foreign key relationship to the Category
        public Category Category { get; set; }
        public Inventory Inventory { get; set; } // One-to-One relationship with Inventory
        //public ICollection<Supplier> Suppliers { get; set; }
        public ICollection<ProductSupplier> ProductSuppliers { get; set; } // Many-to-Many relationship with Suppliers
    }
}

