using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorClassLib
{
    public interface IFlyeble
    {
        void IncreaseSpeedHandler(object sender, EventArgs e);
        void DecreaseSpeedHandler(object sender, EventArgs e);
        void IncreaseHeightHandler(object sender, EventArgs e);
        void DecreaseHeightHandler(object sender, EventArgs e);
        void TurboIncreaseSpeedHandler(object sender, EventArgs e);
        void TurboDecreaseSpeedHandler(object sender, EventArgs e);
        void TurboIncreaseHeightHandler(object sender, EventArgs e);
        void TurboDecreaseHeightHandler(object sender, EventArgs e);
    }
}
