using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProductDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductData.EntityConfiguration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.OrderId);  // Primary key for Order
            builder.Property(o => o.OrderDate).IsRequired();

            // One-to-many relationship between Order and OrderDetail
            builder.HasMany(o => o.OrderDetails)
                   .WithOne(od => od.Order)
                   .HasForeignKey(od => od.OrderId);
            // Add shadow property for tracking last updated time
            builder.Property<DateTime>("LastUpdated");
            // Seed data for Orders
            builder.HasData(
                new  { OrderId = 1, OrderDate = new DateOnly(2024, 10, 1), LastUpdated = DateTime.Now },
                new  { OrderId = 2, OrderDate = new DateOnly(2024, 10, 2), LastUpdated = DateTime.Now }
            );
            
        }
    }

}
