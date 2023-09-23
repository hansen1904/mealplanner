using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace mealplanner.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ConfigureServices).Assembly));

            return services;
        }
    }
}
