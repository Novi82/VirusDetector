using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VirusDetector.Detector
{
    class DataGeneration
    {
        List<string> filenames = new List<string>();
        public TrainingData BenignFragmentInput = new TrainingData();
        public TrainingData VirusFragmentInput = new TrainingData();
        public TrainingData VirusFragmentOutput = new TrainingData();
        public int[] state;
        private int filesRemains = 0;
        private Matching M;
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
        private int length;
        private int stepsize;// 1 byte= 8 bit       
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
        private ManualResetEvent Event;

        // Stop support
        Boolean _done;

        public DataGeneration(string _VirusDirectory, string _BenignDirectory, int d, int r, int _length, int _stepsize, bool Flag1, bool Flag2)
        {
            M = new Matching(d, r, Flag1, Flag2);
            length = _length;
            stepsize = _stepsize;
            benignDirectory = _BenignDirectory;
            virusDirectory = _VirusDirectory;

            _initialize();

        }

        private void _initialize()
        {
            _done = false;
        }
        private void Readfile(string Path, bool flag)
        {
            byte[] bytes = File.ReadAllBytes(Path);
            byte[] temp = new byte[length];
            byte[] binaryArray;
            for (int i = 0; i <= bytes.Length - length; i += stepsize)
            {
                Array.Copy(bytes, i, temp, 0, length);
                binaryArray = Utils.Utils.ConvertBytesIntoBinary(temp);
                String strBinary = String.Join("", binaryArray);

                if (flag)
                {
                    if (binaryArray != null)
                        BenignFragmentInput.Add(binaryArray);
                }
                else
                {
                    if (binaryArray != null)
                    {
                        VirusFragmentInput.Add(binaryArray);
                    }
                        
                }
            }
        }

        //public static void ProcessDirectory(string targetDirectory)
        //{
        //    // Process the list of files found in the directory.
        //    string[] fileEntries = Directory.GetFiles(targetDirectory);
        //    foreach (string fileName in fileEntries)
        //        ProcessFile(fileName);
        //    // Recurse into subdirectories of this directory.
        //    string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
        //    foreach (string subdirectory in subdirectoryEntries)
        //        ProcessDirectory(subdirectory);
        //}
        private void ReadDirectory(string directory, bool flag)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories);
            foreach (string fileName in fileEntries)
                Readfile(fileName, flag);
        }

        //private void ReadDirectory(string directory, bool flag)
        //{
        //    filenames.Clear();
        //    filenames.AddRange(Directory.GetFiles(directory, "*.exe", SearchOption.AllDirectories));
        //    filenames.AddRange(Directory.GetFiles(directory, "*.com", SearchOption.AllDirectories));
        //    filenames.AddRange(Directory.GetFiles(directory, "*.bat", SearchOption.AllDirectories));

        //    foreach (string file in filenames)
        //    {
        //        Readfile(file, flag);
        //    }
        //}


        public void startBuildDetector()
        {
            _done = false;

            ReadDirectory(benignDirectory, true);
            ReadDirectory(virusDirectory, false);

            // Init progressbar before work
            Utils.Utils.GLOBAL_PROGRESSBAR_COUNT_MAX = VirusFragmentInput.Count;
            Utils.Utils.GUI_SUPPORT.initProgressBar();

            // Init virus count
            Utils.Utils.GLOBAL_PROGRESSBAR_COUNT = 0;
            Utils.Utils.GLOBAL_VIRUS_COUNT = 0;
            Utils.Utils.GLOBAL_BENIGN_COUNT = this.BenignFragmentInput.Count;

            NegativeSelection();
        }


        private void NegativeSelection()
        {
            if ((filesRemains = VirusFragmentInput.Count) == 0)
            {
                return;
            }
                
            state = new int[VirusFragmentInput.Count];
            Event = new ManualResetEvent(false);
            for (int i = 0; i < VirusFragmentInput.Count ; i++)
            {
                ThreadPool.QueueUserWorkItem(ThreadCallBack, i);
            }
            Event.WaitOne();
        }
        private void ThreadCallBack(Object ob)
        {

            if (_done)
            {
                return;
            }

            int index = (int)ob;
            byte[] binaryArray = VirusFragmentInput[index];
            if (binaryArray != null && !IsMatchSelf(binaryArray))
            {
                state[index] = 0;

                lock (VirusFragmentOutput)
                {
                    VirusFragmentOutput.Add(binaryArray);
                }

                Utils.Utils.GLOBAL_VIRUS_COUNT++;
                Utils.Utils.GUI_SUPPORT.updateVirusFragment();

            }
            else
            {
                state[index] = 1;
            }

            

            if (Interlocked.Decrement(ref filesRemains) == 0)
            {
                Event.Set();
            }

            // Update progress bar
            Utils.Utils.GUI_SUPPORT.updateProgressBar();

        }
        private bool IsMatchSelf(byte[] _byte)
        {

            for (int j = 0; j < BenignFragmentInput.Count; j++)
            {
                if (M.Match(_byte, BenignFragmentInput[j]))
                    return true;
            }
            return false;
        }


        internal void stopBuildDetector()
        {
            _done = true;
            Event.Set();
        }

        internal void startAdditionNegative(TrainingData virusFragments_)
        {
            _done = false;

            VirusFragmentInput = virusFragments_;
            ReadDirectory(benignDirectory, true);

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
