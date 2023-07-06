namespace NLayer.Core.DTOs
{
    public class ProductWithCategoryDto : ProductDTO
    {
        public CategoryDto Category { get; set; }
    }
}
