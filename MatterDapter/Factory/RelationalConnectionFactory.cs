using MatterDapter.Extensions;
using MatterDapter.Shared.Enum;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
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

        public IDbConnection GetRelationConnection(SupportedRelationalTypes relationalTypes)
        {
            return relationalTypes switch
            {
                SupportedRelationalTypes.SQLSERVER => new SqlConnection(_config.GetSQLServerConnectionString()),
                _ => throw new NotSupportedException($"Connection could not be created for {relationalTypes}."),
            };
        }
    }
}
