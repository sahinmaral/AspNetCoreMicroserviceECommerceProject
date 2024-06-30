using MultiShop.Cargo.Entity.Abstract;

namespace MultiShop.Cargo.Entity.Concrete
{
    public class CargoDetail : BaseEntity
    {
        public string SenderCustomer { get; set; }
        public string ReceiverCustomer { get; set; }
        public int BarcodeNumber { get; set; }
        public string CargoCompanyId { get; set; }
        public CargoCompany CargoCompany { get; set; }
    }

}
