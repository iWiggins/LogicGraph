using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGraphTests
{
    [TestClass]
    public class XORTest
    {
        [TestMethod]
        public void XOR_0() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.XOR, 0));

        [TestMethod]
        public void XOR_1() =>
            Assert.AreEqual(1,
                GateBaseTest.TestLogicGate(Gates.Gate.XOR, 1));

        [TestMethod]
        public void XOR_00() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.XOR, 0, 0));

        [TestMethod]
        public void XOR_01() =>
            Assert.AreEqual(1,
                GateBaseTest.TestLogicGate(Gates.Gate.XOR, 0, 1));

        [TestMethod]
        public void XOR_10() =>
            Assert.AreEqual(1,
                GateBaseTest.TestLogicGate(Gates.Gate.XOR, 1, 0));

        [TestMethod]
        public void XOR_11() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.XOR, 1, 1));

        [TestMethod]
        public void XOR_000() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.XOR, 0, 0, 0));

        [TestMethod]
        public void XOR_001() =>
            Assert.AreEqual(1,
                GateBaseTest.TestLogicGate(Gates.Gate.XOR, 0, 0, 1));

        [TestMethod]
        public void XOR_010() =>
            Assert.AreEqual(1,
                GateBaseTest.TestLogicGate(Gates.Gate.XOR, 0, 1, 0));

        [TestMethod]
        public void XOR_011() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.XOR, 0, 1, 1));

        [TestMethod]
        public void XOR_100() =>
            Assert.AreEqual(1,
                GateBaseTest.TestLogicGate(Gates.Gate.XOR, 1, 0, 0));

        [TestMethod]
        public void XOR_101() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.XOR, 1, 0, 1));

        [TestMethod]
        public void XOR_110() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.XOR, 1, 1, 0));

        [TestMethod]
        public void XOR_111() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.XOR, 1, 1, 1));
    }
}
