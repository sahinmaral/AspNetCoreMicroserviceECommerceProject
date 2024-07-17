namespace MultiShop.Order.Application.Features.Orderings.Results
{
    public class GetAllByUserIdQueryResult
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
