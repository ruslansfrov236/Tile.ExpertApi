using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.data
{
    static class Configuration
    {
        static public string ConnectionString
        {

            get



            {
                ConfigurationManager configurationManager = new();
                try
                {

                    var extension = "../test.api";
                    configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), extension));
                    configurationManager.AddJsonFile("appsettings.json");
                }
                catch
                {
                    configurationManager.AddJsonFile("appsettings.json");
                }

                return configurationManager.GetConnectionString("SQLServer");
            }
        }
    }
}
