using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PassionPortal.Infrastracture.Configurations;
using PassionPortal.Infrastracture.Contracts;
using PassionPortal.Infrastracture.Services;

namespace PassionPortal.Infrastracture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabaseSqlServer(configuration);
            services.AddConfigurations(configuration);
            services.AddServices();
            return services;
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

        /// <summary>
        /// Adds the Infrastracture Services
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
            .AddScoped<ITokenProviderService, TokenProviderService>();
        }
    }
}
