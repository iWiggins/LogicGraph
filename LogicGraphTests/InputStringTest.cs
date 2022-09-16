using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGraphTests
{
    [TestClass]
    public class InputStringTest
    {
        [TestMethod]
        public void FeedInputStringReturnsCorrectValues()
        {
            GateGraph graph = new(3, 1);

            var gate = graph.CreateGate(Gates.Gate.XOR);
            graph.ConnectInputToGate(0, gate);
            graph.ConnectInputToGate(1, gate);
            graph.ConnectInputToGate(2, gate);
            graph.ConnectGateToOutput(0, gate);

            int[] correctResults = new int[]
            {
                0, // 000 => 0
                1, // 001 => 1
                1, // 010 => 1
                0, // 011 => 0
                1, // 100 => 1
                0, // 101 => 0
                0, // 110 => 0
                0, // 111 => 0
            };

            for(int i = 000; i <= 0b111; ++i)
            {
                graph.FeedInputString(i);
                int expected = correctResults[i];
                int actual = graph.GetOutputValue(0);
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
