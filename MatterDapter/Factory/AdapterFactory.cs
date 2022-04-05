using MatterDapter.Adapter;
using MatterDapter.Factory;
using MatterDapter.Shared.Enum;
using MatterDapter.Stores.Common.Interface;
using MatterDapter.Stores.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatterDapter.Factory
{
    internal class AdapterFactory : IAdapterFactory
    {
        private readonly IDictionary<Store,IRepository> _adapters;
        public AdapterFactory()
        {
            _adapters = new Dictionary<Store, IRepository>();
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
