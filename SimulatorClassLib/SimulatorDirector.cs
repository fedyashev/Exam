using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorClassLib
{
    /// <summary>
    /// Class configurate simulator object.
    /// </summary>
    public class SimulatorDirector
    {
        /// <summary>
        /// Simulator builder.
        /// </summary>
        private ISimulatorBuilder _builder;

        /// <summary>
        /// Simulator model name.
        /// </summary>
        private string _modelName;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="builber">Simulator builder.</param>
        /// <param name="modelName">Model name.</param>
        public SimulatorDirector(ISimulatorBuilder builber, string modelName)
        {
            this._builder = builber;
            this._modelName = modelName;
        }

        /// <summary>
        /// Configurate simulator object.
        /// </summary>
        public void Configurate()
        {
            _builder.BuildSimulatorParameters();
            _builder.BuildModel(_modelName);
            _builder.BuildView();
            _builder.BuildController();
            _builder.BuildProgram();
            _builder.BuildActions();
            _builder.BuildHandlers();
        }
    }
}
