using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using AForge.Neuro;
using VirusDetector.Detector;

namespace VirusDetector.Utils
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    class Utils
    {
        // Bening | Virus
        public enum EMode
        {
            Benign = 0,
            Virus = 1
        }
        public static double TOLERANCE = 0.001; //byte

        // VR Count Status support
        public static int GLOBAL_LENGTH = 4; //byte
        public static int GLOBAL_STEP_SIZE = 2;

        // ProgressBar support
        public static int GLOBAL_PROGRESSBAR_COUNT = 0;
        public static int GLOBAL_PROGRESSBAR_COUNT_MAX = 0;

        // VR Count Status support
        public static int GLOBAL_VIRUS_COUNT = 0;
        public static int GLOBAL_BENIGN_COUNT = 0;

        // Support Object
        public static GuiSupport GUI_SUPPORT;

        public static int VIRUS_MARK = 1; // define virus as 1 and
        public static int BENIGN_MARK = -1;// benign as -1


        public static int VIRUS_MARK_SVM = 1; // define virus as 1 and
        public static int BENIGN_MARK_SVM = -1;// benign as -1

        // Global stopwatch
        // todo public static Stopwatch GLOBAL_STOPWATCH;

        //Utils.Utils.GLOBAL_STOPWATCH = System.Diagnostics.Stopwatch.StartNew();
        //// Your code U want stopwatch
        //Utils.Utils.GLOBAL_STOPWATCH.Stop();
        //var elapsedMs = Utils.Utils.GLOBAL_STOPWATCH.ElapsedMilliseconds;

        #region Detector Utils

        public static byte[] ConvertBytesIntoBinary(byte[] pBytes)
        {
            return pBytes.SelectMany(GetBits).ToArray();
        }

        public static byte[] Test_ConvertBytesIntoBinary(byte[] pBytes)
        {
            return pBytes.SelectMany(Test_GetBits).ToArray();
        }
        public static IEnumerable<byte> GetBits(byte b)
        {
            for (int i = 0; i < 8; i++)
            {
                if ((b & 0x80) != 0) yield return 1; else yield return 0;
                b *= 2;
            }
        }
        public static IEnumerable<byte> Test_GetBits(byte b)
        {
            for (int i = 0; i < 8; i++)
            {
                if ((b & 0x80) != 0) yield return 1; else yield return 0;
                b *= 2;
            }
        }
        /// <summary>
        /// convert binary array to decArray
        /// </summary>
        /// <param name="binaryArray"></param>
        /// <returns></returns>
        private static double[] BinaryArrayToDecArray(byte[] binaryArray)
        {
            string strBinary = String.Join("", binaryArray);
            string[] binary8 = Split(strBinary, 8);
            double[] result = binary8.Select(x => (double)Convert.ToUInt32(x, 2)).ToArray();
            return result;
        }

        /// <summary>
        // Mix detector, convert binary to decimal, 4 elements
        /// </summary>
        /// <param name="pVirusFragments">Virus fragment from Negative</param>
        /// <param name="pVirusLen">numb of Virus fragment</param>
        /// <param name="pBenignFragments">Benign frament form binign files-set</param>
        /// <param name="pBenignLen">num of Benign frament</param>
        /// <returns></returns>
        public static double[][] MixDetectorBase10(TrainingData pVirusFragments, int pVirusLen,
            TrainingData pBenignFragments, int pBenignLen)
        {
            int virusLen = Math.Min(pVirusFragments.Count, pVirusLen);
            int benignLen = Math.Min(pBenignFragments.Count, pBenignLen);
            int totalLen = virusLen + benignLen;
            //mix matrix
            double[][] mixData = new double[virusLen + benignLen][];
            HashSet<byte[]> virusData = new HashSet<byte[]>();
            HashSet<byte[]> benignData = new HashSet<byte[]>();

            int virusCount = 0;
            int benignCount = 0;
            int totalCount = 0;

            int ratioBenignVirus = (virusLen > 0 ? benignLen / virusLen : benignLen);
            bool isDone = false;

            Random rand = new Random();
            Random benignRand = new Random();

            while (!isDone)
            {
                // 1. kiem tra vr con khong, lay so lan lap random cua vr trong gioi han con lai hoac la size
                var numbProcessFragment = Math.Min(1, virusLen - virusCount);
                double[] decFragments;
                for (int i = 0; i < numbProcessFragment; i++)
                {
                    // get a virus fragment
                    var binaryVirusFragment = pVirusFragments[virusCount];

                    // Prevent data repeat
                    if (virusData.Contains(binaryVirusFragment))
                    {
                        continue;
                    }
                    virusData.Add(binaryVirusFragment);
                    // conver
                    decFragments = BinaryArrayToDecArray(binaryVirusFragment);
                    Array.Resize(ref decFragments, decFragments.Length + 1);
                    decFragments[decFragments.Length - 1] = VIRUS_MARK;
                    mixData[totalCount] = decFragments;

                    virusCount++;
                    totalCount++;
                }

                // 2. lay so lan lap random cua sach nt
                // +1 because Math.Min(a,b) means min from a to b-1 
                int m = Math.Min(benignLen - benignCount, rand.Next(1, ratioBenignVirus + 1));
                for (int i = 0; i < m; i++)
                {
                    // get random Benign Fragment
                    var index = benignRand.Next(0, pBenignFragments.Count);
                    var binaryBenignArray = pBenignFragments[index];

                    // Prevent data repeat
                    if (benignData.Contains(binaryBenignArray))
                    {
                        continue;
                    }
                    benignData.Add(binaryBenignArray);

                    decFragments = BinaryArrayToDecArray(binaryBenignArray);
                    Array.Resize(ref decFragments, decFragments.Length + 1);
                    decFragments[decFragments.Length - 1] = BENIGN_MARK;
                    mixData[totalCount] = decFragments;

                    benignCount++;
                    totalCount++;
                }

                isDone = (totalCount >= totalLen);
            }

            return mixData;
        }


        // Mix detector, out input in binary, 32 elements
        public static double[][] MixDetectorBase2(TrainingData pVirusFragments, int pVirusLen,
            TrainingData pBenignFragments, int pBenignLen)
        {

            int virusLen = Math.Min(pVirusFragments.Count, pVirusLen);
            int benignLen = Math.Min(pBenignFragments.Count, pBenignLen);
            int totalLen = virusLen + benignLen;

            double[][] mixData = new double[virusLen + benignLen][];
            HashSet<byte[]> virusData = new HashSet<byte[]>();
            HashSet<byte[]> benignData = new HashSet<byte[]>();

            int virusCount = 0;
            int benignCount = 0;
            int totalCount = 0;

            int randSize = benignLen / (virusLen > 0 ? virusLen : 1);
            bool done = false;

            Random rand = new Random();
            Random benignRand = new Random();

            while (!done)
            {
                // 1. kiem tra vr con khong, lay so lan lap random cua vr trong gioi han con lai hoac la size
                int n = Math.Min(1, virusLen - virusCount);
                for (int i = 0; i < n; i++)
                {
                    byte[] binaryArray = pVirusFragments[virusCount];

                    // Prevent data repeat
                    if (virusData.Contains(binaryArray))
                    {
                        continue;
                    }
                    virusData.Add(binaryArray);

                    Array.Resize(ref binaryArray, binaryArray.Length + 1);
                    double[] temp = binaryArray.Select(Convert.ToDouble).ToArray();
                    temp[temp.Length - 1] = VIRUS_MARK;
                    mixData[totalCount] = temp;

                    virusCount++;
                    totalCount++;
                }

                // 2. lay so lan lap random cua sach nt
                int m = Math.Min(benignLen - benignCount, rand.Next(1, randSize + 1)); // +1 because Math.Min(a,b) means min from a to b-1 
                for (int i = 0; i < m; i++)
                {
                    int index = benignRand.Next(0, pBenignFragments.Count);
                    byte[] binaryArray = pBenignFragments[index];

                    // Prevent data repeat
                    if (benignData.Contains(binaryArray))
                    {
                        continue;
                    }
                    benignData.Add(binaryArray);

                    Array.Resize(ref binaryArray, binaryArray.Length + 1);
                    double[] temp = binaryArray.Select(Convert.ToDouble).ToArray();
                    temp[temp.Length - 1] = BENIGN_MARK;
                    mixData[totalCount] = temp;

                    benignCount++;
                    totalCount++;
                }

                done = (totalCount >= totalLen);
            }

            return mixData;
        }


        public static String[] Split(string str, int chunkSize)
        {
            int len = str.Length;
            int elementCount = len / chunkSize;
            String[] result = new String[elementCount];
            for (int i = 0, j = 0; i < elementCount; i++, j += chunkSize)
            {
                result[i] = str.Substring(j, chunkSize);
            }
            return result;
        }


        public static String Test_ByteArrayToHex(byte[] byteArray)
        {
            string strBinary = String.Join("", byteArray);
            string strHex = Convert.ToInt32(strBinary, 2).ToString("X8");
            return strHex;
        }
        /// <summary>
        /// save detector to file
        /// </summary>
        /// <param name="pVirusFragments">Virus set</param>
        /// <param name="pVirusSavePath">Virus output file</param>
        /// <param name="pBenignFragments">Benign set</param>
        /// <param name="pbBenignSavePath">Benign output file</param>
        internal static void SaveDetector(TrainingData pVirusFragments, string pVirusSavePath,
            TrainingData pBenignFragments, string pbBenignSavePath)
        {
            using (Stream stream = File.Open(pVirusSavePath, FileMode.Create))
            {
                try
                {
                    var bformatter = new BinaryFormatter();

                    bformatter.Serialize(stream, pVirusFragments);
                }
                finally
                {
                    stream.Close();
                }
            }

            using (Stream stream = File.Open(pbBenignSavePath, FileMode.Create))
            {
                try
                {
                    var bformatter = new BinaryFormatter();

                    bformatter.Serialize(stream, pBenignFragments);
                }
                finally
                {
                    stream.Close();
                }
            }
        }
        /// <summary>
        /// Load detector from file
        /// </summary>
        /// <param name="pVirusFragments">Virus set</param>
        /// <param name="pVirusSavePath">input path</param>
        /// <param name="pBenignFragments">Benign set</param>
        /// <param name="pBenignSavePath">input path</param>
        [SuppressMessage("ReSharper", "RedundantAssignment")]
        internal static void LoadDetector(ref TrainingData pVirusFragments, string pVirusSavePath,
            ref  TrainingData pBenignFragments, string pBenignSavePath)
        {
            //deserialize
            using (Stream stream = File.Open(pVirusSavePath, FileMode.Open))
            {
                try
                {
                    var bformatter = new BinaryFormatter();

                    pVirusFragments = (TrainingData)bformatter.Deserialize(stream);
                }
                finally
                {
                    stream.Close();
                }
            }

            using (Stream stream = File.Open(pBenignSavePath, FileMode.Open))
            {
                try
                {
                    var bformatter = new BinaryFormatter();

                    pBenignFragments = (TrainingData)bformatter.Deserialize(stream);
                }
                finally
                {
                    stream.Close();
                }
            }
        }

        #endregion

        #region Clustering Utils
        public static void SaveNetwork(Network pNetwork, String pFileName)
        {
            pNetwork.Save(pFileName);
        }


        public static Network LoadNetwork(string pFileName)
        {
            return Network.Load(pFileName);
        }

        public static bool CheckVirus(double property)
        {
            var tolerance = TOLERANCE;
            if (Math.Abs(property - VIRUS_MARK) < tolerance)
                return true;
            if (Math.Abs(property - BENIGN_MARK) < tolerance)
                return false;

            throw new Exception("Check Virus Errror");
        }


        #endregion

        #region File Classifier Utils

        public static int CalcFormatRangeIndex(int[] pFormatRange, int pNumber)
        {
            int count = 0;
            foreach (int range in pFormatRange)
            {
                if (range > pNumber)
                    return count - 1;
                count++;
            }
            return count - 1;
        }

        #endregion

        public static int[] CalcFormatRange(string pFormatRange)
        {
            string[] strFormatRange = pFormatRange.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            return strFormatRange.Select(int.Parse).ToArray();
        }
        /// <summary>
        /// calculate numb of virus detector in mixed data
        /// </summary>
        /// <remarks>vi so detector co the trung nhau nen phai tinh lai</remarks>
        /// <param name="pDetectorData">mixed data</param>
        /// <returns></returns>
        internal static int[] CalcNumOfDetector(double[][] pDetectorData)
        {
            int detectorTypeIndex = pDetectorData[0].Length - 1;
            int numVirus = pDetectorData.Count(vector => CheckVirus(vector[detectorTypeIndex]));
            var numBenign = pDetectorData.Length - numVirus;
            return new[] { numVirus, numBenign };
        }

        internal static double CalcDangerousRate(double[] pInputs)
        {
            int len = pInputs.Length;
            double total = 0;
            for (int i = 0; i < len; i++)
            {
                total += pInputs[i] * i *i;
            }
            double count = (double)len * (len - 1) / 2;
            double result = total / count;
            result = Math.Round(result, 4);
            return result;
        }
        #region Unused Method

        //private static int[] HexArray2DecArray(String[] hexArray_)
        //{
        //    int len = hexArray_.Length;
        //    int[] result = new int[len];
        //    for (int i = 0; i < len; i++)
        //    {
        //        result[i] = Convert.ToInt32(hexArray_[i], 16);
        //    }
        //    return result;
        //}

        //private static String ByteArrayToHex(byte[] byteArray)
        //{
        //    try
        //    {
        //        String strBinary = String.Join("", byteArray);
        //        String strHex = Convert.ToUInt32(strBinary, 2).ToString("X8");
        //        return strHex;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception();
        //    }
        //}
        //private static void HexArray2DecArray(String[] hexArray_, ref double[] decArray_)
        //{
        //    int len = hexArray_.Length;
        //    for (int i = 0; i < len; i++)
        //    {
        //        decArray_[i] = Convert.ToInt32(hexArray_[i], 16);
        //    }
        //}

        #endregion
    }
}
