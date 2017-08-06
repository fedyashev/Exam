using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorClassLib
{
    public interface IVieweble : IFlyeble
    {
        void StartNewSimulationHandler(object sender, EventArgs e);
        void ExitSimulationHandler(object sender, EventArgs e);
        void SuccessSimulationHandler(object sender, EventArgs e);
        void FailSimulationHandler(object sender, EventArgs e);
        void ErrorHandler(object sender, EventArgs e);
        void PrintMessageHandler(object sender, EventArgs e);
        void ChangePenaltyPointsHandler(object sender, EventArgs e);
        void RefreshViewHandler(object sender, EventArgs e);
    }
}
