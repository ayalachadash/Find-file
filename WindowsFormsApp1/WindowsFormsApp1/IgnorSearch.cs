using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    class IgnorSearchAttribute : Attribute
    {

    }
}
