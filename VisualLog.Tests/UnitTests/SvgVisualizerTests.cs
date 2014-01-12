using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using VisualLog.Factories;
using VisualLog.GraphCreators;
using VisualLog.Graphs;
using VisualLog.Visualizers;

namespace VisualLog.Tests.UnitTests
{
    [TestFixture]
    class SvgVisualizerTests
    {
        private Mock<IFactoryProvider> _factoryProvider;

        [TestFixtureSetUp]
        public void Init()
        {
            _factoryProvider = new Mock<IFactoryProvider>();
            var graphCreator = new Mock<IGraphCreator>();
            var stringGraph = new Mock<IStringGraph>();
            //graphCreator.Setup(x => x.Create<StringGraph>(It.IsAny<object>())).Returns(new Mock<StringGraph>().Object);

            _factoryProvider.Setup(x => x.CreateGraphCreator()).Returns(graphCreator.Object);
            _factoryProvider.Setup(x => x.CreateStringGraph()).Returns(stringGraph.Object);
        }
        [Test]
        public void TestOne()
        {
            var visualizer = new SvgVisualizer(_factoryProvider.Object);
            var s = visualizer.Visualize(new object());
        }
    }
}
