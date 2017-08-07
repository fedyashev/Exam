using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorClassLib
{
    /// <summary>
    /// Console view airplain simulator.
    /// </summary>
    public class AirplianSimulatorConsoleView : IVieweble
    {
        /// <summary>
        /// Cursor left position.
        /// </summary>
        private int _cursorLeft;

        /// <summary>
        /// Cursor top position.
        /// </summary>
        private int _cursorTop;

        /// <summary>
        /// Print dispatcher list.
        /// </summary>
        /// <param name="simulator"></param>
        private void PrintDispatcherList(AirplainSimulator simulator)
        {
            if (simulator.Dispatchers.Any())
            {
                simulator.Dispatchers.ForEach(p =>
                {
                    Console.WriteLine(String.Format("Dispatcher {0}: recommended heigth {1} m.", p.Name, simulator.Model.Speed > 0 ? p.CalculateRecommendedHeight(simulator.Model) : 0));
                });
            }
            else
            {
                Console.WriteLine("Dispatchers list empty.");
            }
            
        }

        /// <summary>
        /// Print penalty points.
        /// </summary>
        /// <param name="simulator"></param>
        private void PrintPenaltyPoints(AbstructSimulator simulator)
        {
            Console.WriteLine("Penalty points: {0}/{1}", simulator.PenaltyPoints, simulator.MaxPenaltyPoints);
        }

        /// <summary>
        /// Print model.
        /// </summary>
        /// <param name="simulator"></param>
        private void PrintModel(AbstructSimulator simulator)
        {
            Console.WriteLine(simulator.Model);
        }

        /// <summary>
        /// Print menu.
        /// </summary>
        /// <param name="sender">Simulator object.</param>
        private void PrintMenu(object sender)
        {
            Console.Clear();
            var simulator = (AirplainSimulator)sender;
            Console.WriteLine("Airplain simulator.");
            Console.WriteLine("Menu:");
            Console.WriteLine("\t1 - Start new simulation.");
            Console.WriteLine("\t2 - Add dispatcher.");
            Console.WriteLine("\t3 - Remove dispatcher.");
            Console.WriteLine("\t0 - Exit simulator.");
            Console.WriteLine();
            Console.WriteLine("Control keys.....");
            Console.WriteLine();
            _cursorLeft = Console.CursorLeft;
            _cursorTop = Console.CursorTop;
            PrintPenaltyPoints(simulator);
            PrintModel(simulator);
            PrintDispatcherList(simulator);
            Console.WriteLine();
        }

        /// <summary>
        /// Common event handler.
        /// </summary>
        /// <param name="sender">Object that invoke event.</param>
        /// <param name="e">Event argumets.</param>
        /// <param name="menu">Print menu action.</param>
        /// <param name="action">Action.</param>
        private void CommonHandler(object sender, EventArgs e, Action<object> menu, Action action)
        {
            if (sender == null) throw new NullReferenceException("Sender reference is null.");
            if (e == null) throw new NullReferenceException("Event arguments reference is null.");
            if (sender as AbstructSimulator == null) throw new InvalidCastException("Sender incompatible type.");
            if (menu != null) menu(sender);
            if (action != null) action();
        }

        /// <summary>
        /// Decrease height handler.
        /// </summary>
        /// <param name="sender">Event invoker object.</param>
        /// <param name="e">Event arguments.</param>
        public void DecreaseHeightHandler(object sender, EventArgs e)
        {
            CommonHandler(sender, e, PrintMenu, () =>
            {
                var simulator = (AbstructSimulator)sender;
                Console.WriteLine("Airplain {0} decrease height by {1} meters.", simulator.Model.Name, simulator.DeltaHeight);
            });
        }

        /// <summary>
        /// Decrease speed handler.
        /// </summary>
        /// <param name="sender">Event invoker object.</param>
        /// <param name="e">Event arguments.</param>
        public void DecreaseSpeedHandler(object sender, EventArgs e)
        {
            CommonHandler(sender, e, PrintMenu, () =>
            {
                var simulator = (AbstructSimulator)sender;
                Console.WriteLine("Airplain {0} decrease speed by {1} km/h.", simulator.Model.Name, simulator.DeltaSpeed);
            });
        }
        
        /// <summary>
        /// Error handler.
        /// </summary>
        /// <param name="sender">Event invoker object.</param>
        /// <param name="e">Event arguments.</param>
        public void ErrorHandler(object sender, EventArgs e)
        {
            CommonHandler(sender, e, PrintMenu, () =>
            {
                var args = (ErrorEventArgs)e;
                Console.WriteLine(args.Message);
            });
        }

        /// <summary>
        /// Exit simulation handler.
        /// </summary>
        /// <param name="sender">Event invoker object.</param>
        /// <param name="e">Event arguments.</param>
        public void ExitSimulationHandler(object sender, EventArgs e)
        {
            CommonHandler(sender, e, null, () =>
            {
                Console.WriteLine("Exit simutation.");
            });
        }

        /// <summary>
        /// Fail simulation handler.
        /// </summary>
        /// <param name="sender">Event invoker object.</param>
        /// <param name="e">Event arguments.</param>
        public void FailSimulationHandler(object sender, EventArgs e)
        {
            CommonHandler(sender, e, null, () =>
            {
                Console.WriteLine("Fail simulation.");
            });
        }

        /// <summary>
        /// Increase height handler.
        /// </summary>
        /// <param name="sender">Event invoker object.</param>
        /// <param name="e">Event argumets.</param>
        public void IncreaseHeightHandler(object sender, EventArgs e)
        {
            CommonHandler(sender, e, PrintMenu, () =>
            {
                var simulator = (AbstructSimulator)sender;
                Console.WriteLine("Airplain {0} increase height by {1} meters.", simulator.Model.Name, simulator.DeltaHeight);
            });
        }

        /// <summary>
        /// Increase speed handler.
        /// </summary>
        /// <param name="sender">Event invoker object.</param>
        /// <param name="e">Event arguments.</param>
        public void IncreaseSpeedHandler(object sender, EventArgs e)
        {
            CommonHandler(sender, e, PrintMenu, () =>
            {
                var simulator = (AbstructSimulator)sender;
                Console.WriteLine("Airplain {0} increase speed by {1} km/h.", simulator.Model.Name, simulator.DeltaSpeed);
            });
        }

        /// <summary>
        /// Start new simulation handler.
        /// </summary>
        /// <param name="sender">Event invoker object.</param>
        /// <param name="e">Event arguments.</param>
        public void StartNewSimulationHandler(object sender, EventArgs e)
        {
            CommonHandler(sender, e, PrintMenu, () =>
            {
                Console.WriteLine("Start new simulation.");
            });
        }

        /// <summary>
        /// Success simulation handler.
        /// </summary>
        /// <param name="sender">Event invoker object.</param>
        /// <param name="e">Event arguments.</param>
        public void SuccessSimulationHandler(object sender, EventArgs e)
        {
            CommonHandler(sender, e, null, () =>
            {
                Console.WriteLine("Simulation success.");
            });
        }
        
        /// <summary>
        /// Turbo decrease height handler.
        /// </summary>
        /// <param name="sender">Event invoker object.</param>
        /// <param name="e">Event arguments.</param>
        public void TurboDecreaseHeightHandler(object sender, EventArgs e)
        {
            CommonHandler(sender, e, PrintMenu, () =>
            {
                var simulator = (AbstructSimulator)sender;
                Console.WriteLine("Airplain {0} decrease height by {1} meters.", simulator.Model.Name, simulator.DeltaTurboHeight);
            });
        }

        /// <summary>
        /// Turbo decrease speed handler.
        /// </summary>
        /// <param name="sender">Event invoker object.</param>
        /// <param name="e">Event arguments.</param>
        public void TurboDecreaseSpeedHandler(object sender, EventArgs e)
        {
            CommonHandler(sender, e, PrintMenu, () =>
            {
                var simulator = (AbstructSimulator)sender;
                Console.WriteLine("Airplain {0} decrease speed by {1} km/h.", simulator.Model.Name, simulator.DeltaTurboSpeed);
            });
        }

        /// <summary>
        /// Turbo increase height handler.
        /// </summary>
        /// <param name="sender">Event invoker arguments.</param>
        /// <param name="e">Event arguments.</param>
        public void TurboIncreaseHeightHandler(object sender, EventArgs e)
        {
            CommonHandler(sender, e, PrintMenu, () =>
            {
                var simulator = (AbstructSimulator)sender;
                Console.WriteLine("Airplain {0} increase height by {1} meters.", simulator.Model.Name, simulator.DeltaTurboHeight);
            });
        }

        /// <summary>
        /// Turbo increase speed handler.
        /// </summary>
        /// <param name="sender">Event invoker object.</param>
        /// <param name="e">Event arguments.</param>
        public void TurboIncreaseSpeedHandler(object sender, EventArgs e)
        {
            CommonHandler(sender, e, PrintMenu, () =>
            {
                var simulator = (AbstructSimulator)sender;
                Console.WriteLine("Airplain {0} increase speed by {1} km/h.", simulator.Model.Name, simulator.DeltaTurboSpeed);
            });
        }

        /// <summary>
        /// Print message handler.
        /// </summary>
        /// <param name="sender">Event invoker object.</param>
        /// <param name="e">Event argumets.</param>
        public void PrintMessageHandler(object sender, EventArgs e)
        {
            var args = (MessageEventArgs)e;
            Console.WriteLine(args.Message);
        }

        /// <summary>
        /// Change penalty points handler.
        /// </summary>
        /// <param name="sender">Event </param>
        /// <param name="e"></param>
        public void ChangePenaltyPointsHandler(object sender, EventArgs e)
        {
            CommonHandler(sender, e, null, () =>
            {
                var simulator = (AbstructSimulator)sender;
                var cursorLeft = Console.CursorLeft;
                var cursorTop = Console.CursorTop;
                Console.SetCursorPosition(_cursorLeft, _cursorTop);
                Console.WriteLine(new String(' ', 80));
                Console.SetCursorPosition(_cursorLeft, _cursorTop);
                PrintPenaltyPoints(simulator);
                Console.SetCursorPosition(cursorLeft, cursorTop);
            });
        }

        /// <summary>
        /// Refresh view handler.
        /// </summary>
        /// <param name="sender">Event invoker object.</param>
        /// <param name="e">Event argumets.</param>
        public void RefreshViewHandler(object sender, EventArgs e)
        {
            CommonHandler(sender, e, PrintMenu, () => { });
        }

        // Additional event handlers

        /// <summary>
        /// Add dispatcher handler.
        /// </summary>
        /// <param name="sender">Event invoker object.</param>
        /// <param name="e">Event argumets.</param>
        public void AddDispatcher(object sender, EventArgs e)
        {
            CommonHandler(sender, e, PrintMenu, () =>
            {
                var simulator = (AirplainSimulator)sender;
                Console.Write("Enter new dispatcher name: ");
                var name = Console.ReadLine().Trim();
                if (!name.Any()) throw new Exception("Incorrect dispatcher name.");
                if (simulator.Dispatchers.Any() && simulator.Dispatchers.Find(p => p.Name == name) != null)
                    throw new Exception("Dispatcher with this name is already exists.");
                var dispatcher = new Dispatcher(name, AirplainSimulator.MaxSpeed);
                if (simulator.Model.Speed > 0) dispatcher.CalculateRecommendedHeight(simulator.Model);
                simulator.SubscribeDispatcher(dispatcher);
                simulator.Dispatchers.Add(dispatcher);
                RefreshViewHandler(sender, e);
            });
        }

        /// <summary>
        /// Remove dispatcher handler.
        /// </summary>
        /// <param name="sender">Event invoker object.</param>
        /// <param name="e">Event argumets.</param>
        public void RemoveDispatcher(object sender, EventArgs e)
        {
            CommonHandler(sender, e, PrintMenu, () =>
            {
                var simulator = (AirplainSimulator)sender;
                if (!simulator.Dispatchers.Any()) throw new Exception("Dispatcher list is empty.");
                if (simulator.Model.Speed > 0 && simulator.Dispatchers.Count <= AirplainSimulator.DispatchersMinCount)
                    throw new Exception(String.Format("Airplain can\'t have less then {0} dispatchers in the fly.", AirplainSimulator.DispatchersMinCount));
                Console.Write("Enter deletable dispatcher name: ");
                var name = Console.ReadLine().Trim();
                if (!name.Any()) throw new Exception("Incorrect dispatcher name.");
                var dispatcher = simulator.Dispatchers.Find(p => p.Name == name);
                if (dispatcher == null) throw new Exception("Not found dispatcher with this name in dispatcher list.");
                simulator.UnsubscribeDispatcher(dispatcher);
                simulator.Dispatchers.Remove(dispatcher);
                RefreshViewHandler(sender, e);
            });
        }
    }
}