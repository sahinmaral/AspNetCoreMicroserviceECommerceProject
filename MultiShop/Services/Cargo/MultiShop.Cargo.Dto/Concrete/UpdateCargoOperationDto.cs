using MultiShop.Cargo.Dto.Abstract;

namespace MultiShop.Cargo.Dto.Concrete
{
    public class UpdateCargoOperationDto : BaseDto
    {
        public string Id { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public DateTime OperatedAt { get; set; }
    }
}
