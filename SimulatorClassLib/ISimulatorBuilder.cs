using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorClassLib
{
    /// <summary>
    /// Interface simulator builder.
    /// </summary>
    public interface ISimulatorBuilder
    {
        /// <summary>
        /// Build flying model.
        /// </summary>
        /// <param name="name">Model name.</param>
        void BuildModel(string name);

        /// <summary>
        /// Build simulator view.
        /// </summary>
        void BuildView();

        /// <summary>
        /// Build simulator controller.
        /// </summary>
        void BuildController();
        
        /// <summary>
        /// Build simulation program.
        /// </summary>
        void BuildProgram();

        /// <summary>
        /// Build simulator actions.
        /// </summary>
        void BuildActions();

        /// <summary>
        /// Subscribe handlers to events.
        /// </summary>
        void BuildHandlers();

        /// <summary>
        /// Set simulator parameters.
        /// </summary>
        void BuildSimulatorParameters();

        /// <summary>
        /// Get result of configuration simulator object.
        /// </summary>
        /// <returns>Simulator.</returns>
        AbstructSimulator GetResult();
    }
}
