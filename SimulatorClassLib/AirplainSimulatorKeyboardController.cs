using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorClassLib
{
    public class AirplainSimulatorKeyboardController : IControllable
    {
        private int GetKey(string keyStr)
        {
            switch (keyStr)
            {
                case "D1": return SimulatorControls.startNewSimulation;
                case "D2": return AirplainSimulatorControls.AddDispatcher;
                case "D3": return AirplainSimulatorControls.RemoveDispatcher;
                case "D0": return SimulatorControls.exitSimulation;
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

        public int GetControlAction()
        {
            var key = Console.ReadKey(true);
            var modifier = (key.Modifiers & ConsoleModifiers.Shift);
            var keyStr = key.Key.ToString() + (modifier != 0 ? String.Format("+{0}", modifier.ToString()) : "");
            return GetKey(keyStr);
        }
    }
}
