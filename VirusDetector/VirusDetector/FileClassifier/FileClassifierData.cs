using System;
using System.Collections;
using System.IO;
using System.Linq;
using Accord.MachineLearning.VectorMachines;
using VirusDetector.Clustering;

namespace VirusDetector.FileClassifier
{
    class FileClassifierData
    {
        Hashtable _htRawData;
        Hashtable _htFormattedData;
        int[] _pFormatRange;
        String _pFileName;
        int _totalCount; // total str in file

        LkDistanceNetwork _pDistanceNetwork;

        KernelSupportVectorMachine _svm;
        public FileClassifierData()
        {
            _initialize();
        }

        public FileClassifierData(LkDistanceNetwork pDistanceNetwork, string pFileName, int[] pFormatRange)
        {
            _pDistanceNetwork = pDistanceNetwork;
            _pFileName = pFileName;
            _pFormatRange = pFormatRange;
            _initialize();
            _compute();
        }

        public FileClassifierData(LkDistanceNetwork pDistanceNetwork, KernelSupportVectorMachine pSvm, String pFileName, int[] pFormatRange)
        {
            _pDistanceNetwork = pDistanceNetwork;
            _svm = pSvm;
            _pFileName = pFileName;
            _pFormatRange = pFormatRange;
            _initialize();
            _compute();
        }

        private void _initialize()
        {
            _htRawData = new Hashtable();
            _htFormattedData = new Hashtable();
            _totalCount = 0;
        }
        public void _computeSvm()
        {
            // Lay day byte
            // Doc 4 byte => Kohonen => result
            // + add to raw data
            // + calc for format data
            int length = Utils.Utils.GLOBAL_LENGTH;// 4 = 4 byte = 32bit
            int stepsize = Utils.Utils.GLOBAL_STEP_SIZE;// each step = 2 bit to make data more

            byte[] bytes = File.ReadAllBytes(_pFileName);
            for (int i = 0; i < bytes.Length - length; i += stepsize)
            {
                byte[] rawBytes = new byte[length];
                Array.Copy(bytes, i, rawBytes, 0, length);

                if (_pDistanceNetwork.InputsCount == 32)
                     rawBytes = Utils.Utils.ConvertBytesIntoBinary(rawBytes);

                _compute(rawBytes);
                _totalCount++;
            }
        }

        private void _compute()
        {
            // Lay day byte
            // Doc 4 byte => Kohonen => result
            // + add to raw data
            // + calc for format data
            int length = 4;// 4 = 4 byte = 32bit
            int stepsize = 2;// each step = 2 bit to make data more
            byte[] bytes = File.ReadAllBytes(_pFileName);
            for (int i = 0; i < bytes.Length - length; i += stepsize)
            {
                byte[] rawBytes = new byte[length];
                Array.Copy(bytes, i, rawBytes, 0, length);

                if (_pDistanceNetwork.InputsCount == 32)
                    rawBytes = Utils.Utils.ConvertBytesIntoBinary(rawBytes);
                _compute(rawBytes);
                _totalCount++;
            }
        }

        // Compute for 32bit str
        private void _compute(byte[] rawBytes)
        {
            double[] input = rawBytes.Select(Convert.ToDouble).ToArray();

            _pDistanceNetwork.Compute(input);
            LkDistanceNeuron winner = _pDistanceNetwork.GetWinnerNeuron();
            int rawKey = (winner.GetClusterLable() == 2 ? winner.VirusDetectedCount : 0);
            _hashmapAddKey(_htRawData, rawKey);
            int formattedKey = Utils.Utils.CalcFormatRangeIndex(_pFormatRange, rawKey);
            _hashmapAddKey(_htFormattedData, formattedKey);

        }

        private void _hashmapAddKey(Hashtable pHashtable, int key)
        {
            if (pHashtable.ContainsKey(key))
            {
                int value = (int)pHashtable[key];
                value++;
                pHashtable.Remove(key);
                pHashtable.Add(key, value);
            }
            else
                pHashtable.Add(key, 1);
        }

        public double[] GetFormatData()
        {
            int len = _pFormatRange.Length;
            double[] result = new double[len];
            for (int i = 0; i < len; i++)
            {
                if (_htFormattedData.ContainsKey(i))
                    result[i] = (int)_htFormattedData[i];
                else
                    result[i] = 0;
            }
            return result;
        }

        public double[] GetRateFormatData()
        {
            int len = _pFormatRange.Length;
            double[] result = new double[len];
            for (int i = 0; i < len; i++)
            {
                if (_htFormattedData.ContainsKey(i))
                {
                   // double value = (double)(int)_htFormattedData[i] / _totalCount;
                    double value = (double)(int)_htFormattedData[i] / _totalCount;
                    result[i] = Math.Round(value, 4);
                }
                else
                    result[i] = 0;
            }
            return result;
        }

        public String[] Test_GetFormatData(double pType, String pFileName)
        {
            int len = _pFormatRange.Length;
            String[] result = new String[len + 2];
            for (int i = 0; i < len; i++)
            {
                if (_htFormattedData.ContainsKey(i))
                    result[i] = ((int)_htFormattedData[i]).ToString();
                else
                    result[i] = "0";
            }
            result[len] = pType.ToString();
            result[len + 1] = pFileName;
            return result;
        }

        public String[] Test_GetRateFormatData(double type, String pFileName)
        {
            int len = _pFormatRange.Length;
            String[] result = new String[len + 2];
            for (int i = 0; i < len; i++)
            {
                if (_htFormattedData.ContainsKey(i))
                {
                    double value = (double)(int)_htFormattedData[i] / _totalCount;
                    result[i] = Math.Round(value, 4).ToString();
                }
                else
                    result[i] = "0";
            }
            result[len] = type.ToString();
            result[len + 1] = pFileName;
            return result;
        }
    }
}