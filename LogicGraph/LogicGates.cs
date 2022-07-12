namespace LogicGraph
{
    /// <summary>
    /// This class contains the logic to implement gates within a LogicGraph.
    /// This file contains the gates which derive from LogicGate.
    /// </summary>
    public static partial class Gates
    {
        /// <summary>
        /// A logic gate representing logical AND of one or more inputs.
        /// </summary>
        internal class AND : LogicGate
        {
            protected override int CalculateValue()
            {
                if (InputCount == 0) return -1;
                else
                {
                    var value = 1;
                    var input = InputEnumerator;
                    while (input.MoveNext())
                    {
                        switch(input.Current.Value)
                        {
                            case 0: value = 0; break;
                            case 1: break;
                            case -1: return -1;
                            default: return -2;
                        }
                    }
                    
                    return value;
                }
            }
        }

        /// <summary>
        /// A logic gate representing logical OR of one or more inputs.
        /// </summary>
        internal class OR : LogicGate
        {
            protected override int CalculateValue()
            {
                if (InputCount == 0) return -1;
                else
                {

                    int value = 0;
                    var input = InputEnumerator;

                    while (input.MoveNext())
                    {
                        switch (input.Current.Value)
                        {
                            case 1: value = 1; break;
                            case 0: break;
                            case -1: return -1;
                            case -2:
                            default:
                                return -2;
                        }
                    }

                    return value;
                }
            }
        }

        /// <summary>
        /// A logic gate representing logical NAND of one or more inputs.
        /// </summary>
        internal class NAND : LogicGate
        {
            protected override int CalculateValue()
            {
                if (InputCount == 0) return -1;
                else
                {
                    int count = 0;
                    var input = InputEnumerator;

                    while (input.MoveNext())
                    {
                        switch (input.Current.Value)
                        {
                            case 1: ++count; break;
                            case 0: continue;
                            case -1: return -1;
                            case -2:
                            default:
                                return -2;
                        }
                    }

                    return count < InputCount ? 1 : 0;
                }
            }
        }

        /// <summary>
        /// A logic gate representing logical NOR of one or more inputs.
        /// </summary>
        internal class NOR : LogicGate
        {
            protected override int CalculateValue()
            {
                if (InputCount == 0)
                {
                    return -1;
                }

                int value = 1;
                var input = InputEnumerator;

                while (input.MoveNext())
                {
                    switch (input.Current.Value)
                    {
                        case 1: value = 0; break;
                        case 0: break;
                        case -1: return -1;
                        case -2:
                        default:
                            return -2;
                    }
                }

                return value;
            }
        }

        /// <summary>
        /// A logic gate representing logical XOR of one or more inputs.
        /// </summary>
        internal class XOR : LogicGate
        {
            protected override int CalculateValue()
            {
                if (InputCount == 0) return -1;

                int count = 0;
                var input = InputEnumerator;

                while (input.MoveNext())
                {
                    switch (input.Current.Value)
                    {
                        case 1: ++count; break;
                        case 0: break;
                        case -1: return -1;
                        case -2:
                        default:
                            return -2;
                    }
                }

                return count == 1 ? 1 : 0;
            }
        }
    }
}
