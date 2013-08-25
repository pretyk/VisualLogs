using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualLog.GraphCreators
{
    internal interface IGraphCreator
    {
        IStringGraph Create(object obj);
    }
}
