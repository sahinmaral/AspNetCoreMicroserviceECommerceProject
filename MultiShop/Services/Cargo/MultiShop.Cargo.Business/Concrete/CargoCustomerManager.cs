using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.Entity.Concrete;
using MultiShop.Cargo.DataAccess.Abstract;
using System.Linq.Expressions;

namespace MultiShop.Cargo.Business.Concrete
{
    public class CargoCustomerManager : ICargoCustomerService
    {
        private readonly ICargoCustomerDal _cargoCustomerDal;

        public CargoCustomerManager(ICargoCustomerDal cargoCustomerDal)
        {
            _cargoCustomerDal = cargoCustomerDal;
        }

        public async Task<CargoCustomer> CreateAsync(CargoCustomer entity)
        {
            return await _cargoCustomerDal.CreateAsync(entity);
        }

        public async Task<CargoCustomer> DeleteAsync(string id)
        {
            var entity = await _cargoCustomerDal.GetByIdAsync(id);
            if (entity is null)
                throw new NullReferenceException();
            return await _cargoCustomerDal.DeleteAsync(entity);
        }

        public async Task<List<CargoCustomer>> GetAllAsync(Expression<Func<CargoCustomer, bool>>? filter = null)
        {
            return await _cargoCustomerDal.GetAllAsync(filter);
        }

        public async Task<CargoCustomer?> GetAsync(Expression<Func<CargoCustomer, bool>> filter)
        {
            return await _cargoCustomerDal.GetAsync(filter);
        }

        public async Task<CargoCustomer?> GetByIdAsync(string id)
        {
            return await _cargoCustomerDal.GetByIdAsync(id);
        }

        public async Task<CargoCustomer?> GetByUserId(string userId)
        {
            return await _cargoCustomerDal.GetByUserId(userId);
        }

        public async Task<CargoCustomer> UpdateAsync(CargoCustomer entity)
        {
            return await _cargoCustomerDal.UpdateAsync(entity);
        }
    }
}
