
namespace VisualLog.Graphs
{
    public interface IGraph
    {
        void AddEdge(string source, string target);
        void AddVertex(string description);
    }
}
