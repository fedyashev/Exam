using System;
using System.Runtime.Serialization;

namespace SimulatorClassLib
{
    /// <summary>
    /// Incorrect model height exception.
    /// </summary>
    [Serializable]
    internal class ModelHeightException : Exception
    {
        public ModelHeightException()
        {
        }

        public ModelHeightException(string message) : base(message)
        {
        }

        public ModelHeightException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ModelHeightException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}