using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;

namespace NLayer.Repository.Seeds
{
    internal class ProductFeatureSeed : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {
            builder.HasData(
                new ProductFeature { Id = 1, Color = "Red", Height = 150, Width = 350, ProductId = 1 },
                new ProductFeature { Id = 2, Color = "Blue", Height = 50, Width = 30, ProductId = 2 }
           );
        }
    }
}
