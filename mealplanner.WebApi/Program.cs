using mealplanner.Application;
using mealplanner.WebApi.Configuration;
using mealplanner.WebApi.Extensions;

namespace mealplanner.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        IServiceCollection service = builder.Services;

        var configuration = builder.Configuration;

        configuration
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.development.json")
            .AddJsonFile("appsettings.local.json")
            .AddEnvironmentVariables();

        builder.Logging.AddConsole();

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(
            policy =>
            {
                policy.WithOrigins("https://localhost:44413");
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
            });

        });

        //Configure Database connection.
        service.AddEntityFramework(configuration);

        service.AddControllersWithViews();

        service.AddApiVersion();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        service.AddEndpointsApiExplorer();
        service.AddSwaggerGen(c =>
        {
            c.EnableAnnotations();
        });

        service.AddInfrastructureServices();
        service.AddApplicationServices();

        //service.AddAuth(builder.Configuration);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseStaticFiles();
        app.UseRouting();

        app.UseCors();

        app.UseExceptionHandler("/error");

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseHttpsRedirection();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller}/{action=Index}/{id?}");

        app.MapFallbackToFile("index.html");

        app.Run();
    }
}