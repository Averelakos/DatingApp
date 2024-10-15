using Microsoft.EntityFrameworkCore;
using PassionPortal.Application;
using PassionPortal.Infrastracture;
using PassionPortal.Infrastracture.Configurations;

namespace PassionPortal.API;

public static class ServiceCollectionExtension
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddConfigurations(configuration);
        services.AddProjects(configuration);
        services.AddEndpointsApiExplorer();
        services.AddHttpContextAccessor();
    }

    public static void AddProjects(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplicationServices(configuration);
        services.AddInfrastructureServices(configuration);
    }
    
  

    /// <summary>
    /// Adds the Db context and sets the option
    /// for the server to connecto to database in sql light
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddDatabaseSqlLight(this IServiceCollection services, IConfiguration configuration) 
    {
        return services
        .AddDbContext<DatingAppDbContext>(options => options.UseSqlite(configuration.GetConnectionString("DefaultConnectionSqlLight")));
    }

    /// <summary>
    /// Adds the Infrastracture Services
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    //public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    //{
    //    return services
    //    .AddScoped<ITokenProviderService, TokenProviderService>();
    //}
}
