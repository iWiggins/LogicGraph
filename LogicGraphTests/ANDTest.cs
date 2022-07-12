using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGraphTests
{
    [TestClass]
    public class ANDTest
    {
        [TestMethod]
        public void AND_0() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.AND, 0));
        [TestMethod]
        public void AND_1() =>
            Assert.AreEqual(1,
                GateBaseTest.TestLogicGate(Gates.Gate.AND, 1));

        [TestMethod]
        public void AND_00() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.AND, 0, 0));

        [TestMethod]
        public void AND_01() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.AND, 0, 1));

        [TestMethod]
        public void AND_10() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.AND, 1, 0));

        [TestMethod]
        public void AND_11() =>
            Assert.AreEqual(1,
                GateBaseTest.TestLogicGate(Gates.Gate.AND, 1, 1));

        [TestMethod]
        public void AND_000() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.AND, 0, 0, 0));

        [TestMethod]
        public void AND_001() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.AND, 0, 0, 1));

        [TestMethod]
        public void AND_010() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.AND, 0, 1, 0));

        [TestMethod]
        public void AND_011() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.AND, 0, 1, 1));

        [TestMethod]
        public void AND_100() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.AND, 1, 0, 0));

        [TestMethod]
        public void AND_101() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.AND, 1, 0, 1));

        [TestMethod]
        public void AND_110() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.AND, 1, 1, 0));

        [TestMethod]
        public void AND_111() =>
            Assert.AreEqual(1,
                GateBaseTest.TestLogicGate(Gates.Gate.AND, 1, 1, 1));
    }
}
