using System;
using System.Runtime.Serialization;

namespace SimulatorClassLib
{
    /// <summary>
    /// Simulator penalty points exception.
    /// </summary>
    [Serializable]
    internal class SimulatorMaxPenaltyPointsException : Exception
    {
        public SimulatorMaxPenaltyPointsException()
        {
        }

        public SimulatorMaxPenaltyPointsException(string message) : base(message)
        {
        }

        public SimulatorMaxPenaltyPointsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SimulatorMaxPenaltyPointsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}