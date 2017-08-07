using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorClassLib
{
    /// <summary>
    /// Message event arguments.
    /// </summary>
    public class MessageEventArgs : EventArgs
    {
        /// <summary>
        /// Message.
        /// </summary>
        private string _message;

        /// <summary>
        /// Message.
        /// </summary>
        public string Message
        {
            get
            {
                return _message;
            }

            private set
            {
                _message = value;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Message.</param>
        public MessageEventArgs(string message)
        {
            this._message = message;
        }
    }
}
