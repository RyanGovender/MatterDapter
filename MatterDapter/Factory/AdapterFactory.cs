using MatterDapter.Shared.Enum;
using MatterDapter.Stores.Common.Interface;
using MatterDapter.Stores.Relational;

namespace MatterDapter.Factory
{
    internal class AdapterFactory : IAdapterFactory
    {
        private readonly IDictionary<Store,IRepository> _adapters;
        private readonly IRelationalConnectionFactory _relationalConnectionFactory;

        public AdapterFactory(IRelationalConnectionFactory relationalConnectionFactory)
        {
            _relationalConnectionFactory = relationalConnectionFactory;
            _adapters = new Dictionary<Store, IRepository>
            {
                { Store.SQL_SERVER, new SqlServer(_relationalConnectionFactory) }
            };
        }

        public IRepository GetMatterAdapter(Store dataStore)
        {
            var getAdapter = _adapters.TryGetValue(dataStore, out var adapter);

            if (getAdapter && adapter != null)
            {
                return adapter;
            }

            throw new ArgumentException("Adaptor not found");
        }
     
    }
}
