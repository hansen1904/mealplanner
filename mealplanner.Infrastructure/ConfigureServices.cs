using mealplanner.Application.Repository;
using mealplanner.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace mealplanner.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<IFoodItemRepo, FoodItemRepo>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            
            return services;
        }
    }
}
