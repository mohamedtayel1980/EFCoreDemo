using ProductData;
using ProductData.Services;
using System;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new AppDbContext())
        {
            var productService = new ProductService(context);

            // Create a product
            productService.CreateProduct("Laptop", 999.99M, "Electronics");

            // Read all products
            var products = productService.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine($"Product: {product.Name}, Category: {product.Category.Name}, Price: {product.Price}");
            }

            // Update product price
            var productIdToUpdate = products[0].Id;
            productService.UpdateProductPrice(productIdToUpdate, 899.99M);

            
        }
        CallInventory();

    }

    public static void CallInventory()
    {
        using (var context = new AppDbContext())
        {
            var inventoryService = new InventoryService(context);

            // Access seeded inventory data for Product 1
            var inventory = inventoryService.GetInventoryByProduct(3);
            Console.WriteLine($"Product 3 has {inventory.Quantity} items in stock.");

            // Update quantity with a valid value (greater than 0)
            inventoryService.UpdateQuantity(3, 150);
            Console.WriteLine("Quantity updated to 150.");

            // Try updating with an invalid quantity (less than 0)
            try
            {
                inventoryService.UpdateQuantity(3, -50);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}