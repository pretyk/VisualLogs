using VisualLog;
using VisualLog.Attributes;

namespace ClientExample
{
    class Program
    {
        static void Main(string[] args)
        {
           // Console.WriteLine(SvgObjectVisualizer.GetSvgStringFromArrowGraph("action1->action2|action1->action3|action3->action2|action1->action1"));
            var someobj = new SomeObject(new InnerObject1 {SomeDescription = "some1"},
                                         new InnerObject2 {OtherDescription = "some2"});

            someobj.Name = "hello";
            var visualizer = new SvgObjectVisualizer(someobj);
            visualizer.Visualize();
        }
    }


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
}
