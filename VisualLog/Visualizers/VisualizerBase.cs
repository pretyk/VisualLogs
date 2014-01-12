using VisualLog.Factories;
using VisualLog.GraphCreators;

namespace VisualLog.Visualizers
{
    internal abstract class VisualizerBase :  IVisualizer
    {
        protected IFactoryProvider FactoryProvider
        {
            private set; 
            get;
        }

        public abstract string Visualize(object o);

        protected VisualizerBase(IFactoryProvider factoryProvider)
        {
            FactoryProvider = factoryProvider;
        }
    }
}
