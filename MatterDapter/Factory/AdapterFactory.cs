using MatterDapter.Adapter;
using MatterDapter.Factory;
using MatterDapter.Stores.Common.Interface;
using MatterDapter.Stores.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatterDapter.Factory
{
    internal class AdapterFactory : IAdapterFactory
    {
        public IRepository GetMatterAdapter()
        {
            return new SqlServer();
        }
    }
}
