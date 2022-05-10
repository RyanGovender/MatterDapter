using MatterDapter.Extensions;
using MatterDapter.Shared.Enum;
using MatterDapter.Stores.Common.Interface;
using MatterDapter.Stores.NonRelational.Elasticsearch;
using MatterDapter.Stores.Relational;
using Microsoft.Extensions.Configuration;

namespace MatterDapter.Factory
{
    internal class AdapterFactory : IAdapterFactory
    {
        private readonly IDictionary<Store,IRepository> _adapters;
        private readonly IRelationalConnectionFactory _relationalConnectionFactory;
        private readonly IConfiguration _config;

        public AdapterFactory(IRelationalConnectionFactory relationalConnectionFactory, IConfiguration configuration)
        {
            _relationalConnectionFactory = relationalConnectionFactory;
            _config = configuration;

            _adapters = new Dictionary<Store, IRepository>
            {
                { Store.SQL_SERVER, new SqlServer(_relationalConnectionFactory) },
                { Store.MYSQL, new MySql(_relationalConnectionFactory) },
                { Store.POSTGRES, new Postgres(_relationalConnectionFactory) },
                { Store.ELASTICSEARCH, new elasticearch(_config)}
            };
        }

        public IRepository GetMatterAdapter(Store dataStore = Store.NO_STORE)
        {
           if(dataStore == Store.NO_STORE)
            {
                dataStore = IserviceExtension.DefaultStore;

                if (dataStore is Store.NO_STORE)
                    throw new Exception("No Store has been selected or found");
            }

            var getAdapter = _adapters.TryGetValue(dataStore, out var adapter);

            if (getAdapter && adapter != null)
            {
                return adapter;
            }

            throw new ArgumentException("Adaptor not found");
        }
     
    }
}
