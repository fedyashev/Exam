using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorClassLib
{
    public class ErrorEventArgs : EventArgs
    {
        private string _message;

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

        public ErrorEventArgs(string message)
        {
            this._message = message;
        }
    }
}
