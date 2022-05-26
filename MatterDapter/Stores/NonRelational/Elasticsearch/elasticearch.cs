using Elasticsearch.Net;
using MatterDapter.Extensions;
using MatterDapter.Models;
using MatterDapter.Stores.Common.Interface;
using MatterDapter.Stores.Common.Logic;
using MatterDapter.Attributes;
using Microsoft.Extensions.Configuration;
using Nest;


namespace MatterDapter.Stores.NonRelational.Elasticsearch
{
    internal class elasticearch : IRepository
    {
        private readonly IConfiguration _config;
        
        private readonly ElasticClient _esClient;

        private readonly ElasticSettings _settings;

        public const int GetAllLimit = 10000;
      

        public elasticearch(IConfiguration configuration)
        {
            _config = configuration;
            _settings = _config.GetElasticSettings();
            _esClient = CreateConnection(_settings);
        }

        private static string GetIndexName<T>()
        {
            return typeof(T).Name.ToLower();
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

        public async Task<MatterDapterResponse<T>> FindAsync<T>(object id) where T : class
        {
            var documentResponse = await _esClient
                 .GetAsync<T>(id.ToString(), x => x
                 .Index(GetIndexName<T>()));

            return new MatterDapterResponse<T>(documentResponse.Source);
        }

        public async Task<MatterDapterResponse<IEnumerable<T>>> GetAllAsync<T>() where T : class
        {
            var documentResponse = await _esClient
               .SearchAsync<T>(s => s
               .MatchAll(m => m)
               .Size(GetAllLimit)
               .Index(GetIndexName<T>()));

            return new MatterDapterResponse<IEnumerable<T>>(documentResponse.Documents);
        }

        public async Task<MatterDapterResponse<T>> InsertAsync<T>(T data) where T : class
        {
            var getId = typeof(T)
                .GetProperties()
                .FirstOrDefault(p => p
                .GetCustomAttributes(typeof(IdPropertyAttribute), false).Length == 1);
           
            var test = getId.GetValue(data);

            var insertResult = await _esClient
               .IndexAsync(data, i => i
               .Id(new Id(getId.GetValue(test)))
               .Index(GetIndexName<T>()));

            return insertResult.IsValid ? 
                new MatterDapterResponse<T>(insertResult.Id):
                new MatterDapterResponse<T>(insertResult.ServerError, false, Messages.Insert_Failed);
        }

        public async Task<MatterDapterResponse<T>> UpdateAsync<T>(T data) where T : class
        {
            var id = DocumentPath<T>.Id(data);

            var updateResult = await _esClient
              .UpdateAsync(id, update => update
              .Index(GetIndexName<T>())
              .Doc(data)
              .DocAsUpsert()
              .Refresh(Refresh.True));

            return updateResult.IsValid ? 
                new MatterDapterResponse<T>(updateResult.Id, true, Messages.Update_Success) :
                new MatterDapterResponse<T>(updateResult.ServerError, false, Messages.Update_Failed);
        }
    }
}
