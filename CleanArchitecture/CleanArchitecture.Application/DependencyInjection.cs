using CleanArchitecture.Application.Services;
using CleanArchitecture.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICarService, CarService>();

            return services;
        }
    }
}
