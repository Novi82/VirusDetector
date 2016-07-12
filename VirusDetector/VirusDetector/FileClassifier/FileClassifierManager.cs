using System;
using System.IO;
using Accord.MachineLearning.VectorMachines;
using Accord.MachineLearning.VectorMachines.Learning;
using Accord.Statistics.Kernels;
using AForge;
using AForge.Neuro;
using AForge.Neuro.Learning;
using VirusDetector.Clustering;

namespace VirusDetector.FileClassifier
{
    class FileClassifierManager
    {
        //todo del
        //private int _hiddenNeuron;
        //private int _outputNeuron;
        //private int _iterator;
        //private double _errorThresold;
        //double[][] _input;
        //double[][] _output; 
        //string[][] _testInput;
        public double[][] GraphMap;
        readonly string _pVirusFolder;
        readonly string _pBenignFolder;
        LkDistanceNetwork _distancePDistanceNetwork;
        
        double[][] _inputSvm;
        int[] _outputSvm;
        
        readonly int[] _formatRange;

        //bool _done;

        // SVM
        private double _sigma ;
        private double _epsilon ;
        private double _complexity;
        private double _tolenace;
        private int _cacheSize;
        private SelectionStrategy _strategy;
        // the kernel ( gausse | poly)
        private IKernel _svmKernel;
        KernelSupportVectorMachine _svm;

        internal LkDistanceNetwork DistancePDistanceNetwork
        {
            get { return _distancePDistanceNetwork; }
            set { _distancePDistanceNetwork = value; }
        }
        ActivationNetwork _activationNetwork;

        public ActivationNetwork ActivationNetwork
        {
            get { return _activationNetwork; }
            set { _activationNetwork = value; }
        }

        public KernelSupportVectorMachine Svm
        {
            get { return _svm; }
            set { _svm = value; }
        }

        public FileClassifierManager(string pVirusFolder, string pBenignFolder, LkDistanceNetwork pDistanceNetwork, string pFormatRange )
        {
            _pVirusFolder = pVirusFolder;
            _pBenignFolder = pBenignFolder;
            _distancePDistanceNetwork = pDistanceNetwork;

            _formatRange = Utils.Utils.CalcFormatRange(pFormatRange);

            _initialize();
        }

        private void _initialize()
        {
           // _done = false;
        }
        //todo del
        ///// <summary>
        ///// build training set
        ///// </summary>
        //public void BuildTrainingSet()
        //{
        //    // Read virus folder and benign folder
        //    // extract to all 32bit string
        //    // compute each string => get sum of result
        //    string[] virusFile = Directory.GetFiles(_pVirusFolder, "*.*", SearchOption.AllDirectories);
        //    string[] benignFile = Directory.GetFiles(_pBenignFolder, "*.*", SearchOption.AllDirectories);

        //    int virusLen = virusFile.Length;
        //    int benignLen = benignFile.Length;
        //    int totalLen = virusLen + benignLen;


        //    _input = new double[totalLen][];
        //    _output = new double[totalLen][];

        //    // Init for draw graph
        //    GraphMap = new double[totalLen][];


        //    _testInput = new String[totalLen][];


        //    int virusCount = 0;
        //    int benignCount = 0;
        //    int totalCount = 0;

        //    int randSize = 5;
        //    bool done = false;

        //    Random rand = new Random();

        //    while (!done)
        //    {
        //        // 1. For virus
        //        int m = Math.Min(virusLen - virusCount, rand.Next(1, randSize + 1)); // +1 because Math.Min(a,b) means min from a to b-1
        //        for (int i = 0; i < m; i++)
        //        {
        //            FileClassifierData data = new FileClassifierData(_distancePDistanceNetwork, virusFile[virusCount], _formatRange);
        //            //_input[totalCount] = data.getFormatData();
        //            _input[totalCount] = data.GetRateFormatData();

        //            _testInput[totalCount] = data.Test_GetRateFormatData(Utils.Utils.VIRUS_MARK, virusFile[virusCount]);
        //            _output[totalCount] = new double[] { Utils.Utils.VIRUS_MARK };

        //            // Calc graph map value
        //            GraphMap[totalCount] = new double[2];
        //            GraphMap[totalCount][0] = Utils.Utils.CalcDangerousRate(_input[totalCount]);
        //            GraphMap[totalCount][1] = Utils.Utils.VIRUS_MARK;


        //            virusCount++;
        //            totalCount++;
        //        }

