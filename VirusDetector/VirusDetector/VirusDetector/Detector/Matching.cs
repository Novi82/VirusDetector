namespace VirusDetector.Detector
{
    class Matching
    {
        #region variable
        private bool _isUseHamming;
        private bool _isRcontinous;
        /// <summary>
        /// is use Hamming Distance
        /// </summary>
        public bool UseHammingDistance { get { return _isUseHamming; } set { _isUseHamming = value; } }
        /// <summary>
        /// is use RContinous Distance
        /// </summary>
        public bool UseR_continuous { get { return _isRcontinous; } set { _isRcontinous = value; } }
        private int _hammingThreshold;
        private int _rContinousThreshold;
        /// <summary>
        /// Hamming Distance
        /// </summary>
        public int HammingThreshold { get { return _hammingThreshold; } set { _hammingThreshold = value; } }
        /// <summary>
        /// RContinous Distance
        /// </summary>
        public int RContinousThreshold { get { return _rContinousThreshold; } set { _rContinousThreshold = value; } }

        #endregion

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="pHamming">Hamming</param>
        /// <param name="pRContinous">RContinous</param>
        /// <param name="pisUseHamming">is UseHammingDistance</param>
        /// <param name="pisUseRcontinous">is UseR_continuous</param>
        public Matching(int pHamming, int pRContinous, bool pisUseHamming, bool pisUseRcontinous)
        {
            _hammingThreshold = pHamming;
            _rContinousThreshold = pRContinous;
            _isUseHamming = pisUseHamming;
            _isRcontinous = pisUseRcontinous;

        }
        /// <summary>
        /// Compare 2 detector
        /// </summary>
        /// <param name="pDetector1"></param>
        /// <param name="pDetector2"></param>
        /// <returns></returns>
        public bool Match(byte[] pDetector1, byte[] pDetector2)
        {
            #if debug
            String strBinary1 = String.Join("", pDetector1);
            String strBinary2 = String.Join("", pDetector2);
            #endif
            // calculate distance
            int hammingDistance = Hamming.Distance(pDetector1, pDetector2);
            int rConDistance = RContiguous.MaxDistance(pDetector1, pDetector2);
            // use both Hamming and RCon
            if (_isUseHamming && _isRcontinous || !_isUseHamming && !_isRcontinous)
            {
                if (rConDistance >= _rContinousThreshold && hammingDistance <= _hammingThreshold)
                    return true;
            }
            // use Rcon
            if (!_isUseHamming && _isRcontinous)
                if (rConDistance >= _rContinousThreshold)
                    return true;
            // use hamming
            if (_isUseHamming && !_isRcontinous)
                if (hammingDistance <= _hammingThreshold)
                    return true;
            return false;
        }
    }
}
