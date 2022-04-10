using MatterDapter.Adapter;
using MatterDapter.Shared.Enum;
using MatterDapter.Stores.Common.Interface;

namespace MatterDapter.Factory
{
    public interface IAdapterFactory
    {
        IRepository GetMatterAdapter(Store dataStore);
    }
}
