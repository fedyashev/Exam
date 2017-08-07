using System;
using System.Runtime.Serialization;

namespace SimulatorClassLib
{
    // Dispatcher count exception.
    [Serializable]
    internal class DispatcherCountException : Exception
    {
        public DispatcherCountException()
        {
        }

        public DispatcherCountException(string message) : base(message)
        {
        }

        public DispatcherCountException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DispatcherCountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}