using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Super.Digital.Data;

namespace Super.Digital.WebAPI.Configuration
{
    public static class EntityFrameworkConfig
    {
        public static IServiceCollection AddDbContextConfiguration(this IServiceCollection services, string connectionstring)
        {
            connectionstring = "Data Source=localhost;Initial Catalog=SuperDigital;User Id=sa;Password=Developer@;";
            services.AddDbContext<SuperDigitalDbContext>(options =>
            {
                options.UseSqlServer(connectionstring);
            });
            return services;
        }
    }
}
