using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions//don't need to create a new instance of the class cuz its static
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            //connects DataContext class with other parts of the project
            //using the SQLite extension to configure the connection string
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));//string references DefaultConnection object in appsettings.Development.json (allows access to database)
            });
            services.AddScoped<ITokenService, TokenService>();//service is added to make HTTP requests using tokens

            return services;
        }
    }
}