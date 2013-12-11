// ReSharper disable InconsistentNaming
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using VisualLog.Attributes;
using VisualLog.GraphCreators.AttributeBased;

namespace VisualLog.Tests
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
