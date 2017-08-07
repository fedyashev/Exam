using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorClassLib
{
    /// <summary>
    /// Flying interface.
    /// </summary>
    public interface IFlyeble
    {
        /// <summary>
        /// Increase speed event handler.
        /// </summary>
        /// <param name="sender">Event invoker object.</param>
        /// <param name="e">Event arguments.</param>
        void IncreaseSpeedHandler(object sender, EventArgs e);

        /// <summary>
        /// Decrease speed event handler.
        /// </summary>
        /// <param name="sender">Event invoker object.</param>
        /// <param name="e">Event arguments.</param>
        void DecreaseSpeedHandler(object sender, EventArgs e);

        /// <summary>
        /// Increase height event handler.
        /// </summary>
        /// <param name="sender">Event invoker arguments.</param>
        /// <param name="e"></param>
        void IncreaseHeightHandler(object sender, EventArgs e);

        /// <summary>
        /// Decrease height event handler.
        /// </summary>
        /// <param name="sender">Event invoker object.</param>
        /// <param name="e">Event argumets.</param>
        void DecreaseHeightHandler(object sender, EventArgs e);

        /// <summary>
        /// Turbo increase speed event handler.
        /// </summary>
        /// <param name="sender">Event invoker object.</param>
        /// <param name="e">Event arguments.</param>
        void TurboIncreaseSpeedHandler(object sender, EventArgs e);

        /// <summary>
        /// Turbo decrease speed event handler.
        /// </summary>
        /// <param name="sender">Event invoker object.</param>
        /// <param name="e">Event arguments.</param>
        void TurboDecreaseSpeedHandler(object sender, EventArgs e);

        /// <summary>
        /// Turbo increase height event handler.
        /// </summary>
        /// <param name="sender">Event invoker object.</param>
        /// <param name="e">Event arguments.</param>
        void TurboIncreaseHeightHandler(object sender, EventArgs e);

        /// <summary>
        /// Turbo decrease height event handler.
        /// </summary>
        /// <param name="sender">Event invoker object.</param>
        /// <param name="e">Event arguments.</param>
        void TurboDecreaseHeightHandler(object sender, EventArgs e);
    }
}
