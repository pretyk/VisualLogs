using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualLog.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class VisualLogAttribute : Attribute
    {
        public string Description { set; get; }

    }
}
