using System;
using System.Runtime.Serialization;

namespace SimulatorClassLib
{
    /// <summary>
    /// Airplain crash exception.
    /// </summary>
    [Serializable]
    internal class DispatcherAirplainCrashException : Exception
    {
        public DispatcherAirplainCrashException()
        {
        }

        public DispatcherAirplainCrashException(string message) : base(message)
        {
        }

        public DispatcherAirplainCrashException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DispatcherAirplainCrashException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}