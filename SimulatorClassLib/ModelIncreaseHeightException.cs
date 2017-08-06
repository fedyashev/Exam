using System;
using System.Runtime.Serialization;

namespace SimulatorClassLib
{
    /// <summary>
    /// Model increase height exception.
    /// </summary>
    [Serializable]
    internal class ModelIncreaseHeightException : Exception
    {
        public ModelIncreaseHeightException()
        {
        }

        public ModelIncreaseHeightException(string message) : base(message)
        {
        }

        public ModelIncreaseHeightException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ModelIncreaseHeightException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}