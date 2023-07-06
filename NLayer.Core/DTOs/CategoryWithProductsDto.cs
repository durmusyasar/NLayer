namespace NLayer.Core.DTOs
{
    public  class CategoryWithProductsDto: CategoryDto
    {
        public List<ProductDTO> Products { get; set; }
    }
}
