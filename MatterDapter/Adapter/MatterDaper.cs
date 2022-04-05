using MatterDapter.Factory;
using MatterDapter.Models;
using MatterDapter.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatterDapter.Adapter
{
    internal class MatterDaper : IMatterAdapter
    {
        private readonly IAdapterFactory _adapterFactory;
        public MatterDaper(IAdapterFactory adapterFactory)
        {
            _adapterFactory = adapterFactory;
        }

        public Task<MatterDapterResponse> DeleteAsync(dynamic id, Store selectedDataStore)
        {
            var adapter = _adapterFactory.GetMatterAdapter(selectedDataStore);

            return adapter.DeleteAsync(id);
        }

        public Task<MatterDapterResponse<T>> GetAsync<T>(Store selectedDataStore, int pageNumber = 1, int count = 10)
        {
            var adapter = _adapterFactory.GetMatterAdapter(selectedDataStore);

            return adapter.GetAsync<T>(pageNumber, count);
        }

        public Task<MatterDapterResponse<T>> InsertAsync<T>(T data, Store selectedDataStore)
        {
            var adapter = _adapterFactory.GetMatterAdapter(selectedDataStore);

            return adapter.InsertAsync(data);
        }

        public Task<MatterDapterResponse<T>> UpdateAsync<T>(T data, Store selectedDataStore)
        {
            var adapter = _adapterFactory.GetMatterAdapter(selectedDataStore);

            return adapter.UpdateAsync(data);
        }
    }
}
