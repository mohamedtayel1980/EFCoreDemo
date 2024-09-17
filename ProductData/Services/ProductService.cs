using Microsoft.EntityFrameworkCore;
using ProductDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductData.Services
{
    public class ProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public void CreateProduct(string productName, decimal price, string categoryName)
        {
            var category = new Category { Name = categoryName };
            var product = new Product { Name = productName, Price = price, Category = category };
            _context.Products.Add(product);
            _context.Entry(product).Property("LastUpdated").CurrentValue = DateTime.Now;
            _context.SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.Include(p => p.Category).ToList();
        }

        public void UpdateProductPrice(int productId, decimal newPrice)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                product.Price = newPrice;
                _context.Entry(product).Property("LastUpdated").CurrentValue = DateTime.Now;

                _context.SaveChanges();
            }
        }

        public void DeleteProduct(int productId)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
        public List<Product> GetProductsByCategory(string categoryName)
        {
            return _context.Products
                           .Where(p => p.Category.Name == categoryName)
                           .Include(p => p.Inventory)
                           .ToList();
        }
        
    }
}
