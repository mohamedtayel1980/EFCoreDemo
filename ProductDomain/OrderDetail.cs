namespace ProductDomain
{
    public class OrderDetail
    {
        public int OrderId { get; set; }  // Foreign key to Order
        public int ProductId { get; set; }  // Foreign key to Product
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Order Order { get; set; }  // Navigation property to Order
    }
}
