using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VisualLog.Attributes;
using VisualLog.GraphCreators.AttributeBased;

namespace VisualLog.GraphCreators
{
    internal class AttributeBasedGraphCreator : IGraphCreator
    {
        public IStringGraph Create(object obj)
        {
            var reflectedObject = new ReflectedObject(obj);

            return null;
        }
    }
}
