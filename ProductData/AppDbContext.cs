using Microsoft.EntityFrameworkCore;
using ProductDomain;

namespace ProductData
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Inventory> Inventories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=MTAYEL-LT\MSSQLSERVER01;Database=ProductDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
