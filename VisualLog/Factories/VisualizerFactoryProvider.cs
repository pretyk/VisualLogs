namespace VisualLog.Factories
{
    internal static class VisualizerFactoryProvider
    {
        public static IFactoryProvider AttributeBasedFactoryProvider
        {
            get { return new AttributeBasedFactoryProvider(); }
        }
    }
}
