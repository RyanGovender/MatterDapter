using MatterDapter.Factory;
using MatterDapter.Models;
using MatterDapter.Shared.Enum;

namespace MatterDapter.Adapter
{
    public class MatterDaper : IMatterAdapter
    {
        private readonly IAdapterFactory _adapterFactory;
        public MatterDaper(IAdapterFactory adapterFactory)
        {
            _adapterFactory = adapterFactory;
        }
 
        public Task<MatterDapterResponse> DeleteAsync<T>(T entityToDelete, Store selectedDataStore = Store.NO_STORE) where T : class
        {
            var adapter = _adapterFactory.GetMatterAdapter(selectedDataStore);

            return adapter.DeleteAsync(entityToDelete);
        }

        public Task<MatterDapterResponse<T>> FindAsync<T>(object id, Store selectedDataStore = Store.NO_STORE) where T : class
        {
            var adapter = _adapterFactory.GetMatterAdapter(selectedDataStore);

            return adapter.FindAsync<T>(id);
        }

        public Task<MatterDapterResponse<IEnumerable<T>>> GetAsync<T>(Store selectedDataStore = Store.NO_STORE) where T : class
        {
            var adapter = _adapterFactory.GetMatterAdapter(selectedDataStore);

            return adapter.GetAllAsync<T>();
        }

        public Task<MatterDapterResponse<T>> InsertAsync<T>(T data, Store selectedDataStore = Store.NO_STORE) where T : class
        {
            var adapter = _adapterFactory.GetMatterAdapter(selectedDataStore);

            return adapter.InsertAsync(data);
        }

        public Task<MatterDapterResponse<T>> UpdateAsync<T>(T data, Store selectedDataStore = Store.NO_STORE) where T : class
        {
            var adapter = _adapterFactory.GetMatterAdapter(selectedDataStore);

            return adapter.UpdateAsync(data);
        }
    }
}
