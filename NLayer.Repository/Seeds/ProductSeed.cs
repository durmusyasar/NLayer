using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;

namespace NLayer.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                 new Product { Id = 1, CreatedDate = DateTime.UtcNow, Name = "Pen - 1", CategoryId = 1, Price = 100, Stock = 50 },
                 new Product { Id = 2, CreatedDate = DateTime.UtcNow, Name = "Pen - 2", CategoryId = 1, Price = 200, Stock = 40 },
                 new Product { Id = 3, CreatedDate = DateTime.UtcNow, Name = "Pen - 3", CategoryId = 1, Price = 300, Stock = 30 },
                 new Product { Id = 4, CreatedDate = DateTime.UtcNow, Name = "Book - 1", CategoryId = 2, Price = 300, Stock = 30 },
                 new Product { Id = 5, CreatedDate = DateTime.UtcNow, Name = "Book - 2", CategoryId = 2, Price = 200, Stock = 40 }
            );
        }
    }
}
