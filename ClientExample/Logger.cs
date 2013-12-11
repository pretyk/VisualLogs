using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualLog;
using VisualLog.Factories;
using VisualLog.Visualizers;
using log4net;
using log4net.Config;
using log4net.Core;

[assembly: XmlConfigurator]
namespace ClientExample
{
    internal static class Logger
    {
        private static ILog _log = LogManager.GetLogger("DemoLog");

        public static void Info(string message)
        {
            _log.Info(message);
        }

        public static void Warn(string message)
        {
            _log.Warn(message);
        }

        public static void Error(string message)
        {
            _log.Error(message);
        }

        public static void Debug(string message)
        {
            _log.Debug(message);
        }

        public static void VisualizeObject(object o)
        {
            if (_log.Logger.IsEnabledFor(Level.Verbose))
            {
                var visualizer = Visualizer.GetSvg();

                var objVisualization = visualizer.Visualize(o);

                _log.Debug(objVisualization);
            }
        }
    }
}
