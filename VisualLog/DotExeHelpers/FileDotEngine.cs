using System;
using System.Diagnostics;
using System.IO;
using QuickGraph.Graphviz;
using QuickGraph.Graphviz.Dot;

namespace VisualLog.DotExeHelpers
{
    internal class FileDotEngine : IDotEngine
    {
        #region consts

        private const string DotExeFileName = "Resources//dot.exe";

        #endregion

        #region IDotEngine implementation

        public string Run(GraphvizImageType imageType, string dot, string outputFileName)
        {
            using (var process = new Process())
            {
                var graphFileContext = string.Format("{0}.{1}", outputFileName, "txt");

                using (var graphFile = new StreamWriter(graphFileContext))
                {
                    graphFile.Write(dot);
                    graphFile.Flush();
                }

                string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                // ReSharper disable AssignNullToNotNullAttribute
                process.StartInfo.FileName = Path.Combine(currentDirectory, DotExeFileName);
                process.StartInfo.WorkingDirectory = currentDirectory;

                // ReSharper restore AssignNullToNotNullAttribute

                process.StartInfo.Arguments = string.Format(@"-T{0} -o""{1}"" ""{2}""", imageType.ToString().ToLower(), outputFileName, graphFileContext);

                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;

                process.StartInfo.UseShellExecute = false;
                process.Start();

                return process.StandardOutput.ReadToEnd() + process.StandardError.ReadToEnd();
            }
        }

        #endregion
    }
}