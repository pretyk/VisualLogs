using VisualLog.GraphCreators;
using VisualLog.Graphs;

namespace VisualLog.Factories
{
    public interface IFactoryProvider
    {
        IObjectDescriptorFactory GetObjectDescriptorFactory();
        IGraphCreator CreateGraphCreator();
        IStringGraph CreateStringGraph();
    }
}
