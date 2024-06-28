using MultiShop.Order.Domain.Entities.Abstract;

namespace MultiShop.Order.Domain.Entities.Concrete
{
    public class OrderDetail : BaseEntity
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductAmont { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public string OrderingId { get; set; }
        public Ordering Ordering { get; set; }
    }
}
