using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGraphTests
{
    [TestClass]
    public class NORTest
    {
        [TestMethod]
        void NOR_0() =>
            Assert.AreEqual(1,
                GateBaseTest.TestLogicGate(Gates.Gate.NOR, 0));

        [TestMethod]
        void NOR_1() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.NOR, 1));

        [TestMethod]
        void NOR_00() =>
            Assert.AreEqual(1,
                GateBaseTest.TestLogicGate(Gates.Gate.NOR, 0, 0));

        [TestMethod]
        void NOR_01() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.NOR, 0, 1));

        [TestMethod]
        void NOR_10() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.NOR, 1, 0));

        [TestMethod]
        void NOR_11() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.NOR, 1, 1));

        [TestMethod]
        void NOR_000() =>
            Assert.AreEqual(1,
                GateBaseTest.TestLogicGate(Gates.Gate.NOR, 0, 0, 0));

        [TestMethod]
        void NOR_001() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.NOR, 0, 0, 1));

        [TestMethod]
        void NOR_010() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.NOR, 0, 1, 0));

        [TestMethod]
        void NOR_011() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.NOR, 0, 1, 1));

        [TestMethod]
        void NOR_100() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.NOR, 1, 0, 0));

        [TestMethod]
        void NOR_101() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.NOR, 1, 0, 1));

        [TestMethod]
        void NOR_110() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.NOR, 1, 1, 0));

        [TestMethod]
        void NOR_111() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.NOR, 1, 1, 1));
    }
}
