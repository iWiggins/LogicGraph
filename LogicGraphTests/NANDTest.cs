using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGraphTests
{
    [TestClass]
    public class NANDTest
    {
        [TestMethod]
        public void NAND_0() =>
            Assert.AreEqual(1,
                GateBaseTest.TestLogicGate(Gates.Gate.NAND, 0));

        [TestMethod]
        public void NAND_1() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.NAND, 1));

        [TestMethod]
        public void NAND_00() =>
            Assert.AreEqual(1,
                GateBaseTest.TestLogicGate(Gates.Gate.NAND, 0, 0));

        [TestMethod]
        public void NAND_01() =>
            Assert.AreEqual(1,
                GateBaseTest.TestLogicGate(Gates.Gate.NAND, 0, 1));

        [TestMethod]
        public void NAND_10() =>
            Assert.AreEqual(1,
                GateBaseTest.TestLogicGate(Gates.Gate.NAND, 1, 0));

        [TestMethod]
        public void NAND_11() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.NAND, 1, 1));

        [TestMethod]
        public void NAND_000() =>
            Assert.AreEqual(1,
                GateBaseTest.TestLogicGate(Gates.Gate.NAND, 0, 0, 0));

        [TestMethod]
        public void NAND_001() =>
            Assert.AreEqual(1,
                GateBaseTest.TestLogicGate(Gates.Gate.NAND, 0, 0, 1));

        [TestMethod]
        public void NAND_010() =>
            Assert.AreEqual(1,
                GateBaseTest.TestLogicGate(Gates.Gate.NAND, 0, 1, 0));

        [TestMethod]
        public void NAND_011() =>
            Assert.AreEqual(1,
                GateBaseTest.TestLogicGate(Gates.Gate.NAND, 0, 1, 1));

        [TestMethod]
        public void NAND_100() =>
            Assert.AreEqual(1,
                GateBaseTest.TestLogicGate(Gates.Gate.NAND, 1, 0, 0));

        [TestMethod]
        public void NAND_101() =>
            Assert.AreEqual(1,
                GateBaseTest.TestLogicGate(Gates.Gate.NAND, 1, 0, 1));

        [TestMethod]
        public void NAND_110() =>
            Assert.AreEqual(1,
                GateBaseTest.TestLogicGate(Gates.Gate.NAND, 1, 1, 0));

        [TestMethod]
        public void NAND_111() =>
            Assert.AreEqual(0,
                GateBaseTest.TestLogicGate(Gates.Gate.NAND, 1, 1, 1));
    }
}