        //        // 2. lay so lan lap random cua sach nt
        //        int n = Math.Min(benignLen - benignCount, rand.Next(1, randSize + 1)); // +1 because Math.Min(a,b) means min from a to b-1
        //        for (int j = 0; j < n; j++)
        //        {
        //            FileClassifierData data = new FileClassifierData(_distancePDistanceNetwork, benignFile[benignCount], _formatRange);
        //            _input[totalCount] = data.GetRateFormatData();
        //            _testInput[totalCount] = data.Test_GetRateFormatData(Utils.Utils.BENIGN_MARK, benignFile[benignCount]);
        //            _output[totalCount] = new double[] { Utils.Utils.BENIGN_MARK };

        //            // Vietbn add
        //            _outputSvm = new[] { Utils.Utils.BENIGN_MARK };
        //            // vietbn add end

        //            // Calc graph map value
        //            GraphMap[totalCount] = new double[2];
        //            GraphMap[totalCount][0] = Utils.Utils.CalcDangerousRate(_input[totalCount]);
        //            GraphMap[totalCount][1] = Utils.Utils.BENIGN_MARK;


        //            benignCount++;
        //            totalCount++;
        //        }

        //        done = (totalCount >= totalLen);
        //    }

        //    Test_PrintInput(_testInput);
        //    Test_PrintInput(GraphMap);
        //}

        /// <summary>
        /// build training set
        /// </summary>
        public void BuildTrainingSetSvm()
        {
            // Read virus folder and benign folder
            // extract to all 32bit string
            // compute each string => get sum of result
            string[] virusFile = Directory.GetFiles(_pVirusFolder, "*.*", SearchOption.AllDirectories);
            string[] benignFile = Directory.GetFiles(_pBenignFolder, "*.*", SearchOption.AllDirectories);

            int virusLen = virusFile.Length;
            int benignLen = benignFile.Length;
            int totalLen = virusLen + benignLen;

            _inputSvm = new double[totalLen][];
            _outputSvm = new int[totalLen];

            // Init for draw graph
            GraphMap = new double[totalLen][];

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
                    FileClassifierData data = new FileClassifierData(_distancePDistanceNetwork, virusFile[virusCount], _formatRange);
                   
                    _inputSvm[totalCount] = data.GetRateFormatData();
                    _outputSvm[totalCount] =  Utils.Utils.VIRUS_MARK_SVM ;

                    // Calc graph map value
                    GraphMap[totalCount] = new double[2];
                    GraphMap[totalCount][0] = Utils.Utils.CalcDangerousRate(_inputSvm[totalCount]);
                    GraphMap[totalCount][1] = Utils.Utils.VIRUS_MARK_SVM;
                    
                    virusCount++;
                    totalCount++;
                }

                // 2. lay so lan lap random cua sach nt
                int n = Math.Min(benignLen - benignCount, rand.Next(1, randSize + 1)); // +1 because Math.Min(a,b) means min from a to b-1
                for (int j = 0; j < n; j++)
                {
                    FileClassifierData data = new FileClassifierData(_distancePDistanceNetwork, benignFile[benignCount], _formatRange);
                    _inputSvm[totalCount] = data.GetRateFormatData();
                    _outputSvm[totalCount] =   Utils.Utils.BENIGN_MARK_SVM ;

                    // Calc graph map value
                    GraphMap[totalCount] = new double[2];
                    GraphMap[totalCount][0] = Utils.Utils.CalcDangerousRate(_inputSvm[totalCount]);
                    GraphMap[totalCount][1] = Utils.Utils.BENIGN_MARK_SVM;


                    benignCount++;
                    totalCount++;
                }

