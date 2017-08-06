using System;
using System.Runtime.Serialization;

namespace SimulatorClassLib
{
    /// <summary>
    /// Model turbo decrease speed exception.
    /// </summary>
    [Serializable]
    internal class ModelTurboDecreaseHeightException : Exception
    {
        public ModelTurboDecreaseHeightException()
        {
        }

        public ModelTurboDecreaseHeightException(string message) : base(message)
        {
        }

        public ModelTurboDecreaseHeightException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ModelTurboDecreaseHeightException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}