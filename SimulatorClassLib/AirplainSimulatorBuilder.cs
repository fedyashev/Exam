using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorClassLib
{
    public class AirplainSimulatorBuilder : ISimulatorBuilder
    {
        private AirplainSimulator _simulator;

        public AirplainSimulatorBuilder()
        {
            this._simulator = new AirplainSimulator(1000);
            this._simulator.DeltaSpeed = 50;
            this._simulator.DeltaHeight = 250;
            this._simulator.DeltaTurboSpeed = 150;
            this._simulator.DeltaTurboHeight = 500;
        }

        public void BuildActions()
        {
            _simulator.InitializeActionDictionary();
        }

        public void BuildProgram()
        {
            _simulator.Program = new AirplainSimulationProgram();
        }

        public void BuildController()
        {
            _simulator.Controller = new AirplainSimulatorKeyboardController();
        }

        public void BuildHandlers()
        {
            _simulator.InitializeHandlers();
        }

        public void BuildModel(string name)
        {
            _simulator.Model = new Airplain(name);
        }

        public void BuildView()
        {
            _simulator.View = new AirplianSimulatorConsoleView();
        }

        public AbstructSimulator GetResult()
        {
            return _simulator;
        }
    }
}
