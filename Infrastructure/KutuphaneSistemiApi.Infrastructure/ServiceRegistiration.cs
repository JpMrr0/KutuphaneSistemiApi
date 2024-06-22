using KutuphaneSistemiApi.Application.Abstractions;
using KutuphaneSistemiApi.Application.Abstractions.Services.User;
using KutuphaneSistemiApi.Infrastructure.Services.Token;
using KutuphaneSistemiApi.Infrastructure.Services.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Infrastructure
{
    public static class ServiceRegistiration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler,Infrastructure.Services.Token.TokenHandler>();
            services.AddScoped<IUserService, UserService>();
        }
        public static void AddAuthentications(this IServiceCollection services)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer("Admin", x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettingsConfig.SigningKey)),
                    ValidIssuer = AppSettingsConfig.Issuer,
                    ValidAudience = AppSettingsConfig.Audience,
                    LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false
                };
            });
        }
    }
}
