namespace MultiShop.WebUI.Dtos.Order
{
    public class ResultOrderingByUserIdDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
