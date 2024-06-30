using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.Entity.Concrete;
using MultiShop.Cargo.DataAccess.Abstract;
using System.Linq.Expressions;

namespace MultiShop.Cargo.Business.Concrete
{
    public class CargoOperationManager : ICargoOperationService
    {
        private readonly ICargoOperationDal _cargoOperationDal;

        public CargoOperationManager(ICargoOperationDal cargoOperationDal)
        {
            _cargoOperationDal = cargoOperationDal;
        }

        public async Task<CargoOperation> CreateAsync(CargoOperation entity)
        {
            return await _cargoOperationDal.CreateAsync(entity);
        }

        public async Task<CargoOperation> DeleteAsync(string id)
        {
            var entity = await _cargoOperationDal.GetByIdAsync(id);
            if (entity is null)
                throw new NullReferenceException();
            return await _cargoOperationDal.DeleteAsync(entity);
        }

        public async Task<List<CargoOperation>> GetAllAsync(Expression<Func<CargoOperation, bool>>? filter = null)
        {
            return await _cargoOperationDal.GetAllAsync(filter);
        }

        public async Task<CargoOperation?> GetAsync(Expression<Func<CargoOperation, bool>> filter)
        {
            return await _cargoOperationDal.GetAsync(filter);
        }

        public async Task<CargoOperation?> GetByIdAsync(string id)
        {
            return await _cargoOperationDal.GetByIdAsync(id);
        }

        public async Task<CargoOperation> UpdateAsync(CargoOperation entity)
        {
            return await _cargoOperationDal.UpdateAsync(entity);
        }
    }
}
