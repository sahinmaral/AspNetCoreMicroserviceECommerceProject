using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using MultiShop.Discount.Entities;

using System.Data;

namespace MultiShop.Discount.Context
{
    public class DiscountContext:DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DiscountContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("Default");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<Coupon> Coupons { get; set; }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
