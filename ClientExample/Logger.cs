using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

[assembly: XmlConfigurator]
namespace ClientExample
{
    internal class Logger
    {
       

        public Logger()
        {
            //BasicConfigurator.Configure();
             // Define a static logger variable so that it references the
    // Logger instance named "MyApp".
    
    ILog log = LogManager.GetLogger("SomeLog");
            log.Info("Entering application.");
    
            log.Info("Exiting application.");
        }
    }
}
