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
        Task<MatterDapterResponse<T>> GetAsync<T>();
        Task<MatterDapterResponse<T>> InsertAsync<T>(T data);
        Task<MatterDapterResponse<T>> UpdateAsync<T>(T data);
        Task<MatterDapterResponse> DeleteAsync(dynamic id);
    }
}
