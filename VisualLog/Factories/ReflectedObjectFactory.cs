using VisualLog.GraphCreators;
using VisualLog.GraphCreators.AttributeBased;

namespace VisualLog.Factories
{
    internal class ReflectedObjectFactory : IObjectDescriptorFactory
    {
        public IObjectDescriptor Create(object o)
        {
            return new ReflectedObject(o);
        }
    }
}
