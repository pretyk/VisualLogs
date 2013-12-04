using System;
using System.IO;
using QuickGraph;
using QuickGraph.Graphviz;
using QuickGraph.Graphviz.Dot;
using VisualLog.DotExeHelpers;
using VisualLog.GraphCreators.AttributeBased;
using VisualLog.Graphs;

namespace VisualLog.Visualizers
{
    internal class SvgVisualizer : VisualizerBase<AttributeBasedGraphCreator>
    {
        #region private

        private string CreateImageFile(object o, GraphvizImageType imageType, string imageFileName)
        {
           var graph = GraphCreator.Create<StringGraph>(o);
           var graphviz = new GraphvizAlgorithm<string, TaggedEdge<string, string>>(graph.ToQuickGraph()) { ImageType = imageType };

            graphviz.FormatVertex += FormatVertexHandler;

            // ReSharper disable AssignNullToNotNullAttribute
            string outputfile = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), imageFileName);
            // ReSharper restore AssignNullToNotNullAttribute

            graphviz.Generate(new FileDotEngine(), outputfile);
            return outputfile;
        }


        #endregion

        #region events

        private static void FormatVertexHandler(object sender, FormatVertexEventArgs<string> e)
        {
            e.VertexFormatter.Label = e.Vertex;
            e.VertexFormatter.Shape = GraphvizVertexShape.MSquare;
            e.VertexFormatter.Style = GraphvizVertexStyle.Rounded;
        }

        #endregion

        public override string Visualize(object o)
        {
            var outputFileName = CreateImageFile(o, GraphvizImageType.Svg, Path.GetTempFileName());

            using (var stream = new StreamReader(outputFileName))
            {
                return stream.ReadToEnd();
            }

        }
    }

    
}
