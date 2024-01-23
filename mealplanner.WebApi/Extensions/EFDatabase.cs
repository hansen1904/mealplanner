using mealplanner.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace mealplanner.WebApi.Extensions
{
    public static class EFDatabase
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection service, IConfiguration configuration)
        {
            var dbConnection = configuration.GetValue<String>("Database:ConnectionString");
            service.AddDbContext<ApplicationDbContext>(options =>
            {
                if (dbConnection == null)
                {
                    options.UseInMemoryDatabase(databaseName: "MealPlannerDB");
                }
                else
                {
                    options.UseNpgsql(dbConnection);
                }
            });

            return service;
        }
    }
}
