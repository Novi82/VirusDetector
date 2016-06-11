using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusDetector.Utils;
using VirusDetector.Clustering;

namespace VirusDetector.FileClassifier
{
    class FileClassifierData
    {
        Hashtable _htRawData;
        Hashtable _htFormattedData;
        int[] _formatRange;
        String _fileName;
        int _totalCount; // total str in file


        LKDistanceNetwork _distanceNetwork;

        public FileClassifierData()
        {
            _initialize();
        }

        public FileClassifierData(LKDistanceNetwork distanceNetwork_, String fileName_, int[] formatRange_)
        {
            _distanceNetwork = distanceNetwork_;
            _fileName = fileName_;
            _formatRange = formatRange_;
            _initialize();
            _compute();
        }

        private void _initialize()
        {
            _htRawData = new Hashtable();
            _htFormattedData = new Hashtable();
            _totalCount = 0;
        }

        private void _compute()
        {
            // Lay day byte
            // Doc 4 byte => Kohonen => result
            // + add to raw data
            // + calc for format data
            int length = 4;// 4 = 4 byte = 32bit
            int stepsize = 2;// each step = 2 bit to make data more
            byte[] bytes = File.ReadAllBytes(_fileName);
            for (int i = 0; i < bytes.Length - length; i += stepsize)
            {
                byte[] rawBytes = new byte[length];
                Array.Copy(bytes, i, rawBytes, 0, length);

                if (_distanceNetwork.InputsCount == 32)
                    rawBytes = Utils.Utils.ConvertBytesIntoBinary(rawBytes);
                _compute(rawBytes);
                _totalCount++;
            }
        }


        // Compute for 32bit str
        private void _compute(byte[] rawBytes)
        {
            double[] input = rawBytes.Select(Convert.ToDouble).ToArray();

            _distanceNetwork.Compute(input);
            LKDistanceNeuron winner = _distanceNetwork.getWinnerNeuron();
            int rawKey = (winner.getClusterLable() == 2 ? winner.VirusDetectedCount : 0);
            _hashmapAddKey(_htRawData, rawKey);
            int formattedKey = Utils.Utils.calcFormatRangeIndex(_formatRange, rawKey);
            _hashmapAddKey(_htFormattedData, formattedKey);

        }

        private void _hashmapAddKey(Hashtable _hashmap, int key)
        {
            if (_hashmap.ContainsKey(key))
            {
                int value = (int)_hashmap[key];
                value++;
                _hashmap.Remove(key);
                _hashmap.Add(key, value);
            }
            else
                _hashmap.Add(key, 1);
        }

        public double[] getFormatData()
        {
            int len = _formatRange.Length;
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

        public double[] getRateFormatData()
        {
            int len = _formatRange.Length;
            double[] result = new double[len];
            for (int i = 0; i < len; i++)
            {
                if (_htFormattedData.ContainsKey(i))
                {
                    double value = (double)(int)_htFormattedData[i] / _totalCount;
                    result[i] = Math.Round(value, 4);
                }
                else
                    result[i] = 0;
            }
            return result;
        }

        public String[] Test_GetFormatData(double type, String fileName_)
        {
            int len = _formatRange.Length;
            String[] result = new String[len + 2];
            for (int i = 0; i < len; i++)
            {
                if (_htFormattedData.ContainsKey(i))
                    result[i] = ((int)_htFormattedData[i]).ToString();
                else
                    result[i] = "0";
            }
            result[len] = type.ToString();
            result[len + 1] = fileName_;
            return result;
        }

        public String[] Test_GetRateFormatData(double type, String fileName_)
        {
            int len = _formatRange.Length;
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
            result[len + 1] = fileName_;
            return result;
        }

        public double[] getRawData()
        {
            return null;
        }
    
    }
}
