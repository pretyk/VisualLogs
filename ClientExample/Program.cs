using System.IO;
using VisualLog;
using VisualLog.Attributes;

namespace ClientExample
{
    class Program
    {
        private static void Main(string[] args)
        {
            
            Logger.Info("Some info log");
            var someobj = new SomeObject(new InnerObject1 {SomeDescription = "some1"},
                                         new InnerObject2 {OtherDescription = "some2"});
            Logger.Debug("Object Created");
            someobj.Name = "hello";



            Logger.VisualizeObject(someobj);

            Logger.Debug("Exiting.....");

          //  StreamWriter sw = new StreamWriter("test.html");
           // sw.Write(res);
            //sw.Flush();
            //sw.Close();
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
