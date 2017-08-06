using System;
using System.Runtime.Serialization;

namespace SimulatorClassLib
{
    /// <summary>
    /// Pilot is unfit to fly exception.
    /// </summary>
    [Serializable]
    internal class UnfitToFlyException : Exception
    {
        public UnfitToFlyException()
        {
        }

        public UnfitToFlyException(string message) : base(message)
        {
        }

        public UnfitToFlyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnfitToFlyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}