using MatterDapter.Models;
using MatterDapter.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatterDapter.Adapter
{
    public interface IMatterAdapter
    {
        Task<MatterDapterResponse<T>> GetAsync<T>(Store selectedDataStore, int pageNumber = 1, int count = 10);
        Task<MatterDapterResponse<T>> InsertAsync<T>(T data, Store selectedDataStore);
        Task<MatterDapterResponse<T>> UpdateAsync<T>(T data, Store selectedDataStore);
        Task<MatterDapterResponse> DeleteAsync(dynamic id, Store selectedDataStore);
    }
}
