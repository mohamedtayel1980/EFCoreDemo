using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProductDomain;


namespace ProductData.EntityConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.Property(p => p.Price)
                   .HasColumnType("decimal(18,2)");

            // Add shadow property for tracking last updated time
            builder.Property<DateTime>("LastUpdated");

            // One-to-One relationship with Inventory
            builder.HasOne(p => p.Inventory)
                   .WithOne(i => i.Product)
                   .HasForeignKey<Inventory>(i => i.ProductId);

            ////// Seed data for Products
            ////builder.HasData(
            ////new Product { Id = 3, Name = "Tablet", Price = 299.99M, CategoryId = 1 },
            ////new Product { Id = 4, Name = "Smartwatch", Price = 199.99M, CategoryId = 1 },
            ////new Product { Id = 5, Name = "Desktop", Price = 1200.00M, CategoryId = 1 },
            ////new Product { Id = 6, Name = "Monitor", Price = 300.00M, CategoryId = 1 }
            //);
        }
    }
}
