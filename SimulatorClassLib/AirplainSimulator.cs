using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorClassLib
{
    public class AirplainSimulator : AbstructSimulator
    {
        /// <summary>
        /// List of dispatchers.
        /// </summary>
        private List<Dispatcher> _dispatchers;

        /// <summary>
        /// Airplain max speed.
        /// </summary>
        private const int maxSpeed = 1000;

        /// <summary>
        /// Minimum amount of dispatchers.
        /// </summary>
        private const int dispatchersMinCount = 2;

        /// <summary>
        /// Error event.
        /// </summary>
        public override event EventHandler Error;

        /// <summary>
        /// List of dispatchers.
        /// </summary>
        public List<Dispatcher> Dispatchers
        {
            get
            {
                return _dispatchers;
            }

            private set
            {
                if (value == null) throw new NullReferenceException("Dispatchers reference is null.");
                this._dispatchers = value;
            }
        }

        /// <summary>
        /// Max model speed.
        /// </summary>
        public static int MaxSpeed
        {
            get
            {
                return maxSpeed;
            }
        }

        /// <summary>
        /// Mininal amount of dispatchers.
        /// </summary>
        public static int DispatchersMinCount
        {
            get
            {
                return dispatchersMinCount;
            }
        }

        /// <summary>
        /// Add dispatcher event.
        /// </summary>
        public event EventHandler AddDispatcher;

        /// <summary>
        /// Remove dispatcher event.
        /// </summary>
        public event EventHandler RemoveDispatcher;

        /// <summary>
        /// Increase speed event invoker.
        /// </summary>
        public override void OnIncreseSpeed()
        {
            if (Dispatchers.Count < AirplainSimulator.DispatchersMinCount) throw new AirplainFlyException(String.Format("Dispatchers count less than {0}.", AirplainSimulator.DispatchersMinCount));
            base.OnIncreseSpeed();
        }

        /// <summary>
        /// Decrease speed event invoker.
        /// </summary>
        public override void OnDecreaseSpeed()
        {
            if (Dispatchers.Count < AirplainSimulator.DispatchersMinCount) throw new AirplainFlyException(String.Format("Dispatchers count less than {0}.", AirplainSimulator.DispatchersMinCount));
            base.OnDecreaseSpeed();
        }

        /// <summary>
        /// Increase height event invoker.
        /// </summary>
        public override void OnIncreaseHeight()
        {
            if (Dispatchers.Count < AirplainSimulator.DispatchersMinCount) throw new AirplainFlyException(String.Format("Dispatchers count less than {0}.", AirplainSimulator.DispatchersMinCount));
            if (Model.Speed <= 0) throw new AirplainFlyException("Incorrect increase height operation.");
            base.OnIncreaseHeight();
        }

        /// <summary>
        /// Decrease height event invoker.
        /// </summary>
        public override void OnDecreaseHeight()
        {
            if (Dispatchers.Count < AirplainSimulator.DispatchersMinCount) throw new AirplainFlyException(String.Format("Dispatchers count less than {0}.", AirplainSimulator.DispatchersMinCount));
            if (Model.Speed <= 0) throw new AirplainFlyException("Incorrect decrease height operataion.");
            base.OnDecreaseHeight();
        }

        /// <summary>
        /// Turbo increase speed event invoker.
        /// </summary>
        public override void OnTurboIncreaseSpeed()
        {
            if (Dispatchers.Count < AirplainSimulator.DispatchersMinCount) throw new AirplainFlyException(String.Format("Dispatchers count less than {0}.", AirplainSimulator.DispatchersMinCount));
            base.OnTurboIncreaseSpeed();
        }

        /// <summary>
        /// Turbo decrease speed event invoker.
        /// </summary>
        public override void OnTurboDecreaseSpeed()
        {
            if (Dispatchers.Count < AirplainSimulator.DispatchersMinCount) throw new AirplainFlyException(String.Format("Dispatchers count less than {0}.", AirplainSimulator.DispatchersMinCount));
            base.OnTurboDecreaseSpeed();
        }

        /// <summary>
        /// Turbo increase height invoker.
        /// </summary>
        public override void OnTurboIncreaseHeight()
        {
            if (Dispatchers.Count < AirplainSimulator.DispatchersMinCount) throw new AirplainFlyException(String.Format("Dispatchers count less than {0}.", AirplainSimulator.DispatchersMinCount));
            if (Model.Speed <= 0) throw new AirplainFlyException("Incorrect turbo increase height operation.");
            base.OnTurboIncreaseHeight();
        }

        /// <summary>
        /// Turbo decrease height event invoker.
        /// </summary>
        public override void OnTurboDecreaseHeight()
        {
            if (Dispatchers.Count < AirplainSimulator.DispatchersMinCount) throw new AirplainFlyException(String.Format("Dispatchers count less than {0}.", AirplainSimulator.DispatchersMinCount));
            if (Model.Speed <= 0) throw new AirplainFlyException("Incorrect turbo decrease height operation.");
            base.OnTurboDecreaseHeight();
        }

        /// <summary>
        /// Add dispatcher event invoker.
        /// </summary>
        public void OnAddDispatcher()
        {
            if (AddDispatcher != null) AddDispatcher(this, EventArgs.Empty);
        }

        /// <summary>
        /// Remove dispatcher event invoker.
        /// </summary>
        public void OnRemoveDispatcher()
        {
            if (RemoveDispatcher != null) RemoveDispatcher(this, EventArgs.Empty);
        }

        /// <summary>
        /// Start new simulation event invoker.
        /// </summary>
        public override void OnStartNewSimulation()
        {
            Dispatchers.ForEach(UnsubscribeDispatcher);
            Dispatchers = new List<Dispatcher>();
            base.OnStartNewSimulation();
        }

        /// <summary>
        /// Error event invoker.
        /// </summary>
        /// <param name="message">Error message.</param>
        public void OnError(string message)
        {
            if (Error != null) Error(this, new ErrorEventArgs(message));
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="maxPenaltyPoints">Max penalty points value.</param>
        public AirplainSimulator(int maxPenaltyPoints) : base(maxPenaltyPoints)
        {
            this.Dispatchers = new List<Dispatcher>();
        }

        /// <summary>
        /// Subscribe handlers to events.
        /// </summary>
        public override void InitializeHandlers()
        {
            base.InitializeHandlers();
            AddDispatcher += ((AirplianSimulatorConsoleView)View).AddDispatcher;
            RemoveDispatcher += ((AirplianSimulatorConsoleView)View).RemoveDispatcher;
        }

        /// <summary>
        /// Initialize action dictionary.
        /// </summary>
        public override void InitializeActionDictionary()
        {
            base.InitializeActionDictionary();
            Actions.Add(AirplainSimulatorControls.AddDispatcher, OnAddDispatcher);
            Actions.Add(AirplainSimulatorControls.RemoveDispatcher, OnRemoveDispatcher);
        }

        /// <summary>
        /// Subscribe dispatcher handlers to simulator events
        /// and simulator handlers to dispatcher events.
        /// </summary>
        /// <param name="dispatcher">Dispatcher.</param>
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

        /// <summary>
        /// Unsubscribe dispatcher handlers to simulator events
        /// and simulator handlers to dispatcher events.
        /// </summary>
        /// <param name="dispatcher">Dispatcher.</param>
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

        /// <summary>
        /// Run simulation.
        /// </summary>
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
