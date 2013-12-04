using System.Collections.Generic;
using QuickGraph;
using VisualLog.Graphs;

namespace VisualLog.GraphCreators.AttributeBased
{
    internal class AttributeBasedGraphCreator : IGraphCreator
    {

        public T Create<T>(object obj) where T: IStringGraph, new()
        {
            var reflectedObject = new ReflectedObject(obj);

            var queue = new Queue<ReflectedObject>();
            var stringGraph = new T();

            queue.Enqueue(reflectedObject);
            var visitedList = new List<ReflectedObject> { reflectedObject };
            stringGraph.AddVertex(reflectedObject.Description);
            while (queue.Count > 0)
            {
                var curRoot = queue.Dequeue();

                foreach (var reflectedChild in curRoot.InnerReflectedObjects)
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
}
