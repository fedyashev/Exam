using System;
using System.Runtime.Serialization;

namespace SimulatorClassLib
{
    /// <summary>
    /// Airplain can't fly exception.
    /// </summary>
    [Serializable]
    internal class AirplainFlyException : Exception
    {
        public AirplainFlyException()
        {
        }

        public AirplainFlyException(string message)
            : base(message)
        {
        }

        public AirplainFlyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected AirplainFlyException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}