using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorClassLib
{
    /// <summary>
    /// Airplaint simulator builder.
    /// </summary>
    public class AirplainSimulatorBuilder : ISimulatorBuilder
    {
        /// <summary>
        /// Manimum penalty points.
        /// </summary>
        private const int maxPenaltyPoints = 1000;

        /// <summary>
        /// Increase / decrease model speed delta.
        /// </summary>
        private const int deltaSpeed = 50;

        /// <summary>
        /// Increase / decrease model height delta.
        /// </summary>
        private const int deltaHeight = 250;

        /// <summary>
        /// Turbo increase / decrease model speed delta.
        /// </summary>
        private const int deltaTurboSpeed = 150;

        /// <summary>
        /// Turbo increase / decrease model height delta.
        /// </summary>
        private const int deltaTurboHeight = 500;

        /// <summary>
        /// Airplain simulator.
        /// </summary>
        private AirplainSimulator _simulator;

        /// <summary>
        /// Constructor.
        /// </summary>
        public AirplainSimulatorBuilder()
        {
            this._simulator = new AirplainSimulator(maxPenaltyPoints);
        }

        /// <summary>
        /// Build simulator actions.
        /// </summary>
        public void BuildActions()
        {
            _simulator.InitializeActionDictionary();
        }

        /// <summary>
        /// Build simulation program.
        /// </summary>
        public void BuildProgram()
        {
            _simulator.Program = new AirplainSimulationProgram();
        }

        /// <summary>
        /// Build simulator controller.
        /// </summary>
        public void BuildController()
        {
            _simulator.Controller = new AirplainSimulatorKeyboardController();
        }

        /// <summary>
        /// Subscribe handlers to events.
        /// </summary>
        public void BuildHandlers()
        {
            _simulator.InitializeHandlers();
        }

        /// <summary>
        /// Build flying model.
        /// </summary>
        /// <param name="name">Model name.</param>
        public void BuildModel(string name)
        {
            _simulator.Model = new Airplain(name);
        }

        /// <summary>
        /// Build view.
        /// </summary>
        public void BuildView()
        {
            _simulator.View = new AirplianSimulatorConsoleView();
        }

        /// <summary>
        /// Set simulator parameters.
        /// </summary>
        public void BuildSimulatorParameters()
        {
            this._simulator.DeltaSpeed = deltaSpeed;
            this._simulator.DeltaHeight = deltaHeight;
            this._simulator.DeltaTurboSpeed = deltaTurboSpeed;
            this._simulator.DeltaTurboHeight = deltaTurboHeight;
        }

        /// <summary>
        /// Get result of configuration simulator object.
        /// </summary>
        /// <returns></returns>
        public AbstructSimulator GetResult()
        {
            return _simulator;
        }
    }
}
