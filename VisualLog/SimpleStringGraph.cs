using System;
using System.Collections.Generic;
using QuickGraph;

namespace VisualLog
{
    internal class SimpleStringGraph : IStringGraph
    {

        #region fields

        private readonly List<string> _edges = new List<string>();
        private readonly List<Tuple<string, string>> _relations = new List<Tuple<string, string>>();

        #endregion

        #region properties

        public IEnumerable<Tuple<string, string>> Relations { get { return _relations; } }

        public IEnumerable<string> Names { get { return _edges; } }

        #endregion

        #region public methods

        public void AddEdge(string actionName)
        {
            _edges.Add(actionName);
        }

        public void AddRelation(string edgeName1, string edgeName2)
        {
            _relations.Add(new Tuple<string, string>(edgeName1, edgeName2));
        }


        public AdjacencyGraph<string, TaggedEdge<string, string>> ToQuickGraph()
        {
            var names = Names;
            var relations = Relations;

            var graph = new AdjacencyGraph<string, TaggedEdge<string, string>>();

            foreach (var item in names)
            {
                graph.AddVertex(item);
            }

            foreach (var relation in relations)
            {
                graph.AddEdge(new TaggedEdge<string, string>(relation.Item1, relation.Item2, string.Empty));
            }

            return graph;
        }
        #endregion
    }
}
