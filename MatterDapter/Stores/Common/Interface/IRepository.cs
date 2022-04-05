
using MatterDapter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatterDapter.Stores.Common.Interface
{
    internal interface IRepository
    {
        Task<MatterDapterResponse<T>> GetAsync<T>(int pageNumber = 1, int count = 10);
        Task<MatterDapterResponse<T>> InsertAsync<T>(T data);
        Task<MatterDapterResponse<T>> UpdateAsync<T>(T data);
        Task<MatterDapterResponse> DeleteAsync(dynamic id);
    }
}
