using VisualLog.Visualizers;

namespace VisualLog.Factories
{
    public static class Visualizer 
    {
        public static IVisualizer GetSvg()
        {
            return new SvgVisualizer(VisualizerFactoryProvider.AttributeBasedFactoryProvider);
        }
    }
}
