using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGraphTests
{
    [TestClass]
    public class OUTTest
    {
        [TestMethod]
        public void OUT_accepts_only_one_input()
        {
            Gates.IN in1, in2;
            in1 = new();
            in2 = new();

            Gates.OUT output = new();

            in1.Connect(output);

            Assert.IsFalse(in2.Connect(output));
        }

        [TestMethod]
        public void OUT_null()
        {
            Gates.IN input = new();
            Gates.OUT output = new();

            input.Connect(output);

            input.SetValue(-1);

            Assert.AreEqual(-1, output.Value);
        }

        [TestMethod]
        public void OUT_0()
        {
            Gates.IN input = new();
            Gates.OUT output = new();

            input.Connect(output);

            input.SetValue(0);

            Assert.AreEqual(0, output.Value);
        }

        [TestMethod]
        public void OUT_1()
        {
            Gates.IN input = new();
            Gates.OUT output = new();

            input.Connect(output);

            input.SetValue(1);

            Assert.AreEqual(1, output.Value);
        }
    }
}
