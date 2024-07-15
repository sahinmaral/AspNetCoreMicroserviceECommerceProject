namespace MultiShop.WebUI.Dtos.Basket
{
    public class BasketTotalDto
    {
        public string? UserId { get; set; }
        public string? DiscountCode { get; set; }
        public int DiscountRate { get; set; } = 0;
        public List<BasketItemDto> BasketItems { get; set; } = new List<BasketItemDto>();
        public decimal TotalPrice { get => BasketItems.Sum((item) => item.Price * item.Quantity); }
    }
}
