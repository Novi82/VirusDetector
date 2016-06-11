using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using VirusDetector.Detector;

namespace VirusDetector.StringCompare
{
    class StringCompareManager
    {
        private TrainingData _detector;
        public double[][] _graphMap;

        // Compare info
        int _length;
        int _stepSize;
        int _hamingThresold;
        int _rContinuousThresold;
        Boolean _useHaming;
        Boolean _useRContinuous;


        String _virusFolder;
        String _benignFolder;

        public FileInfo[] _mAnalysisFile;
        int _totalFile;

        bool _done;

        ManualResetEvent _event;

        public StringCompareManager()
        {
            _detector = new TrainingData();
            _initialize();
        }

        private void _initialize()
        {
            _graphMap = new double[0][];
            _totalFile = 0;
            _done = false;
        }

        public StringCompareManager(TrainingData detector_, int length_, int stepSize_, int hamingThresold_, int rContinuousThresold_, Boolean useHaming_, Boolean useRContinuous_, String virusFolder_, String benignFolder_)
        {
            _detector = detector_;
            _length = length_;
            _stepSize = stepSize_;
            _hamingThresold = hamingThresold_;
            _rContinuousThresold = rContinuousThresold_;
            _useHaming = useHaming_;
            _useRContinuous = useRContinuous_;

            _virusFolder = virusFolder_;
            _benignFolder = benignFolder_;
            _initialize();
        }

        public void stringCompareAnalysis()
        {
            _done = false;
            // Read virus folder and benign folder
            // extract to all 32bit string
            // compute each string => get sum of result
            String[] virusFile = Directory.GetFiles(_virusFolder, "*.*", SearchOption.AllDirectories);
            String[] benignFile = Directory.GetFiles(_benignFolder, "*.*", SearchOption.AllDirectories);

            int virusLen = virusFile.Length;
            int benignLen = benignFile.Length;
            int totalLen = virusLen + benignLen;

            _mAnalysisFile = new FileInfo[totalLen];

            _totalFile = totalLen;

            // Init progressbar here
            Utils.Utils.GLOBAL_PROGRESSBAR_COUNT_MAX = totalLen;
            Utils.Utils.GUI_SUPPORT.initProgressBar();


            // Init for draw graph
            _graphMap = new double[totalLen][];


            int virusCount = 0;
            int benignCount = 0;
            int totalCount = 0;

            int randSize = 5;

            Random rand = new Random();

            bool done = false;

            while (!done)
            {
                // 1. For virus
                int m = Math.Min(virusLen - virusCount, rand.Next(1, randSize + 1)); // +1 because Math.Min(a,b) means min from a to b-1
                for (int i = 0; i < m; i++)
                {
                    FileInfo fileInfo = new FileInfo(virusFile[virusCount], Utils.Utils.VIRUS_MARK);
                    _mAnalysisFile[totalCount] = fileInfo;

                    virusCount++;
                    totalCount++;
                }

                // 2. lay so lan lap random cua sach nt
                int n = Math.Min(benignLen - benignCount, rand.Next(1, randSize + 1)); // +1 because Math.Min(a,b) means min from a to b-1
                for (int j = 0; j < n; j++)
                {
                    FileInfo fileInfo = new FileInfo(benignFile[benignCount], Utils.Utils.BENIGN_MARK);
                    _mAnalysisFile[totalCount] = fileInfo;

                    benignCount++;
                    totalCount++;
                }

                if (totalCount >= totalLen)
                    break;
            }

            _stringCompareAnalysis();
        }

        private void _stringCompareAnalysis()
        {
            int len = _totalFile;

            if (len <= 0)
                return;

            _event = new ManualResetEvent(false);
            for (int i = 0; i < len; i++)
            {
                ThreadPool.QueueUserWorkItem(_threadCallback, i);
            }
            _event.WaitOne();
        }

        private void _threadCallback(object index_)
        {
            if (_done)
                return;

            int index = (int)index_;

            FileInfo fileInfo = _mAnalysisFile[index];
            StringCompareData stringCompareData = new StringCompareData(_detector, _hamingThresold, _rContinuousThresold, _length, _stepSize, _useHaming, _useRContinuous);

            stringCompareData.Compute(fileInfo.FileName);

            Console.WriteLine(fileInfo.FileName + "xxx" + fileInfo.Mark);

            // Calc graph map value
            _graphMap[index] = new double[3];
            _graphMap[index][0] = stringCompareData.getRateWithTotalVirusFragment();
            _graphMap[index][1] = stringCompareData.getRateWithTotalFileString();
            _graphMap[index][2] = fileInfo.Mark;

            if (Interlocked.Decrement(ref _totalFile) == 0)
            {
                _event.Set();
            }

            Utils.Utils.GUI_SUPPORT.updateProgressBar();
        }


        public void stopStringCompareAnalysis()
        {
            _done = true;
            _event.Set();
        }

        public StringCompareData StringCompareData
        {
            get
            {
                return new StringCompareData(_detector, _hamingThresold, _rContinuousThresold, _length, _stepSize, _useHaming, _useRContinuous);
            }
        }
    }
}
