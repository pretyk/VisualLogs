using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualLog.Factories;
using VisualLog.GraphCreators;
using VisualLog.GraphCreators.AttributeBased;

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
