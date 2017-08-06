using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorClassLib
{
    /// <summary>
    /// Airplain training model.
    /// </summary>
    class Airplain : AbstructFlyingModel
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Airplain name.</param>
        public Airplain(string name) : base(name)
        {
        }

        /// <summary>
        /// Overrided method interpetation airplain object as string.
        /// </summary>
        /// <returns>String describes airplain object.</returns>
        public override string ToString()
        {
            return String.Format("Airplain {0}, height: {1} m, speed: {2} km/h.", Name, Height, Speed);
        }
    }
}
