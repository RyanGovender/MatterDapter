using MatterDapter.Adapter;
using MatterDapter.Factory;
using MatterDapter.Shared.Enum;
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
        internal static Store DefaultStore { get; private set; }
        public static void AddMatterDapter(this IServiceCollection services)
        {
            services.AddSingleton<IMatterAdapter, MatterDaper>();
            services.AddSingleton<IAdapterFactory, AdapterFactory>();
            services.AddSingleton<IRelationalConnectionFactory, RelationalConnectionFactory>();
        }

        public static void SetSingleStoreType(this IServiceCollection serviceDescriptors, Store store)
        {
            DefaultStore = store;
        }
    }
}
