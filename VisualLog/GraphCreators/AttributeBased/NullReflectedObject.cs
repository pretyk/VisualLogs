using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualLog.GraphCreators.AttributeBased
{
    internal class NullReflectedObject : IObjectDescriptor, IEquatable<NullReflectedObject>
    {
       

    

        public IEnumerable<IObjectDescriptor> InnerObjectsDescriptors { get { return null; } }
        public string Description { get { return null; } }
        public bool Equals(ReflectedObject other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(NullReflectedObject other)
        {
            return other != null; //all NullReflectedObjects objects are equal
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NullReflectedObject) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}
