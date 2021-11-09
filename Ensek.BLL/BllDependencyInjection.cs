using Ensek.BLL.Services;
using Ensek.BLL.Services.IServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ensek.DAL;

namespace Ensek.BLL
{
    public static class BllDependencyInjection
    {
       

        public static void InjectDependencies(IServiceCollection services, IConfiguration configuration)
        {

           // services.AddAutoMapper(typeof(AutoMapperProfiles));
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IMeterReadingService, MeterReadingService>();

            DalDependencyInjection.InjectDependencies(services, configuration);

        }
    }
}
