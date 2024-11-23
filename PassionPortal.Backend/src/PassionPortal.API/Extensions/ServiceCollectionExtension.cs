using PassionPortal.Application;
using PassionPortal.Infrastracture;

namespace PassionPortal.API;

public static class ServiceCollectionExtension
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddConfigurations(configuration);
        services.AddProjects(configuration);
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddHttpContextAccessor();
        services.AddCors();
    }

    public static void AddProjects(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplicationServices(configuration);
        services.AddInfrastructureServices(configuration);
    }
}
