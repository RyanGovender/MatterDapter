using MatterDapter.Models;
using MatterDapter.Stores.Common.Interface;
using System.Data;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using MatterDapter.Extensions;
using MatterDapter.Factory;
using MatterDapter.Shared.Enum;

namespace MatterDapter.Stores.Relational
{
    public class SqlServer : IRepository
    {
        private readonly IRelationalConnectionFactory  _relationalConnectionFactory;

        public SqlServer(IRelationalConnectionFactory relationalConnectionFactory)
        {
            _relationalConnectionFactory = relationalConnectionFactory;
        }

        public async Task<MatterDapterResponse> DeleteAsync<T>(T entityToDelete) where T : class
        {
            try
            {
                using IDbConnection connection = _relationalConnectionFactory.GetRelationConnection(SupportedRelationalTypes.SQLSERVER);

                var result = await connection.DeleteAsync(entityToDelete).ConfigureAwait(false);

                return new MatterDapterResponse(result);
            }
            catch (Exception ex)
            {
                return new MatterDapterResponse(ex);
            }
        }

        public async Task<MatterDapterResponse<T>> FindAsync<T>(object id) where T : class
        {
            try
            {
                using IDbConnection connection = _relationalConnectionFactory.GetRelationConnection(SupportedRelationalTypes.SQLSERVER);

                if(id is null)
                {
                    throw new ArgumentNullException(nameof(id));
                }

                var result = await connection.GetAsync<T>(id);

                return new MatterDapterResponse<T>(result);
            }
            catch (Exception ex)
            {
                return new MatterDapterResponse<T>(ex);
            }
        }

        public async Task<MatterDapterResponse<IEnumerable<T>>> GetAllAsync<T>() where T : class
        {
            try
            {
                using IDbConnection connection = _relationalConnectionFactory.GetRelationConnection(SupportedRelationalTypes.SQLSERVER);

                var result = await connection.GetAllAsync<T>();

                return new MatterDapterResponse<IEnumerable<T>>(result);
            }
            catch (Exception ex)
            {
                return new MatterDapterResponse<IEnumerable<T>>(new List<T>(),ex);
            }
        }

        public async Task<MatterDapterResponse<T>> InsertAsync<T>(T data) where T : class
        {
            try
            {
                using IDbConnection connection = _relationalConnectionFactory.GetRelationConnection(SupportedRelationalTypes.SQLSERVER);

                var result = await connection.InsertAsync(data).ConfigureAwait(false);

                if(result == 0)
                {
                    return new MatterDapterResponse<T>(false);
                }

                return new MatterDapterResponse<T>(result, true, "Success");
               
            }
            catch(Exception ex)
            {
                return new MatterDapterResponse<T>(ex);
            }
        }

        public async Task<MatterDapterResponse<T>> UpdateAsync<T>(T data) where T : class
        {
            try
            {
                using IDbConnection connection = _relationalConnectionFactory.GetRelationConnection(SupportedRelationalTypes.SQLSERVER);

                var result = await connection.UpdateAsync(data).ConfigureAwait(false);

                return new MatterDapterResponse<T>(result);
            }
            catch (Exception ex)
            {
                return new MatterDapterResponse<T>(ex);
            }
        }
    }
}
