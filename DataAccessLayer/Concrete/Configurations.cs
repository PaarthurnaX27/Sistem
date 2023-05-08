using System;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.Concrete
{
    public class Configurations
    {
        static public string ConnectionString
        {
            // get
            // {
            //     ConfigurationManager configurationManager = new();
            //     configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../SmServis"));
            //     configurationManager.AddJsonFile("appsettings.json");
            //     return configurationManager.GetConnectionString("PostgreSQL");
            // }
            get
            {
                ConfigurationManager configurationManager = new();
             configurationManager.SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName);
               configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetConnectionString("PostgreSQL");
            }
          
        }
    }
}

