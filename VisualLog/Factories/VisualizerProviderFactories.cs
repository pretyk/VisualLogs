using VisualLog.GraphCreators;
using VisualLog.GraphCreators.AttributeBased;

namespace VisualLog.Factories
{
    internal static class VisualizerFactoryProvider
    {
        public static IFactoryProvider AttributeBasedFactoryProvider
        {
            get { return new AttributeBasedFactoryProvider(); }
        }
    }

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
    }

    internal interface IFactoryProvider
    {
        IObjectDescriptorFactory GetObjectDescriptorFactory();
        IGraphCreator CreateGraphCreator();
    }
}
