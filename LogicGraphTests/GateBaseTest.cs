namespace LogicGraphTests
{
    [TestClass]
    public class GateBaseTest
    {
        [TestMethod]
        public void Create_gate_creates_correct_type()
        {
            var andGate = Gates.CreateGate(Gates.Gate.AND);
            Assert.IsInstanceOfType(andGate, typeof(Gates.AND));
            var orGate = Gates.CreateGate(Gates.Gate.OR);
            Assert.IsInstanceOfType(orGate, typeof(Gates.OR));
            var notGate = Gates.CreateGate(Gates.Gate.NOT);
            Assert.IsInstanceOfType(notGate, typeof(Gates.NOT));
            var nandGate = Gates.CreateGate(Gates.Gate.NAND);
            Assert.IsInstanceOfType( nandGate, typeof(Gates.NAND));
            var norGate = Gates.CreateGate(Gates.Gate.NOR);
            Assert.IsInstanceOfType(norGate, typeof(Gates.NOR));
            var xorGate = Gates.CreateGate(Gates.Gate.XOR);
            Assert.IsInstanceOfType(xorGate, typeof(Gates.XOR));
            var inGate = Gates.CreateGate(Gates.Gate.IN);
            Assert.IsInstanceOfType(inGate, typeof(Gates.IN));
            var outGate = Gates.CreateGate(Gates.Gate.OUT);

            Assert.ThrowsException<ArgumentException>(() =>
                Gates.CreateGate((Gates.Gate)100));
        }

        [TestMethod]
        public void Gates_connect()
        {
            foreach (Gates.Gate firstGateType in Enum.GetValues(typeof(Gates.Gate)))
            {
                // IN and OUT are special cases, not tested here.
                if (firstGateType == Gates.Gate.IN) continue;
                if (firstGateType == Gates.Gate.OUT) continue;

                foreach (Gates.Gate secondGateType in Enum.GetValues(typeof(Gates.Gate)))
                {
                    // IN and OUT are special cases, not tested here.
                    if (secondGateType == Gates.Gate.IN) continue;
                    if (secondGateType == Gates.Gate.OUT) continue;

                    var firstGate = Gates.CreateGate(firstGateType);
                    var secondGate = Gates.CreateGate(secondGateType);

                    Assert.IsTrue(firstGate.Connect(secondGate));
                }
            }
        }

        [TestMethod]
        public void Gates_do_not_self_connect()
        {
            foreach (Gates.Gate gateType in Enum.GetValues(typeof(Gates.Gate)))
            {
                var gate = Gates.CreateGate(gateType);

                Assert.IsFalse(gate.Connect(gate));
            }
        }

        [TestMethod]
        public void Gates_do_not_reconnect()
        {
            foreach (Gates.Gate firstGateType in Enum.GetValues(typeof(Gates.Gate)))
            {
                // IN and OUT are special cases, not tested here.
                if (firstGateType == Gates.Gate.IN) continue;
                if (firstGateType == Gates.Gate.OUT) continue;

                foreach (Gates.Gate secondGateType in Enum.GetValues(typeof(Gates.Gate)))
                {
                    // IN and OUT are special cases, not tested here.
                    if (secondGateType == Gates.Gate.IN) continue;
                    if (secondGateType == Gates.Gate.OUT) continue;

                    var firstGate = Gates.CreateGate(firstGateType);
                    var secondGate = Gates.CreateGate(secondGateType);

                    firstGate.Connect(secondGate);
                    Assert.IsFalse(firstGate.Connect(secondGate));
                }
            }
        }

        [TestMethod]
        public void Gates_do_not_recurse()
        {
            foreach (Gates.Gate firstGateType in Enum.GetValues(typeof(Gates.Gate)))
            {
                // IN and OUT are special cases, not tested here.
                if (firstGateType == Gates.Gate.IN) continue;
                if (firstGateType == Gates.Gate.OUT) continue;

                foreach (Gates.Gate secondGateType in Enum.GetValues(typeof(Gates.Gate)))
                {
                    // IN and OUT are special cases, not tested here.
                    if (secondGateType == Gates.Gate.IN) continue;
                    if (secondGateType == Gates.Gate.OUT) continue;

                    var firstGate = Gates.CreateGate(firstGateType);
                    var secondGate = Gates.CreateGate(secondGateType);

                    firstGate.Connect(secondGate);
                    Assert.IsFalse(secondGate.Connect(firstGate));
                }
            }
        }

        [TestMethod]
        public void Gates_do_not_deep_recurse()
        {
            foreach (Gates.Gate firstGateType in Enum.GetValues(typeof(Gates.Gate)))
            {
                // IN and OUT are special cases, not tested here.
                if (firstGateType == Gates.Gate.IN) continue;
                if (firstGateType == Gates.Gate.OUT) continue;

                foreach (Gates.Gate secondGateType in Enum.GetValues(typeof(Gates.Gate)))
                {
                    // IN and OUT are special cases, not tested here.
                    if (secondGateType == Gates.Gate.IN) continue;
                    if (secondGateType == Gates.Gate.OUT) continue;

                    foreach (Gates.Gate thirdGateType in Enum.GetValues(typeof(Gates.Gate)))
                    {
                        // IN and OUT are special cases, not tested here.
                        if (thirdGateType == Gates.Gate.IN) continue;
                        if (thirdGateType == Gates.Gate.OUT) continue;

                        var firstGate = Gates.CreateGate(firstGateType);
                        var secondGate = Gates.CreateGate(secondGateType);
                        var thirdGate = Gates.CreateGate(thirdGateType);

                        firstGate.Connect(secondGate);
                        secondGate.Connect(thirdGate);
                        Assert.IsFalse(thirdGate.Connect(firstGate));
                    }
                }
            }
        }

        [TestMethod]
        public void Parents_disconnect_children()
        {
            foreach (Gates.Gate firstGateType in Enum.GetValues(typeof(Gates.Gate)))
            {
                // IN and OUT are special cases, not tested here.
                if (firstGateType == Gates.Gate.IN) continue;
                if (firstGateType == Gates.Gate.OUT) continue;

                foreach (Gates.Gate secondGateType in Enum.GetValues(typeof(Gates.Gate)))
                {
                    // IN and OUT are special cases, not tested here.
                    if (secondGateType == Gates.Gate.IN) continue;
                    if (secondGateType == Gates.Gate.OUT) continue;

                    var firstGate = Gates.CreateGate(firstGateType);
                    var secondGate = Gates.CreateGate(secondGateType);

                    firstGate.Connect(secondGate);

                    Assert.IsTrue(firstGate.Disconnect(secondGate));
                }
            }
        }

        [TestMethod]
        public void Children_disconnect_parents()
        {
            foreach (Gates.Gate firstGateType in Enum.GetValues(typeof(Gates.Gate)))
            {
                // IN and OUT are special cases, not tested here.
                if (firstGateType == Gates.Gate.IN) continue;
                if (firstGateType == Gates.Gate.OUT) continue;

                foreach (Gates.Gate secondGateType in Enum.GetValues(typeof(Gates.Gate)))
                {
                    // IN and OUT are special cases, not tested here.
                    if (secondGateType == Gates.Gate.IN) continue;
                    if (secondGateType == Gates.Gate.OUT) continue;

                    var firstGate = Gates.CreateGate(firstGateType);
                    var secondGate = Gates.CreateGate(secondGateType);

                    firstGate.Connect(secondGate);

                    Assert.IsTrue(secondGate.Disconnect(firstGate));
                }
            }
        }

        [TestMethod]
        public void Gates_do_not_self_disconnect()
        {
            foreach (Gates.Gate gateType in Enum.GetValues(typeof(Gates.Gate)))
            {
                // IN and OUT are special cases, not tested here.
                if (gateType == Gates.Gate.IN) continue;
                if (gateType == Gates.Gate.OUT) continue;

                var gate = Gates.CreateGate(gateType);

                Assert.IsFalse(gate.Disconnect(gate));
            }
        }

        [TestMethod]
        public void Gates_do_not_redisconnect()
        {
            foreach (Gates.Gate firstGateType in Enum.GetValues(typeof(Gates.Gate)))
            {
                // IN and OUT are special cases, not tested here.
                if (firstGateType == Gates.Gate.IN) continue;
                if (firstGateType == Gates.Gate.OUT) continue;

                foreach (Gates.Gate secondGateType in Enum.GetValues(typeof(Gates.Gate)))
                {
                    // IN and OUT are special cases, not tested here.
                    if (secondGateType == Gates.Gate.IN) continue;
                    if (secondGateType == Gates.Gate.OUT) continue;

                    var firstGate = Gates.CreateGate(firstGateType);
                    var secondGate = Gates.CreateGate(secondGateType);

                    firstGate.Connect(secondGate);

                    firstGate.Disconnect(secondGate);

                    Assert.IsFalse(firstGate.Disconnect(secondGate));
                }
            }
        }

        [TestMethod]
        public void Disconnection_invalidates()
        {
            foreach (Gates.Gate gateType in Enum.GetValues(typeof(Gates.Gate)))
            {
                // IN and OUT are special cases.
                if (gateType == Gates.Gate.IN) continue;
                if (gateType == Gates.Gate.OUT) continue;

                var gate = Gates.CreateGate(gateType);

                Gates.IN input = new();

                Gates.OUT output = new();

                input.Connect(gate);
                gate.Connect(output);

                input.SetValue(1);

                gate.Disconnect();

                Assert.AreEqual(-1, output.Value);
            }
        }

        [TestMethod]
        public void Do_not_disconnect_unconnected_gate()
        {
            foreach (Gates.Gate firstGateType in Enum.GetValues(typeof(Gates.Gate)))
            {
                // IN and OUT are special cases, not tested here.
                if (firstGateType == Gates.Gate.IN) continue;
                if (firstGateType == Gates.Gate.OUT) continue;

                foreach (Gates.Gate secondGateType in Enum.GetValues(typeof(Gates.Gate)))
                {
                    // IN and OUT are special cases, not tested here.
                    if (secondGateType == Gates.Gate.IN) continue;
                    if (secondGateType == Gates.Gate.OUT) continue;

                    var firstGate = Gates.CreateGate(firstGateType);
                    var secondGate = Gates.CreateGate(secondGateType);

                    Assert.IsFalse(firstGate.Disconnect(secondGate));
                }
            }
        }

        [TestMethod]
        public void Gate_fully_disconnects()
        {
            foreach (Gates.Gate firstGateType in Enum.GetValues(typeof(Gates.Gate)))
            {
                // IN and OUT are special cases, not tested here.
                if (firstGateType == Gates.Gate.IN) continue;
                if (firstGateType == Gates.Gate.OUT) continue;

                foreach (Gates.Gate secondGateType in Enum.GetValues(typeof(Gates.Gate)))
                {
                    // IN and OUT are special cases, not tested here.
                    if (secondGateType == Gates.Gate.IN) continue;
                    if (secondGateType == Gates.Gate.OUT) continue;

                    foreach (Gates.Gate thirdGateType in Enum.GetValues(typeof(Gates.Gate)))
                    {
                        // IN and OUT are special cases, not tested here.
                        if (thirdGateType == Gates.Gate.IN) continue;
                        if (thirdGateType == Gates.Gate.OUT) continue;

                        var firstGate = Gates.CreateGate(firstGateType);
                        var secondGate = Gates.CreateGate(secondGateType);
                        var thirdGate = Gates.CreateGate(thirdGateType);

                        firstGate.Connect(secondGate);
                        secondGate.Connect(thirdGate);

                        secondGate.Disconnect();

                        Assert.IsTrue(firstGate.Connect(secondGate));
                        Assert.IsTrue(secondGate.Connect(thirdGate));
                    }
                }
            }
        }

        [TestMethod]
        public void Gate_connects_multiple_inputs()
        {
            foreach (Gates.Gate firstGateType in Enum.GetValues(typeof(Gates.Gate)))
            {
                // IN and OUT are special cases, not tested here.
                if (firstGateType == Gates.Gate.IN) continue;
                if (firstGateType == Gates.Gate.OUT) continue;

                foreach (Gates.Gate secondGateType in Enum.GetValues(typeof(Gates.Gate)))
                {
                    // IN and OUT are special cases, not tested here.
                    if (secondGateType == Gates.Gate.IN) continue;
                    if (secondGateType == Gates.Gate.OUT) continue;

                    foreach (Gates.Gate thirdGateType in Enum.GetValues(typeof(Gates.Gate)))
                    {
                        // IN, OUT, and NOT are special cases, not tested here.
                        if (thirdGateType == Gates.Gate.IN) continue;
                        if (thirdGateType == Gates.Gate.OUT) continue;
                        if (thirdGateType == Gates.Gate.NOT) continue;

                        var firstGate = Gates.CreateGate(firstGateType);
                        var secondGate = Gates.CreateGate(secondGateType);
                        var thirdGate = Gates.CreateGate(thirdGateType);

                        Assert.IsTrue(firstGate.Connect(thirdGate));
                        Assert.IsTrue(secondGate.Connect(thirdGate));
                    }
                }
            }
        }

        [TestMethod]
        public void Gate_fully_disconnects_multiple_inputs()
        {
            foreach (Gates.Gate firstGateType in Enum.GetValues(typeof(Gates.Gate)))
            {
                // IN and OUT are special cases, not tested here.
                if (firstGateType == Gates.Gate.IN) continue;
                if (firstGateType == Gates.Gate.OUT) continue;

                foreach (Gates.Gate secondGateType in Enum.GetValues(typeof(Gates.Gate)))
                {
                    // IN and OUT are special cases, not tested here.
                    if (secondGateType == Gates.Gate.IN) continue;
                    if (secondGateType == Gates.Gate.OUT) continue;

                    foreach (Gates.Gate thirdGateType in Enum.GetValues(typeof(Gates.Gate)))
                    {
                        // IN, OUT, and NOT are special cases, not tested here.
                        if (thirdGateType == Gates.Gate.IN) continue;
                        if (thirdGateType == Gates.Gate.OUT) continue;
                        if (thirdGateType == Gates.Gate.NOT) continue;

                        var firstGate = Gates.CreateGate(firstGateType);
                        var secondGate = Gates.CreateGate(secondGateType);
                        var thirdGate = Gates.CreateGate(thirdGateType);

                        thirdGate.Disconnect();

                        Assert.IsTrue(firstGate.Connect(thirdGate));
                        Assert.IsTrue(secondGate.Connect(thirdGate));
                    }
                }
            }
        }

        [TestMethod]
        public void Gate_connects_multiple_outputs()
        {
            foreach (Gates.Gate firstGateType in Enum.GetValues(typeof(Gates.Gate)))
            {
                // IN and OUT are special cases, not tested here.
                if (firstGateType == Gates.Gate.IN) continue;
                if (firstGateType == Gates.Gate.OUT) continue;

                foreach (Gates.Gate secondGateType in Enum.GetValues(typeof(Gates.Gate)))
                {
                    // IN and OUT are special cases, not tested here.
                    if (secondGateType == Gates.Gate.IN) continue;
                    if (secondGateType == Gates.Gate.OUT) continue;

                    foreach (Gates.Gate thirdGateType in Enum.GetValues(typeof(Gates.Gate)))
                    {
                        // IN and OUT are special cases, not tested here.
                        if (thirdGateType == Gates.Gate.IN) continue;
                        if (thirdGateType == Gates.Gate.OUT) continue;

                        var firstGate = Gates.CreateGate(firstGateType);
                        var secondGate = Gates.CreateGate(secondGateType);
                        var thirdGate = Gates.CreateGate(thirdGateType);

                        Assert.IsTrue(firstGate.Connect(secondGate));
                        Assert.IsTrue(firstGate.Connect(thirdGate));
                    }
                }
            }
        }

        [TestMethod]
        public void Gate_fully_disconnects_multiple_outputs()
        {
            foreach (Gates.Gate firstGateType in Enum.GetValues(typeof(Gates.Gate)))
            {
                // IN and OUT are special cases, not tested here.
                if (firstGateType == Gates.Gate.IN) continue;
                if (firstGateType == Gates.Gate.OUT) continue;

                foreach (Gates.Gate secondGateType in Enum.GetValues(typeof(Gates.Gate)))
                {
                    // IN and OUT are special cases, not tested here.
                    if (secondGateType == Gates.Gate.IN) continue;
                    if (secondGateType == Gates.Gate.OUT) continue;

                    foreach (Gates.Gate thirdGateType in Enum.GetValues(typeof(Gates.Gate)))
                    {
                        // IN, OUT, and NOT are special cases, not tested here.
                        if (thirdGateType == Gates.Gate.IN) continue;
                        if (thirdGateType == Gates.Gate.OUT) continue;

                        var firstGate = Gates.CreateGate(firstGateType);
                        var secondGate = Gates.CreateGate(secondGateType);
                        var thirdGate = Gates.CreateGate(thirdGateType);

                        firstGate.Connect(secondGate);
                        firstGate.Connect(thirdGate);

                        firstGate.Disconnect();

                        Assert.IsTrue(firstGate.Connect(secondGate));
                        Assert.IsTrue(firstGate.Connect(thirdGate));
                    }
                }
            }
        }

        [TestMethod]
        public void Gates_are_initially_empty()
        {
            foreach (Gates.Gate gateType in Enum.GetValues(typeof(Gates.Gate)))
            {
                var gate = Gates.CreateGate(gateType);
                Assert.AreEqual(-1, gate.Value);
            }
        }

        internal static int TestLogicGate(Gates.Gate gateType, params int[] inputs)
        {
            var gate = Gates.CreateGate(gateType);

            List<Gates.IN> inputList = new();

            foreach (var input in inputs)
            {
                Gates.IN inputGate = new();
                inputGate.Connect(gate);
                inputGate.SetValue(input);
                inputList.Add(inputGate);
            }

            return gate.Value;
        }
    }
}