using MatterDapter.Adapter;
using MatterDapter.Factory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatterDapter.Extensions
{
    public static class IserviceExtension
    {
        public static void AddMatterDapter(this IServiceCollection services)
        {
            services.AddSingleton<IMatterAdapter, MatterDaper>();
            services.AddSingleton<IAdapterFactory, AdapterFactory>();
            services.AddSingleton<IRelationalConnectionFactory, RelationalConnectionFactory>();
        }
    }
}
