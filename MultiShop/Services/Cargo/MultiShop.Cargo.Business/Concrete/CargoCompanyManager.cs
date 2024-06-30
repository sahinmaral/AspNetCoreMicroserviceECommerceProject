using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.Entity.Concrete;
using MultiShop.Cargo.DataAccess.Abstract;
using System.Linq.Expressions;

namespace MultiShop.Cargo.Business.Concrete
{
    public class CargoCompanyManager : ICargoCompanyService
    {
        private readonly ICargoCompanyDal _cargoCompanyDal;

        public CargoCompanyManager(ICargoCompanyDal cargoCompanyDal)
        {
            _cargoCompanyDal = cargoCompanyDal;
        }

        public async Task<CargoCompany> CreateAsync(CargoCompany entity)
        {
            return await _cargoCompanyDal.CreateAsync(entity);
        }

        public async Task<CargoCompany> DeleteAsync(string id)
        {
            var entity = await _cargoCompanyDal.GetByIdAsync(id);
            if (entity is null)
                throw new NullReferenceException();
            return await _cargoCompanyDal.DeleteAsync(entity);
        }

        public async Task<List<CargoCompany>> GetAllAsync(Expression<Func<CargoCompany, bool>>? filter = null)
        {
            return await _cargoCompanyDal.GetAllAsync(filter);
        }

        public async Task<CargoCompany?> GetAsync(Expression<Func<CargoCompany, bool>> filter)
        {
            return await _cargoCompanyDal.GetAsync(filter);
        }

        public async Task<CargoCompany?> GetByIdAsync(string id)
        {
            return await _cargoCompanyDal.GetByIdAsync(id);
        }

        public async Task<CargoCompany> UpdateAsync(CargoCompany entity)
        {
            return await _cargoCompanyDal.UpdateAsync(entity);
        }
    }
}
