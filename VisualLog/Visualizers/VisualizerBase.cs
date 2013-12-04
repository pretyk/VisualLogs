using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualLog.Visualizers
{
    public abstract class VisualizerBase<T> :  IVisualizer where T : new()
    {
        private readonly T _graphCreator;

        protected T GraphCreator
        {
            get { return _graphCreator; }
        }
        public abstract string Visualize(object o);

        protected VisualizerBase()
        {
            _graphCreator = new T();
        }
    }
}
