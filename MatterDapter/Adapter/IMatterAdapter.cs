using MatterDapter.Models;
using MatterDapter.Shared.Enum;

namespace MatterDapter.Adapter
{
    public interface IMatterAdapter
    {
        Task<MatterDapterResponse<IEnumerable<T>>> GetAsync<T>(Store selectedDataStore) where T : class;
        Task<MatterDapterResponse<T>> InsertAsync<T>(T data, Store selectedDataStore) where T : class;
        Task<MatterDapterResponse<T>> UpdateAsync<T>(T data, Store selectedDataStore) where T : class;
        Task<MatterDapterResponse> DeleteAsync<T>(T entityToDelete, Store selectedDataStore) where T : class;
        Task<MatterDapterResponse<T>> FindAsync<T>(object id, Store selectedDataStore) where T : class;
    }
}
