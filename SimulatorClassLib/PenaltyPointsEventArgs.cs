using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorClassLib
{
    /// <summary>
    /// Penalty points event argument.
    /// </summary>
    public class PenaltyPointsEventArgs : EventArgs
    {
        /// <summary>
        /// Penalty points.
        /// </summary>
        private int _penaltyPoints;

        /// <summary>
        /// Penalty points.
        /// </summary>
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

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="penaltyPoints">Penalty points.</param>
        public PenaltyPointsEventArgs(int penaltyPoints)
        {
            this.PenaltyPoints = penaltyPoints;
        }
    }
}
