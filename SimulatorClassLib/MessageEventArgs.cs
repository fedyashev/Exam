using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorClassLib
{
    public class MessageEventArgs : EventArgs
    {
        private string _message;

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

        public MessageEventArgs(string message)
        {
            this._message = message;
        }
    }
}
