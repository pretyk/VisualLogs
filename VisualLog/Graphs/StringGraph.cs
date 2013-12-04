using QuickGraph;

namespace VisualLog.Graphs
{
    internal class StringGraph : IStringGraph
    {
        private readonly AdjacencyGraph<string, TaggedEdge<string, string>> _graph = new AdjacencyGraph<string, TaggedEdge<string, string>>();

        public void AddEdge(string source, string target)
        {
            _graph.AddEdge(new TaggedEdge<string, string>(source, target, string.Empty));
        }

        public void AddVertex(string description)
        {
            _graph.AddVertex(description);
        }

        public IEdgeListGraph<string, TaggedEdge<string, string>> ToQuickGraph()
        {
            return _graph;
        }
    }
}
