using MultiShop.Cargo.Dto.Abstract;

namespace MultiShop.Cargo.Dto.Concrete
{
    public class CreateCargoOperationDto : BaseDto
    {
        public string Barcode { get; set; }
        public string Description { get; set; }
        public DateTime OperatedAt { get; set; }
    }
}
