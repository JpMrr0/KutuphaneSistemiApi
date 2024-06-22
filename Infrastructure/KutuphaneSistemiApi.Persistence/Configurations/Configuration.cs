using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Persistence.Configurations
{
    public static class Configuration
    {

        static public string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../KutuphaneSistemiApi.API"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetConnectionString("MySQL");
            }
        }
        static public string Audience
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../KutuphaneSistemiApi.API"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager["Token:Audience"];
            }
        }
        static public string Issuer
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../KutuphaneSistemiApi.API"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager["Token:Issuer"];
            }
        }static public string SigningKey
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../KutuphaneSistemiApi.API"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager["Token:SigningKey"];
            }
        }
    }
}
