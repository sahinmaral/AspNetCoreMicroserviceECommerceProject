using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.Entity.Concrete;
using MultiShop.Cargo.DataAccess.Abstract;
using System.Linq.Expressions;

namespace MultiShop.Cargo.Business.Concrete
{
    public class CargoDetailManager : ICargoDetailService
    {
        private readonly ICargoDetailDal _cargoDetailDal;

        public CargoDetailManager(ICargoDetailDal cargoDetailDal)
        {
            _cargoDetailDal = cargoDetailDal;
        }

        public async Task<CargoDetail> CreateAsync(CargoDetail entity)
        {
            return await _cargoDetailDal.CreateAsync(entity);
        }

        public async Task<CargoDetail> DeleteAsync(string id)
        {
            var entity = await _cargoDetailDal.GetByIdAsync(id);
            if (entity is null)
                throw new NullReferenceException();
            return await _cargoDetailDal.DeleteAsync(entity);
        }

        public async Task<List<CargoDetail>> GetAllAsync(Expression<Func<CargoDetail, bool>>? filter = null)
        {
            return await _cargoDetailDal.GetAllAsync(filter);
        }

        public async Task<CargoDetail?> GetAsync(Expression<Func<CargoDetail, bool>> filter)
        {
            return await _cargoDetailDal.GetAsync(filter);
        }

        public async Task<CargoDetail?> GetByIdAsync(string id)
        {
            return await _cargoDetailDal.GetByIdAsync(id);
        }

        public async Task<CargoDetail> UpdateAsync(CargoDetail entity)
        {
            return await _cargoDetailDal.UpdateAsync(entity);
        }
    }
}
