using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorClassLib
{
    /// <summary>
    /// Airplain keyboard controllesr.
    /// </summary>
    public class AirplainSimulatorKeyboardController : IControllable
    {
        /// <summary>
        /// Get control key action number.
        /// </summary>
        /// <param name="keyStr">String with control key.</param>
        /// <returns>Number of control action.</returns>
        private int GetKey(string keyStr)
        {
            switch (keyStr)
            {
                case "NumPad1":
                case "D1":
                    return SimulatorControls.startNewSimulation;
                case "NumPad2": 
                case "D2":
                    return AirplainSimulatorControls.AddDispatcher;
                case "NumPad3":
                case "D3":
                    return AirplainSimulatorControls.RemoveDispatcher;
                case "NumPad0":
                case "D0":
                    return SimulatorControls.exitSimulation;
                case "UpArrow": return SimulatorControls.increaseHeight;
                case "DownArrow": return SimulatorControls.decreaseHeight;
                case "RightArrow": return SimulatorControls.increaseSpeed;
                case "LeftArrow": return SimulatorControls.decreaseSpeed;
                case "UpArrow+Shift": return SimulatorControls.turboIncreaseHeight;
                case "DownArrow+Shift": return SimulatorControls.turboDecreaseHeight;
                case "RightArrow+Shift": return SimulatorControls.turboIncreaseSpeed;
                case "LeftArrow+Shift": return SimulatorControls.turboDecreaseSpeed;
                default: return SimulatorControls.unknowControl;
            }
        }

        /// <summary>
        /// Get control action number.
        /// </summary>
        /// <returns>Number of action.</returns>
        public int GetControlAction()
        {
            var key = Console.ReadKey(true);
            var modifier = (key.Modifiers & ConsoleModifiers.Shift);
            var keyStr = key.Key.ToString() + (modifier != 0 ? String.Format("+{0}", modifier.ToString()) : "");
            return GetKey(keyStr);
        }
    }
}
