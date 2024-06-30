using MultiShop.Cargo.DataAccess.Abstract;
using MultiShop.Cargo.DataAccess.Context;
using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.DataAccess.Concrete.EntityFramework
{
    public class EfCargoCompanyDal : GenericRepository<CargoCompany>, ICargoCompanyDal
    {
        public EfCargoCompanyDal(CargoContext context) : base(context)
        {
        }
    }
}
