using Microsoft.EntityFrameworkCore;
using ProductDomain;

namespace ProductData
{
    public class AppDbContext : DbContext
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
            // One-to-One relationship between Product and Inventory
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Inventory)
                .WithOne(i => i.Product)
                .HasForeignKey<Inventory>(i => i.ProductId);

            // One-to-Many relationship between Category and Products
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id); // Set primary key
                entity.Property(c => c.Name)
                      .IsRequired()
                      .HasMaxLength(50); // Limit the Name length to 50 characters

                entity.HasMany(c => c.Products)
                      .WithOne(p => p.Category)
                      .HasForeignKey(p => p.CategoryId);
            });

            // Many-to-Many relationship between Products and Suppliers with custom join table
            modelBuilder.Entity<ProductSupplier>()
     .HasKey(ps => ps.Id); // Define primary key for ProductSupplier

            modelBuilder.Entity<ProductSupplier>()
                .HasOne(ps => ps.Product) // Configure the relationship to Product
                .WithMany(p => p.ProductSuppliers)
                .HasForeignKey(ps => ps.ProductId);

            modelBuilder.Entity<ProductSupplier>()
                .HasOne(ps => ps.Supplier) // Configure the relationship to Supplier
                .WithMany(s => s.ProductSuppliers)
                .HasForeignKey(ps => ps.SupplierId);

            modelBuilder.Entity<ProductSupplier>()
                .ToTable("ProductSuppliers"); // Define the table name
        }
    }

   
}