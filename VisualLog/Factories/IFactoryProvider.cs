using VisualLog.GraphCreators;
using VisualLog.GraphCreators.AttributeBased;

namespace VisualLog.Factories
{
    internal interface IFactoryProvider
    {
        IObjectDescriptorFactory GetObjectDescriptorFactory();
        IGraphCreator CreateGraphCreator();
    }
}
