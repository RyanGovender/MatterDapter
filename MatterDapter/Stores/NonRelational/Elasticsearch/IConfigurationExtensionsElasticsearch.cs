using MatterDapter.Extensions;
using MatterDapter.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatterDapter.Stores.NonRelational.Elasticsearch
{
    internal static partial class IConfigurationExtension
    {
        public static ElasticSettings GetElasticSettings(this IConfiguration configuration)
        {
            var settingsString = configuration.GetAppsetting("MatterDapter:Elasticsearch:ConnectionString");
            ElasticSettings elasticSettings = new();

            //eg Url="localhost:9200";username="ryangovender";password="govender";

            try
            {
                var settings = settingsString.Split(';');
                foreach (var item in settings)
                {
                    if (string.IsNullOrEmpty(item)) 
                        throw new ArgumentException("Connection string missing value.");
                    var value = item.Split('=');

                    if (value.Length != 2) throw new ArgumentException("");

                    elasticSettings
                        .GetType()
                        .GetProperties()
                        .FirstOrDefault(x => x.Name
                        .Equals(value[0], StringComparison.OrdinalIgnoreCase))
                        ?.SetValue(elasticSettings, value[1]);
                }

                return elasticSettings;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Invalid connection string for {"Test"}");
            }
        }

    }
}
