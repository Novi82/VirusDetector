using System;
using AForge;
using AForge.Neuro;

namespace VirusDetector.Clustering
{
    class ClusteringManager
    {
        #region Variable
        int _numPInputNeuron;
        private int _pNetworkWidth;
        private int _pNetworkHeight;
        private double _pLearningRate;
        private double _pLearningRadius;
        private int _pNumOfIterator;
        private double _pErrorThresold;

        LkDistanceNetwork _network;
        double[][] _pInputs;
        float _pMaxInputRange;

        bool _done;
        public int NumPInputNeuron
        {
            get { return _numPInputNeuron; }
            set { _numPInputNeuron = value; }
        }

        public int NumOutputNeron
        {
            get
            {
                if (_network != null)
                    return _network.Layers[0].Neurons.Length;

                return _pNetworkWidth * _pNetworkHeight;
            }
        }
        internal LkDistanceNetwork DistanceNetwork
        {
            get { return _network; }
            set { _network = value; }
        }

        #endregion
        #region Method
        /// <summary>
        /// default constructor
        /// </summary>
        public ClusteringManager()
        {
            _pInputs = new double[0][];
            _numPInputNeuron = 0;
            _pMaxInputRange = 0;
            _pNetworkWidth = 0;
            _pNetworkHeight = 0;
            _pNumOfIterator = 0;
            _pErrorThresold = 0;

            _initialize();
        }

        /// <summary>
        ///  constructor with param
        /// </summary>
        /// <param name="pInputCount"></param>
        /// <param name="pNetworkWidth"></param>
        /// <param name="pNetworkHeight"></param>
        /// <param name="pLearningRate"></param>
        /// <param name="pLearningRadius"></param>
        /// <param name="pNumOfIterator"></param>
        /// <param name="pErrorThresold"></param>
        /// <param name="pInputs"></param>
        /// <param name="pMaxInputRange"></param>
        public ClusteringManager(int pInputCount, int pNetworkWidth, int pNetworkHeight, double pLearningRate, double pLearningRadius, int pNumOfIterator, double pErrorThresold, double[][] pInputs, float pMaxInputRange)
        {
            _numPInputNeuron = pInputCount;
            _pNetworkWidth = pNetworkWidth;
            _pNetworkHeight = pNetworkHeight;
            _pLearningRate = pLearningRate;
            _pLearningRadius = pLearningRadius;
            _pNumOfIterator = pNumOfIterator;
            _pErrorThresold = pErrorThresold;

            _pInputs = pInputs;
            _pMaxInputRange = pMaxInputRange;

            _initialize();
        }
       
        /// <summary>
        /// init variable
        /// </summary>
        private void _initialize()
        {
            _done = false;
        }

        /// <summary>
        /// training network
        /// </summary>
        public void TrainDistanceNetwork()
        {
            // Init progressbar here
            Utils.Utils.GLOBAL_PROGRESSBAR_COUNT_MAX = _pNumOfIterator;
            Utils.Utils.GUI_SUPPORT.InitProgressBar();

            // Set random range
            Neuron.RandRange = new Range(0, _pMaxInputRange);

            // Create network
            _network = new LkDistanceNetwork(_numPInputNeuron, _pNetworkWidth * _pNetworkHeight);

            // create learning algorithm
            LksomLearning trainer = new LksomLearning(_network, _pNetworkWidth, _pNetworkHeight);

            double fixedLearningRate = _pLearningRate / 10;
            double driftingLearningRate = fixedLearningRate * 9;


            int count = 0;// iterations
            //training network in 1000 epoch or ErrorRate < 0.2
            while (!_done)
            {
                trainer.LearningRate = driftingLearningRate * (_pNumOfIterator - count) / _pNumOfIterator + fixedLearningRate;
                trainer.LearningRadius = _pLearningRadius * (_pNumOfIterator - count) / _pNumOfIterator;

                // run training epoch
                double error = trainer.RunEpoch(_pInputs);
                //Console.WriteLine("Error: " + error + "; [" + count + "/ " + _pNumOfIterator + "]");

                // increase current iteration
                count++;

                // Update progressbar
                Utils.Utils.GUI_SUPPORT.UpdateProgressBar();

                // stop ?
                if (count >= _pNumOfIterator || error <= _pErrorThresold)
                    break;
            }
            trainer.MapNeuronLabel(_pInputs);

        }

        /// <summary>
        /// init data to chart
        /// </summary>
        /// <returns></returns>
        public double[][] DangerLevel()
        {
            int inputLen = _pInputs.Length;
            double[][] dangerLevel = new double[inputLen][];

            for (int i = 0; i < inputLen; i++)
            {
                double[] inputI = _pInputs[i];
                int inputILen = inputI.Length;

                _network.Compute(_pInputs[i]);
                LkDistanceNeuron noronWin = _network.GetWinnerNeuron();

                dangerLevel[i] = new double[2];
                // so luong detector virus
                dangerLevel[i][0] = (noronWin.BenignDetectedCount > 0 ? 0 : noronWin.VirusDetectedCount);
                dangerLevel[i][1] = inputI[inputILen - 1];

            }
            return dangerLevel;
        }

        public void SaveDistanceNetwork(string pFileName)
        {
            Utils.Utils.SaveNetwork(_network, pFileName);
        }

        public void LoadDistanceNetwork(string pFileName)
        {
            _network = (LkDistanceNetwork)Utils.Utils.LoadNetwork(pFileName);

            _numPInputNeuron = _network.InputsCount;
        } 
        internal void StopTrainDistanceNetwork()
        {
            _done = true;
        }

        #endregion

        //todo del region
        #region Test Method
        public void Test_Data(double[][] pTestDb)
        {
            foreach (double[] items in pTestDb)
            {
                int winner = Test_Data(items);
                Test_Println(items, winner);
            }
        }

        private void Test_Println(double[] items, int winner)
        {
            foreach (double item in items)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("==> " + winner);
        }

        public void Test_PrintlnNeuron()
        {
            ((LkDistanceLayer)_network.Layers[0]).printNeuron();
        }

        public int Test_Data(double[] vector)
        {
            _network.Compute(vector);
            int winner = _network.GetWinner();
            return winner;
        }
        #endregion
      
    }
}
