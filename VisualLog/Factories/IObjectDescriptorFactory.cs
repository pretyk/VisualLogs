using VisualLog.GraphCreators;

namespace VisualLog.Factories
{
    internal interface IObjectDescriptorFactory
    {
        IObjectDescriptor Create(object o);
    }
}
