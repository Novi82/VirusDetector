using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using VirusDetector.Clustering;
using VirusDetector.Detector;
using AForge.Neuro;

namespace VirusDetector.Utils
{
    class Utils
    {
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

        // Global stopwatch
        public static System.Diagnostics.Stopwatch GLOBAL_STOPWATCH;

        //Utils.Utils.GLOBAL_STOPWATCH = System.Diagnostics.Stopwatch.StartNew();
        //// Your code U want stopwatch
        //Utils.Utils.GLOBAL_STOPWATCH.Stop();
        //var elapsedMs = Utils.Utils.GLOBAL_STOPWATCH.ElapsedMilliseconds;

        #region Detector Utils

        public static byte[] ConvertBytesIntoBinary(byte[] _bytes)
        {
            return _bytes.SelectMany(GetBits).ToArray();
        }

        public static byte[] Test_ConvertBytesIntoBinary(byte[] _bytes)
        {
            return _bytes.SelectMany(Test_GetBits).ToArray();
        }
        public static IEnumerable<byte> GetBits(byte b)
        {
            for (int i = 0; i < 8; i++)
            {
                if ((b & 0x80) != 0) yield return (byte)1; else yield return (byte)0;
                b *= 2;
            }
        }
        public static IEnumerable<byte> Test_GetBits(byte b)
        {
            for (int i = 0; i < 8; i++)
            {
                if ((b & 0x80) != 0) yield return (byte)1; else yield return (byte)0;
                b *= 2;
            }
        }

        private static double[] binaryArrayToDecArray(byte[] binaryArray)
        {
            String strBinary = String.Join("", binaryArray);
            String[] binary8 = Split(strBinary, 8);
            double[] result = binary8.Select(x => (double)Convert.ToUInt32(x, 2)).ToArray();
            return result;
        }

        // Mix detector, convert binary to decimal, 4 elements
        public static double[][] mixDetectorBase10(TrainingData VirusFragments, int virusLen_, TrainingData BenignFragments, int benignLen_)
        {

            int virusLen = Math.Min(VirusFragments.Count, virusLen_);
            int benignLen = Math.Min(BenignFragments.Count, benignLen_);
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
                    byte[] binaryArray = VirusFragments[virusCount];

                    // Prevent data repeat
                    if (virusData.Contains(binaryArray))
                    {
                        continue;
                    }
                    virusData.Add(binaryArray);

                    double[] temp = binaryArrayToDecArray(binaryArray);
                    Array.Resize<double>(ref temp, temp.Length + 1);
                    temp[temp.Length - 1] = VIRUS_MARK;
                    mixData[totalCount] = temp;

                    virusCount++;
                    totalCount++;
                }

                // 2. lay so lan lap random cua sach nt
                int m = Math.Min(benignLen - benignCount, rand.Next(1, randSize + 1)); // +1 because Math.Min(a,b) means min from a to b-1 
                for (int i = 0; i < m; i++)
                {
                    int index = benignRand.Next(0, BenignFragments.Count);
                    byte[] binaryArray = BenignFragments[index];

                    // Prevent data repeat
                    if (benignData.Contains(binaryArray))
                    {
                        continue;
                    }
                    benignData.Add(binaryArray);

                    double[] temp = binaryArrayToDecArray(binaryArray);
                    Array.Resize<double>(ref temp, temp.Length + 1);
                    temp[temp.Length - 1] = BENIGN_MARK;
                    mixData[totalCount] = temp;

                    benignCount++;
                    totalCount++;
                }

                done = (totalCount >= totalLen);
            }

