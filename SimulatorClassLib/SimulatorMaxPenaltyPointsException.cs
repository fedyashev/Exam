using System;
using System.Runtime.Serialization;

namespace SimulatorClassLib
{
    /// <summary>
    /// Model turbo increase speed exception.
    /// </summary>
    [Serializable]
    internal class SimulatorMaxPenaltyPointsException : Exception
    {
        public SimulatorMaxPenaltyPointsException()
        {
        }

        public SimulatorMaxPenaltyPointsException(string message)
            : base(message)
        {
        }

        public SimulatorMaxPenaltyPointsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected SimulatorMaxPenaltyPointsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}