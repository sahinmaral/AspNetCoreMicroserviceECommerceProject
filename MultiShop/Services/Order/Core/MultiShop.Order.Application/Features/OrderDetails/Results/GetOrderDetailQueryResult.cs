namespace MultiShop.Order.Application.Features.OrderDetails.Results
{
    public class GetOrderDetailQueryResult
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductAmont { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public string OrderingId { get; set; }
    }
}
