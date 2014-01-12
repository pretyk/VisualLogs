using VisualLog.Attributes;

namespace VisualLog.Tests
{
    public class TestObjectWithNoAttributedInners
    {
        public DummyObject DummyObject { get; set; }
    }

    public class DummyObject
    {
        
    }

    public class TestObjectWith2AttributedInners
    {
        [VisualLog]
        private InnerObject1 _innerObject1;
        [VisualLog]
        private InnerObject2 _innerObject2;

        private InnerObject1 _innerObject3NoAttr;

        public TestObjectWith2AttributedInners(InnerObject1 innerObject1, InnerObject2 innerObject2)
        {
            InnerObject2 = innerObject2;
            InnerObject1 = innerObject1;
        }

        [VisualLogDescription]
        public string Name;//{ get; set; }

        public InnerObject1 InnerObject1
        {
            get { return _innerObject1; }
            set { _innerObject1 = value; }
        }

        public InnerObject2 InnerObject2
        {
            get { return _innerObject2; }
            set { _innerObject2 = value; }
        }

        public InnerObject1 InnerObject3NoAttr
        {
            get { return _innerObject3NoAttr; }
            set { _innerObject3NoAttr = value; }
        }
    }

    public class InnerObject1
    {
        public InnerObject1()
        {
            SomeDescription = "innerobject1";
        }
        [VisualLogDescription]
        public string SomeDescription { get; set; }
    }

    public class InnerObject2
    {
        public InnerObject2()
        {
            OtherDescription = "innerobject2";
        }
        [VisualLogDescription]
        public string OtherDescription { get; set; }

    }
}
