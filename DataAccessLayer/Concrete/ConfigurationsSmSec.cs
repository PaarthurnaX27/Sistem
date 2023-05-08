using System;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.Concrete
{
	public class ConfigurationsSmSec
	{
        static public string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
               configurationManager.SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName);
              //  configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../SmServis"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetConnectionString("SECCMP");
            }

        }
    }
}

