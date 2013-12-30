// ReSharper disable InconsistentNaming

using System.Linq;
using NUnit.Framework;
using VisualLog.GraphCreators.AttributeBased;

namespace VisualLog.Tests.UnitTests
{
    class ReflectedTypeTests
    {
        [TestCase]
        public void ReflectedTypeCreation_SimpleObjectWithTwoMembers_CorrectReflectedType()
        {
            var o = new TestObject(new InnerObject1(), new InnerObject2());

            var reflectedObject = new ReflectedObject(o);
            Assert.IsNotNull(reflectedObject);
            Assert.AreEqual(new[] { new ReflectedObject(o.InnerObject1), new ReflectedObject(o.InnerObject2) }, reflectedObject.InnerObjectsDescriptors.ToArray());
            
            //var rt = new ReflectedObject(obj);
        }
    }
}
