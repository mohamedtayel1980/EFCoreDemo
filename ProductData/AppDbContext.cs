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
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

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


            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
        }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<Order>())
            {
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    entry.Property("LastUpdated").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}