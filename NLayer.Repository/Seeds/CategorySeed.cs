using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;
using NLayer.Core.Models;

namespace NLayer.Repository.Seeds
{
    internal class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = 1, CreatedDate = DateTime.UtcNow, Name = "Pens" },
                new Category { Id = 2, CreatedDate = DateTime.UtcNow, Name = "Books" },
                new Category { Id = 3, CreatedDate = DateTime.UtcNow, Name = "Notebooks" }
           );
        }
    }
}
