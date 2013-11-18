using System;
using System.Collections.Generic;
using QuickGraph;

namespace VisualLog
{
    internal interface IStringGraph
    {
        void AddObject(string actionName);
        void AddRelation(string edgeName1, string edgeName2);
        AdjacencyGraph<string, TaggedEdge<string, string>> ToQuickGraph();
    }
}