using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicGraph;

namespace LogicGraphExample
{
    internal static class XorGateFromBasics
    {
        public static void RunExample()
        {
            Console.WriteLine("A X !B + !A X B = F");

            GateGraph graph = new(2, 1);

            void executeWithInputs(int a, int b)
            {
                graph.FeedInputs(a, b);
                int f = graph.GetOutputValue(0);
                Console.WriteLine("A={0} B={1} F={2}", a, b, f);
            }

            int andGate0 = graph.CreateGate(Gates.Gate.AND);
            int andGate1 = graph.CreateGate(Gates.Gate.AND);
            int orGate0 = graph.CreateGate(Gates.Gate.OR);
            int notGate0 = graph.CreateGate(Gates.Gate.NOT);
            int notGate1 = graph.CreateGate(Gates.Gate.NOT);

            // Create an inverter for each input.
            graph.ConnectInputToGate(0, notGate0);
            graph.ConnectInputToGate(1, notGate1);

            // Connect in0 and not1 to and0
            graph.ConnectInputToGate(0, andGate0);
            graph.ConnectGates(notGate1, andGate0);

            // Connect not0 and in1 to and1
            graph.ConnectInputToGate(1, andGate1);
            graph.ConnectGates(notGate0, andGate1);

            // Connect and0 and and1 to or0
            graph.ConnectGates(andGate0, orGate0);
            graph.ConnectGates(andGate1, orGate0);

            // Connect or0 to the output.
            graph.ConnectGateToOutput(0, orGate0);

            // Run the graph with all possible inputs.
            executeWithInputs(0, 0);
            executeWithInputs(0, 1);
            executeWithInputs(1, 0);
            executeWithInputs(1, 1);
        }
    }
}
