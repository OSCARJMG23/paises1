using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Infrastructure.Repository;
using Infrastructure.UnitOfWork;
using Microsoft.Extensions.Options;

namespace API.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()  //WithOrigins("https://domini.com")
                .AllowAnyOrigin()         //WithMethods(*Get", "POST")      
                .AllowAnyHeader());       //WithHeaders(*accept", "content-type")
            });

        public static void AddAplicationsServices(this IServiceCollection services)
        {
            /* services.AddScoped<IPaisInterface, PaisRepository>(); */
            services.AddScoped<IUnitOfWork,UnitOfWork>();
        }
    }
}