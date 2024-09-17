using ProductDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductData.Services
{
    public class InventoryService
    {
        private readonly AppDbContext _context;

        public InventoryService(AppDbContext context)
        {
            _context = context;
        }

        // Retrieve inventory by ProductId
        public Inventory GetInventoryByProduct(int productId)
        {
            return _context.Inventories.FirstOrDefault(i => i.ProductId == productId);
        }

        // Update the quantity of inventory for a specific product
        public void UpdateQuantity(int productId, int quantity)
        {
            var inventory = _context.Inventories.FirstOrDefault(i => i.ProductId == productId);
            if (inventory != null)
            {
                try
                {
                    inventory.Quantity = quantity;  // Backing field logic will validate this
                      // Update the LastUpdated shadow property
                    _context.Entry(inventory).Property("LastUpdated").CurrentValue = DateTime.Now;
                    _context.SaveChanges();
                }
                catch (ArgumentException ex)
                {
                    // Log the exception or throw a custom error if needed
                    throw new ArgumentException(ex.Message);
                }
            }
            else
            {
                throw new InvalidOperationException("Inventory not found.");
            }
        }

        public DateTime? GetLastUpdated(int productId)
        {
            var inventory = _context.Inventories.FirstOrDefault(i => i.ProductId == productId);
            if (inventory != null)
            {
                // Retrieve the LastUpdated shadow property
                return _context.Entry(inventory).Property("LastUpdated").CurrentValue as DateTime?;
            }

            return null;
        }
        public int GetTotalStockByProduct(int productId)
        {
            return _context.Inventories
                           .Where(i => i.ProductId == productId)
                           .Sum(i => i.Quantity);
        }
    }
}
