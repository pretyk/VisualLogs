using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualLog.Visualizers;

namespace VisualLog
{
    public static class VisualizerFactory
    {
        public static IVisualizer GetVisualizer(VisualizerType type)
        {
            switch (type)
            {
                case VisualizerType.Svg:
                    return new SvgVisualizer();
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }
    }

    public enum VisualizerType
    {
        Svg,
        //TODO: support more types
    }
}
