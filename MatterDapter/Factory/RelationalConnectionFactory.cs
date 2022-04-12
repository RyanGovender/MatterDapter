using MatterDapter.Extensions;
using MatterDapter.Shared.Enum;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatterDapter.Factory
{
    internal class RelationalConnectionFactory : IRelationalConnectionFactory
    {
        private readonly IConfiguration _config;
        public RelationalConnectionFactory(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IDbConnection GetRelationConnection(Store relationalTypes)
        {
            return relationalTypes switch
            {
                Store.SQL_SERVER => new SqlConnection(_config.GetSQLServerConnectionString()),
                Store.MYSQL => new MySqlConnection(_config.GetMySQLConnectionString()),
                Store.POSTGRES => new NpgsqlConnection(_config.GetPostgresConnectionString()),
                _ => throw new NotSupportedException($"Connection could not be created for {relationalTypes}."),
            };
        }
    }
}
