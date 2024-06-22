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
using KutuphaneSistemiApi.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using KutuphaneSistemiApi.Domain.Entities.Identity;
using KutuphaneSistemiApi.Application.Abstractions;
using KutuphaneSistemiApi.Application.Abstractions.Services.User;

namespace KutuphaneSistemiApi.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));
            services.AddDbContext<KutuphaneSistemiApiDbContext>(options => options.UseMySql(Configuration.ConnectionString, serverVersion));
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequiredLength = 3;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<KutuphaneSistemiApiDbContext>();

            services.AddScoped<IBookReadRepository, BookReadRepository>();
            services.AddScoped<IBookWriteRepository, BookWriteRepository>();
        }
    }
}
