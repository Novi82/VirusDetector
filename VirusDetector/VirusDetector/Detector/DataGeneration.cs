using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VirusDetector.Utils;

namespace VirusDetector.Detector
{
    class DataGeneration
    {
        #region Variable
        
        List<string> filenames = new List<string>();
        public TrainingData BenignFragmentInput = new TrainingData();
        public TrainingData VirusFragmentInput = new TrainingData();
        public TrainingData VirusFragmentOutput = new TrainingData();
        /// <summary>
        /// todo
        /// </summary>
        public EFragmentType[] state;
        private int filesRemains = 0;
        /// <summary>
        /// Matching object
        /// </summary>
        private Matching oMatching;
        private string virusDirectory = "";
        private string benignDirectory = "";
        public string VirusDirectory
        {
            get { return virusDirectory; }
            set { virusDirectory = value; }
        }
        public string BenignDirectory
        {
            get { return benignDirectory; }
            set { benignDirectory = value; }
        }
        private string outputFile = "";
        public string OutputFile
        {
            get { return outputFile; }
            set { outputFile = value; }
        }
        private int length;     // 4 bytes (32 bits )
        private int stepsize;   // 2 bytes (16 bits )
        public int Length
        {
            get { return length; }
            set
            {
                length = value;
            }
        }
        public int Stepsize
        {
            get { return stepsize; }
        }
        #endregion

        #region event
        private ManualResetEvent Event;

        // Stop support
        Boolean _done;
        #endregion
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="_VirusDirectory"></param>
        /// <param name="_BenignDirectory"></param>
        /// <param name="_Hamming"></param>
        /// <param name="_RContiguous"></param>
        /// <param name="_length"></param>
        /// <param name="_stepsize"></param>
        /// <param name="Flag1"></param>
        /// <param name="Flag2"></param>
        public DataGeneration(string _VirusDirectory, string _BenignDirectory, int _Hamming, int _RContiguous, int _length, int _stepsize, bool Flag1, bool Flag2)
        {
            oMatching = new Matching(_Hamming, _RContiguous, Flag1, Flag2);
            length = _length;
            stepsize = _stepsize;
            benignDirectory = _BenignDirectory;
            virusDirectory = _VirusDirectory;

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
        /// <param name="Path"></param>
        /// <param name="pMode">1: Benign | 2: Virus</param>
        private void ReadFile(string Path, Utils.Utils.EMode pMode)
        {
            byte[] bytes = File.ReadAllBytes(Path);
            byte[] temp = new byte[length];
            byte[] binaryArray;
            for (int i = 0; i <= bytes.Length - length; i += stepsize)
            {
                Array.Copy(bytes, i, temp, 0, length);
                binaryArray = Utils.Utils.ConvertBytesIntoBinary(temp);
                String strBinary = String.Join("", binaryArray);

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
        public void startBuildDetector()
        {
            _done = false;

            this.ReadDirectory(benignDirectory,Utils.Utils.EMode.Benign);
            this.ReadDirectory(virusDirectory, Utils.Utils.EMode.Virus);

            // Init progressbar before work
            Utils.Utils.GLOBAL_PROGRESSBAR_COUNT_MAX = VirusFragmentInput.Count;
            Utils.Utils.GUI_SUPPORT.initProgressBar();

            // Init virus count
            Utils.Utils.GLOBAL_PROGRESSBAR_COUNT = 0;
            Utils.Utils.GLOBAL_VIRUS_COUNT = 0;
            Utils.Utils.GLOBAL_BENIGN_COUNT = this.BenignFragmentInput.Count;

            NegativeSelection();
        }

        /// <summary>
        /// NegativeSelection -- remove benign in virus data set
        /// </summary>
        private void NegativeSelection()
        {
            filesRemains = VirusFragmentInput.Count;
            if (filesRemains == 0)
            {
                return;
            }

            state = new EFragmentType[VirusFragmentInput.Count];
            Event = new ManualResetEvent(false);
            for (int i = 0; i < VirusFragmentInput.Count; i++)
            {
                ThreadPool.QueueUserWorkItem(ThreadCallBack, i);
            }
            Event.WaitOne();
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
                state[index] = EFragmentType.Virus;

                lock (VirusFragmentOutput)
                {
                    // add to output Fragement
                    VirusFragmentOutput.Add(binaryArray);
                }
                // update global info
                Utils.Utils.GLOBAL_VIRUS_COUNT++;
                Utils.Utils.GUI_SUPPORT.updateVirusFragment();
            }
            else
            {
                // benign
                state[index] = EFragmentType.Benign;
            }

            if (Interlocked.Decrement(ref filesRemains) == 0)
            {
                Event.Set();
            }

            // Update progress bar
            Utils.Utils.GUI_SUPPORT.updateProgressBar();

        }
        /// <summary>
        /// is Contain pBytes in BenignFragmentInput
        /// </summary>
        /// <param name="pBytes">Input bytes list</param>
        /// <returns></returns>
        private bool IsMatchSelf(byte[] pBytes)
        {
            foreach (byte[] temp in BenignFragmentInput)
            {
                if (oMatching.Match(pBytes, temp))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Stop Building detector
        /// </summary>
        internal void stopBuildDetector()
        {
            _done = true;
            Event.Set();
        }
        /// <summary>
        /// add detector into system
        /// </summary>
        /// <param name="pVirusFragments"></param>
        internal void startAdditionNegative(TrainingData pVirusFragments)
        {
            _done = false;

            VirusFragmentInput = pVirusFragments;
            ReadDirectory(benignDirectory, Utils.Utils.EMode.Benign);

            // Init progressbar before work
            Utils.Utils.GLOBAL_PROGRESSBAR_COUNT_MAX = VirusFragmentInput.Count;
            Utils.Utils.GUI_SUPPORT.initProgressBar();

            // Init virus count
            Utils.Utils.GLOBAL_PROGRESSBAR_COUNT = 0;
            Utils.Utils.GLOBAL_VIRUS_COUNT = 0;
            Utils.Utils.GLOBAL_BENIGN_COUNT = this.BenignFragmentInput.Count;

            NegativeSelection();
        }

    }
}
