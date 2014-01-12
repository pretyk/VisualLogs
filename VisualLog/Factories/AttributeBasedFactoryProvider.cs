using VisualLog.GraphCreators;
using VisualLog.GraphCreators.AttributeBased;
using VisualLog.Graphs;

namespace VisualLog.Factories
{
    internal class AttributeBasedFactoryProvider : IFactoryProvider
    {
        public IObjectDescriptorFactory GetObjectDescriptorFactory()
        {
            return new ReflectedObjectFactory();
        }

        public IGraphCreator CreateGraphCreator()
        {
            return new AttributeBasedGraphCreator(new ReflectedObjectFactory());
        }

        public IStringGraph CreateStringGraph()
        {
            return new StringGraph();
        }
    }
}