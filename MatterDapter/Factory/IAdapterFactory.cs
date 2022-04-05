using MatterDapter.Adapter;
using MatterDapter.Stores.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatterDapter.Factory
{
    internal interface IAdapterFactory
    {
        IRepository GetMatterAdapter();
    }
}
