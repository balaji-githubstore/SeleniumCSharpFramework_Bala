using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trianz.DataUtlis
{
    class ConfigurationUtils
    {
        public static string GetValueFromAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString(); 
        }
        public static string GetConnectionStringDetails(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        
    }
}
