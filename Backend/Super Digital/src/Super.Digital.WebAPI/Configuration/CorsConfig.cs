using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Super.Digital.WebAPI.Configuration
{
    public static class CorsConfig
    {
        public static IServiceCollection CorsConfiguration(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("Development",
                    builder =>
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        );


                options.AddPolicy("Production",
                    builder =>
                        builder
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .WithOrigins("http://www.superdigital.com.br", "http://www.fcamera.com.br")
                            .SetIsOriginAllowedToAllowWildcardSubdomains());
            });
            return services;
        }
    }
}
