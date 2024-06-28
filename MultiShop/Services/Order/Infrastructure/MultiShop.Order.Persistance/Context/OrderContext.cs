using Microsoft.EntityFrameworkCore;

using MultiShop.Order.Domain.Entities.Abstract;
using MultiShop.Order.Domain.Entities.Concrete;

namespace MultiShop.Order.Persistance.Context
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Ordering> Orderings { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
