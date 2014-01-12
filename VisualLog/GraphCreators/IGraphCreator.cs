using VisualLog.Graphs;

namespace VisualLog.GraphCreators
{
    public interface IGraphCreator 
    {
        void Create(object obj, IStringGraph stringGraph);
    }
}
