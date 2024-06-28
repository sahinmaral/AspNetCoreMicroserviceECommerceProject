using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Persistance.Context;
using MultiShop.Order.Persistance.Repositories;

namespace MultiShop.Order.Persistance
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>),typeof(GenericRepository<>));
            services.AddDbContext<OrderContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"));
            });

            return services;
        }
    }
}
