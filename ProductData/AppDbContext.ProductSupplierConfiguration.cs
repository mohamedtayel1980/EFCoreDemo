using Microsoft.EntityFrameworkCore;
using ProductDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductData
{
    public partial class AppDbContext : DbContext
    {
        private void ConfigureProductSupplier(ModelBuilder modelBuilder)
        {
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
