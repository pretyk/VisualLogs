using System.Collections.Generic;

namespace VisualLog.GraphCreators
{
    public interface IObjectDescriptor
    {
        IEnumerable<IObjectDescriptor> InnerObjectsDescriptors { get; }
        string Description { get; }
    }
}
