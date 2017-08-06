using System;
using System.Runtime.Serialization;

namespace SimulatorClassLib
{
    /// <summary>
    /// Incorrect model name exception.
    /// </summary>
    [Serializable]
    internal class ModelNameException : Exception
    {
        public ModelNameException()
        {
        }

        public ModelNameException(string message) : base(message)
        {
        }

        public ModelNameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ModelNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}