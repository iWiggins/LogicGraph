namespace LogicGraph
{
    /// <summary>
    /// Manages a network of LogicGates connected as nodes in a graph.
    /// </summary>
    public class GateGraph
    {
        /// <summary>
        /// Creates a gate and adds it to the graph.
        /// Does not connect the gate to any other part of the graph.
        /// </summary>
        /// <param name="gateType">The type of gate to create.</param>
        /// <returns>The key of the created gate.</returns>
        /// <exception cref="ArgumentException">
        /// Throws an ArgumentException if:
        /// * The user attempts to create an IN gate.
        /// * The user attempts to create an OUT gate.
        /// * THe user passes an invalid type.
        /// </exception>
        public int CreateGate(Gates.Gate gateType)
        {
            if (gateType == Gates.Gate.IN)
                throw new ArgumentException(
                    "Can't create inputs after graph construction.");
            if (gateType == Gates.Gate.OUT)
                throw new ArgumentException(
                    "Can't create outputs after graph construction.");

            var gate = Gates.CreateGate(gateType);

            gateMap.Add(gate.GetHashCode(), gate);

            return gate.GetHashCode();
        }

        /// <summary>
        /// Removes the gate with the passed key from the graph.
        /// Disconnects all the gate's connections.
        /// </summary>
        /// <param name="key">The key of the gate to destroy.</param>
        /// <returns>
        /// True: Success
        /// False: The passed key is an input or output, or was not found.
        /// </returns>
        public bool DestroyGate(int key)
        {
            if (gateMap.TryGetValue(key, out Gates.GateBase? gate))
            {
                if (gate is Gates.IN) return false;
                if (gate is Gates.OUT) return false;

                gate.Disconnect();
                gateMap.Remove(key);
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Connects two gates.
        /// </summary>
        /// <param name="firstKey">The parent (input) gate.</param>
        /// <param name="secondKey">The child (output) gate.</param>
        /// <returns>
        /// True: Success
        /// False: Failure
        /// </returns>
        /// <remarks>
        /// Failure indicates that either one of the two keys was not found,
        /// or that the connection failed.
        /// The connection can fail for a variety of reasons (See documentation
        /// for the GateBase class and its derived members).
        /// </remarks>
        public bool ConnectGates(int firstKey, int secondKey)
        {

            if (!gateMap.TryGetValue(firstKey, out Gates.GateBase? firstGate)) return false;
            if (!gateMap.TryGetValue(secondKey, out Gates.GateBase? secondGate)) return false;

            return firstGate.Connect(secondGate);
        }

        /// <summary>
        /// Disconnects two gates.
        /// </summary>
        /// <param name="firstKey">The first gate.</param>
        /// <param name="secondKey">The second gate.</param>
        /// <returns>
        /// True: Success
        /// False: Failure
        /// </returns>
        /// <remarks>
        /// Failure indicates that either one of the two keys was not found,
        /// or that the disconnection failed.
        /// Disconnection can fail for a variety of reasons (See documentation
        /// for the GateBase class and its derived members).
        /// This function will successfuly disconnect two connected gates,
        /// regardless of the order their keys are passed.
        /// However, the underlying code will run more efficiently if the
        /// parent is the firstKey and the child is the secondKey.
        /// </remarks>
        public bool DisconnectGates(int firstKey, int secondKey)
        {

            if (!gateMap.TryGetValue(firstKey, out Gates.GateBase? firstGate)) return false;
            if (!gateMap.TryGetValue(secondKey, out Gates.GateBase? secondGate)) return false;

            return firstGate.Disconnect(secondGate);
        }

        /// <summary>
        /// Sets the ordered values of the input nodes to the ordered values
        /// given.
        /// </summary>
        /// <param name="inputValues">An ordered array of values.</param>
        /// <returns>
        /// True: Success
        /// False: The argument length is not equal to the number of
        /// input nodes.
        /// </returns>
        /// <remarks>
        /// Possible inputs are:
        /// 0: Represents logical FALSE
        /// 1: Represents logical TRUE
        /// -1: Represents a NULL value
        /// All other inputs will result in error codes propagating through
        /// the graph.
        /// </remarks>
        public bool FeedInputs(params int[] inputValues)
        {
            if (inputValues.Length != inputs.Count) return false;

            for (int i = 0; i < inputValues.Length; ++i)
            {
                inputs[i].SetValue(inputValues[i]);
            }

            return true;
        }

        /// <summary>
        /// Returns the value of the indexed output.
        /// </summary>
        /// <param name="output">Index of the output to value-check.</param>
        /// <returns>
        /// 0: False
        /// 1: True
        /// -1: No value
        /// -2: Error
        /// -3: Index out of range
        /// </returns>
        public int GetOutputValue(int output)
        {
            if (output < 0 || output >= outputs.Count) return -3;
            return outputs[output].Value;
        }

        /// <summary>
        /// Returns the value of the gate with the given key.
        /// </summary>
        /// <param name="key">The key of a gate in the graph.</param>
        /// <returns>
        /// The value of the gate. One of:
        /// 0: Represents logical FALSE
        /// 1: Represents logical TRUE
        /// -1: Represents a NULL value
        /// -2: An error occured calculating the value
        /// </returns>
        public int GetValue(int key)
        {
            if (!gateMap.TryGetValue(key, out Gates.GateBase? gate)) return -2;
            else return gate.Value;
        }

        /// <summary>
        /// Creates an ordered list containing the keys of the input nodes of
        /// the graph.
        /// </summary>
        /// <returns>The list of integer keys.</returns>
        public List<int> GetInputKeys() =>
            inputs.ConvertAll(input => input.GetHashCode());

        /// <summary>
        /// Creates an ordered iist containing the keys of the output nodes of
        /// the graph.
        /// </summary>
        /// <returns>The list of integer keys.</returns>
        public List<int> GetOutputKeys() =>
            outputs.ConvertAll(output => output.GetHashCode());

        /// <summary>
        /// Connects the indexed input to the gate with the given key.
        /// </summary>
        /// <param name="input">Index of the input to connect.</param>
        /// <param name="key">Key of the gate to connect.</param>
        /// <returns>
        /// True: Success
        /// False: Failure
        /// </returns>
        public bool ConnectInputToGate(int input, int key)
        {
            if (input < 0 || input >= inputs.Count) return false;

            var inputGate = inputs[input];


            if (!gateMap.TryGetValue(key, out Gates.GateBase? gate)) return false;

            return inputGate.Connect(gate!);
        }

        /// <summary>
        /// Connects the gate with the given key to the indexed output.
        /// </summary>
        /// <param name="output">Index of the output to connect.</param>
        /// <param name="key">Key of the gate to connect.</param>
        /// <returns>
        /// True: Success
        /// False: Failure
        /// </returns>
        public bool ConnectGateToOutput(int output, int key)
        {
            if (output < 0 || output >= outputs.Count) return false;

            var outputGate = outputs[output];


            if (!gateMap.TryGetValue(key, out Gates.GateBase? gate)) return false;

            return gate.Connect(outputGate);
        }

        /// <summary>
        /// Constructs a logic graph.
        /// </summary>
        /// <param name="inputCount">The number of input nodes.</param>
        /// <param name="outputCount">The number of output nodes.</param>
        /// <remarks>
        /// The numbers of input and output nodes cannot be modified after
        /// a graph is constructed. The keys for the input and output nodes
        /// can be retrieved post-construction using the GetInputKeys and
        /// GetOutputKeys methods.
        /// </remarks>
        public GateGraph(int inputCount, int outputCount)
        {
            if (inputCount <= 0) throw new ArgumentOutOfRangeException(
                nameof(inputCount),
                "inputCount must be at least 1.");

            if (outputCount <= 0) throw new ArgumentOutOfRangeException(
                nameof(outputCount),
                "outputCount must be at least 1.");

            gateMap = new Dictionary<int, Gates.GateBase>();

            inputs = new(inputCount);
            outputs = new(outputCount);

            for (int i = 0; i < inputCount; ++i)
            {
                Gates.IN input = new();
                gateMap[input.GetHashCode()] = input;
                inputs.Add(input);
            }

            for (int i = 0; i < outputCount; ++i)
            {
                Gates.OUT output = new();
                gateMap[output.GetHashCode()] = output;
                outputs.Add(output);
            }
        }

        #region Private fields
        private readonly Dictionary<int, Gates.GateBase> gateMap;
        private readonly List<Gates.IN> inputs;
        private readonly List<Gates.OUT> outputs;
        #endregion
    }

}
