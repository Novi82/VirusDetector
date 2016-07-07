//using System;
//using System.IO;
//using VirusDetector.Detector;

//namespace VirusDetector.StringCompare
//{
//    class StringCompareData
//    {
//        TrainingData _virusFragments;
//        int _length;
//        int _stepsize;
//        int _detectCount;
//        int _totalStringCount;

//        //
//        private Matching M;
//        public StringCompareData(TrainingData detector_, int hamingThresold_, int rContinuousThresold_, int length_, int stepsize_, Boolean useHaming_, Boolean useRContinuous_)
//        {
//            _virusFragments = detector_;
//            _length = length_;
//            _stepsize = stepsize_;
//            M = new Matching(hamingThresold_, rContinuousThresold_, useHaming_, useRContinuous_);

//            _initialize();
//        }

//        private void _initialize()
//        {
//            _detectCount = 0;
//            _totalStringCount = 0;
//        }

//        private void _reset()
//        {
//            _detectCount = 0;
//            _totalStringCount = 0;
//        }

//        public void Compute(String fileName_)
//        {
//            _reset();

//            // Doc file
//            byte[] bytes = File.ReadAllBytes(fileName_);
//            // Lay tung chuoi so sanh voi cac detector
//            for (int i = 0; i < bytes.Length - _length; i += _stepsize)
//            {
//                byte[] rawBytes = new byte[_length];
//                Array.Copy(bytes, i, rawBytes, 0, _length);
//                byte[] binaryArray = Utils.Utils.ConvertBytesIntoBinary(rawBytes);
//                _totalStringCount++;
//                Boolean result = _compute(binaryArray);
//                if (result)
//                    _detectCount++;
//            }

//            // Debug
//            //Console.WriteLine(_detectCount + ": " + fileName_);
//        }

//        private bool _compute(byte[] binaryArray)
//        {
//            if (binaryArray == null)
//                return false;
//            bool result = IsMatchSelf(binaryArray);
//            return result;
//        }

//        private bool IsMatchSelf(byte[] _byte)
//        {

//            for (int j = 0; j < _virusFragments.Count; j++)
//            {
//                if (M.Match(_byte, _virusFragments[j]))
//                    return true;
//            }
//            return false;
//        }

//        public double getRateWithTotalFileString()
//        {
//            return (double)_detectCount / _totalStringCount;
//        }

//        public double getRateWithTotalVirusFragment()
//        {
//            return (double)_detectCount / _virusFragments.Count;
//        }
//    }
//}
