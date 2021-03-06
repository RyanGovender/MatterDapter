using MatterDapter.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatterDapter.Factory
{
    public interface IRelationalConnectionFactory
    {
        internal IDbConnection GetRelationConnection(Store relationalTypes);
    }
}
