using System;
using System.Runtime.Serialization;

namespace SimulatorClassLib
{
    /// <summary>
    /// Model increase speed exception.
    /// </summary>
    [Serializable]
    internal class ModelIncreaseSpeedException : Exception
    {
        public ModelIncreaseSpeedException()
        {
        }

        public ModelIncreaseSpeedException(string message) : base(message)
        {
        }

        public ModelIncreaseSpeedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ModelIncreaseSpeedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}