namespace VisualLog.Graphs
{
    internal interface IStringGraph
    {
        void AddEdge(string source, string target);
        void AddVertex(string description);
    }
}
