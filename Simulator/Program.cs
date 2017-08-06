using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimulatorClassLib;

namespace Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new AirplainSimulatorBuilder();

            var director = new SimulatorDirector(builder, "Boeing 737");
            director.Configurate();

            var simulator = builder.GetResult();
            simulator.Run();
        }
    }
}
