using System;
using System.Collections.Generic;
using QuickGraph;

namespace VisualLog
{
    internal class SimpleStringGraph : IStringGraph
    {

        #region fields

        private AdjacencyGraph<string, TaggedEdge<string, string>> _graph = new AdjacencyGraph<string, TaggedEdge<string, string>>();

        #endregion

    

        #region public methods

        public void AddObject(string actionName)
        {
            _graph.AddVertex(actionName);
        }

        public void AddRelation(string edgeName1, string edgeName2)
        {
            _graph.AddEdge(new TaggedEdge<string, string>(edgeName1, edgeName2,""));
        }


        public AdjacencyGraph<string, TaggedEdge<string, string>> ToQuickGraph()
        {
            return _graph;
        }
        #endregion
    }
}
