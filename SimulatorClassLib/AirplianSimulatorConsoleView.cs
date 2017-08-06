using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorClassLib
{
    public class AirplianSimulatorConsoleView : IVieweble
    {
        private int _cursorLeft;
        private int _cursorTop;

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

        private void PrintPenaltyPoints(AbstructSimulator simulator)
        {
            Console.WriteLine("Penalty points: {0}/{1}", simulator.PenaltyPoints, simulator.MaxPenaltyPoints);
        }

        private void PrintModel(AbstructSimulator simulator)
        {
            Console.WriteLine(simulator.Model);
        }

        private void PrintMenu(object sender, EventArgs e)
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

        private void CommonHandler(object sender, EventArgs e, Action<object, EventArgs> menu, Action action)
        {
            if (sender == null) throw new Exception("Sender reference is null.");
            if (e == null) throw new Exception("Event arguments reference is null.");
            if (action == null) throw new Exception("Action reference is null.");
            if (sender as AbstructSimulator == null) throw new Exception("Sender incompatible type.");
            if (menu != null) menu(sender, e);
            action();
        }

        public void DecreaseHeightHandler(object sender, EventArgs e)
        {
            CommonHandler(sender, e, PrintMenu, () =>
            {
                var simulator = (AbstructSimulator)sender;
                Console.WriteLine("Airplain {0} decrease height by {1} meters.", simulator.Model.Name, simulator.DeltaHeight);
            });
        }

        public void DecreaseSpeedHandler(object sender, EventArgs e)
        {
            CommonHandler(sender, e, PrintMenu, () =>
            {
                var simulator = (AbstructSimulator)sender;
                Console.WriteLine("Airplain {0} decrease speed by {1} km/h.", simulator.Model.Name, simulator.DeltaSpeed);
            });
        }
           
        public void ErrorHandler(object sender, EventArgs e)
        {
            CommonHandler(sender, e, PrintMenu, () =>
            {
                var args = (ErrorEventArgs)e;
                Console.WriteLine(args.Message);
            });
        }

        public void ExitSimulationHandler(object sender, EventArgs e)
        {
            CommonHandler(sender, e, null, () =>
            {
                Console.WriteLine("Exit simutation.");
            });
        }

        public void FailSimulationHandler(object sender, EventArgs e)
        {
            CommonHandler(sender, e, null, () =>
            {
                Console.WriteLine("Fail simulation.");
            });
        }

        public void IncreaseHeightHandler(object sender, EventArgs e)
        {
            CommonHandler(sender, e, PrintMenu, () =>
            {
                var simulator = (AbstructSimulator)sender;
                Console.WriteLine("Airplain {0} increase height by {1} meters.", simulator.Model.Name, simulator.DeltaHeight);
            });
        }

        public void IncreaseSpeedHandler(object sender, EventArgs e)
        {
            CommonHandler(sender, e, PrintMenu, () =>
            {
                var simulator = (AbstructSimulator)sender;
                Console.WriteLine("Airplain {0} increase speed by {1} km/h.", simulator.Model.Name, simulator.DeltaSpeed);
            });
        }

        public void StartNewSimulationHandler(object sender, EventArgs e)
        {
            CommonHandler(sender, e, PrintMenu, () =>
            {
                Console.WriteLine("Start new simulation.");
            });
        }

        public void SuccessSimulationHandler(object sender, EventArgs e)
        {
            CommonHandler(sender, e, null, () =>
            {
                Console.WriteLine("Simulation success.");
            });
        }

        public void TurboDecreaseHeightHandler(object sender, EventArgs e)
        {
            CommonHandler(sender, e, PrintMenu, () =>
            {
                var simulator = (AbstructSimulator)sender;
                Console.WriteLine("Airplain {0} decrease height by {1} meters.", simulator.Model.Name, simulator.DeltaTurboHeight);
            });
        }

        public void TurboDecreaseSpeedHandler(object sender, EventArgs e)
        {
            CommonHandler(sender, e, PrintMenu, () =>
            {
                var simulator = (AbstructSimulator)sender;
                Console.WriteLine("Airplain {0} decrease speed by {1} km/h.", simulator.Model.Name, simulator.DeltaTurboSpeed);
            });
        }

        public void TurboIncreaseHeightHandler(object sender, EventArgs e)
        {
            CommonHandler(sender, e, PrintMenu, () =>
            {
                var simulator = (AbstructSimulator)sender;
                Console.WriteLine("Airplain {0} increase height by {1} meters.", simulator.Model.Name, simulator.DeltaTurboHeight);
            });
        }

        public void TurboIncreaseSpeedHandler(object sender, EventArgs e)
        {
            CommonHandler(sender, e, PrintMenu, () =>
            {
                var simulator = (AbstructSimulator)sender;
                Console.WriteLine("Airplain {0} increase speed by {1} km/h.", simulator.Model.Name, simulator.DeltaTurboSpeed);
            });
        }

        public void PrintMessageHandler(object sender, EventArgs e)
        {
            var args = (MessageEventArgs)e;
            Console.WriteLine(args.Message);
        }

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

        public void RefreshViewHandler(object sender, EventArgs e)
        {
            CommonHandler(sender, e, PrintMenu, () => { });
        }

        // Additional event handlers

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