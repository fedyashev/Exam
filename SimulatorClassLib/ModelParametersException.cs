using System;
using System.Runtime.Serialization;

namespace SimulatorClassLib
{
    /// <summary>
    /// Incorrect model parameters.
    /// </summary>
    [Serializable]
    internal class ModelParametersException : Exception
    {
        public ModelParametersException()
        {
        }

        public ModelParametersException(string message) : base(message)
        {
        }

        public ModelParametersException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ModelParametersException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}