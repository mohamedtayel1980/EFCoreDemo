using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProductDomain;


namespace ProductData
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
          
            builder.Property(p => p.Price)
                   .HasColumnType("decimal(18,2)");



            // One-to-One relationship with Inventory
            builder.HasOne(p => p.Inventory)
                   .WithOne(i => i.Product)
                   .HasForeignKey<Inventory>(i => i.ProductId);


        }
    }
}
