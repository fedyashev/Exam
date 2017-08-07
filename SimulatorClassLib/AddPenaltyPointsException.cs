using System;
using System.Runtime.Serialization;

namespace SimulatorClassLib
{
    /// <summary>
    /// Add penalty points exception.
    /// </summary>
    [Serializable]
    internal class AddPenaltyPointsException : Exception
    {
        public AddPenaltyPointsException()
        {
        }

        public AddPenaltyPointsException(string message) : base(message)
        {
        }

        public AddPenaltyPointsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AddPenaltyPointsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}