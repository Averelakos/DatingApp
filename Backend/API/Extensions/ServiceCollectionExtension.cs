using Infrastructure;
using Infrastructure.Configurations;
using Infrastructure.Contracts;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace API;

public static class ServiceCollectionExtension
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddDatabaseSqlServer(configuration);
        services.AddConfigurations(configuration);
        services.AddInfrastructureServices();
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

    /// <summary>
    /// Adds the Infrastracture Services
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        return services
        .AddScoped<ITokenProviderService, TokenProviderService>();
    }

    /// <summary>
    /// Adds the configurations.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="configuration">The configuration.</param>
    /// <returns></returns>
    /// <exception cref="System.Exception">Missing token configuration</exception>
    public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        var tokenConfiguration = configuration.GetSection(nameof(TokenConfiguration)).Get<TokenConfiguration>();
        if (tokenConfiguration is null)
            throw new Exception("Missing token configuration");
        services.AddSingleton(tokenConfiguration);
        return services;
    }
}
