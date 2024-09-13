namespace ProductDomain
{
    public class ProductSupplier
    {
        public int Id { get; set; } // Primary key for the join table
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
