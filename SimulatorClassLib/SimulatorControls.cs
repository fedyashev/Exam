using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorClassLib
{
    /// <summary>
    /// Simulator action controls constants.
    /// </summary>
    public class SimulatorControls
    {
        /// <summary>
        /// Unknow control.
        /// </summary>
        public const int unknowControl = -1;

        /// <summary>
        /// Increase speed action control.
        /// </summary>
        public const int increaseSpeed = 0;

        //Decrease spees action control.
        public const int decreaseSpeed = 1;

        /// <summary>
        /// Increase height action control.
        /// </summary>
        public const int increaseHeight = 2;

        /// <summary>
        /// Decrease height action control.
        /// </summary>
        public const int decreaseHeight = 3;

        /// <summary>
        /// Turbo increase speed action control.
        /// </summary>
        public const int turboIncreaseSpeed = 4;

        /// <summary>
        /// Turbo decrease speed action control.
        /// </summary>
        public const int turboDecreaseSpeed = 5;

        /// <summary>
        /// Turbo increase height action control.
        /// </summary>
        public const int turboIncreaseHeight = 6;

        /// <summary>
        /// Turbo decrease height action control.
        /// </summary>
        public const int turboDecreaseHeight = 7;

        /// <summary>
        /// Start new simulation action control.
        /// </summary>
        public const int startNewSimulation = 8;

        /// <summary>
        /// Exit simulation aciton control.
        /// </summary>
        public const int exitSimulation = 9;
    }
}
