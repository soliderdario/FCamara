using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Super.Digital.Data;
using Super.Digital.Domain.Interface;
using Super.Digital.Infrastructure.Notifiers;
using Super.Digital.Service;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Super.Digital.WebAPI.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<SuperDigitalDbContext>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountEntryService, AccountEntryService>();
            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IAuthenticationService, AuthenticationService>();
            //services.AddScoped<IToken, Token>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
