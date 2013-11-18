using System;
using System.IO;
using QuickGraph;
using QuickGraph.Graphviz;
using QuickGraph.Graphviz.Dot;
using VisualLog.DotExeHelpers;
using VisualLog.GraphCreators;

namespace VisualLog
{
    public class SvgObjectVisualizer : IObjectVisualizer
    {
        private readonly object _objectToVisualize;
        private readonly IGraphCreator _graphCreator;

        #region ctor

        public SvgObjectVisualizer(object objectToVisualize) : this(objectToVisualize, new AttributeBasedGraphCreator())
        {
            

        }

        internal SvgObjectVisualizer(object objectToVisualize, IGraphCreator graphCreator)
        {
            _objectToVisualize = objectToVisualize;
            _graphCreator = graphCreator;
        }
        #endregion

        #region public

        public string GetSvgStringFromArrowGraph(string graph)
        {
            var pairs = graph.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            var simpleStringGraph = new SimpleStringGraph();
            foreach (var pair in pairs)
            {
                var pairArray = pair.Split(new[] { "->" }, StringSplitOptions.None);
                simpleStringGraph.AddObject(pairArray[0]);
                simpleStringGraph.AddObject(pairArray[1]);
                simpleStringGraph.AddRelation(pairArray[0], pairArray[1]);
            }

            return SvgStringFromStringGraph(simpleStringGraph);
        }

        private string SvgStringFromStringGraph(IStringGraph stringGraph)
        {
            var outputFileName = CreateImageFile(stringGraph, GraphvizImageType.Svg, Path.GetTempFileName());

            using (var stream = new StreamReader(outputFileName))
            {
                return stream.ReadToEnd();
            }
        }

        #endregion

        #region private

        private string CreateImageFile(IStringGraph stringGraph, GraphvizImageType imageType, string imageFileName)
        {
            var graph = stringGraph.ToQuickGraph();
            var graphviz = new GraphvizAlgorithm<string, TaggedEdge<string, string>>(graph) { ImageType = imageType };

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
            e.VertexFormatter.Shape = GraphvizVertexShape.TripleOctagon;
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
