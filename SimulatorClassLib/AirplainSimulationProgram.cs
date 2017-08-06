using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorClassLib
{
    class AirplainSimulationProgram : AbstractSimulationProgram
    {
        private bool _isMaxSpeedAchived;
        private bool _isAirplainLanded;

        private const int _maxSpeed = 1000;

        public override void ChangeStateHandler(object sender, EventArgs e)
        {
            // TODO
            if (IsDone) return;
            var simulator = (AbstructSimulator)sender;
            _isAirplainLanded = simulator.Model.Height == 0 && simulator.Model.Speed == 0 ? true : false;
            if (!_isMaxSpeedAchived && simulator.Model.Height > 0 && simulator.Model.Speed >= _maxSpeed) _isMaxSpeedAchived = true;
            IsDone = _isMaxSpeedAchived && _isAirplainLanded;
        }

        public override void RestartProgram()
        {
            _isMaxSpeedAchived = false;
            _isAirplainLanded = false;
        }
    }
}
