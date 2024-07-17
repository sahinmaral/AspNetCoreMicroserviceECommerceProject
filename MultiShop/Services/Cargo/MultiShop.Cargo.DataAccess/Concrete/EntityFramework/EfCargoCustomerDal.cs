using Microsoft.EntityFrameworkCore;

using MultiShop.Cargo.DataAccess.Abstract;
using MultiShop.Cargo.DataAccess.Context;
using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.DataAccess.Concrete.EntityFramework
{
    public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
    {
        private readonly CargoContext _context;

        public EfCargoCustomerDal(CargoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<CargoCustomer?> GetByUserId(string userId)
        {
            return await _context.CargoCustomers.FirstOrDefaultAsync(x => x.UserId == userId);
        }
    }
}
