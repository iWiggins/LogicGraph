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
    }
}
