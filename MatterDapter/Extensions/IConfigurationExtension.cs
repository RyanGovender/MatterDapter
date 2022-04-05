using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatterDapter.Extensions
{
    internal static class IConfigurationExtension
    {
        public static string GetSQLServerConnectionString(this IConfiguration configuration)
        {
            return configuration.GetAppsetting("MatterDapter:SQLServer:ConnectionString");
        }

        public static string GetAppsetting(this IConfiguration configuration, string sectionName)
        {
            var configValue = configuration.GetSection(sectionName);

            if (configValue is null || !configValue.Exists()) throw new KeyNotFoundException();

            return configValue.Value;
        }
    }
}
