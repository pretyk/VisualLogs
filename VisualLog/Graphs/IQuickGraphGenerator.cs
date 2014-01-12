using QuickGraph;

namespace VisualLog.Graphs
{
    public interface IQuickGraphGenerator
    {
        IEdgeListGraph<string, TaggedEdge<string, string>> ToQuickGraph();
    }
}
