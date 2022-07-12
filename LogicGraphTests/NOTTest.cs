using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGraphTests
{
    [TestClass]
    public class NOTTest
    {
        [TestMethod]
        public void NOT_accepts_only_one_input()
        {
            Gates.IN in1, in2;
            in1 = new();
            in2 = new();

            Gates.NOT not = new();

            in1.Connect(not);

            Assert.IsFalse(in2.Connect(not));
        }

        [TestMethod]
        public void NOT_0() =>
            Assert.AreEqual(1,
                GateBaseTest.TestLogicGate(Gates.Gate.NOT, 0));

        [TestMethod]
        public void NOT_1() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.NOT, 1));
    }
}
