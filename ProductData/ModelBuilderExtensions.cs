using Microsoft.EntityFrameworkCore;
using ProductDomain;

namespace ProductData
{
    public static class ModelBuilderExtensions
    {
        public static void ConfigureCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name).IsRequired().HasMaxLength(50);

                // One-to-Many relationship with Products
                entity.HasMany(c => c.Products)
                      .WithOne(p => p.Category)
                      .HasForeignKey(p => p.CategoryId);
            });
        }
    }
}