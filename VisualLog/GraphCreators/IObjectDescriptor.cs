using System.Collections.Generic;

namespace VisualLog.GraphCreators
{
    internal interface IObjectDescriptor
    {
        IEnumerable<IObjectDescriptor> InnerObjectsDescriptors { get; }
        string Description { get; }
    }
}
