using System;
using System.Runtime.Serialization;

namespace SimulatorClassLib
{
    /// <summary>
    /// Airplain crash exception.
    /// </summary>
    [Serializable]
    internal class AirplainCrashException : Exception
    {
        public AirplainCrashException()
        {
        }

        public AirplainCrashException(string message) : base(message)
        {
        }

        public AirplainCrashException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AirplainCrashException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}