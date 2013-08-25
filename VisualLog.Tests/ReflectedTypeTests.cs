// ReSharper disable InconsistentNaming
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualLog.Attributes;
using VisualLog.GraphCreators.AttributeBased;

namespace VisualLog.Tests
{
    public class SomeObject
    {
        [VisualLog]
        private InnerObject1 _innerObject1;
        [VisualLog]
        private InnerObject2 _innerObject2;

        public SomeObject(InnerObject1 innerObject1, InnerObject2 innerObject2)
        {
            _innerObject2 = innerObject2;
            _innerObject1 = innerObject1;
        }

        [VisualLogDescription]
        public string Name ;//{ get; set; }
    }
     
    public class InnerObject1
    {
        [VisualLogDescription]
        public string SomeDescription { get; set; }
    }

    public class InnerObject2
    {
        [VisualLogDescription]
        public string OtherDescription { get; set; }
        
    }

    class ReflectedTypeTests
    {

        public void ReflectedTypeCreation_SimpleObjectWithTwoMembers_CorrectReflectedType()
        {
            //object obj = new SomeObject();
            //var rt = new ReflectedObject(obj);
        }
    }
}
