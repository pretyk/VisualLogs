using VisualLog.Factories;
using VisualLog.GraphCreators;

namespace VisualLog.Visualizers
{
    internal abstract class VisualizerBase :  IVisualizer
    {
        private readonly IGraphCreator _graphCreator;

        protected IGraphCreator GraphCreator
        {
            get { return _graphCreator; }
        }

        public abstract string Visualize(object o);

        protected VisualizerBase(IFactoryProvider factoryProvider)
        {
            _graphCreator = factoryProvider.CreateGraphCreator();
        }
    }
}
