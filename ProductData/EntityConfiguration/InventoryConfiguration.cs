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
    public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.Property(i => i.Quantity).IsRequired();

            // Add shadow property for tracking last updated time
            builder.Property<DateTime>("LastUpdated");

            ////// Seed data for Inventory
            ////builder.HasData(
            ////    new Inventory { Id = 4, ProductId = 3, Quantity = 50 },
            ////    new Inventory { Id = 5, ProductId = 4, Quantity = 100 },
            ////    new Inventory { Id = 6, ProductId = 5, Quantity = 100 }
            //);
        }
    }
}
