using MultiShop.Order.Domain.Entities.Abstract;

namespace MultiShop.Order.Domain.Entities.Concrete
{
    public class Address : BaseEntity
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail1 { get; set; }
        public string Detail2 { get; set; }
    }
}
