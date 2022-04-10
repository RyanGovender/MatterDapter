using MatterDapter.Factory;
using MatterDapter.Models;
using MatterDapter.Shared.Enum;
using MatterDapter.Stores.Common.Interface;
using MatterDapter.Stores.Relational.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatterDapter.Stores.Relational
{
    internal class MySql : RelationalBase, IRepository
    {
        public MySql(IRelationalConnectionFactory relationalConnectionFactory) : base(relationalConnectionFactory)
        {
        }

        protected override SupportedRelationalTypes DatabaseType() => SupportedRelationalTypes.MYSQL;
    }
}
