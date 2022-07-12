using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGraphTests
{
    [TestClass]
    public class ORTest
    {
        [TestMethod]
        public void OR_0() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.OR, 0));

        [TestMethod]
        public void OR_1() =>
            Assert.AreEqual(1,
                GateBaseTest.TestLogicGate(Gates.Gate.OR, 1));

        [TestMethod]
        public void OR_00() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.OR, 0, 0));

        [TestMethod]
        public void OR_01() =>
            Assert.AreEqual(1,
                GateBaseTest.TestLogicGate(Gates.Gate.OR, 0, 1));

        [TestMethod]
        public void OR_10() =>
            Assert.AreEqual(1,
                GateBaseTest.TestLogicGate(Gates.Gate.OR, 1, 0));

        [TestMethod]
        public void OR_11() =>
            Assert.AreEqual(1,
                GateBaseTest.TestLogicGate(Gates.Gate.OR, 1, 1));

        [TestMethod]
        public void OR_000() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.OR, 0, 0, 0));

        [TestMethod]
        public void OR_001() =>
            Assert.AreEqual(1,
                GateBaseTest.TestLogicGate(Gates.Gate.OR, 0, 0, 1));

        [TestMethod]
        public void OR_010() =>
            Assert.AreEqual(1,
                GateBaseTest.TestLogicGate(Gates.Gate.OR, 0, 1, 0));

        [TestMethod]
        public void OR_011() =>
            Assert.AreEqual(1,
                GateBaseTest.TestLogicGate(Gates.Gate.OR, 0, 1, 1));

        [TestMethod]
        public void OR_100() =>
            Assert.AreEqual(1,
                GateBaseTest.TestLogicGate(Gates.Gate.OR, 1, 0, 0));

        [TestMethod]
        public void OR_101() =>
            Assert.AreEqual(1,
                GateBaseTest.TestLogicGate(Gates.Gate.OR, 1, 0, 1));

        [TestMethod]
        public void OR_110() =>
            Assert.AreEqual(1,
                GateBaseTest.TestLogicGate(Gates.Gate.OR, 1, 1, 0));

        [TestMethod]
        public void OR_111() =>
            Assert.AreEqual(1,
                GateBaseTest.TestLogicGate(Gates.Gate.OR, 1, 1, 1));
    }
}
