namespace MultiShop.Basket.Models
{
    public class BasketTotalDto
    {
        public string? UserId { get; set; }
        public string? DiscountCode { get; set; }
        public int DiscountRate { get; set; } = 0;
        public List<BasketItemDto> BasketItems { get; set; }
        public decimal TotalPrice { get => BasketItems.Sum((item) => item.Price * item.Quantity); }
    }
}
