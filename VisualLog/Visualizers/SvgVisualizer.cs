using System;
using System.IO;
using QuickGraph;
using QuickGraph.Graphviz;
using QuickGraph.Graphviz.Dot;
using VisualLog.DotExeHelpers;
using VisualLog.GraphCreators.AttributeBased;

namespace VisualLog.Visualizers
{
    public class SvgObjectVisualizer : IObjectVisualizer
    {
        private readonly object _objectToVisualize;
        private readonly AttributeBasedGraphCreator _graphCreator;

        #region ctor

        public SvgObjectVisualizer(object objectToVisualize) : this(objectToVisualize, new AttributeBasedGraphCreator())
        {}

        internal SvgObjectVisualizer(object objectToVisualize, AttributeBasedGraphCreator graphCreator)
        {
            _objectToVisualize = objectToVisualize;
            _graphCreator = graphCreator;
        }
        #endregion

        #region public

        private string SvgStringFromStringGraph(AdjacencyGraph<string, TaggedEdge<string, string>> stringGraph)
        {
            var outputFileName = CreateImageFile(stringGraph, GraphvizImageType.Svg, Path.GetTempFileName());

            using (var stream = new StreamReader(outputFileName))
            {
                return stream.ReadToEnd();
            }
        }

        #endregion

        #region private

        private string CreateImageFile(AdjacencyGraph<string, TaggedEdge<string, string>> stringGraph, GraphvizImageType imageType, string imageFileName)
        {
            var graphviz = new GraphvizAlgorithm<string, TaggedEdge<string, string>>(stringGraph) { ImageType = imageType };

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

        public string Visualize()
        {

            var graph = _graphCreator.Create(_objectToVisualize);
            return SvgStringFromStringGraph(graph);
        }
    }

    
}
