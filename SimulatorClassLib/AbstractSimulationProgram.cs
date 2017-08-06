using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorClassLib
{
    /// <summary>
    /// Simulation program abstract class.
    /// </summary>
    public abstract class AbstractSimulationProgram
    {
        /// <summary>
        /// Prorgam done flag field.
        /// </summary>
        private bool _isDone;

        /// <summary>
        /// Program done flag property.
        /// </summary>
        public bool IsDone
        {
            get { return _isDone; }
            protected set { _isDone = value; }
        }

        /// <summary>
        /// Restart program.
        /// </summary>
        public abstract void RestartProgram();

        /// <summary>
        /// Change state handler.
        /// </summary>
        /// <param name="sender">Object.</param>
        /// <param name="e">Event arguments.</param>
        public abstract void ChangeStateHandler(object sender, EventArgs e);
    }
}
