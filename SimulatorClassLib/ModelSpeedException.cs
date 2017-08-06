using System;
using System.Runtime.Serialization;

namespace SimulatorClassLib
{
    /// <summary>
    /// Incorrect model speed exception.
    /// </summary>
    [Serializable]
    internal class ModelSpeedException : Exception
    {
        public ModelSpeedException()
        {
        }

        public ModelSpeedException(string message) : base(message)
        {
        }

        public ModelSpeedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ModelSpeedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}