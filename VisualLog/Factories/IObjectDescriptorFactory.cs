using VisualLog.GraphCreators;

namespace VisualLog.Factories
{
    public interface IObjectDescriptorFactory
    {
        IObjectDescriptor Create(object o);
    }
}
