//using System;
//using System.IO;
//using System.Threading;
//using VirusDetector.Detector;

//namespace VirusDetector.StringCompare
//{
//    class StringCompareManager
//    {
//        private TrainingData _pDetector;
//        public double[][] GraphMap;

//        // Compare info
//        private readonly int _pLength;
//        private readonly int _pStepSize;
//        private readonly int _pHamingThresold;
//        private readonly int _pRContinuousThresold;
//        private readonly bool _pIsUseHaming;
//        private readonly bool _pIsUseRContinuous;


//        readonly String _pVirusFolder;
//        readonly String _pBenignFolder;

//        public FileInfo[] MAnalysisFile;
//        int _totalFile;

//        bool _done;

//        ManualResetEvent _event;

//        public StringCompareManager()
//        {
//            _pDetector = new TrainingData();
//            _initialize();
//        }

//        private void _initialize()
//        {
//            GraphMap = new double[0][];
//            _totalFile = 0;
//            _done = false;
//        }

//        public StringCompareManager(TrainingData pDetector, int pLength, int pStepSize, int pHamingThresold, 
//            int pRContinuousThresold, Boolean pIsUseHaming, Boolean pIsUseRContinuous, String pVirusFolder, String pBenignFolder)
//        {
//            _pDetector = pDetector;
//            _pLength = pLength;
//            _pStepSize = pStepSize;
//            _pHamingThresold = pHamingThresold;
//            _pRContinuousThresold = pRContinuousThresold;
//            _pIsUseHaming = pIsUseHaming;
//            _pIsUseRContinuous = pIsUseRContinuous;

//            _pVirusFolder = pVirusFolder;
//            _pBenignFolder = pBenignFolder;
//            _initialize();
//        }

//        public void StringCompareAnalysis()
//        {
//            _done = false;
//            // Read virus folder and benign folder
//            // extract to all 32bit string
//            // compute each string => get sum of result
//            String[] virusFile = Directory.GetFiles(_pVirusFolder, "*.*", SearchOption.AllDirectories);
//            String[] benignFile = Directory.GetFiles(_pBenignFolder, "*.*", SearchOption.AllDirectories);

//            int virusLen = virusFile.Length;
//            int benignLen = benignFile.Length;
//            int totalLen = virusLen + benignLen;

//            MAnalysisFile = new FileInfo[totalLen];

//            _totalFile = totalLen;

//            // Init progressbar here
//            Utils.Utils.GLOBAL_PROGRESSBAR_COUNT_MAX = totalLen;
//            Utils.Utils.GUI_SUPPORT.InitProgressBar();


//            // Init for draw graph
//            GraphMap = new double[totalLen][];


//            int virusCount = 0;
//            int benignCount = 0;
//            int totalCount = 0;

//            int randSize = 5;

//            Random rand = new Random();

//            bool done = false;

//            while (!done)
//            {
//                // 1. For virus
//                int m = Math.Min(virusLen - virusCount, rand.Next(1, randSize + 1)); // +1 because Math.Min(a,b) means min from a to b-1
//                for (int i = 0; i < m; i++)
//                {
//                    FileInfo fileInfo = new FileInfo(virusFile[virusCount], Utils.Utils.VIRUS_MARK);
//                    MAnalysisFile[totalCount] = fileInfo;

//                    virusCount++;
//                    totalCount++;
//                }

//                // 2. lay so lan lap random cua sach nt
//                int n = Math.Min(benignLen - benignCount, rand.Next(1, randSize + 1)); // +1 because Math.Min(a,b) means min from a to b-1
//                for (int j = 0; j < n; j++)
//                {
//                    FileInfo fileInfo = new FileInfo(benignFile[benignCount], Utils.Utils.BENIGN_MARK);
//                    MAnalysisFile[totalCount] = fileInfo;

//                    benignCount++;
//                    totalCount++;
//                }

//                if (totalCount >= totalLen)
//                    break;
//            }

//            _stringCompareAnalysis();
//        }

//        private void _stringCompareAnalysis()
//        {
//            int len = _totalFile;

//            if (len <= 0)
//                return;

//            _event = new ManualResetEvent(false);
//            for (int i = 0; i < len; i++)
//            {
//                ThreadPool.QueueUserWorkItem(_threadCallback, i);
//            }
//            _event.WaitOne();
//        }

//        private void _threadCallback(object pIndex)
//        {
//            if (_done)
//                return;

//            int index = (int)pIndex;

//            FileInfo fileInfo = MAnalysisFile[index];
//            StringCompareData stringCompareData = new StringCompareData(_pDetector, _pHamingThresold, _pRContinuousThresold, _pLength, _pStepSize, _pIsUseHaming, _pIsUseRContinuous);

//            stringCompareData.Compute(fileInfo.FileName);

//           // todo debug Console.WriteLine(fileInfo.FileName + "xxx" + fileInfo.Mark);

//            // Calc graph map value
//            GraphMap[index] = new double[3];
//            GraphMap[index][0] = stringCompareData.getRateWithTotalVirusFragment();
//            GraphMap[index][1] = stringCompareData.getRateWithTotalFileString();
//            GraphMap[index][2] = fileInfo.Mark;

//            if (Interlocked.Decrement(ref _totalFile) == 0)
//            {
//                _event.Set();
//            }

//            Utils.Utils.GUI_SUPPORT.UpdateProgressBar();
//        }


//        public void StopStringCompareAnalysis()
//        {
//            _done = true;
//            _event.Set();
//        }

//        public StringCompareData StringCompareData
//        {
//            get
//            {
//                return new StringCompareData(_pDetector, _pHamingThresold, _pRContinuousThresold, _pLength, _pStepSize, _pIsUseHaming, _pIsUseRContinuous);
//            }
//        }
//    }
//}
