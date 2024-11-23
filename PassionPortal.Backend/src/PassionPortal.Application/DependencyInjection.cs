using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PassionPortal.Application.Authentications;

namespace PassionPortal.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<UserService>();
            return services;
        }
    }
}
