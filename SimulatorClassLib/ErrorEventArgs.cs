using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorClassLib
{
    /// <summary>
    /// Error event argumet.
    /// </summary>
    public class ErrorEventArgs : EventArgs
    {
        /// <summary>
        /// Error message.
        /// </summary>
        private string _message;

        /// <summary>
        /// Error message.
        /// </summary>
        public string Message
        {
            get
            {
                return _message;
            }

            set
            {
                this._message = value;
            }
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="message">Message.</param>
        public ErrorEventArgs(string message)
        {
            this._message = message;
        }
    }
}
