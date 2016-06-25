using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge;
using AForge.Neuro;
using AForge.Neuro.Learning;
using VirusDetector.Clustering;

namespace VirusDetector.FileClassifier
{
    class FileClassifierManager
    {
        private int _numOfHiddenNeuron;
        private int _numOfOutputNeuron;
        private int _numOfIterator;
        private double _errorThresold;

        String _virusFolder;
        String _benignFolder;
        LKDistanceNetwork _distanceNetwork;

        double[][] _input;
        double[][] _output;
        public double[][] _graphMap;
        String[][] _testInput;
        int[] _formatRange;

        bool _done;

        internal LKDistanceNetwork DistanceNetwork
        {
            get { return _distanceNetwork; }
            set { _distanceNetwork = value; }
        }
        ActivationNetwork _activationNetwork;

        public ActivationNetwork ActivationNetwork
        {
            get { return _activationNetwork; }
            set { _activationNetwork = value; }
        }

        public FileClassifierManager(String virusFolder_, String benignFolder_, LKDistanceNetwork network_, String formatRange_)
        {

            _virusFolder = virusFolder_;
            _benignFolder = benignFolder_;
            _distanceNetwork = network_;

            _formatRange = Utils.Utils.calcFormatRange(formatRange_);

            _initialize();
        }

        private void _initialize()
        {
            _done = false;
        }
        /// <summary>
        /// build training set
        /// </summary>
        public void buildTrainingSet()
        {
            // Read virus folder and benign folder
            // extract to all 32bit string
            // compute each string => get sum of result
            String[] virusFile = Directory.GetFiles(_virusFolder, "*.*", SearchOption.AllDirectories);
            String[] benignFile = Directory.GetFiles(_benignFolder, "*.*", SearchOption.AllDirectories);

            int virusLen = virusFile.Length;
            int benignLen = benignFile.Length;
            int totalLen = virusLen + benignLen;


            _input = new double[totalLen][];
            _output = new double[totalLen][];

            // Init for draw graph
            _graphMap = new double[totalLen][];


            _testInput = new String[totalLen][];


            int virusCount = 0;
            int benignCount = 0;
            int totalCount = 0;

            int randSize = 5;
            bool done = false;

            Random rand = new Random();

            while (!done)
            {
                // 1. For virus
                int m = Math.Min(virusLen - virusCount, rand.Next(1, randSize + 1)); // +1 because Math.Min(a,b) means min from a to b-1
                for (int i = 0; i < m; i++)
                {
                    FileClassifierData data = new FileClassifierData(_distanceNetwork, virusFile[virusCount], _formatRange);
                    //_input[totalCount] = data.getFormatData();
                    _input[totalCount] = data.getRateFormatData();

                    _testInput[totalCount] = data.Test_GetRateFormatData(Utils.Utils.VIRUS_MARK, virusFile[virusCount]);
                    _output[totalCount] = new double[] { Utils.Utils.VIRUS_MARK };

                    // Calc graph map value
                    _graphMap[totalCount] = new double[2];
                    _graphMap[totalCount][0] = Utils.Utils.calcDangerousRate(_input[totalCount]);
                    _graphMap[totalCount][1] = Utils.Utils.VIRUS_MARK;


                    virusCount++;
                    totalCount++;
                }

                // 2. lay so lan lap random cua sach nt
                int n = Math.Min(benignLen - benignCount, rand.Next(1, randSize + 1)); // +1 because Math.Min(a,b) means min from a to b-1
                for (int j = 0; j < n; j++)
                {
                    FileClassifierData data = new FileClassifierData(_distanceNetwork, benignFile[benignCount], _formatRange);
                    _input[totalCount] = data.getRateFormatData();
                    _testInput[totalCount] = data.Test_GetRateFormatData(Utils.Utils.BENIGN_MARK, benignFile[benignCount]);
                    _output[totalCount] = new double[] { Utils.Utils.BENIGN_MARK };

                    // Calc graph map value
                    _graphMap[totalCount] = new double[2];
                    _graphMap[totalCount][0] = Utils.Utils.calcDangerousRate(_input[totalCount]);
                    _graphMap[totalCount][1] = Utils.Utils.BENIGN_MARK;


                    benignCount++;
                    totalCount++;
                }

                done = (totalCount >= totalLen);
            }

            Test_PrintInput(_testInput);
            Test_PrintInput(_graphMap);
        }

