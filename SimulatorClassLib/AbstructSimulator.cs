using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorClassLib
{
    /// <summary>
    /// Abstruct flying simulator.
    /// </summary>
    public abstract class AbstructSimulator
    {
        /// <summary>
        /// Flying model.
        /// </summary>
        private AbstructFlyingModel _model;

        /// <summary>
        /// Simulator view.
        /// </summary>
        private IVieweble _view;

        /// <summary>
        /// Simulation program.
        /// </summary>
        private AbstractSimulationProgram _program;

        /// <summary>
        /// Simulator controller.
        /// </summary>
        private IControllable _controller;

        /// <summary>
        /// Model increase / decrease delta speed.
        /// </summary>
        private int _deltaSpeed;

        /// <summary>
        /// Model turbo increase / decrease delta speed.
        /// </summary>
        private int _deltaTurboSpeed;

        /// <summary>
        /// Model increase / decrease delta height.
        /// </summary>
        private int _deltaHeight;

        /// <summary>
        /// Model turbo increase / decrease delta height.
        /// </summary>
        private int _deltaTurboHeight;

        /// <summary>
        /// Penatly points.
        /// </summary>
        private int _penaltyPoints;

        /// <summary>
        /// Maximal count of penalty points.
        /// </summary>
        private int _maxPenaltyPoints;

        /// <summary>
        /// Actions distionary.
        /// </summary>
        private Dictionary<int, Action> _actions;

        /// <summary>
        /// Simulation flag.
        /// </summary>
        private bool _isSimulation;

        /// <summary>
        /// Increase speed event.
        /// </summary>
        public event EventHandler IncreaseSpeed;

        /// <summary>
        /// Decrease speed event.
        /// </summary>
        public event EventHandler DecreaseSpeed;

        /// <summary>
        /// Increase height event.
        /// </summary>
        public event EventHandler IncreaseHeight;

        /// <summary>
        /// Decrease height event.
        /// </summary>
        public event EventHandler DecreaseHeight;

        /// <summary>
        /// Turbo increase speed event.
        /// </summary>
        public event EventHandler TurboIncreaseSpeed;

        /// <summary>
        /// Turbo decrease speed event.
        /// </summary>
        public event EventHandler TurboDecreaseSpeed;

        /// <summary>
        /// Turbo increase height event.
        /// </summary>
        public event EventHandler TurboIncreaseHeight;

        /// <summary>
        /// Turbo decrease height event.
        /// </summary>
        public event EventHandler TurboDecreaseHeight;

        /// <summary>
        /// Start new simulation event.
        /// </summary>
        public event EventHandler StartNewSimulation;

        /// <summary>
        /// Exit simualtion event.
        /// </summary>
        public event EventHandler ExitSimulation;

        /// <summary>
        /// Success simulaition event.
        /// </summary>
        public event EventHandler SuccessSimulation;

        /// <summary>
        /// Fail simulation event.
        /// </summary>
        public event EventHandler FailSimulation;

        /// <summary>
        /// Simulator error virtual event.
        /// </summary>
        public virtual event EventHandler Error;

        /// <summary>
        /// Change simulator state event.
        /// </summary>
        public event EventHandler ChangeState;

        /// <summary>
        /// Change simulator penalty points event.
        /// </summary>
        public event EventHandler ChangePenaltyPoints;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="maxPenaltyPoints">Maximal count of penalty points.</param>
        public AbstructSimulator(int maxPenaltyPoints)
        {
            this.MaxPenaltyPoints = maxPenaltyPoints;
        }

        /// <summary>
        /// Flying model.
        /// </summary>
        public AbstructFlyingModel Model
        {
            get
            {
                return _model;
            }

            set
            {
                if (value == null) throw new NullReferenceException("Model reference is null.");
                this._model = value;
            }
        }

        /// <summary>
        /// Flying simulator viewer.
        /// </summary>
        public IVieweble View
        {
            get
            {
                return _view;
            }

            set
            {
                if (value == null) throw new NullReferenceException("View reference is null.");
                this._view = value;
            }
        }

        /// <summary>
        /// Simulation program.
        /// </summary>
        public AbstractSimulationProgram Program
        {
            get
            {
                return _program;
            }

            set
            {
                if (value == null) throw new NullReferenceException("Program reference is null.");
                _program = value;
            }
        }

        /// <summary>
        /// Simulator controller.
        /// </summary>
        public IControllable Controller
        {
            get
            {
                return _controller;
            }

            set
            {
                if (value == null) throw new NullReferenceException("Controller reference is null.");
                _controller = value;
            }
        }

        /// <summary>
        /// Model increase / decrease speed delta.
        /// </summary>
        public int DeltaSpeed
        {
            get
            {
                return _deltaSpeed;
            }

            set
            {
                this._deltaSpeed = value;
            }
        }

        /// <summary>
        /// Model turbo increase / decrease speed delta.
        /// </summary>
        public int DeltaTurboSpeed
        {
            get
            {
                return _deltaTurboSpeed;
            }

            set
            {
                this._deltaTurboSpeed = value;
            }
        }

        /// <summary>
        /// Model increase / decrease height delta.
        /// </summary>
        public int DeltaHeight
        {
            get
            {
                return _deltaHeight;
            }

            set
            {
                this._deltaHeight = value;
            }
        }

        /// <summary>
        /// Model turbo increase / decrease height delta.
        /// </summary>
        public int DeltaTurboHeight
        {
            get
            {
                return _deltaTurboHeight;
            }

            set
            {
                this._deltaTurboHeight = value;
            }
        }

        /// <summary>
        /// Actions dictionary.
        /// </summary>
        public Dictionary<int, Action> Actions
        {
            get
            {
                return _actions;
            }

            set
            {
                if (value == null) throw new NullReferenceException("Actions reference is null.");
                this._actions = value;
            }
        }

        /// <summary>
        /// Simulation flag.
        /// </summary>
        public bool IsSimulation
        {
            get
            {
                return _isSimulation;
            }

            set
            {
                this._isSimulation = value;
            }
        }

        /// <summary>
        /// Penalty points.
        /// </summary>
        public int PenaltyPoints
        {
            get
            {
                return _penaltyPoints;
            }

            set
            {
                if (value < 0) throw new SimulatorPenaltyPointsException("Incorrect penalty points value.");
                this._penaltyPoints = value;
            }
        }

        /// <summary>
        /// Maximal count of penalty points.
        /// </summary>
        public int MaxPenaltyPoints
        {
            get
            {
                return _maxPenaltyPoints;
            }

            protected set
            {
                if (value < 0) throw new SimulatorMaxPenaltyPointsException("Incorrect max penalty points value.");
                this._maxPenaltyPoints = value;
            }
        }

        /// <summary>
        /// Increase speed event invoker.
        /// </summary>
        public virtual void OnIncreseSpeed()
        {
            if (IncreaseSpeed != null)
                IncreaseSpeed(this, EventArgs.Empty);
        }

        /// <summary>
        /// Decrease speed event invoker.
        /// </summary>
        public virtual void OnDecreaseSpeed()
        {
            if (DecreaseSpeed != null)
                DecreaseSpeed(this, EventArgs.Empty);
        }

        /// <summary>
        /// Increase height event invoker.
        /// </summary>
        public virtual void OnIncreaseHeight()
        {
            if (IncreaseHeight != null)
                IncreaseHeight(this, EventArgs.Empty);
        }

        /// <summary>
        /// Decrease height event invoker.
        /// </summary>
        public virtual void OnDecreaseHeight()
        {
            if (DecreaseHeight != null)
                DecreaseHeight(this, EventArgs.Empty);
        }

        /// <summary>
        /// Turbo increase speed event invoker.
        /// </summary>
        public virtual void OnTurboIncreaseSpeed()
        {
            if (TurboIncreaseSpeed != null)
                TurboIncreaseSpeed(this, EventArgs.Empty);
        }

        /// <summary>
        /// Turbo decrease speed event invoker.
        /// </summary>
        public virtual void OnTurboDecreaseSpeed()
        {
            if (TurboDecreaseSpeed != null)
                TurboDecreaseSpeed(this, EventArgs.Empty);
        }

        /// <summary>
        /// Turbo increase height event invoker.
        /// </summary>
        public virtual void OnTurboIncreaseHeight()
        {
            if (TurboIncreaseHeight != null)
                TurboIncreaseHeight(this, EventArgs.Empty);
        }

        /// <summary>
        /// Turbo decrease height event invoker.
        /// </summary>
        public virtual void OnTurboDecreaseHeight()
        {
            if (TurboDecreaseHeight != null)
                TurboDecreaseHeight(this, EventArgs.Empty);
        }

        /// <summary>
        /// Start simulator event invoker.
        /// </summary>
        public virtual void OnStartNewSimulation()
        {
            Model.Height = 0;
            Model.Speed = 0;
            Program.RestartProgram();
            if (StartNewSimulation != null)
                StartNewSimulation(this, EventArgs.Empty);
        }

        /// <summary>
        /// Exit simulator event invoker.
        /// </summary>
        public virtual void OnExitSimulation()
        {
            IsSimulation = false;
            if (ExitSimulation != null)
                ExitSimulation(this, EventArgs.Empty);
        }

        /// <summary>
        /// Success simulation event invoker.
        /// </summary>
        public virtual void OnSuccessSimulation()
        {
            IsSimulation = false;
            if (SuccessSimulation != null)
                SuccessSimulation(this, EventArgs.Empty);
        }

        /// <summary>
        /// Fail simulation event invoker.
        /// </summary>
        public virtual void OnFailSimulation()
        {
            IsSimulation = false;
            if (FailSimulation != null)
                FailSimulation(this, EventArgs.Empty);
        }

        /// <summary>
        /// Error event invoker.
        /// </summary>
        public virtual void OnError()
        {
            if (Error != null)
                Error(this, EventArgs.Empty);
        }

        /// <summary>
        /// Change state event invoker.
        /// </summary>
        public virtual void OnChangeState()
        {
            if (ChangeState != null)
                ChangeState(this, EventArgs.Empty);
        }

        /// <summary>
        /// Change penalty points event invoker.
        /// </summary>
        public virtual void OnChangePenaltyPoints()
        {
            if (ChangePenaltyPoints != null)
                ChangePenaltyPoints(this, EventArgs.Empty);
        }

        /// <summary>
        /// Add penatly points event handler.
        /// </summary>
        /// <param name="sender">Object than invoke event.</param>
        /// <param name="e">Event arguments.</param>
        public virtual void AddPenaltyPointsHandler(object sender, EventArgs e)
        {
            try
            {
                if (e == null) throw new NullReferenceException();
                if (e as PenaltyPointsEventArgs == null) throw new InvalidCastException();
                var args = (PenaltyPointsEventArgs)e;
                PenaltyPoints += args.PenaltyPoints;
                OnChangePenaltyPoints();
            }
            catch (NullReferenceException ex)
            {
                throw new AddPenaltyPointsException("Event agruments reference is null.", ex);
            }
            catch (InvalidCastException ex)
            {
                throw new AddPenaltyPointsException("Incompatible type of event arguments.", ex);
            }
        }

        /// <summary>
        /// Initialize aciton dictionary.
        /// </summary>
        public virtual void InitializeActionDictionary()
        {
            Actions = new Dictionary<int, Action>();
            Actions.Add(SimulatorControls.startNewSimulation, OnStartNewSimulation);
            Actions.Add(SimulatorControls.exitSimulation, OnExitSimulation);
            Actions.Add(SimulatorControls.increaseHeight, OnIncreaseHeight);
            Actions.Add(SimulatorControls.decreaseHeight, OnDecreaseHeight);
            Actions.Add(SimulatorControls.decreaseSpeed, OnDecreaseSpeed);
            Actions.Add(SimulatorControls.increaseSpeed, OnIncreseSpeed);
            Actions.Add(SimulatorControls.turboIncreaseHeight, OnTurboIncreaseHeight);
            Actions.Add(SimulatorControls.turboDecreaseHeight, OnTurboDecreaseHeight);
            Actions.Add(SimulatorControls.turboDecreaseSpeed, OnTurboDecreaseSpeed);
            Actions.Add(SimulatorControls.turboIncreaseSpeed, OnTurboIncreaseSpeed);
        }

        /// <summary>
        /// Subscribe handlers to events.
        /// </summary>
        public virtual void InitializeHandlers()
        {
            IncreaseSpeed += Model.IncreaseSpeedHandler;
            IncreaseSpeed += View.IncreaseSpeedHandler;

            DecreaseSpeed += Model.DecreaseSpeedHandler;
            DecreaseSpeed += View.DecreaseSpeedHandler;

            IncreaseHeight += Model.IncreaseHeightHandler;
            IncreaseHeight += View.IncreaseHeightHandler;

            DecreaseHeight += Model.DecreaseHeightHandler;
            DecreaseHeight += View.DecreaseHeightHandler;

            TurboIncreaseSpeed += Model.TurboIncreaseSpeedHandler;
            TurboIncreaseSpeed += View.TurboIncreaseSpeedHandler;

            TurboDecreaseSpeed += Model.TurboDecreaseSpeedHandler;
            TurboDecreaseSpeed += View.TurboDecreaseSpeedHandler;

            TurboIncreaseHeight += Model.TurboIncreaseHeightHandler;
            TurboIncreaseHeight += View.TurboIncreaseHeightHandler;

            TurboDecreaseHeight += Model.TurboDecreaseHeightHandler;
            TurboDecreaseHeight += View.TurboDecreaseHeightHandler;

            StartNewSimulation += View.StartNewSimulationHandler;
            ExitSimulation += View.ExitSimulationHandler;
            SuccessSimulation += View.SuccessSimulationHandler;
            FailSimulation += View.FailSimulationHandler;
            Error += View.ErrorHandler;
            ChangePenaltyPoints += View.ChangePenaltyPointsHandler;

            ChangeState += Program.ChangeStateHandler;

        }

        /// <summary>
        /// Run simulation.
        /// </summary>
        public virtual void Run()
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
                        if (PenaltyPoints >= MaxPenaltyPoints) OnFailSimulation();
                        if (Program.IsDone) OnSuccessSimulation();
                    }
                }
                catch (Exception ex)
                {
                    if (Error != null) Error(this, new ErrorEventArgs(ex.Message));
                }
            }
        }
    }
}
