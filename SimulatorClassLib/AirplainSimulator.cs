using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorClassLib
{
    public class AirplainSimulator : AbstructSimulator
    {
        private List<Dispatcher> _dispatchers;
        private const int maxSpeed = 1000;
        private const int dispatchersMinCount = 2;

        public override event EventHandler Error;

        public List<Dispatcher> Dispatchers
        {
            get
            {
                return _dispatchers;
            }

            set
            {
                this._dispatchers = value;
            }
        }

        public static int MaxSpeed
        {
            get
            {
                return maxSpeed;
            }
        }

        public static int DispatchersMinCount
        {
            get
            {
                return dispatchersMinCount;
            }
        }

        public event EventHandler AddDispatcher;
        public event EventHandler RemoveDispatcher;

        public override void OnIncreseSpeed()
        {
            if (Dispatchers.Count < AirplainSimulator.DispatchersMinCount) throw new Exception(String.Format("Dispatchers count less than {0}.", AirplainSimulator.DispatchersMinCount));
            base.OnIncreseSpeed();
        }

        public override void OnDecreaseSpeed()
        {
            if (Dispatchers.Count < AirplainSimulator.DispatchersMinCount) throw new Exception(String.Format("Dispatchers count less than {0}.", AirplainSimulator.DispatchersMinCount));
            base.OnDecreaseSpeed();
        }

        public override void OnIncreaseHeight()
        {
            if (Dispatchers.Count < AirplainSimulator.DispatchersMinCount) throw new Exception(String.Format("Dispatchers count less than {0}.", AirplainSimulator.DispatchersMinCount));
            if (Model.Speed <= 0) throw new Exception("Incorrect increase height operation.");
            base.OnIncreaseHeight();
        }

        public override void OnDecreaseHeight()
        {
            if (Dispatchers.Count < AirplainSimulator.DispatchersMinCount) throw new Exception(String.Format("Dispatchers count less than {0}.", AirplainSimulator.DispatchersMinCount));
            if (Model.Speed <= 0) throw new Exception("Incorrect decrease height operataion.");
            base.OnDecreaseHeight();
        }

        public override void OnTurboIncreaseSpeed()
        {
            if (Dispatchers.Count < AirplainSimulator.DispatchersMinCount) throw new Exception(String.Format("Dispatchers count less than {0}.", AirplainSimulator.DispatchersMinCount));
            base.OnTurboIncreaseSpeed();
        }

        public override void OnTurboDecreaseSpeed()
        {
            if (Dispatchers.Count < AirplainSimulator.DispatchersMinCount) throw new Exception(String.Format("Dispatchers count less than {0}.", AirplainSimulator.DispatchersMinCount));
            base.OnTurboDecreaseSpeed();
        }

        public override void OnTurboIncreaseHeight()
        {
            if (Dispatchers.Count < AirplainSimulator.DispatchersMinCount) throw new Exception(String.Format("Dispatchers count less than {0}.", AirplainSimulator.DispatchersMinCount));
            if (Model.Speed <= 0) throw new Exception("Incorrect turbo increase height operation.");
            base.OnTurboIncreaseHeight();
        }

        public override void OnTurboDecreaseHeight()
        {
            if (Dispatchers.Count < AirplainSimulator.DispatchersMinCount) throw new Exception(String.Format("Dispatchers count less than {0}.", AirplainSimulator.DispatchersMinCount));
            if (Model.Speed <= 0) throw new Exception("Incorrect turbo decrease height operation.");
            base.OnTurboDecreaseHeight();
        }

        public void OnAddDispatcher()
        {
            if (AddDispatcher != null) AddDispatcher(this, EventArgs.Empty);
        }

        public void OnRemoveDispatcher()
        {
            if (RemoveDispatcher != null) RemoveDispatcher(this, EventArgs.Empty);
        }

        public override void OnStartNewSimulation()
        {
            Dispatchers.ForEach(UnsubscribeDispatcher);
            Dispatchers = new List<Dispatcher>();
            base.OnStartNewSimulation();
        }

        public void OnError(string message)
        {
            if (Error != null) Error(this, new ErrorEventArgs(message));
        }

        public AirplainSimulator(int maxPenaltyPoints) : base(maxPenaltyPoints)
        {
            this.Dispatchers = new List<Dispatcher>();
        }

        public override void InitializeHandlers()
        {
            base.InitializeHandlers();
            if (View as AirplianSimulatorConsoleView == null) throw new Exception("View incompatible type.");
            AddDispatcher += ((AirplianSimulatorConsoleView)View).AddDispatcher;
            RemoveDispatcher += ((AirplianSimulatorConsoleView)View).RemoveDispatcher;
        }

        public override void InitializeActionDictionary()
        {
            base.InitializeActionDictionary();
            Actions.Add(AirplainSimulatorControls.AddDispatcher, OnAddDispatcher);
            Actions.Add(AirplainSimulatorControls.RemoveDispatcher, OnRemoveDispatcher);
        }

        public void SubscribeDispatcher(Dispatcher dispatcher)
        {
            dispatcher.SendMessage += View.PrintMessageHandler;
            dispatcher.AddPenaltyPoints += AddPenaltyPointsHandler;
            IncreaseSpeed += dispatcher.ChangeStateHandler;
            DecreaseSpeed += dispatcher.ChangeStateHandler;
            IncreaseHeight += dispatcher.ChangeStateHandler;
            DecreaseHeight += dispatcher.ChangeStateHandler;
            TurboIncreaseSpeed += dispatcher.ChangeStateHandler;
            TurboDecreaseSpeed += dispatcher.ChangeStateHandler;
            TurboIncreaseHeight += dispatcher.ChangeStateHandler;
            TurboDecreaseHeight += dispatcher.ChangeStateHandler;
        }

        public void UnsubscribeDispatcher(Dispatcher dispatcher)
        {
            dispatcher.SendMessage -= View.PrintMessageHandler;
            dispatcher.AddPenaltyPoints -= AddPenaltyPointsHandler;
            IncreaseSpeed -= dispatcher.ChangeStateHandler;
            DecreaseSpeed -= dispatcher.ChangeStateHandler;
            IncreaseHeight -= dispatcher.ChangeStateHandler;
            DecreaseHeight -= dispatcher.ChangeStateHandler;
            TurboIncreaseSpeed -= dispatcher.ChangeStateHandler;
            TurboDecreaseSpeed -= dispatcher.ChangeStateHandler;
            TurboIncreaseHeight -= dispatcher.ChangeStateHandler;
            TurboDecreaseHeight -= dispatcher.ChangeStateHandler;
        }

        public override void Run()
        {
            OnStartNewSimulation();
            IsSimulation = true;
            while (IsSimulation)
            {
                try
                {
                    var key = Controller.GetControlAction();
                    if (Actions.ContainsKey(key))
                    {
                        Actions[key]();
                        OnChangeState();
                        if (PenaltyPoints >= MaxPenaltyPoints) throw new UnfitToFlyException("Pilot is unfit to fly.");
                        if (Program.IsDone) OnSuccessSimulation();
                    }
                }
                catch (DispatcherChangeStateException ex) when (ex.InnerException is AirplainCrashException)
                {
                    OnError(ex.Message);
                    OnFailSimulation();
                }
                catch (UnfitToFlyException ex)
                {
                    OnError(ex.Message);
                    OnFailSimulation();
                }
                catch (Exception ex)
                {
                    OnError(ex.Message);
                }
            }
        }
    }
}
