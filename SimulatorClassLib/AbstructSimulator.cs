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
        private AbstructFlyingModel _model;
        private IVieweble _view;
        private AbstractSimulationProgram _program;
        private IControllable _controller;

        private int _deltaSpeed;
        private int _deltaTurboSpeed;
        private int _deltaHeight;
        private int _deltaTurboHeight;

        private int _penaltyPoints;
        private int _maxPenaltyPoints;

        private Dictionary<int, Action> _actions;
        private bool _isSimulation;

        public event EventHandler IncreaseSpeed;
        public event EventHandler DecreaseSpeed;
        public event EventHandler IncreaseHeight;
        public event EventHandler DecreaseHeight;
        public event EventHandler TurboIncreaseSpeed;
        public event EventHandler TurboDecreaseSpeed;
        public event EventHandler TurboIncreaseHeight;
        public event EventHandler TurboDecreaseHeight;
        public event EventHandler StartNewSimulation;
        public event EventHandler ExitSimulation;
        public event EventHandler SuccessSimulation;
        public event EventHandler FailSimulation;
        public virtual event EventHandler Error;
        public event EventHandler ChangeState;
        public event EventHandler ChangePenaltyPoints;

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
                if (value == null) throw new Exception("Incorrect flying model.");
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
                if (value == null) throw new Exception("Incorrect flying simulator viewer.");
                this._view = value;
            }
        }

        public AbstractSimulationProgram Program
        {
            get
            {
                return _program;
            }

            set
            {
                _program = value;
            }
        }

        public IControllable Controller
        {
            get
            {
                return _controller;
            }

            set
            {
                _controller = value;
            }
        }

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

        public Dictionary<int, Action> Actions
        {
            get
            {
                return _actions;
            }

            set
            {
                this._actions = value;
            }
        }

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

        public int PenaltyPoints
        {
            get
            {
                return _penaltyPoints;
            }

            set
            {
                this._penaltyPoints = value;
            }
        }

        public int MaxPenaltyPoints
        {
            get
            {
                return _maxPenaltyPoints;
            }

            protected set
            {
                this._maxPenaltyPoints = value;
            }
        }

        public virtual void OnIncreseSpeed()
        {
            if (IncreaseSpeed != null)
                IncreaseSpeed(this, EventArgs.Empty);
        }

        public virtual void OnDecreaseSpeed()
        {
            if (DecreaseSpeed != null)
                DecreaseSpeed(this, EventArgs.Empty);
        }

        public virtual void OnIncreaseHeight()
        {
            if (IncreaseHeight != null)
                IncreaseHeight(this, EventArgs.Empty);
        }

        public virtual void OnDecreaseHeight()
        {
            if (DecreaseHeight != null)
                DecreaseHeight(this, EventArgs.Empty);
        }

        public virtual void OnTurboIncreaseSpeed()
        {
            if (TurboIncreaseSpeed != null)
                TurboIncreaseSpeed(this, EventArgs.Empty);
        }

        public virtual void OnTurboDecreaseSpeed()
        {
            if (TurboDecreaseSpeed != null)
                TurboDecreaseSpeed(this, EventArgs.Empty);
        }

        public virtual void OnTurboIncreaseHeight()
        {
            if (TurboIncreaseHeight != null)
                TurboIncreaseHeight(this, EventArgs.Empty);
        }

        public virtual void OnTurboDecreaseHeight()
        {
            if (TurboDecreaseHeight != null)
                TurboDecreaseHeight(this, EventArgs.Empty);
        }

        public virtual void OnStartNewSimulation()
        {
            Model.Height = 0;
            Model.Speed = 0;
            Program.RestartProgram();
            if (StartNewSimulation != null)
                StartNewSimulation(this, EventArgs.Empty);
        }

        public virtual void OnExitSimulation()
        {
            IsSimulation = false;
            if (ExitSimulation != null)
                ExitSimulation(this, EventArgs.Empty);
        }

        public virtual void OnSuccessSimulation()
        {
            IsSimulation = false;
            if (SuccessSimulation != null)
                SuccessSimulation(this, EventArgs.Empty);
        }

        public virtual void OnFailSimulation()
        {
            IsSimulation = false;
            if (FailSimulation != null)
                FailSimulation(this, EventArgs.Empty);
        }

        public virtual void OnError()
        {
            if (Error != null)
                Error(this, EventArgs.Empty);
        }

        public virtual void OnChangeState()
        {
            if (ChangeState != null)
                ChangeState(this, EventArgs.Empty);
        }

        public virtual void OnChangePenaltyPoints()
        {
            if (ChangePenaltyPoints != null)
                ChangePenaltyPoints(this, EventArgs.Empty);
        }

        public virtual void AddPenaltyPointsHandler(object sender, EventArgs e)
        {
            var args = (PenaltyPointsEventArgs)e;
            PenaltyPoints += args.PenaltyPoints;
            OnChangePenaltyPoints();
        }

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
