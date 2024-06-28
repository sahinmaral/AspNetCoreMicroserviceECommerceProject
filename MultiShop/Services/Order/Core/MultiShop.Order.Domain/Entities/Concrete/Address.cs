using MultiShop.Order.Domain.Entities.Abstract;

namespace MultiShop.Order.Domain.Entities.Concrete
{
    public class Address : BaseEntity
    {
        public string UserId { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
    }
}
