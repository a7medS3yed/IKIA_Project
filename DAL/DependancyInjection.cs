using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Contracts;
using DAL.Persistance.Data;
using DAL.Persistance.Data.DbInitializer;
using DAL.Persistance.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddPersistanceService(this IServiceCollection services, IConfiguration configuration)
        {
            // Add your DbContext and other persistence-related services here
            
            services.AddDbContext<ApplicationDbContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IDbInitializer, DbInitializer>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            

            return services;
        }
    }
}
