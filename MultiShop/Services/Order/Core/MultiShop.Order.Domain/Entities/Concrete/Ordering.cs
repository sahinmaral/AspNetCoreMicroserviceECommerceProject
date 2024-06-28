using MultiShop.Order.Domain.Entities.Abstract;

namespace MultiShop.Order.Domain.Entities.Concrete
{
    public class Ordering : BaseEntity
    {
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
