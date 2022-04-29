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

            //eg Url="localhost:9200";username="ryangovender";password="govender";

            try
            {
                var settings = settingsString.Split('\u002C');
            }
            catch (Exception ex)
            {

            }
        }

    }
}