            return mixData;
        }


        // Mix detector, out input in binary, 32 elements
        public static double[][] mixDetectorBase2(TrainingData VirusFragments, int virusLen_, TrainingData BenignFragments, int benignLen_)
        {

            int virusLen = Math.Min(VirusFragments.Count, virusLen_);
            int benignLen = Math.Min(BenignFragments.Count, benignLen_);
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
                    byte[] binaryArray = VirusFragments[virusCount];

                    // Prevent data repeat
                    if (virusData.Contains(binaryArray))
                    {
                        continue;
                    }
                    virusData.Add(binaryArray);

                    Array.Resize<byte>(ref binaryArray, binaryArray.Length + 1);
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
                    int index = benignRand.Next(0, BenignFragments.Count);
                    byte[] binaryArray = BenignFragments[index];

                    // Prevent data repeat
                    if (benignData.Contains(binaryArray))
                    {
                        continue;
                    }
                    benignData.Add(binaryArray);

                    Array.Resize<byte>(ref binaryArray, binaryArray.Length + 1);
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

        public static void saveMixDetector(double[][] input_, String fileName_)
        {
            StreamWriter file = new StreamWriter(fileName_);
            int len0 = input_.Length;
            int len1 = input_[0].Length;

            for (int i = 0; i < len0 - 1; i++)
            {
                for (int j = 0; j < len1 - 1; j++)
                {
                    file.Write(input_[i][j] + ",");
                }
                file.WriteLine(input_[i][len1 - 1]);
            }

            // Write the last one
            for (int j = 0; j < len1 - 1; j++)
            {
                file.Write(input_[len0 - 1][j] + ",");
            }
            file.Write(input_[len0 - 1][len1 - 1]);

            // Close file
            file.Close();
        }

        public static double[][] loadMixDetector(String fileName_)
        {
            double[][] _input;
            var lines = File.ReadAllLines(fileName_);
            var len = lines.Length;
            _input = new double[len][];
            int countX = 0;
            foreach (var line in lines)
            {
                String[] raw = line.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                int countY = 0;
                _input[countX] = new double[raw.Length];
                foreach (var item in raw)
                {
                    _input[countX][countY] = double.Parse(item);
                    countY++;
                }
                countX++;

            }
            return _input;
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
            try
            {
                String strBinary = String.Join("", byteArray);
                String strHex = Convert.ToInt32(strBinary, 2).ToString("X8");
                return strHex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        internal static void saveDetector(TrainingData _virusFragments, string virusSavePath, TrainingData BenignFragments, string benignSavePath)
        {
            using (Stream stream = File.Open(virusSavePath, FileMode.Create))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                bformatter.Serialize(stream, _virusFragments);
            }

            using (Stream stream = File.Open(benignSavePath, FileMode.Create))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                bformatter.Serialize(stream, BenignFragments);
            }



        }

        internal static void loadDetector(ref TrainingData _virusFragments, string virusSavePath, ref  TrainingData BenignFragments, string benignSavePath)
        {
            //deserialize
            using (Stream stream = File.Open(virusSavePath, FileMode.Open))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                _virusFragments = (TrainingData)bformatter.Deserialize(stream);
            }

            using (Stream stream = File.Open(benignSavePath, FileMode.Open))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                BenignFragments = (TrainingData)bformatter.Deserialize(stream);
            }
        }



        #endregion

        #region Clustering Utils
        public static void saveNetwork(Network network_, String fileName_)
        {
            network_.Save(fileName_);
        }


        public static Network loadNetwork(string fileName_)
        {
            return Network.Load(fileName_);
        }

        public static bool checkVirus(double property)
        {
            if (property == VIRUS_MARK)
                return true;
            else if (property == BENIGN_MARK)
                return false;

            throw new Exception();
        }


        #endregion

        #region File Classifier Utils

        public static int calcFormatRangeIndex(int[] formatRange_, int number_)
        {
            int count = 0;
            foreach (int range in formatRange_)
            {
                if (range > number_)
                    return count - 1;
                count++;
            }
            return count - 1;
        }

        #endregion

        public static int[] calcFormatRange(string formatRange_)
        {
            String[] strFormatRange = formatRange_.Split(new String[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            return strFormatRange.Select(int.Parse).ToArray();
        }

        internal static int[] calcNumOfDetector(double[][] detectorData_)
        {
            int numVirus = 0;
            int numBenign = 0;
            int detectorTypeIndex = detectorData_[0].Length - 1;
            foreach (double[] vector in detectorData_)
            {
                if (checkVirus(vector[detectorTypeIndex]))
                {
                    numVirus++;
                }
            }
            numBenign = detectorData_.Length - numVirus;
            return new int[] { numVirus, numBenign };
        }

        internal static double calcDangerousRate(double[] input_)
        {
            int len = input_.Length;
            double total = 0;
            for (int i = 0; i < len; i++)
            {
                total += input_[i] * i;
            }
            double count = len * (len - 1) / 2;
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
