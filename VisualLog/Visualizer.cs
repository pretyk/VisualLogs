using VisualLog.Factories;
using VisualLog.Visualizers;

namespace VisualLog
{
    public static class Visualizer
    {
        public static IVisualizer Svg
        {
            get { return new SvgVisualizer(VisualizerFactoryProvider.AttributeBasedFactoryProvider); }
        }
    }
}
