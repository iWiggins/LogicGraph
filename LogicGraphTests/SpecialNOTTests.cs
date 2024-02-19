using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGraphTests
{
    [TestClass]
    public class SpecialNOTTests
    {
        [TestMethod]
        public void NotGraphProvidesCorrectOutput()
        {
            GateGraph graph = new(2, 1);

            var inputs = graph.GetInputKeys();

            int key = graph.CreateGate(Gates.Gate.NOT);

            graph.ConnectInputToGate(0, key);

            graph.ConnectGateToOutput(0, key);

            graph.FeedInputs(0, 0);
            Assert.AreEqual(1, graph.GetValue(key));
            Assert.AreEqual(1, graph.GetOutputValue(0));

            graph.FeedInputs(0, 1);
            Assert.AreEqual(1, graph.GetValue(key));
            Assert.AreEqual(1, graph.GetOutputValue(0));

            graph.FeedInputs(1, 0);
            Assert.AreEqual(0, graph.GetValue(key));
            Assert.AreEqual(0, graph.GetOutputValue(0));

            graph.FeedInputs(1, 1);
            Assert.AreEqual(0, graph.GetValue(key));
            Assert.AreEqual(0, graph.GetOutputValue(0));
        }
    }
}
