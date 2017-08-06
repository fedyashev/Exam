using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorClassLib
{
    public class PenaltyPointsEventArgs : EventArgs
    {
        private int _penaltyPoints;

        public int PenaltyPoints
        {
            get
            {
                return _penaltyPoints;
            }

            private set
            {
                this._penaltyPoints = value;
            }
        }

        public PenaltyPointsEventArgs(int penaltyPoints)
        {
            this.PenaltyPoints = penaltyPoints;
        }
    }
}
