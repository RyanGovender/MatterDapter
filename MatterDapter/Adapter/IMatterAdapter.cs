using MatterDapter.Models;
using MatterDapter.Shared.Enum;

namespace MatterDapter.Adapter
{
    public interface IMatterAdapter
    {
        Task<MatterDapterResponse<IEnumerable<T>>> GetAsync<T>(Store selectedDataStore = Store.NO_STORE) where T : class;
        Task<MatterDapterResponse<T>> InsertAsync<T>(T data, Store selectedDataStore = Store.NO_STORE) where T : class;
        Task<MatterDapterResponse<T>> UpdateAsync<T>(T data, Store selectedDataStore = Store.NO_STORE) where T : class;
        Task<MatterDapterResponse> DeleteAsync<T>(T entityToDelete, Store selectedDataStore = Store.NO_STORE) where T : class;
        Task<MatterDapterResponse<T>> FindAsync<T>(object id, Store selectedDataStore = Store.NO_STORE) where T : class;
    }
}
