using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatterDapter.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IdPropertyAttribute : Attribute
    {
        public string IdName { get; private init; }
        public IdPropertyAttribute(string name)
        {
            IdName = name;
        }
    }
}
