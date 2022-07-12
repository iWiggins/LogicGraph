using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGraphTests
{
    internal static class TestUtilities
    {
        public static void FeedInput(this GateGraph graph, params int[] input) =>
            graph.FeedInputs(input);
    }
}
