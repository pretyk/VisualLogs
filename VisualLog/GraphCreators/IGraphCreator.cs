

namespace VisualLog.GraphCreators
{
    internal interface IGraphCreator<T>
    {
        T Create(object obj);
    }
}
