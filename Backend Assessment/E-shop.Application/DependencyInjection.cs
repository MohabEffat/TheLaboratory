using E_shop.Application.Behaviors;
using E_shop.Core.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System.Reflection;

namespace E_shop.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped<IPasswordHasher<Customer>, PasswordHasher<Customer>>();

            return services;
        }
    }
}
