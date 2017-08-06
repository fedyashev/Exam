using System;
using System.Runtime.Serialization;

namespace SimulatorClassLib
{
    /// <summary>
    /// Model turbo increase speed exception.
    /// </summary>
    [Serializable]
    internal class ModelTurboIncreaseSpeedException : Exception
    {
        public ModelTurboIncreaseSpeedException()
        {
        }

        public ModelTurboIncreaseSpeedException(string message) : base(message)
        {
        }

        public ModelTurboIncreaseSpeedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ModelTurboIncreaseSpeedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}