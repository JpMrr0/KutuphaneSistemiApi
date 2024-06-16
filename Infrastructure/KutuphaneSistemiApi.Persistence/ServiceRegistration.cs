using KutuphaneSistemiApi.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using KutuphaneSistemiApi.Persistence.Configurations;
using KutuphaneSistemiApi.Application.Repositories;
using KutuphaneSistemiApi.Persistence.Repositories;

namespace KutuphaneSistemiApi.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));
            services.AddDbContext<KutuphaneSistemiApiDbContext>(options => options.UseMySql(Configuration.ConnectionString, serverVersion));
            services.AddScoped<IBookReadRepository, BookReadRepository>();
            services.AddScoped<IBookWriteRepository, BookWriteRepository>();
            services.AddScoped<IMemberReadRepository, MemberReadRepository>();
            services.AddScoped<IMemberWriteRepository, MemberWriteRepository>();
        }
    }
}
