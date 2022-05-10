using MatterDapter.Models;
using Microsoft.Extensions.Configuration;

namespace MatterDapter.Extensions
{
    internal static class IConfigurationExtension
    {
        public static string GetSQLServerConnectionString(this IConfiguration configuration)
        {
            return configuration.GetAppsetting("MatterDapter:SQLServer:ConnectionString");
        }

        public static string GetMySQLConnectionString(this IConfiguration configuration)
        {
            return configuration.GetAppsetting("MatterDapter:MySql:ConnectionString");
        }

        public static string GetPostgresConnectionString(this IConfiguration configuration)
        {
            return configuration.GetAppsetting("MatterDapter:Postgres:ConnectionString");
        }

        public static ElasticSettings GetElasticSettings(this IConfiguration configuration)
        {
            //eg Url="localhost:9200";username="ryangovender";password="govender";
            var settingsString = configuration.GetAppsetting("MatterDapter:Elasticsearch:ConnectionString");

            return GetSettingsFromConnectionString<ElasticSettings>(settingsString);
        }

        public static string GetAppsetting(this IConfiguration configuration, string sectionName)
        {
            var configValue = configuration.GetSection(sectionName);

            if (configValue is null || !configValue.Exists()) throw new KeyNotFoundException();

            return configValue.Value;
        }
    
        private static T GetSettingsFromConnectionString<T>(string connectionString) where T : new()
        {
            T memberType = new();
            try
            {
                var settings = connectionString?.TrimEnd(';').Split(';');

                if (settings is null) throw new KeyNotFoundException();

                foreach (var item in settings)
                {
                    if (string.IsNullOrEmpty(item))
                        throw new ArgumentException("Connection string missing value.");

                    var value = item.Split('=');

                    if (value.Length != 2) throw new ArgumentException("value is missing.");

                    memberType
                        .GetType()
                        .GetProperties()
                        .FirstOrDefault(x => x.Name
                        .Equals(value[0], StringComparison.OrdinalIgnoreCase))
                        ?.SetValue(memberType, value[1]);
                }

                return memberType;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Invalid connection string for {ex.Message}");
            }
        }
    }
}
