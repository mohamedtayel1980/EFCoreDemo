using ProductDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProductData.Services
{
    public class OrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        // Create a new order with order details
        public void CreateOrder(List<OrderDetail> orderDetails)
        {
            var order = new Order
            {
                OrderDate = DateOnly.FromDateTime(DateTime.Now),
                OrderDetails = orderDetails
            };

            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        // Retrieve all orders with their details and products
        public List<Order> GetAllOrders()
        {
            return _context.Orders
                           .Include(o => o.OrderDetails)
                           .ThenInclude(od => od.Product)
                           .ToList();
        }

        // Retrieve recent orders within a specific number of days
        public List<Order> GetRecentOrders(int days)
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            var comparisonDate = today.AddDays(-days);

            return _context.Orders
                           .Where(o => o.OrderDate >= comparisonDate)
                           .Include(o => o.OrderDetails)
                           .ThenInclude(od => od.Product)
                           .ToList();
        }
        // Asynchronously create a new order with details
        public async Task CreateOrderAsync(List<OrderDetail> orderDetails)
        {
            var order = new Order
            {
                OrderDate = DateOnly.FromDateTime(DateTime.Now),
                OrderDetails = orderDetails
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();  // Asynchronous save
        }

        // Asynchronously retrieve all orders with details
        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders
                                 .Include(o => o.OrderDetails)
                                 .ThenInclude(od => od.Product)
                                 .ToListAsync();
        }

        // Asynchronously retrieve recent orders within a specific number of days
        public async Task<List<Order>> GetRecentOrdersAsync(int days)
        {
            var fromDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-days));

            return await _context.Orders
                                 .Where(o => o.OrderDate >= fromDate)
                                 .Include(o => o.OrderDetails)
                                 .ThenInclude(od => od.Product)
                                 .ToListAsync();
        }
    }
}
