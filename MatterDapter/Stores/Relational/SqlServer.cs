using MatterDapter.Models;
using MatterDapter.Stores.Common.Interface;
using System.Data;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using MatterDapter.Extensions;
using MatterDapter.Factory;
using MatterDapter.Shared.Enum;
using MatterDapter.Stores.Relational.Base;

namespace MatterDapter.Stores.Relational
{
    internal class SqlServer : RelationalBase, IRepository
    {

        public SqlServer(IRelationalConnectionFactory relationalConnectionFactory) : base(relationalConnectionFactory)
        {
        }

        protected override SupportedRelationalTypes DatabaseType() => SupportedRelationalTypes.SQLSERVER;
       
    }
}
