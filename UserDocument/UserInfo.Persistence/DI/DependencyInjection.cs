using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Document.Application.Interfaces.Persistence;
using Document.Persistence.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Document.Persistence.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<ApplicationDbContext>(options =>
           options.UseSqlServer(
               configuration.GetConnectionString("DefaultConnection"),
               b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            return services;
        }

        public static IServiceCollection AddSeeds(this IServiceCollection services, ApplicationDbContext ApplicationDbContext)
        {
            return services;
        }

    }
}
