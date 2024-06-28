using Microsoft.Extensions.DependencyInjection;

using MultiShop.Order.Application.Services.Repositories;

namespace MultiShop.Order.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(AssemblyReference.Assembly);
            });

            return services;
        }
    }
}
