using System.Collections.Generic;
using VisualLog.Factories;
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

        public void Create(object obj, IStringGraph stringGraph)
        {
            var reflectedObject = _objectDescriptorFactory.Create(obj);

            var queue = new Queue<IObjectDescriptor>();

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
        }
    }
}
