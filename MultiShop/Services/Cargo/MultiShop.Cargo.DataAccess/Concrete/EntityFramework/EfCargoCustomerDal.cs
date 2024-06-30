using MultiShop.Cargo.DataAccess.Abstract;
using MultiShop.Cargo.DataAccess.Context;
using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.DataAccess.Concrete.EntityFramework
{
    public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
    {
        public EfCargoCustomerDal(CargoContext context) : base(context)
        {
        }
    }
}
