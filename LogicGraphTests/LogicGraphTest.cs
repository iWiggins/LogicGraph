using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGraphTests
{
    [TestClass]
    public class LogicGraphTest
    {
        [TestMethod]
        public void FeedInputsSetsInputValues()
        {
            GateGraph graph = new(3, 1);

            var inputs = graph.GetInputKeys();

            int[] feed = new int[] { 0, 0, 0 };

            graph.FeedInputs(feed);

            for(int i = 0; i < 3; ++i)
            {
                Assert.AreEqual(feed[i], graph.GetValue(inputs[i]));
            }

            feed = new int[] { 1, 1, 1 };

            graph.FeedInputs(feed);

            for (int i = 0; i < 3; ++i)
            {
                Assert.AreEqual(feed[i], graph.GetValue(inputs[i]));
            }
        }

        [TestMethod]
        public void GetValue_returns_value_of_gate()
        {
            GateGraph graph = new(1, 1);

            var inputs = graph.GetInputKeys();

            int key = graph.CreateGate(Gates.Gate.AND);

            graph.ConnectGates(inputs[0], key);

            Assert.AreEqual(-1, graph.GetValue(key));

            graph.FeedInputs(0);

            Assert.AreEqual(0, graph.GetValue(key));

            graph.FeedInputs(1);

            Assert.AreEqual(1, graph.GetValue(key));
        }

        [TestMethod]
        public void ConnectingGateToGraphCalculatesItsValue()
        {
            GateGraph graph = new(2, 1);

            var inputs = graph.GetInputKeys();

            graph.FeedInputs(0, 1);

            var andGate = graph.CreateGate(Gates.Gate.AND);

            graph.ConnectGates(inputs[1], andGate);

            var andValue = graph.GetValue(andGate);

            Assert.AreEqual(1, andValue);
        }

        [TestMethod]
        public void CanGetIndexedOutputValue()
        {
            GateGraph graph = new(2, 1);

            var inputs = graph.GetInputKeys();
            var outputs = graph.GetOutputKeys();

            graph.FeedInputs(1, 1);

            var notGate = graph.CreateGate(Gates.Gate.NOT);

            graph.ConnectGates(inputs[0], notGate);
            graph.ConnectGates(notGate, outputs[0]);

            var notValue = graph.GetValue(notGate);

            var outValueK = graph.GetValue(outputs[0]);

            var outValue = graph.GetOutputValue(0);

            Assert.AreEqual(notValue, outValueK);
        }
    }
}
