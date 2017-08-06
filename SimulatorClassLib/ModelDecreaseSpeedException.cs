using System;
using System.Runtime.Serialization;

namespace SimulatorClassLib
{
    /// <summary>
    /// Model decrease speed exception.
    /// </summary>
    [Serializable]
    internal class ModelDecreaseSpeedException : Exception
    {
        public ModelDecreaseSpeedException()
        {
        }

        public ModelDecreaseSpeedException(string message) : base(message)
        {
        }

        public ModelDecreaseSpeedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ModelDecreaseSpeedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}