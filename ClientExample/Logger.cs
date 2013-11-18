using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace ClientExample
{
    internal class Logger
    {
        private static readonly ILog _log = LogManager.GetLogger("SomeLog");

        public Logger()
        {
            BasicConfigurator.Configure();

             // Define a static logger variable so that it references the
    // Logger instance named "MyApp".
    

            _log.Info("Entering application.");
    
            _log.Info("Exiting application.");
        }
    }
}
