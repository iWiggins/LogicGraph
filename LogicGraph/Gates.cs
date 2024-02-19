namespace LogicGraph
{
    /// <summary>
    /// This class contains the logic to implement gates within a LogicGraph.
    /// This file contains the base logic underlying all gates.
    /// </summary>
    public static partial class Gates
    {
        /// <summary>
        /// An enum used to select a type of logic gate.
        /// </summary>
        public enum Gate
        {
            AND,
            OR,
            NOT,
            NAND,
            NOR,
            XOR,
            IN,
            OUT
        }

        /// <summary>
        /// An interface indicating the basic connectivity functions for gates,
        /// allowing gates to be treated as nodes in a graph.
        /// </summary>
        /// <remarks>
        /// This interface is separate from GateBase is so that GateBase's
        /// protected connection methods can be accessed publicly within the
        /// scope of the Gates class.
        /// </remarks>
        private interface IGateNode
        {
            /// <summary>
            /// Adds the argument as a child of this node.
            /// </summary>
            /// <param name="gate">The child node to add.</param>
            /// <returns>
            /// True: Success
            /// False: Failure
            /// </returns>
            bool AddInput(GateBase gate);

            /// <summary>
            /// Removes the argument as a child of this node.
            /// </summary>
            /// <param name="gate">The child node to remove.</param>
            /// <returns>
            /// True: Success
            /// False: Failure
            /// </returns>
            bool RemoveInput(GateBase gate);

            /// <summary>
            /// Adds the argument as a parent of this node.
            /// </summary>
            /// <param name="gate">The parent node to add.</param>
            /// <returns>
            /// True: Success
            /// False: Failure
            /// </returns>
            bool AddOutput(GateBase gate);

            /// <summary>
            /// Removes the argument as a parent of this node.
            /// </summary>
            /// <param name="gate">The parent node to remove.</param>
            /// <returns>
            /// True: Success
            /// False: Failure
            /// </returns>
            bool RemoveOutput(GateBase gate);

            /// <summary>
            /// Tests if the argument is a child of this node.
            /// </summary>
            /// <param name="gate">The node to test.</param>
            /// <returns>
            /// True: The argument is a child of this node.
            /// False: The argument is not a child of this node.
            /// </returns>
            bool IsDirectOutput(GateBase gate);

            /// <summary>
            /// Tests if the argument is a parent of this node.
            /// </summary>
            /// <param name="gate">The node to test.</param>
            /// <returns>
            /// True: The argument is a parent of this node.
            /// False: The argument is not a parent of this node.
            /// </returns>
            bool IsDirectInput(GateBase gate);

            /// <summary>
            /// Tests if the argument is an ancestor of this node.
            /// </summary>
            /// <param name="gate">The node to test.</param>
            /// <returns>
            /// True: The node is an ancestor of this node.
            /// True: The node is not an ancestor of this node.
            /// </returns>
            bool IsIndirectOutpt(GateBase gate);

            /// <summary>
            /// Tests if the argument is a descendant of this node.
            /// </summary>
            /// <param name="gate">The node to test.</param>
            /// <returns>
            /// True: The argument is a descendant of this node.
            /// False: The argument is not a descendant of this node.
            /// </returns>
            bool IsIndirectInput(GateBase gate);
        }

        /// <summary>
        /// A representation of a logic gate.
        /// </summary>
        internal abstract class GateBase : IGateNode
        {
            #region Public interface
            /// <summary>
            /// The value of the Gate.
            /// 0:  False
            /// 1:  True
            /// -1: No value
            /// </summary>
            public virtual int Value
            {
                get
                {
                    if (valid) return value;
                    else
                    {
                        value = CalculateValue();
                        valid = true;
                        return value;
                    }
                }
            }

            /// <summary>
            /// Connects this gate to another, with this gate being the parent
            /// (input), and the argument being the child (output).
            /// Invalidates the child.
            /// </summary>
            /// <remarks>
            /// The connection fails if:
            /// * The argument is this gate.
            /// * The argument is already connected to this gate.
            /// * The argument fails to connect.
            /// </remarks>
            /// <param name="gate">The gate to connect.</param>
            /// <returns>
            /// True: Success
            /// False: Failure
            /// </returns>
            public abstract bool Connect(GateBase gate);

            /// <summary>
            /// Disconnects this gate from another.
            /// Invalidates all children.
            /// </summary>
            /// <remarks>
            /// The method fails if the argument is not connected to this gate.
            /// The expected use of the method is a parent passing in one of
            /// its children as the argument. Overrides should take that
            /// intended use into consideration when optimizing whether to
            /// search the inputs or the outputs for the passed gate.
            /// </remarks>
            /// <param name="gate">The gate to disconnect.</param>
            /// <returns>
            /// True: Success
            /// False: Failure
            /// </returns>
            public abstract bool Disconnect(GateBase gate);

            /// <summary>
            /// Removes all parents from this Gate,
            /// removing this Gate as a child from each.
            /// Removes all children from this Gate,
            /// removing this Gate as an parent from each.
            /// Invalidates all children.
            /// </summary>
            public abstract void Disconnect();

            /// <summary>
            /// Invalidates the Gate's inner state,
            /// forcing recalculation of its value.
            /// Invalidates all children.
            /// </summary>
            public virtual void Invalidate()
            {
                valid = false;
            }
            #endregion

            #region IGateNode implementation
            bool IGateNode.AddInput(GateBase gate) => OnAddInput(gate);
            bool IGateNode.RemoveInput(GateBase gate) => OnRemoveInput(gate);
            bool IGateNode.AddOutput(GateBase gate) => OnAddOutput(gate);
            bool IGateNode.RemoveOutput(GateBase gate) => OnRemoveOutput(gate);
            bool IGateNode.IsDirectInput(GateBase gate) => OnIsDirectInput(gate);
            bool IGateNode.IsDirectOutput(GateBase gate) => OnIsDirectOutput(gate);
            bool IGateNode.IsIndirectInput(GateBase gate) => OnIsIndirectInput(gate);
            bool IGateNode.IsIndirectOutpt(GateBase gate) => OnIsIndirectOutput(gate);
            #endregion

            #region Protected members
            /// <summary>
            /// Used as the implementation of IGateNode.AddInput.
            /// </summary>
            protected abstract bool OnAddInput(GateBase gate);
            /// <summary>
            /// Used as the implementation of IGateNode.AddOutput.
            /// </summary>
            protected abstract bool OnAddOutput(GateBase gate);
            /// <summary>
            /// Used as the implementation of IGateNode.RemoveInput.
            /// </summary>
            protected abstract bool OnRemoveInput(GateBase gate);
            /// <summary>
            /// Used as the implementation of IGateNode.RemoveOutput.
            /// </summary>
            protected abstract bool OnRemoveOutput(GateBase gate);
            /// <summary>
            /// Used as the implementation of IGateNode.IsDirectInput.
            /// </summary>
            protected abstract bool OnIsDirectInput(GateBase gate);
            /// <summary>
            /// Used as the implementation of IGateNode.IsDirectOutput.
            /// </summary>
            protected abstract bool OnIsDirectOutput(GateBase gate);
            /// <summary>
            /// Used as the implementation of IGateNode.IsIndirectInput.
            /// </summary>
            protected abstract bool OnIsIndirectInput(GateBase gate);
            /// <summary>
            /// Used as the implementation of IGateNode.IsIndirectOutput.
            /// </summary>
            protected abstract bool OnIsIndirectOutput(GateBase gate);

            /// <summary>
            /// Calculates the value of this gate.
            /// </summary>
            /// <returns>
            /// 0:  False
            /// 1:  True
            /// -1: Nothing
            /// -2: Error
            /// </returns>
            protected abstract int CalculateValue();
            #endregion

            #region Private fields
            private bool valid;
            private int value;
            #endregion
        }

        /// <summary>
        /// Extension function to cast a GateBase to an IGateNode.
        /// Used for function chaining to IGateNode functions.
        /// </summary>
        /// <param name="gate">The calling GateBase.</param>
        /// <returns>The calling GateBase as an IGateNode.</returns>
        private static IGateNode AsNode(this GateBase gate) => gate as IGateNode;

        /// <summary>
        /// Creates a gate of the passed type.
        /// </summary>
        /// <param name="gate">The type of gate to return.</param>
        /// <returns>A gate of the passed type.</returns>
        /// <exception cref="ArgumentException">
        /// Throws if an invalid gate type is passed
        /// </exception>
        internal static GateBase CreateGate(Gate gate)
        {
            return gate switch
            {
                Gate.AND => new AND(),
                Gate.OR => new OR(),
                Gate.NOT => new NOT(),
                Gate.NAND => new NAND(),
                Gate.NOR => new NOR(),
                Gate.XOR => new XOR(),
                Gate.IN => new IN(),
                Gate.OUT => new OUT(),
                _ => throw new ArgumentException($"Invalid gate type {gate}")
            };
        }

        /// <summary>
        /// An abstract logic gate.
        /// Capable of connecting and networking with other gates.
        /// Derived classes need to implement value calculation,
        /// and may override connection mathods.
        /// </summary>
        internal abstract class LogicGate : GateBase
        {
            #region IGateNode implementation
            public override bool Connect(GateBase gate)
            {
                if (this == gate) return false;
                if (this.OnIsIndirectInput(gate)) return false;
                if (!(gate as IGateNode).AddInput(this)) return false;
                return this.OnAddOutput(gate);
            }

            public override bool Disconnect(GateBase gate)
            {
                Invalidate();

                if (outputs.Contains(gate))
                {
                    (gate as IGateNode).RemoveInput(this);
                    outputs.Remove(gate);
                    return true;
                }
                else if (inputs.Contains(gate))
                {
                    (gate as IGateNode).RemoveOutput(this);
                    inputs.Remove(gate);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public override void Disconnect()
            {
                Invalidate();

                foreach (var gate in inputs)
                {
                    (gate as IGateNode).RemoveOutput(this);
                }
                inputs.Clear();

                foreach (var gate in outputs)
                {
                    (gate as IGateNode).RemoveInput(this);
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
            #endregion

            protected LogicGate()
            {
                inputs = new();
                outputs = new();
            }

            #region GateBase implementation
            protected override bool OnAddInput(GateBase input)
            {
                if (inputs.Add(input))
                {
                    Invalidate();
                    return true;
                }
                else return false;
            }

            protected override bool OnAddOutput(GateBase output) =>
                outputs.Add(output);

            protected override bool OnRemoveInput(GateBase input)
            {
                if (inputs.Remove(input))
                {
                    Invalidate();
                    return true;
                }
                else return false;

            }

            protected override bool OnRemoveOutput(GateBase output) =>
                outputs.Remove(output);

            protected override bool OnIsDirectOutput(GateBase gate) =>
                outputs.Contains(gate);

            protected override bool OnIsDirectInput(GateBase gate) =>
                inputs.Contains(gate);

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

            protected override bool OnIsIndirectInput(GateBase gate)
            {
                if (inputs.Contains(gate)) return true;

                else
                {
                    foreach (var input in inputs)
                    {
                        if (input.AsNode().IsIndirectInput(gate)) return true;
                    }

                    return false;
                }
            }
            #endregion

            #region Private fields with protected accessors
            // Access to these fields in some manner is required for derived
            // classes to calculate their output values. Rather than give
            // derived classes direct access, the protected properties
            // are used to ensure the private fields are not improperty
            // modified.

            private readonly HashSet<GateBase> inputs;
            protected int InputCount => inputs.Count;
            protected IEnumerator<GateBase> InputEnumerator =>
                inputs.GetEnumerator();
            private readonly HashSet<GateBase> outputs;
            #endregion
        }
    }
}
