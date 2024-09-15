namespace ProductDomain
{
    public class Inventory
    {
        private int _quantity; // Backing field for Quantity

        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Quantity cannot be negative.");
                _quantity = value;
            }
        }
    }
}
