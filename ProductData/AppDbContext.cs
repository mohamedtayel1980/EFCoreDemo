using Microsoft.EntityFrameworkCore;
using ProductData.EntityConfiguration;
using ProductDomain;

namespace ProductData
{
    public partial  class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=MTAYEL-LT\MSSQLSERVER01;Database=ProductDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply Product configuration using IEntityTypeConfiguration
            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            // Apply Category configuration using extension method
            modelBuilder.ConfigureCategory();

            // Apply ProductSupplier configuration using partial class method
            ConfigureProductSupplier(modelBuilder);


            // Apply Inventory configuration 
            modelBuilder.ApplyConfiguration(new InventoryConfiguration());
        }
    }
}