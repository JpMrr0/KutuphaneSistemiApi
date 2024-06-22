using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Infrastructure
{
    public static class AppSettingsConfig
    {
        public static string SigningKey
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../KutuphaneSistemiApi.API"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager["Token:SigningKey"];
            }
        }
        public static string Audience
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../KutuphaneSistemiApi.API"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager["Token:Audience"];
            }
        }
        public static string Issuer
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../KutuphaneSistemiApi.API"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager["Token:Issuer"];
            }
        }
    }
}
