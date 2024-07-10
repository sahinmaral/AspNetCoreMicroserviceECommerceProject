namespace MultiShop.Catalog.Dtos.Product
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ThumbnailImageUrl { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public List<string> AdditionalImageUrls { get; set; }
    }
}
