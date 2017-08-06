using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorClassLib
{
    public class SimulatorDirector
    {
        private ISimulatorBuilder _builder;
        private string _modelName;

        public SimulatorDirector(ISimulatorBuilder builber, string modelName)
        {
            this._builder = builber;
            this._modelName = modelName;
        }

        public void Configurate()
        {
            _builder.BuildModel(_modelName);
            _builder.BuildView();
            _builder.BuildController();
            _builder.BuildProgram();
            _builder.BuildActions();
            _builder.BuildHandlers();
        }
    }
}
