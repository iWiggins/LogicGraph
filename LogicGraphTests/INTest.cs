using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGraphTests
{
    [TestClass]
    public class INTest
    {
        [TestMethod]
        public void IN_accepts_no_input()
        {
            Gates.IN input = new();

            Gates.AND gate = new();

            Assert.IsFalse(gate.Connect(input));
        }

        [TestMethod]
        public void IN_connects()
        {
            Gates.IN input = new();
            Gates.AND gate = new();

            Assert.IsTrue(input.Connect(gate));
        }

        [TestMethod]
        public void IN_does_not_reconnect()
        {
            Gates.IN input = new();
            Gates.AND gate = new();

            input.Connect(gate);
            Assert.IsFalse(input.Connect(gate));
        }

        [TestMethod]
        public void IN_connects_multiple_outputs()
        {
            Gates.IN input = new();

            Gates.AND gate1, gate2;
            gate1 = new();
            gate2 = new();

            Assert.IsTrue(input.Connect(gate1));
            Assert.IsTrue(input.Connect(gate2));
        }

        [TestMethod]
        public void IN_disconnects()
        {
            Gates.IN input = new();
            Gates.AND gate = new();

            input.Connect(gate);
            Assert.IsTrue(input.Disconnect(gate));
            Assert.IsTrue(input.Connect(gate));
        }

        [TestMethod]
        public void IN_full_disconnects()
        {
            Gates.IN input = new();

            Gates.AND gate1, gate2;
            gate1 = new();
            gate2 = new();

            input.Connect(gate1);
            input.Connect(gate2);

            input.Disconnect();

            Assert.IsTrue(input.Connect(gate1));
            Assert.IsTrue(input.Connect(gate2));
        }

        [TestMethod]
        public void IN_null()
        {
            Gates.IN input = new();

            input.SetValue(-1);

            Assert.AreEqual(-1, input.Value);
        }

        [TestMethod]
        public void IN_0()
        {
            Gates.IN input = new();

            input.SetValue(0);

            Assert.AreEqual(0, input.Value);
        }

        [TestMethod]
        public void IN_1()
        {
            Gates.IN input = new();

            input.SetValue(1);

            Assert.AreEqual(1, input.Value);
        }

        [TestMethod]
        public void IN_changes_value()
        {
            Gates.IN input = new();

            input.SetValue(0);
            input.SetValue(1);
            Assert.AreEqual(1, input.Value);
        }
    }
}
