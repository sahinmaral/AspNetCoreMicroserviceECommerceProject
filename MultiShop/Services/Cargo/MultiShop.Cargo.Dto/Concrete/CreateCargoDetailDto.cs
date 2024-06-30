using MultiShop.Cargo.Dto.Abstract;

namespace MultiShop.Cargo.Dto.Concrete
{
    public class CreateCargoDetailDto  : BaseDto
    {
        public string SenderCustomer { get; set; }
        public string ReceiverCustomer { get; set; }
        public int BarcodeNumber { get; set; }
        public string CargoCompanyId { get; set; }
    }
}
