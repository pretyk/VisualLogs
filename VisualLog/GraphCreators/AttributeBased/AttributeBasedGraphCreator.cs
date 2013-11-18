using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VisualLog.Attributes;
using VisualLog.GraphCreators.AttributeBased;

namespace VisualLog.GraphCreators
{
    internal class AttributeBasedGraphCreator : IGraphCreator
    {
        private IStringGraph _stringGraph;

        public AttributeBasedGraphCreator(IStringGraph stringGraph)
        {
            _stringGraph = new SimpleStringGraph();
        }
        public AttributeBasedGraphCreator() : this(new SimpleStringGraph())
        {

        }
        public IStringGraph Create(object obj)
        {
            var reflectedObject = new ReflectedObject(obj);

            var queue = new Queue<ReflectedObject>();

            queue.Enqueue(reflectedObject);
            var visitedList = new List<ReflectedObject>() { reflectedObject };
            _stringGraph.AddObject(reflectedObject.Description);
            while (queue.Count > 0)
            {
                var curRoot = queue.Dequeue();

                foreach (var reflectedChild in curRoot.InnerReflectedObjects)
                {
                    _stringGraph.AddObject(reflectedChild.Description);
                    _stringGraph.AddRelation(curRoot.Description, reflectedChild.Description); //TODO: add also objecy
                    if (!visitedList.Contains(reflectedChild))
                    {
                        queue.Enqueue(reflectedChild);
                        visitedList.Add(reflectedChild);
                    }
                }
            }
            return _stringGraph;
        }
    }
}
