using System;
using System.Collections.Generic;
using QuickGraph;

namespace VisualLog
{
    internal interface IStringGraph
    {
        IEnumerable<Tuple<string, string>> Relations { get; }
        IEnumerable<string> Names { get; }
        void AddEdge(string actionName);
        void AddRelation(string edgeName1, string edgeName2);
        AdjacencyGraph<string, TaggedEdge<string, string>> ToQuickGraph();
    }
}