using Microsoft.EntityFrameworkCore;

using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.DataAccess.Context
{
    public class CargoContext : DbContext
    {
        public CargoContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CargoOperation> CargoOperations { get; set; }
        public DbSet<CargoCompany> CargoCompanies { get; set; }
        public DbSet<CargoDetail> CargoDetails { get; set; }
        public DbSet<CargoCustomer> CargoCustomers { get; set; }
    }
}