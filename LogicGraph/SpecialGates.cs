namespace LogicGraph
{
    /// <summary>
    /// This class contains the logic to implement gates within a LogicGraph.
    /// This file contains the gates too specialized to derive from LogicGate.
    /// Instead, they derive from GateBase.
    /// </summary>
    public static partial class Gates
    {
        /// <summary>
        /// A logic gate representing logical NOT of one input.
        /// </summary>
        /// <remarks>
        /// This is created from GateBase instead of LogicGate because an
        /// inverter (NOT gate) can take only a single input. This renders the
        /// logic of the inputs HashSet in GateBase incompatible.
        /// </remarks>
        internal class NOT : GateBase
        {
            public override bool Connect(GateBase gate)
            {
                if (this == gate) return false;
                if (outputs.Contains(gate)) return false;
                if (this.OnIsIndirectInput(gate)) return false;
                if (!gate.AsNode().AddInput(this)) return false;
                return outputs.Add(gate);
            }

            public override bool Disconnect(GateBase gate)
            {
                if (outputs.Contains(gate))
                {
                    gate.AsNode().RemoveInput(this);
                    outputs.Remove(gate);
                    return true;
                }
                else if (input == gate)
                {
                    gate.AsNode().RemoveOutput(this);
                    input = null;
                    return true;
                }
                else return false;
            }

            public override void Disconnect()
            {
                Invalidate();
                if (input != null) input.AsNode().RemoveOutput(this);
                foreach (var gate in outputs)
                {
                    gate.AsNode().RemoveInput(this);
                }
                input = null;
                outputs.Clear();
            }

            internal NOT()
            {
                input = null;
                outputs = new();
            }

            protected override bool OnAddInput(GateBase gate)
            {
                if (gate == this) return false;
                if (input != null) return false;
                if (input == gate) return false;
                if (OnIsIndirectOutput(gate)) return false;
                input = gate;
                Invalidate();
                return true;
            }

            protected override bool OnAddOutput(GateBase gate)
            {
                if (gate == this) return false;
                if (OnIsIndirectInput(gate)) return false;
                return outputs.Add(gate);
            }

            protected override bool OnIsDirectInput(GateBase gate)
            {
                return gate == input;
            }

            protected override bool OnIsDirectOutput(GateBase gate)
            {
                return outputs.Contains(gate);
            }

            protected override bool OnIsIndirectInput(GateBase gate)
            {
                if (input == null) return false;
                else if (OnIsDirectInput(gate)) return true;
                else return input.AsNode().IsDirectInput(gate);
            }

            protected override bool OnIsIndirectOutput(GateBase gate)
            {
                if (OnIsDirectOutput(gate)) return true;
                else
                {
                    foreach (var output in outputs)
                    {
                        if (output.AsNode().IsIndirectOutpt(gate)) return true;
                    }
                    return false;
                }
            }

            protected override bool OnRemoveInput(GateBase gate)
            {
                if (gate == this) return false;
                if (gate != input) return false;
                if (!gate.AsNode().RemoveOutput(this)) return false;
                else
                {
                    input = null;
                    return true;
                }

            }

            protected override bool OnRemoveOutput(GateBase gate)
            {
                if (gate == this) return false;
                if (!outputs.Contains(gate)) return false;
                else
                {
                    outputs.Remove(gate);
                    return true;
                }
            }

            protected override int CalculateValue()
            {
                if (input == null) return -1;
                else return input.Value switch
                {
                    0 => 1,
                    1 => 0,
                    -1 => -1,
                    _ => -2
                };
            }

            public override void Invalidate()
            {
                base.Invalidate();
                foreach(var output in outputs)
                {
                    output.Invalidate();
                }
            }

            private GateBase? input;
            private readonly HashSet<GateBase> outputs;
        }

        /// <summary>
        /// A special gate used to represent the input to a LogicGraph.
        /// </summary>
        /// <remarks>
        /// This gate is noteworthy in that it is the only gate with a Value
        /// that can (must) be manually set by the user.
        /// </remarks>
        internal class IN : GateBase
        {
            public void SetValue(int v)
            {
                _value = v;
                Invalidate();
            }

            public override bool Connect(GateBase gate)
            {
                if (gate == this) return false;
                if (!gate.AsNode().AddInput(this)) return false;
                return outputs.Add(gate);
            }

            public override bool Disconnect(GateBase gate)
            {
                if (!gate.AsNode().RemoveInput(this)) return false;
                return outputs.Remove(gate);
            }

            public override void Disconnect()
            {
                foreach (var gate in outputs)
                {
                    gate.AsNode().RemoveInput(this);
                }
                outputs.Clear();
            }

            public override void Invalidate()
            {
                base.Invalidate();
                foreach (var output in outputs)
                {
                    output.Invalidate();
                }
            }

            internal IN()
            {
                _value = -1;
                outputs = new();
            }

            protected override int CalculateValue() => _value;

            protected override bool OnAddInput(GateBase gate) =>
                false;

            protected override bool OnAddOutput(GateBase gate)
            {
                if (gate == this) return false;
                return outputs.Add(gate);
            }

            protected override bool OnIsDirectInput(GateBase gate) =>
                false;

            protected override bool OnIsDirectOutput(GateBase gate)
                => outputs.Contains(gate);

            protected override bool OnIsIndirectInput(GateBase gate)
                => false;

            protected override bool OnIsIndirectOutput(GateBase gate)
            {
                if (outputs.Contains(gate)) return true;

                else
                {
                    foreach (var output in outputs)
                    {
                        if (output.AsNode().IsIndirectOutpt(gate)) return true;
                    }
                    return false;
                }
            }

            protected override bool OnRemoveInput(GateBase gate) =>
                false;

            protected override bool OnRemoveOutput(GateBase gate) =>
                outputs.Remove(gate);

            private int _value;
            private readonly HashSet<GateBase> outputs;
        }

        /// <summary>
        /// A special gate used to represent the output from a LogicGraph.
        /// </summary>
        internal class OUT : GateBase
        {
            public override bool Connect(GateBase gate) => false;

            public override bool Disconnect(GateBase gate)
            {
                if (gate == input)
                {
                    if (!gate.AsNode().RemoveOutput(this)) return false;
                    else
                    {
                        input = null;
                        return true;
                    }
                }
                else return false;
            }

            public override void Disconnect()
            {
                input?.AsNode().RemoveOutput(this);
                input = null;
            }

            protected override int CalculateValue()
            {
                if (input == null) return -1;
                else return input.Value switch
                {
                    0 => 0,
                    1 => 1,
                    -1 => -1,
                    _ => -2
                };
            }

            protected override bool OnAddInput(GateBase gate)
            {
                if (gate == this) return false;
                else if (input != null) return false;
                else if (input == gate) return false;
                else
                {
                    input = gate;
                    Invalidate();
                    return true;
                }
            }

            protected override bool OnAddOutput(GateBase gate) =>
                false;

            protected override bool OnIsDirectInput(GateBase gate) =>
                input == gate;

            protected override bool OnIsDirectOutput(GateBase gate)
                => false;

            protected override bool OnIsIndirectInput(GateBase gate)
            {
                if (input == null) return false;
                else if (gate == input) return true;
                else return input.AsNode().IsIndirectInput(gate);
            }

            protected override bool OnIsIndirectOutput(GateBase gate)
                => false;

            protected override bool OnRemoveInput(GateBase gate)
            {
                if (input != gate) return false;
                else
                {
                    input = null;
                    return true;
                }
            }

            protected override bool OnRemoveOutput(GateBase gate) => false;

            private GateBase? input;
        }
    }
}
