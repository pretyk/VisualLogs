using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualLog.Graphs
{
    internal interface IStringGraph
    {
        void AddEdge(string source, string target);
        void AddVertex(string description);
    }
}
