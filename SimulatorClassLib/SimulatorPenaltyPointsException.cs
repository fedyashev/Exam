using System;
using System.Runtime.Serialization;

namespace SimulatorClassLib
{
    /// <summary>
    /// Simulator penalty points exception.
    /// </summary>
    [Serializable]
    internal class SimulatorPenaltyPointsException : Exception
    {
        public SimulatorPenaltyPointsException()
        {
        }

        public SimulatorPenaltyPointsException(string message)
            : base(message)
        {
        }

        public SimulatorPenaltyPointsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected SimulatorPenaltyPointsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}