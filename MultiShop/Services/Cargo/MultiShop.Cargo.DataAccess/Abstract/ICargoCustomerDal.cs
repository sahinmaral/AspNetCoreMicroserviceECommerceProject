using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.DataAccess.Abstract
{
    public interface ICargoCustomerDal : IRepository<CargoCustomer>
    {
        Task<CargoCustomer?> GetByUserId(string userId);
    }

}
