using MatterDapter.Adapter;
using MatterDapter.Factory;
using MatterDapter.Models;
using MatterDapter.Shared.Enum;
using MatterDapter.Stores.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatterDapter.Stores.Relational
{
    internal class SqlServer : IRepository
    {
        public Task<MatterDapterResponse> DeleteAsync(dynamic id)
        {
            throw new NotImplementedException();
        }

        public Task<MatterDapterResponse<T>> GetAsync<T>(int pageNumber = 1, int count = 10)
        {
            throw new NotImplementedException();
        }

        public Task<MatterDapterResponse<T>> InsertAsync<T>(T data)
        {
            throw new NotImplementedException();
        }

        public Task<MatterDapterResponse<T>> UpdateAsync<T>(T data)
        {
            throw new NotImplementedException();
        }
    }
}
