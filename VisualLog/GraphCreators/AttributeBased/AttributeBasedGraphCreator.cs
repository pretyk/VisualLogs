using System.Collections.Generic;
using VisualLog.Graphs;

namespace VisualLog.GraphCreators.AttributeBased
{
    internal class AttributeBasedGraphCreator : IGraphCreator
    {
        private readonly IObjectDescriptorFactory _objectDescriptorFactory;

        public AttributeBasedGraphCreator(IObjectDescriptorFactory objectDescriptorFactory)
        {
            _objectDescriptorFactory = objectDescriptorFactory;
        }

        public T Create<T>(object obj) where T: IStringGraph, new()
        {
            var reflectedObject = _objectDescriptorFactory.Create(obj);

            var queue = new Queue<IObjectDescriptor>();
            var stringGraph = new T();

            queue.Enqueue(reflectedObject);
            var visitedList = new List<IObjectDescriptor> { reflectedObject };
            stringGraph.AddVertex(reflectedObject.Description);
            while (queue.Count > 0)
            {
                var curRoot = queue.Dequeue();

                foreach (var reflectedChild in curRoot.InnerObjectsDescriptors)
                {
                    stringGraph.AddVertex(reflectedChild.Description);
                    stringGraph.AddEdge(curRoot.Description, reflectedChild.Description);
                    if (!visitedList.Contains(reflectedChild))
                    {
                        queue.Enqueue(reflectedChild);
                        visitedList.Add(reflectedChild);
                    }
                }
            }
            return stringGraph;
        }
    }

    internal interface IObjectDescriptorFactory
    {
        IObjectDescriptor Create(object o);
    }

    internal class ReflectedObjectFactory : IObjectDescriptorFactory
    {
        public IObjectDescriptor Create(object o)
        {
            return new ReflectedObject(o);
        }
    }
}
