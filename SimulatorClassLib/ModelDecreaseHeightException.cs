using System;
using System.Runtime.Serialization;

namespace SimulatorClassLib
{
    /// <summary>
    /// Decrease height exception.
    /// </summary>
    [Serializable]
    internal class ModelDecreaseHeightException : Exception
    {
        public ModelDecreaseHeightException()
        {
        }

        public ModelDecreaseHeightException(string message) : base(message)
        {
        }

        public ModelDecreaseHeightException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ModelDecreaseHeightException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}