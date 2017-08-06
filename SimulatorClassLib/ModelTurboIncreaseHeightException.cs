using System;
using System.Runtime.Serialization;

namespace SimulatorClassLib
{
    /// <summary>
    /// Model turbo increase speed height exception.
    /// </summary>
    [Serializable]
    internal class ModelTurboIncreaseHeightException : Exception
    {
        public ModelTurboIncreaseHeightException()
        {
        }

        public ModelTurboIncreaseHeightException(string message) : base(message)
        {
        }

        public ModelTurboIncreaseHeightException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ModelTurboIncreaseHeightException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}