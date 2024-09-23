using Microsoft.EntityFrameworkCore;
using ProductData;
using ProductData.Services;
using ProductDomain;
using System;
using System.Diagnostics;

class Program
{
    static async Task Main(string[] args)
    {
        //CallProdcut();
        //CallInventory();
        //callOrder();
        await TestQueryPerformanceAsync();
    }

    private static void CallProdcut()
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
            // Retrieve products by category (e.g., "Electronics")
            var electronicsProducts = productService.GetProductsByCategory("Electronics");
            foreach (var product in electronicsProducts)
            {
                Console.WriteLine($"Product: {product.Name}, Price: {product.Price}");
            }


        }
    }

    private static void CallInventory()
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
            var lastUpdated = inventoryService.GetLastUpdated(3);
            Console.WriteLine($"Product 1 Last Updated: {lastUpdated}");
            // Try updating with an invalid quantity (less than 0)
            try
            {
                inventoryService.UpdateQuantity(3, -50);
                // Sum total stock for a product (e.g., ProductId = 1)
                var totalStock = inventoryService.GetTotalStockByProduct(3);
                Console.WriteLine($"Total stock for product 1: {totalStock}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    private static void callOrder()
    {
        using (var context = new AppDbContext())
        {
            var orderService = new OrderService(context);
            // Create a new order with order details
            var orderDetails = new List<OrderDetail>
    {
        new OrderDetail { ProductId = 3, Quantity = 2, Price = 999.99M },
        new OrderDetail { ProductId = 4, Quantity = 1, Price = 499.99M }
    };
            orderService.CreateOrder(orderDetails);

            // Query recent orders (within the last 30 days)
            var recentOrders = orderService.GetRecentOrders(30);
            foreach (var order in recentOrders)
            {
                Console.WriteLine($"Order {order.OrderId}, Date: {order.OrderDate}");
            }
        }
    }

    public static async Task TestQueryPerformanceAsync()
    {
        using (var _context = new AppDbContext())
        {
            var productService = new ProductService(_context);
            var stopwatch = new Stopwatch();

            // Measure synchronous query time
            stopwatch.Start();
            var productsSync = productService.GetAllProducts(); // Synchronous
            stopwatch.Stop();
            Console.WriteLine($"Synchronous query time: {stopwatch.ElapsedMilliseconds} ms");

            // Measure asynchronous query time
            stopwatch.Start();
            var productsAsync = await productService.GetAllProductsAsync();  // Asynchronous
            stopwatch.Stop();
            Console.WriteLine($"Asynchronous query time: {stopwatch.ElapsedMilliseconds} ms");
        }
            
    }
}