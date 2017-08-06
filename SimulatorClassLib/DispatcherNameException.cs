using System;
using System.Runtime.Serialization;

namespace SimulatorClassLib
{
    /// <summary>
    /// Dispatcher name exception.
    /// </summary>
    [Serializable]
    internal class DispatcherNameException : Exception
    {
        public DispatcherNameException()
        {
        }

        public DispatcherNameException(string message) : base(message)
        {
        }

        public DispatcherNameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DispatcherNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}