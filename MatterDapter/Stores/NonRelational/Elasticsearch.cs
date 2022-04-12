using Elasticsearch.Net;
using MatterDapter.Models;
using MatterDapter.Stores.Common.Interface;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatterDapter.Stores.NonRelational
{
    internal class Elasticsearch : IRepository
    {
        private readonly ElasticClient _esClient;
        private string _indexName { get; set; }

        public Elasticsearch()
        {
            _esClient = CreateConnection(null);
        }

        private void SetIndexName<T>() where T : class
        {
           this._indexName = nameof(T);
        }

        internal static ElasticClient CreateConnection(ElasticSettings elkSettings)
        {
            var uri = new Uri(elkSettings.Url);

            var pool = new SingleNodeConnectionPool(uri);

            var settings = new ConnectionSettings(pool);

            if (elkSettings.Username is not null && elkSettings.Password is not null)
            {
                settings.BasicAuthentication(elkSettings.Username, elkSettings.Password);
            }

            return new ElasticClient(settings);
        }

        public Task<MatterDapterResponse> DeleteAsync<T>(T entityToDelete) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<MatterDapterResponse<T>> FindAsync<T>(object id) where T : class
        {
            throw new NotImplementedException();
        }

        public async Task<MatterDapterResponse<IEnumerable<T>>> GetAllAsync<T>() where T : class
        {
            var documentResponse = await _esClient
               .SearchAsync<T>(s => s
               .MatchAll(m => m)
               .Size(10)
               .Index(nameof(T)));

            return new MatterDapterResponse<IEnumerable<T>>(documentResponse.Hits);
        }

        public async Task<MatterDapterResponse<T>> InsertAsync<T>(T data) where T : class
        {
            var insertResult = await _esClient
               .IndexAsync(data, i => i
               .Index(nameof(T)));

            return insertResult.IsValid ? 
                new MatterDapterResponse<T>(insertResult.Id):
                new MatterDapterResponse<T>(insertResult.ServerError);
        }

        public Task<MatterDapterResponse<T>> UpdateAsync<T>(T data) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
