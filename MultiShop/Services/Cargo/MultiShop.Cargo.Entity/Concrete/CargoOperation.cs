using MultiShop.Cargo.Entity.Abstract;

namespace MultiShop.Cargo.Entity.Concrete
{
    public class CargoOperation : BaseEntity
    {
        public string Barcode { get; set; }
        public string Description { get; set; }
        public DateTime OperatedAt { get; set; }
    }

}
