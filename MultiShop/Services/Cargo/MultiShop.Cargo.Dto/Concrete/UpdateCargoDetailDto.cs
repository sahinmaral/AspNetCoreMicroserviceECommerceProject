using MultiShop.Cargo.Dto.Abstract;

namespace MultiShop.Cargo.Dto.Concrete
{
    public class UpdateCargoDetailDto : BaseDto
    {
        public string Id { get; set; }
        public string SenderCustomer { get; set; }
        public string ReceiverCustomer { get; set; }
        public int BarcodeNumber { get; set; }
        public string CargoCompanyId { get; set; }
    }
}
