using ProductData;
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

            // Delete the product
            var productIdToDelete = products[0].Id;
            productService.DeleteProduct(productIdToDelete);
        }
    }
}