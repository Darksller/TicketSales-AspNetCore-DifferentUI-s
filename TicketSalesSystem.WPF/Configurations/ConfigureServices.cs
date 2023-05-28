using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TicketSalesSystem.BLL.Configurations;

namespace TicketSalesSystem.WPF.Configurations
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddWpfMvvmServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddBusinessLogicServices(configuration);

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
