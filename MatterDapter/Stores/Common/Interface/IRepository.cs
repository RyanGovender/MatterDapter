using MatterDapter.Models;


namespace MatterDapter.Stores.Common.Interface
{
    public interface IRepository
    {
        Task<MatterDapterResponse<IEnumerable<T>>> GetAllAsync<T>() where T : class;
        Task<MatterDapterResponse<T>> InsertAsync<T>(T data) where T : class;
        Task<MatterDapterResponse<T>> UpdateAsync<T>(T data) where T : class;
        Task<MatterDapterResponse> DeleteAsync<T>(T entityToDelete) where T : class;
         Task<MatterDapterResponse<T>> FindAsync<T>(object id) where T : class;
    }
}
