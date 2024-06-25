namespace MultiShop.Catalog.Dtos.ProductImage
{
    public class GetByProductImageIdDto
    {
        public string Id { get; set; }
        public string? ImageUrl1 { get; set; }
        public string? ImageUrl2 { get; set; }
        public string? ImageUrl3 { get; set; }
        public string ProductId { get; set; }
    }
}
