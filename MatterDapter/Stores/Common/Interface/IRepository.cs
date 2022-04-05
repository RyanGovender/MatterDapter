
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
        Task<MatterDapterResponse<IEnumerable<T>>> GetAllAsync<T>() where T : class;
        Task<MatterDapterResponse<T>> InsertAsync<T>(T data);
        Task<MatterDapterResponse<T>> UpdateAsync<T>(T data);
        Task<MatterDapterResponse> DeleteAsync<T>(T entityToDelete) where T : class;
 
         Task<MatterDapterResponse<T>> FindAsync<T>(dynamic id);
    }
}
