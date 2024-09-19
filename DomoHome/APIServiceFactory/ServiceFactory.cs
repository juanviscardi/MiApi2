using BusinessLogic;
using DataAccess.Context;
using DataAccess.Repositories;
using IBusinessLogic;
using IDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServiceFactory
{
    public static class ServiceFactory
    {
        public static void AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IDeviceLogic, DeviceLogic>();
            serviceCollection.AddScoped<IDeviceRepository, DeviceRepository>();
        }

        public static void AddConnectionString(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<DbContext, DeviceContext>(o => o.UseSqlServer(connectionString));
        }
    }
}
