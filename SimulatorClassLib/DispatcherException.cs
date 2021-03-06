﻿using System;
using System.Runtime.Serialization;

namespace SimulatorClassLib
{
    /// <summary>
    /// Dispatcher common exception.
    /// </summary>
    [Serializable]
    internal class DispatcherException : Exception
    {
        public DispatcherException()
        {
        }

        public DispatcherException(string message) : base(message)
        {
        }

        public DispatcherException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DispatcherException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}