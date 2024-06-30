using MultiShop.Cargo.Entity.Abstract;

namespace MultiShop.Cargo.Entity.Concrete
{
    public class CargoCustomer : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }

}
