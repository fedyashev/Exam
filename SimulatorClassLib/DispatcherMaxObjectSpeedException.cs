using System;
using System.Runtime.Serialization;

namespace SimulatorClassLib
{
    /// <summary>
    /// Dispatcher max object speed exception.
    /// </summary>
    [Serializable]
    internal class DispatcherMaxObjectSpeedException : Exception
    {
        public DispatcherMaxObjectSpeedException()
        {
        }

        public DispatcherMaxObjectSpeedException(string message) : base(message)
        {
        }

        public DispatcherMaxObjectSpeedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DispatcherMaxObjectSpeedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}