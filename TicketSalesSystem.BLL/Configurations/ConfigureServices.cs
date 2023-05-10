using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TicketSalesSystem.BLL.Interfaces;
using TicketSalesSystem.BLL.Services;
using TicketSalesSystem.DAL.Configurations;

namespace TicketSalesSystem.BLL.Configurations
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataAccessServices(configuration);

            services.AddScoped<IAirplaneService, AirplaneService>()
                .AddScoped<IFlightService, FlightService>()
                .AddScoped<IFlightStatusService, FlightStatusService>()
                .AddScoped<IRouteService, RouteService>()
                .AddScoped<ISeatTypeService, SeatTypeService>()
                .AddScoped<ITicketService, TicketService>()
                .AddScoped<IAirlineService, AirlineService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<ITokenService, TokenService>()
                .AddScoped<IEmailService, EmailService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