        public void trainActiveNetwork(int numOfHiddenNeuron_, int numOfOutputNeuron_, int numOfIterator_, double errorThresold_)
        {
            // Init for ANN
            _numOfHiddenNeuron = numOfHiddenNeuron_;
            _numOfOutputNeuron = numOfOutputNeuron_;
            _numOfIterator = numOfIterator_;
            _errorThresold = errorThresold_;


            // Init progressbar here
            Utils.Utils.GLOBAL_PROGRESSBAR_COUNT_MAX = _numOfIterator;
            Utils.Utils.GUI_SUPPORT.initProgressBar();

            // Set random range
            Neuron.RandRange = new Range(0.0f, 1.0f);

            // Create ANN
            _activationNetwork = new ActivationNetwork(new BipolarSigmoidFunction(), _formatRange.Length, _numOfHiddenNeuron, _numOfOutputNeuron);
            BackPropagationLearning teacher = new BackPropagationLearning(_activationNetwork);

            // Train ANN
            double error = 0;
            int count = 0;
            while (!_done)
            {
                error = teacher.RunEpoch(_input, _output);
                Console.WriteLine("Error: " + error + "; [" + count + "/ " + _numOfIterator + "]");
                count++;

                // Update progressbar
                Utils.Utils.GUI_SUPPORT.updateProgressBar();

                if (count >= _numOfIterator || error <= _errorThresold)
                    break;
            };
        }

        public void trainActiveNetwork1(int numOfHiddenNeuron_, int numOfOutputNeuron_, int numOfIterator_, double errorThresold_)
        {
            // Init for ANN
            _numOfHiddenNeuron = numOfHiddenNeuron_;
            _numOfOutputNeuron = numOfOutputNeuron_;
            _numOfIterator = numOfIterator_;
            _errorThresold = errorThresold_;

            // Setting for trainActivenetwork1
            int numOfInputNeuron = 1;

            // Init progressbar here
            Utils.Utils.GLOBAL_PROGRESSBAR_COUNT_MAX = _numOfIterator;
            Utils.Utils.GUI_SUPPORT.initProgressBar();

            // Set random range
            Neuron.RandRange = new Range(0.0f, 1.0f);

            // Create ANN
            _activationNetwork = new LKActivationNetwork(new BipolarSigmoidFunction(), numOfInputNeuron, _numOfHiddenNeuron, _numOfOutputNeuron);
            BackPropagationLearning teacher = new BackPropagationLearning(_activationNetwork);

            // Train ANN
            double error = 0;
            int count = 0;
            while (!_done)
            {
                error = teacher.RunEpoch(_graphMap, _output);
                Console.WriteLine("Error: " + error + "; [" + count + "/ " + _numOfIterator + "]");
                count++;

                // Update progressbar
                Utils.Utils.GUI_SUPPORT.updateProgressBar();

                if (count >= _numOfIterator || error <= _errorThresold)
                    break;
            };
        }

        public void saveActiveNetwork(String fileName_)
        {
            Utils.Utils.saveNetwork(_activationNetwork, fileName_);
        }

        public void loadActiveNetwork(String fileName_)
        {
            _activationNetwork = (ActivationNetwork)Utils.Utils.loadNetwork(fileName_);
        }

        private void Test_PrintInput(double[][] input_)
        {
            foreach (double[] item in input_)
            {
                foreach (double _item in item)
                {
                    Console.Write(_item + ",");
                }
                Console.WriteLine();
            }
        }

        private void Test_PrintInput(String[][] input_)
        {
            foreach (String[] item in input_)
            {
                foreach (String _item in item)
                {
                    Console.Write(_item + ",");
                }
                Console.WriteLine();
            }
        }


        internal void stopTrainActiveNetwork()
        {
            _done = true;
        }
    }
}
