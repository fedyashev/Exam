using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorClassLib
{
    /// <summary>
    /// Airplain simulation program.
    /// </summary>
    class AirplainSimulationProgram : AbstractSimulationProgram
    {
        /// <summary>
        /// Max speed achived flag.
        /// </summary>
        private bool _isMaxSpeedAchived;

        /// <summary>
        /// Airplain landed flag.
        /// </summary>
        private bool _isAirplainLanded;

        /// <summary>
        /// Airplain max speed.
        /// </summary>
        private const int _maxSpeed = 1000;

        /// <summary>
        /// Change state handler.
        /// </summary>
        /// <param name="sender">Object that invoke event.</param>
        /// <param name="e">Event arguments.</param>
        public override void ChangeStateHandler(object sender, EventArgs e)
        {
            if (IsDone) return;
            var simulator = (AbstructSimulator)sender;
            _isAirplainLanded = simulator.Model.Height == 0 && simulator.Model.Speed == 0 ? true : false;
            if (!_isMaxSpeedAchived && simulator.Model.Height > 0 && simulator.Model.Speed >= _maxSpeed) _isMaxSpeedAchived = true;
            IsDone = _isMaxSpeedAchived && _isAirplainLanded;
        }

        /// <summary>
        /// Restart simulation program.
        /// </summary>
        public override void RestartProgram()
        {
            _isMaxSpeedAchived = false;
            _isAirplainLanded = false;
        }
    }
}
