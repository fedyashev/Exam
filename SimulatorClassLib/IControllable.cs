using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorClassLib
{
    /// <summary>
    /// Simulator controller interface.
    /// </summary>
    public interface IControllable
    {
        /// <summary>
        /// Get control action.
        /// </summary>
        /// <returns>Number of control action.</returns>
        int GetControlAction();
    }
}
