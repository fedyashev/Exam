using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorClassLib
{
    /// <summary>
    /// Simulator view interface.
    /// </summary>
    public interface IVieweble : IFlyeble
    {
        /// <summary>
        /// Start new simulation event handler.
        /// </summary>
        /// <param name="sender">Event invoker object.</param>
        /// <param name="e">Event arguments.</param>
        void StartNewSimulationHandler(object sender, EventArgs e);

        /// <summary>
        /// Exit simulation event handler.
        /// </summary>
        /// <param name="sender">Event invoker object.</param>
        /// <param name="e">Event arguments.</param>
        void ExitSimulationHandler(object sender, EventArgs e);

        /// <summary>
        /// Success simulation event handler.
        /// </summary>
        /// <param name="sender">Event invoker object.</param>
        /// <param name="e">Event arguments.</param>
        void SuccessSimulationHandler(object sender, EventArgs e);

        /// <summary>
        /// Fail simulation event handler.
        /// </summary>
        /// <param name="sender">Event invoker object.</param>
        /// <param name="e">Event arguments.</param>
        void FailSimulationHandler(object sender, EventArgs e);

        /// <summary>
        /// Error event handler.
        /// </summary>
        /// <param name="sender">Event invoker object.</param>
        /// <param name="e">Event arguments.</param>
        void ErrorHandler(object sender, EventArgs e);

        /// <summary>
        /// Print message event handler.
        /// </summary>
        /// <param name="sender">Event invoker object.</param>
        /// <param name="e">Event arguments.</param>
        void PrintMessageHandler(object sender, EventArgs e);

        /// <summary>
        /// Change penalty points event handler.
        /// </summary>
        /// <param name="sender">Event invoker object.</param>
        /// <param name="e">Event arguments.</param>
        void ChangePenaltyPointsHandler(object sender, EventArgs e);

        /// <summary>
        /// Refresh view event handler.
        /// </summary>
        /// <param name="sender">Event invoker object.</param>
        /// <param name="e">Event arguments.</param>
        void RefreshViewHandler(object sender, EventArgs e);
    }
}
