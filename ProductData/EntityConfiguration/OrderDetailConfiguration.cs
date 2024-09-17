using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProductDomain;

namespace ProductData.EntityConfiguration
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            // Composite primary key consisting of OrderId and ProductId
            builder.HasKey(od => new { od.OrderId, od.ProductId });

            builder.Property(od => od.Quantity).IsRequired();
            builder.Property(od => od.Price).HasColumnType("decimal(18,2)");

            // Define the foreign key relationship with Product
            builder.HasOne(od => od.Product)  // Each OrderDetail has one Product
                   .WithMany()  
                   .HasForeignKey(od => od.ProductId);  // ProductId as foreign key

            // Define the foreign key relationship with Order
            builder.HasOne(od => od.Order)  // Each OrderDetail belongs to one Order
                   .WithMany(o => o.OrderDetails)  // An Order can have many OrderDetails
                   .HasForeignKey(od => od.OrderId);  // OrderId as foreign key
            // Seed data for OrderDetails
            builder.HasData(
                new OrderDetail { OrderId = 1, ProductId = 1, Quantity = 2, Price = 999.99M },
                new OrderDetail { OrderId = 1, ProductId = 2, Quantity = 1, Price = 499.99M },
                new OrderDetail { OrderId = 2, ProductId = 1, Quantity = 1, Price = 999.99M }
            );
        }
    }

}