                done = (totalCount >= totalLen);
            }
        }
        //todo del
        //public void TrainActiveNetwork(int pNumOfHiddenNeuron, int pNumOfOutputNeuron, int pNumOfIterator, double pErrorThresold)
        //{
        //    // Init for ANN
        //    _hiddenNeuron = pNumOfHiddenNeuron;
        //    _outputNeuron = pNumOfOutputNeuron;
        //    _iterator = pNumOfIterator;
        //    _errorThresold = pErrorThresold;
            
        //    // Init progressbar here
        //    Utils.Utils.GLOBAL_PROGRESSBAR_COUNT_MAX = _iterator;
        //    Utils.Utils.GUI_SUPPORT.InitProgressBar();

        //    // Set random range
        //    Neuron.RandRange = new Range(0.0f, 1.0f);

        //    // Create ANN
        //    _activationNetwork = new ActivationNetwork(new BipolarSigmoidFunction(), _formatRange.Length, _hiddenNeuron, _outputNeuron);
        //    BackPropagationLearning teacher = new BackPropagationLearning(_activationNetwork);

        //    // Train ANN
        //    int count = 0;
        //    while (!_done)
        //    {
        //        var error = teacher.RunEpoch(_input, _output);
        //        //todo debug Console.WriteLine("Error: " + error + "; [" + count + "/ " + _iterator + "]");
        //        count++;

        //        // Update progressbar
        //        Utils.Utils.GUI_SUPPORT.UpdateProgressBar();

        //        if (count >= _iterator || error <= _errorThresold)
        //            break;
        //    }
        //}
 //public void TrainActiveNetwork1(int pHiddenNeuron, int pOutputNeuron, int pIterator, double pErrorThresold)
 //       {
 //           // Init for ANN
 //           _hiddenNeuron = pHiddenNeuron;
 //           _outputNeuron = pOutputNeuron;
 //           _iterator = pIterator;
 //           _errorThresold = pErrorThresold;

 //           // Setting for trainActivenetwork1
 //           int numOfInputNeuron = 1;

 //           // Init progressbar here
 //           Utils.Utils.GLOBAL_PROGRESSBAR_COUNT_MAX = _iterator;
 //           Utils.Utils.GUI_SUPPORT.InitProgressBar();

 //           // Set random range
 //           //Neuron.RandRange = new Range(0.0f, 1.0f);
 //           Neuron.RandRange = new Range(0.0f, 1.0f);

 //           // Create ANN
 //           _activationNetwork = new LkActivationNetwork(new BipolarSigmoidFunction(), numOfInputNeuron, _hiddenNeuron, _outputNeuron);
 //           BackPropagationLearning teacher = new BackPropagationLearning(_activationNetwork);

 //           // Train ANN
 //           double error;
 //           int count = 0;
 //           while (!_done)
 //           {
 //               error = teacher.RunEpoch(GraphMap, _output);
 //               // todo debug Console.WriteLine("Error: " + error + "; [" + count + "/ " + _iterator + "]");
 //               count++;

 //               // Update progressbar
 //               Utils.Utils.GUI_SUPPORT.UpdateProgressBar();

 //               if (count >= _iterator || error <= _errorThresold)
 //                   break;
 //           }
 //       }

        public void TrainSvm(double pSigma, double pEpsilon, double pComplexity, double pTolenace, int pCacheSize, SelectionStrategy pStrategy)
        {
            //init input param
            _sigma = pSigma;
            _epsilon = pEpsilon;
            _complexity = pComplexity;
            _tolenace = pTolenace;
            _cacheSize = pCacheSize;
            _strategy = pStrategy;
            // Init progressbar here
           //todo  Utils.Utils.GLOBAL_PROGRESSBAR_COUNT_MAX = _iterator;
            Utils.Utils.GUI_SUPPORT.InitProgressBar();

            // Create the chosen kernel function 
            // using the user interface parameters
            //
            _svmKernel = new Linear(1);
            
            int numInputSize = _inputSvm[0].Length;
            //_svm = new KernelSupportVectorMachine(new Linear(), numInputSize);
            _svm = new KernelSupportVectorMachine(new Gaussian(_epsilon),numInputSize);

            // Instantiate a new learning algorithm for SVMs
            //SequentialMinimalOptimization smo = new SequentialMinimalOptimization(_svm, _inputSvm, _outputSvm)
            //{
            //    Complexity = _complexity,
            //    Strategy = _strategy,
            //    CacheSize = _cacheSize,
            //    Epsilon = _epsilon,
            //    Tolerance = _tolenace
            //};
            SequentialMinimalOptimization smo = new SequentialMinimalOptimization(_svm, _inputSvm, _outputSvm)
                        {
                            Complexity = _complexity,
                            Strategy = _strategy,
                            CacheSize = _cacheSize,
                            Epsilon = _epsilon,
                            Tolerance = _tolenace
                        };
            // Set up the learning algorithm

            // Run the learning algorithm
            double error = smo.Run();
            test_printSvmCompute(_svm);}

        private void test_printSvmCompute(KernelSupportVectorMachine pSVm)
        {
            foreach (var input in pSVm.Weights)
            {
                Console.WriteLine(String.Join("-",input));
            }
        }
        public void SaveActiveNetwork(string pFileName)
        {
            Utils.Utils.SaveNetwork(_activationNetwork, pFileName);
        }

        public void LoadActiveNetwork(string pFileName)
        {
            _activationNetwork = (ActivationNetwork)Utils.Utils.LoadNetwork(pFileName);
        }

        private void Test_PrintInput(double[][] pInputs)
        {
            foreach (double[] items in pInputs)
            {
                foreach (double item in items)
                {
                    Console.Write(item + @",");
                }
                Console.WriteLine();
            }
        }

        private void Test_PrintInput(String[][] pInputs)
        {
            foreach (String[] items in pInputs)
            {
                foreach (string item in items)
                {
                    Console.Write(item + @",");
                }
                Console.WriteLine();
            }
        }

        internal void StopTrainActiveNetwork()
        {
            //_done = true;
        }
    }
}
