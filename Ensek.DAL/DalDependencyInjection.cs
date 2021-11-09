using Ensek.DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Ensek.DAL.Repositories.IRepositories;
using Ensek.Entity.Entities;
using Ensek.DAL.Repositories;

namespace Ensek.DAL
{
    public static class DalDependencyInjection
    {

        public static void InjectDependencies(IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<EnsekDbContext>(options =>
            {
                //var optionsBuilder = new DbContextOptionsBuilder<EnsekDbContext>();
                options.UseSqlite(configuration.GetConnectionString("EnsekSqlite"));

            });

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IMeterReadingRepository, MeterReadingRepository>();

        }
    }
}
