namespace ProductData.Services
{
    public class ReportService
    {
        private readonly InventoryService _inventoryService;
        private readonly OrderService _orderService;
        private readonly ProductService _productService;

        public ReportService(InventoryService inventoryService, OrderService orderService, ProductService productService)
        {
            _inventoryService = inventoryService;
            _orderService = orderService;
            _productService = productService;
        }

        // Method to run multiple asynchronous queries concurrently
        public async Task RunMultipleQueriesAsync()
        {
            var productsTask = _productService.GetAllProductsAsync();    // Fetch all products
            var ordersTask = _orderService.GetAllOrdersAsync();          // Fetch all orders
            var inventoryTask = _inventoryService.GetAllInventoriesAsync(); // Fetch all inventory records

            // Run all tasks concurrently and wait for them to complete
            await Task.WhenAll(productsTask, ordersTask, inventoryTask);

            // Access the results from all three services
            var products = await productsTask;
            var orders = await ordersTask;
            var inventories = await inventoryTask;

            Console.WriteLine($"Fetched {products.Count} products, {orders.Count} orders, and {inventories.Count} inventory records.");
        }
    }
}
