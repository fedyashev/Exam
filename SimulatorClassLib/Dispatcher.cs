using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorClassLib
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class Dispatcher
    {
        private string _name;
        private int _weatherCorrection;
        private int _recommendedHeight;
        private int _maxObjectSpeed;
        private const int  minControlledSpeed = 50;

        public event EventHandler SendMessage;
        public event EventHandler AddPenaltyPoints;

        /// <summary>
        /// Dispatcher name.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }

            private set
            {
                try
                {
                    if (value == null) throw new ArgumentNullException();
                    if (!value.Trim().Any()) throw new ArgumentException();
                    this._name = value;
                }
                catch (ArgumentNullException ex)
                {
                    throw new DispatcherNameException("Dispatcher name reference is null.", ex);
                }
                catch (ArgumentException ex)
                {
                    throw new DispatcherNameException("Dispatcher name is empty.", ex);
                }
                catch (Exception ex)
                {
                    throw new DispatcherNameException("Unknow exception.", ex);
                }
            }
        }

        /// <summary>
        /// Weather correction value.
        /// </summary>
        public int WeatherCorrection
        {
            get
            {
                return _weatherCorrection;
            }

            private set
            {
                this._weatherCorrection = value;
            }
        }

        /// <summary>
        /// Recommended height.
        /// </summary>
        public int RecommendedHeight
        {
            get
            {
                return _recommendedHeight;
            }

            private set
            {
                this._recommendedHeight = value;
            }
        }

        /// <summary>
        /// Maximal controlled object speed.
        /// </summary>
        public int MaxObjectSpeed
        {
            get
            {
                return _maxObjectSpeed;
            }

            private set
            {
                try
                {
                    if (value <= 0) throw new ArgumentException();
                }
                catch (ArgumentException ex)
                {
                    throw new DispatcherMaxObjectSpeedException("Incorrect max object speed.", ex);
                }
                catch (Exception ex)
                {
                    throw new DispatcherMaxObjectSpeedException("Unknow exception.", ex);
                }
                this._maxObjectSpeed = value;
            }
        }

        /// <summary>
        /// Airplain change state handler.
        /// </summary>
        /// <param name="sender">Object that invoke event.</param>
        /// <param name="args">Event arguments.</param>
        public void ChangeStateHandler(Object sender, EventArgs args)
        {
            try
            {
                if (sender == null || args == null) throw new ArgumentNullException();
                if (sender as AbstructSimulator == null) throw new InvalidCastException();
                var penaltyPoints = 0;
                var simulator = (AbstructSimulator)sender;
                var model = simulator.Model;
                if (model.Speed < 0 || model.Height < 0) throw new ModelParametersException();
                if (model.Speed > minControlledSpeed)
                {
                    var heightDifferense = Math.Abs(model.Height - RecommendedHeight);
                    if (heightDifferense >= 300 && heightDifferense < 600)
                    {
                        penaltyPoints += 25;
                    }
                    else if (heightDifferense >= 600 && heightDifferense < 1000)
                    {
                        penaltyPoints += 50;
                    }
                    else if (heightDifferense >= 1000)
                    {
                        throw new AirplainCrashException("Airplain crash.");
                    }
                    if (model.Speed > MaxObjectSpeed)
                    {
                        penaltyPoints += 100;
                    }
                    if (penaltyPoints > 0 && AddPenaltyPoints != null && SendMessage != null)
                    {
                        AddPenaltyPoints(this, new PenaltyPointsEventArgs(penaltyPoints));
                        SendMessage(this, new MessageEventArgs(String.Format("Dispatcher {0} added {1} penalty points.", Name, penaltyPoints)));
                        if (penaltyPoints >= 100)
                            SendMessage(this, new MessageEventArgs(String.Format("Dispatcher {0}: You speed is very high. Decrease your speed.", Name)));
                    }
                }
                RecommendedHeight = CalculateRecommendedHeight(model);
            }
            catch (ArgumentNullException ex)
            {
                throw new DispatcherChangeStateException("Dispatcher change state handler parameters is null.", ex);
            }
            catch (InvalidCastException ex)
            {
                throw new DispatcherChangeStateException("Incorrect object sender type.", ex);
            }
            catch (ModelParametersException ex)
            {
                throw new DispatcherChangeStateException("Incorrect model parameters.", ex);
            }
            catch (AirplainCrashException ex)
            {
                throw new DispatcherChangeStateException("Airplain crash.", ex);
            }
            catch (Exception ex)
            {
                throw new DispatcherChangeStateException("Unknow exception.", ex);
            }
        }

        /// <summary>
        /// Calculate recommended height for airplain.
        /// </summary>
        /// <param name="airplain">Airplain</param>
        public int CalculateRecommendedHeight(AbstructFlyingModel model)
        {
            return 7 * model.Speed - WeatherCorrection;
        }

        /// <summary>
        /// Construct Dispatcher object with name.
        /// </summary>
        /// <param name="name">Dispatcher name.</param>
        public Dispatcher(string name, int maxObjectSpeed)
        {
            try
            {
                var rand = new Random(DateTime.Now.Millisecond);
                this.Name = name;
                this.WeatherCorrection = rand.Next(-200, 200);
                this.RecommendedHeight = 0;
                this.MaxObjectSpeed = maxObjectSpeed;
            }
            catch (DispatcherNameException ex)
            {
                throw new DispatcherException("Incorrect dispatcher name.", ex);
            }
            catch (DispatcherMaxObjectSpeedException ex)
            {
                throw new DispatcherException("Incorrect max object speed exception.", ex);
            }
            catch (Exception ex)
            {
                throw new DispatcherException("Unknow exception.", ex);
            }
        }

        /// <summary>
        /// Convert Dispatcher object to string.
        /// </summary>
        /// <returns>String that discribe dispetcher object.</returns>
        public override string ToString()
        {
            return String.Format("Dispatcher {0}, recommended height: {1} m", Name, RecommendedHeight);
        }
    }
}
