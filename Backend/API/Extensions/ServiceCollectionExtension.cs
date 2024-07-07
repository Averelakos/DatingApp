using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace API;

public static class ServiceCollectionExtension
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddDatabaseSqlServer(configuration);
        services.AddEndpointsApiExplorer();
        services.AddHttpContextAccessor();
    }
    
    /// <summary>
    /// Adds the Db context and sets the option
    /// for the server to connecto to database in sql server
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddDatabaseSqlServer(this IServiceCollection services, IConfiguration configuration) 
    {
        return services
        .AddDbContext<DatingAppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionSqlServer")));
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
}
