using MatterDapter.Factory;
using MatterDapter.Shared.Enum;
using MatterDapter.Stores.Common.Interface;
using MatterDapter.Stores.Relational.Base;

namespace MatterDapter.Stores.Relational
{
    internal class Postgres : RelationalBase, IRepository
    {
        public Postgres(IRelationalConnectionFactory relationalConnectionFactory) : base(relationalConnectionFactory)
        {
        }

        protected override Store DatabaseType() => Store.POSTGRES;
    }
}
