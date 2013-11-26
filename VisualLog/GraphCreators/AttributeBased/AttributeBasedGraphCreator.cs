using System.Collections.Generic;
using QuickGraph;

namespace VisualLog.GraphCreators.AttributeBased
{
    internal class AttributeBasedGraphCreator : IGraphCreator<AdjacencyGraph<string, TaggedEdge<string, string>>>
    {
        private AdjacencyGraph<string, TaggedEdge<string, string>> _stringGraph;

        public AttributeBasedGraphCreator(AdjacencyGraph<string, TaggedEdge<string, string>> stringGraph)
        {
            _stringGraph = stringGraph;
        }
        public AttributeBasedGraphCreator() : this(new AdjacencyGraph<string, TaggedEdge<string, string>>())
        {

        }
        public AdjacencyGraph<string, TaggedEdge<string, string>> Create(object obj)
        {
            var reflectedObject = new ReflectedObject(obj);

            var queue = new Queue<ReflectedObject>();

            queue.Enqueue(reflectedObject);
            var visitedList = new List<ReflectedObject>() { reflectedObject };
            _stringGraph.AddVertex(reflectedObject.Description);
            while (queue.Count > 0)
            {
                var curRoot = queue.Dequeue();

                foreach (var reflectedChild in curRoot.InnerReflectedObjects)
                {
                    _stringGraph.AddVertex(reflectedChild.Description);
                    _stringGraph.AddEdge(new TaggedEdge<string, string>(curRoot.Description, reflectedChild.Description, string.Empty));
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
