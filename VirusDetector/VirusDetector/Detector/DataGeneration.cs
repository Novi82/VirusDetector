using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace VirusDetector.Detector
{
    class DataGeneration
    {
        #region Variable

        public List<string> PFilenames { get; set; }
        public TrainingData BenignFragmentInput = new TrainingData();
        public TrainingData VirusFragmentInput = new TrainingData();
        public TrainingData VirusFragmentOutput = new TrainingData();

        private int _filesRemains;
        /// <summary>
        /// Matching object
        /// </summary>
        private readonly Matching _oMatching;
        private string _pVirusDirectory;
        private string _pBenignDirectory;
        public string PVirusDirectory
        {
            get { return _pVirusDirectory; }
            set { _pVirusDirectory = value; }
        }
        public string PBenignDirectory
        {
            get { return _pBenignDirectory; }
            set { _pBenignDirectory = value; }
        }
        private string _outputFile = "";
        public string OutputFile
        {
            get { return _outputFile; }
            set { _outputFile = value; }
        }
        private int _length;     // 4 bytes (32 bits )
        private int _stepSize;   // 2 bytes (16 bits )
        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }
        public int StepSize
        {
            get { return _stepSize; }
            set { _stepSize = value; }
        }
        #endregion

        #region event
        private ManualResetEvent _event;

        // Stop support
        Boolean _done;
        #endregion

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="pVirusDirectory"></param>
        /// <param name="pBenignDirectory"></param>
        /// <param name="pHamming"></param>
        /// <param name="pRContiguous"></param>
        /// <param name="pLength"></param>
        /// <param name="stepSize"></param>
        /// <param name="pIsUseHamming"></param>
        /// <param name="pIsUseRcon"></param>
        public DataGeneration(string pVirusDirectory, string pBenignDirectory, int pHamming, int pRContiguous, int pLength, int stepSize, bool pIsUseHamming, bool pIsUseRcon)
        {
            _oMatching = new Matching(pHamming, pRContiguous, pIsUseHamming, pIsUseRcon);
            _length = pLength;
            _stepSize = stepSize;
            //PFilenames = pFilenames;
            _pBenignDirectory = pBenignDirectory;
            _pVirusDirectory = pVirusDirectory;

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
        /// Read [Benign|Virus] File
        /// </summary>
        /// <param name="pPath"></param>
        /// <param name="pMode">1: Benign | 2: Virus</param>
        private void ReadFile(string pPath, Utils.Utils.EMode pMode)
        {
            byte[] bytes = File.ReadAllBytes(pPath);
            byte[] temp = new byte[_length];
            for (int i = 0; i <= bytes.Length - _length; i += _stepSize)
            {
                Array.Copy(bytes, i, temp, 0, _length);
                var binaryArray = Utils.Utils.ConvertBytesIntoBinary(temp);

                if (pMode == Utils.Utils.EMode.Benign)
                {
                    if (binaryArray != null)
                        BenignFragmentInput.Add(binaryArray);
                }
                else if (pMode == Utils.Utils.EMode.Virus)
                {
                    if (binaryArray != null)
                    {
                        VirusFragmentInput.Add(binaryArray);
                    }

                }
            }
        }

        /// <summary>
        /// Read [Benign|Virus] Directory
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="pMode">True: Benign | False: Virus</param>
        private void ReadDirectory(string directory, Utils.Utils.EMode pMode)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories);
            foreach (string fileName in fileEntries)
                ReadFile(fileName, pMode);
        }

        /// <summary>
        /// Start Building
        /// </summary>
        public void StartBuildDetector()
        {
            _done = false;

            ReadDirectory(_pBenignDirectory, Utils.Utils.EMode.Benign);
            ReadDirectory(_pVirusDirectory, Utils.Utils.EMode.Virus);

            // Init progressbar before work
            Utils.Utils.GLOBAL_PROGRESSBAR_COUNT_MAX = VirusFragmentInput.Count;
            Utils.Utils.GUI_SUPPORT.InitProgressBar();

            // Init virus count
            Utils.Utils.GLOBAL_PROGRESSBAR_COUNT = 0;
            Utils.Utils.GLOBAL_VIRUS_COUNT = 0;
            Utils.Utils.GLOBAL_BENIGN_COUNT = BenignFragmentInput.Count;

            NegativeSelection();
        }

        /// <summary>
        /// NegativeSelection -- remove benign in virus data set
        /// </summary>
        private void NegativeSelection()
        {
            _filesRemains = VirusFragmentInput.Count;
            if (_filesRemains == 0)
            {
                return;
            }

            _event = new ManualResetEvent(false);
            for (int i = 0; i < VirusFragmentInput.Count; i++)
            {
                ThreadPool.QueueUserWorkItem(ThreadCallBack, i);
            }
            _event.WaitOne();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ob">integer - index of element in VirusFragmentInput</param>
        private void ThreadCallBack(Object ob)
        {

            if (_done)
            {
                return;
            }
            //index of element in VirusFragmentInput
            int index = (int)ob;
            //detector
            byte[] binaryArray = VirusFragmentInput[index];
            // not contain in Benign set
            if (binaryArray != null && !IsMatchSelf(binaryArray))
            {
                //  virus

                lock (VirusFragmentOutput)
                {
                    // add to output Fragement
                    VirusFragmentOutput.Add(binaryArray);
                }
                // update global info
                Utils.Utils.GLOBAL_VIRUS_COUNT++;
                Utils.Utils.GUI_SUPPORT.UpdateVirusFragment();
            }

            if (Interlocked.Decrement(ref _filesRemains) == 0)
            {
                _event.Set();
            }

            // Update progress bar
            Utils.Utils.GUI_SUPPORT.UpdateProgressBar();

        }
        /// <summary>
        /// is Contain pBytes in BenignFragmentInput
        /// </summary>
        /// <param name="pBytes">Input bytes list</param>
        /// <returns></returns>
        private bool IsMatchSelf(byte[] pBytes)
        {
            //foreach (byte[] temp in BenignFragmentInput)
            //{
            //    if (_oMatching.Match(pBytes, temp))
            //        return true;
            //}
            //return false;
            return BenignFragmentInput.Any(temp => _oMatching.Match(pBytes, temp));
        }

        /// <summary>
        /// Stop Building detector
        /// </summary>
        internal void StopBuildDetector()
        {
            _done = true;
            _event.Set();
        }
        /// <summary>
        /// add detector into system
        /// </summary>
        /// <param name="pVirusFragments"></param>
        internal void StartAdditionNegative(TrainingData pVirusFragments)
        {
            _done = false;

            VirusFragmentInput = pVirusFragments;
            ReadDirectory(_pBenignDirectory, Utils.Utils.EMode.Benign);

            // Init progressbar before work
            Utils.Utils.GLOBAL_PROGRESSBAR_COUNT_MAX = VirusFragmentInput.Count;
            Utils.Utils.GUI_SUPPORT.InitProgressBar();

            // Init virus count
            Utils.Utils.GLOBAL_PROGRESSBAR_COUNT = 0;
            Utils.Utils.GLOBAL_VIRUS_COUNT = 0;
            Utils.Utils.GLOBAL_BENIGN_COUNT = BenignFragmentInput.Count;

            NegativeSelection();
        }

    }
}
