using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Super.Digital.Data;

namespace Super.Digital.WebAPI.Configuration
{
    public static class EntityFrameworkConfig
    {
        public static IServiceCollection AddDbContextConfiguration(this IServiceCollection services, string connectionstring)
        {
            services.AddDbContext<SuperDigitalDbContext>(options =>
            {
                options.UseSqlServer(connectionstring);
            });
            return services;
        }
    }
}
