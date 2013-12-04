using VisualLog.Graphs;

namespace VisualLog.GraphCreators
{
    internal interface IGraphCreator 
    {
        T Create<T>(object obj) where T : IStringGraph, new();
    }
}
