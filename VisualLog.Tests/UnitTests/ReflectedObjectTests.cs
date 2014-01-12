// ReSharper disable InconsistentNaming

using System;
using System.Linq;
using NUnit.Framework;
using VisualLog.GraphCreators;
using VisualLog.GraphCreators.AttributeBased;

namespace VisualLog.Tests.UnitTests
{
    [TestFixture]
    class ReflectedObjectTests
    {
        [TestCase]
        public void ReflectedTypeCreation_SimpleObjectWithTwoMembers_CorrectReflectedType()
        {
            var o = new TestObjectWith2AttributedInners(new InnerObject1(), new InnerObject2());

            var reflectedObject = new ReflectedObject(o);
            Assert.IsNotNull(reflectedObject);
            Assert.AreEqual(new[] { new ReflectedObject(o.InnerObject1), new ReflectedObject(o.InnerObject2) }, reflectedObject.InnerObjectsDescriptors.ToArray());
        }

        [TestCase]
        public void ReflectedTypeCreation_NullObject_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new ReflectedObject(null));
        }

        [TestCase(typeof(DummyObject))]
        [TestCase(typeof(TestObjectWithNoAttributedInners))]
        public void ReflectedTypeCreation_NonAttributedObject_DontThrowsException(Type t)
        {
            Object o = Activator.CreateInstance(t);
            ReflectedObject reflectedObject = null;
            Assert.DoesNotThrow(() => reflectedObject = new ReflectedObject(o));
            Assert.That(reflectedObject, Is.Not.Null);
            Assert.That(reflectedObject.InnerObjectsDescriptors.Count(), Is.EqualTo(0));
        }

        [TestCase]
        public void ReflectedTypeCreation_SimpleObjectWithTwoMembersOneNull_CorrectReflectedType()
        {
            var o = new TestObjectWith2AttributedInners(new InnerObject1(), null);

            var reflectedObject = new ReflectedObject(o);
            Assert.IsNotNull(reflectedObject);
            Assert.AreEqual(new IObjectDescriptor[] { new ReflectedObject(o.InnerObject1), new NullReflectedObject() }, reflectedObject.InnerObjectsDescriptors.ToArray());
        }
    }
}
