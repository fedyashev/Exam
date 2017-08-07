using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorClassLib
{
    /// <summary>
    /// Abstruct flying model for flying simulator.
    /// </summary>
    public abstract class AbstructFlyingModel : IFlyeble
    {
        /// <summary>
        /// Model speed value.
        /// </summary>
        private int _speed;

        /// <summary>
        /// Model height value.
        /// </summary>
        private int _height;

        /// <summary>
        /// Model name value.
        /// </summary>
        private string _name;

        /// <summary>
        /// Construct object with name parameter.
        /// </summary>
        /// <param name="name">Model name.</param>
        public AbstructFlyingModel(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Change model state event.
        /// </summary>
        public event EventHandler ChangeState;

        /// <summary>
        /// Speed value.
        /// </summary>
        public int Speed
        {
            get
            {
                return _speed;
            }

            set
            {
                if (value < 0) throw new ModelSpeedException("Incorrect speed value.");
                this._speed = value;
            }
        }

        /// <summary>
        /// Height value.
        /// </summary>
        public int Height
        {
            get
            {
                return _height;
            }

            set
            {
                if (value < 0) throw new ModelHeightException("Incorrect height value.");
                this._height = value;
            }
        }

        /// <summary>
        /// Name value.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            
            set
            {
                try
                {
                    if (value == null) throw new NullReferenceException();
                    if (!value.Trim().Any()) throw new ArgumentException();
                    this._name = value;
                }
                catch (NullReferenceException ex)
                {
                    throw new ModelNameException("Name string reference is null", ex);
                }
                catch (ArgumentException ex)
                {
                    throw new ModelNameException("Name string is empty.", ex);
                }
            }
        }

        /// <summary>
        ///  Common handler.
        /// </summary>
        /// <param name="sender">Oject that invoke event.</param>
        /// <param name="e">Event arguments.</param>
        /// <param name="action">Function.</param>
        private void CommonHandler(object sender, EventArgs e, Action<AbstructSimulator> action)
        {
            if (sender == null || e == null) throw new NullReferenceException();
            if (sender as AbstructSimulator == null) throw new InvalidCastException("Incorrect sender object.");
            var simulator = (AbstructSimulator)sender;
            if (action != null) action(simulator);
        }

        /// <summary>
        /// Increase model speed handler.
        /// </summary>
        /// <param name="sender">Object that invoke event.</param>
        /// <param name="e">Event arguments.</param>
        public void IncreaseSpeedHandler(object sender, EventArgs e)
        {
            try
            {
                CommonHandler(sender, e, p => Speed += p.DeltaSpeed);
            }
            catch (NullReferenceException ex)
            {
                throw new ModelIncreaseSpeedException("Handler parameters refences is null.", ex);
            }
            catch (InvalidCastException ex)
            {
                throw new ModelIncreaseSpeedException("Incorrect sender object type.", ex);
            }
            catch (ModelSpeedException ex)
            {
                throw new ModelIncreaseSpeedException("Incorrect speed value.", ex);
            }
        }

        /// <summary>
        /// Decrease model speed handler.
        /// </summary>
        /// <param name="sender">Object.</param>
        /// <param name="e">Event arguments.</param>
        public void DecreaseSpeedHandler(object sender, EventArgs e)
        {
            try
            {
                CommonHandler(sender, e, p => Speed -= p.DeltaSpeed);
            }
            catch (NullReferenceException ex)
            {
                throw new ModelDecreaseSpeedException("Handler parameters refences is null.", ex);
            }
            catch (InvalidCastException ex)
            {
                throw new ModelDecreaseSpeedException("Incorrect sender object type.", ex);
            }
            catch (ModelSpeedException ex)
            {
                throw new ModelDecreaseSpeedException("Incorrect speed value.", ex);
            }
        }

        /// <summary>
        /// Increase model height handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void IncreaseHeightHandler(object sender, EventArgs e)
        {
            try
            {
                CommonHandler(sender, e, p => Height += p.DeltaHeight);
            }
            catch (NullReferenceException ex)
            {
                throw new ModelIncreaseHeightException("Handler parameters refences is null.", ex);
            }
            catch (InvalidCastException ex)
            {
                throw new ModelIncreaseHeightException("Incorrect sender object type.", ex);
            }
            catch (ModelHeightException ex)
            {
                throw new ModelIncreaseHeightException("Incorrect height value.", ex);
            }
        }

        /// <summary>
        /// Decrease height handler.
        /// </summary>
        /// <param name="sender">Object.</param>
        /// <param name="e">Event arguments.</param>
        public void DecreaseHeightHandler(object sender, EventArgs e)
        {
            try
            {
                CommonHandler(sender, e, p => Height -= p.DeltaHeight);
            }
            catch (NullReferenceException ex)
            {
                throw new ModelDecreaseHeightException("Handler parameters refences is null.", ex);
            }
            catch (InvalidCastException ex)
            {
                throw new ModelDecreaseHeightException("Incorrect sender object type.", ex);
            }
            catch (ModelHeightException ex)
            {
                throw new ModelDecreaseHeightException("Incorrect height value.", ex);
            }
        }

        /// <summary>
        /// Turbo increase speed handler.
        /// </summary>
        /// <param name="sender">Object.</param>
        /// <param name="e">Event arguments.</param>
        public void TurboIncreaseSpeedHandler(object sender, EventArgs e)
        {
            try
            {
                CommonHandler(sender, e, p => Speed += p.DeltaTurboSpeed);
            }
            catch (NullReferenceException ex)
            {
                throw new ModelTurboIncreaseSpeedException("Handler parameters refences is null.", ex);
            }
            catch (InvalidCastException ex)
            {
                throw new ModelTurboIncreaseSpeedException("Incorrect sender object type.", ex);
            }
            catch (ModelSpeedException ex)
            {
                throw new ModelTurboIncreaseSpeedException("Incorrect speed value.", ex);
            }
        }

        /// <summary>
        /// Turbo decrease speed handler.
        /// </summary>
        /// <param name="sender">Object.</param>
        /// <param name="e">Event arguments.</param>
        public void TurboDecreaseSpeedHandler(object sender, EventArgs e)
        {
            try
            {
                CommonHandler(sender, e, p => Speed -= p.DeltaTurboSpeed);
            }
            catch (NullReferenceException ex)
            {
                throw new ModelTurboDecreaseSpeedException("Handler parameters refences is null.", ex);
            }
            catch (InvalidCastException ex)
            {
                throw new ModelTurboDecreaseSpeedException("Incorrect sender object type.", ex);
            }
            catch (ModelSpeedException ex)
            {
                throw new ModelTurboDecreaseSpeedException("Incorrect speed value.", ex);
            }
        }

        /// <summary>
        /// Turbo increase height handler.
        /// </summary>
        /// <param name="sender">Object.</param>
        /// <param name="e">Event arguments.</param>
        public void TurboIncreaseHeightHandler(object sender, EventArgs e)
        {
            try
            {
                CommonHandler(sender, e, p => Height += p.DeltaTurboHeight);
            }
            catch (NullReferenceException ex)
            {
                throw new ModelTurboIncreaseHeightException("Handler parameters refences is null.", ex);
            }
            catch (InvalidCastException ex)
            {
                throw new ModelTurboIncreaseHeightException("Incorrect sender object type.", ex);
            }
            catch (ModelHeightException ex)
            {
                throw new ModelTurboIncreaseHeightException("Incorrect height value.", ex);
            }
        }

        /// <summary>
        /// Turbo decrease height handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TurboDecreaseHeightHandler(object sender, EventArgs e)
        {
            try
            {
                CommonHandler(sender, e, p => Height -= p.DeltaTurboHeight);
            }
            catch (NullReferenceException ex)
            {
                throw new ModelTurboDecreaseHeightException("Handler parameters refences is null.", ex);
            }
            catch (InvalidCastException ex)
            {
                throw new ModelTurboDecreaseHeightException("Incorrect sender object type.", ex);
            }
            catch (ModelHeightException ex)
            {
                throw new ModelTurboDecreaseHeightException("Incorrect height value.", ex);
            }
        }
    }
}
