using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorClassLib
{
    public interface ISimulatorBuilder
    {
        void BuildModel(string name);
        void BuildView();
        void BuildController();
        void BuildProgram();
        void BuildActions();
        void BuildHandlers();
        AbstructSimulator GetResult();
    }
}
