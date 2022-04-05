using MatterDapter.Adapter;
using MatterDapter.Factory;
using MatterDapter.Models;
using MatterDapter.Shared.Enum;
using MatterDapter.Stores.Common.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using MatterDapter.Extensions;

namespace MatterDapter.Stores.Relational
{
    internal class SqlServer : IRepository
    {
        private readonly IConfiguration _config;

        public SqlServer(IConfiguration configuration)
        {
            _config = configuration;
        }

        public Task<MatterDapterResponse> DeleteAsync<T>(T entityToDelete) where T : class
        {
            try
            {
                using IDbConnection connection = new SqlConnection(_config.GetSQLServerConnectionString());

                var result = connection.DeleteAsync(entityToDelete);

                return Task.FromResult(new MatterDapterResponse());
            }
            catch (Exception ex)
            {
                return Task.FromResult(new MatterDapterResponse(ex));
            }
        }

        public Task<MatterDapterResponse<T>> FindAsync<T>(dynamic id)
        {
            throw new NotImplementedException();
        }

        public Task<MatterDapterResponse<IEnumerable<T>>> GetAllAsync<T>() where T : class
        {
            try
            {
                using IDbConnection connection = new SqlConnection(_config.GetSQLServerConnectionString());

                var result = connection.GetAllAsync<T>();

                return Task.FromResult(new MatterDapterResponse<IEnumerable<T>>(result.GetAwaiter().GetResult()));
            }
            catch (Exception ex)
            {
                return Task.FromResult(new MatterDapterResponse<IEnumerable<T>>(new List<T>(),ex));
            }
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
