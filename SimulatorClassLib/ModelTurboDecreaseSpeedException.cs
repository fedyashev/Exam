using System;
using System.Runtime.Serialization;

namespace SimulatorClassLib
{
    /// <summary>
    /// Model turbo decrease speed exception.
    /// </summary>
    [Serializable]
    internal class ModelTurboDecreaseSpeedException : Exception
    {
        public ModelTurboDecreaseSpeedException()
        {
        }

        public ModelTurboDecreaseSpeedException(string message) : base(message)
        {
        }

        public ModelTurboDecreaseSpeedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ModelTurboDecreaseSpeedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}