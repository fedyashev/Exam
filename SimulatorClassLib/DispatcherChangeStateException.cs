using System;
using System.Runtime.Serialization;

namespace SimulatorClassLib
{
    /// <summary>
    /// Dispatcher change state exception.
    /// </summary>
    [Serializable]
    internal class DispatcherChangeStateException : Exception
    {
        public DispatcherChangeStateException()
        {
        }

        public DispatcherChangeStateException(string message) : base(message)
        {
        }

        public DispatcherChangeStateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DispatcherChangeStateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}