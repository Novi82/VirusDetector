using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusDetector.Detector
{
    class Matching
    {
        #region variable
        private bool _isUseHamming = true;
        private bool _isRcontinous = true;
        /// <summary>
        /// is use Hamming Distance
        /// </summary>
        public bool UseHammingDistance { get { return _isUseHamming; } set { _isUseHamming = value; } }
        /// <summary>
        /// is use RContinous Distance
        /// </summary>
        public bool UseR_continuous { get { return _isRcontinous; } set { _isRcontinous = value; } }
        private int _HammingThreshold;
        private int _RContinousThreshold;
        /// <summary>
        /// Hamming Distance
        /// </summary>
        public int HammingThreshold { get { return _HammingThreshold; } set { _HammingThreshold = value; } }
        /// <summary>
        /// RContinous Distance
        /// </summary>
        public int RContinousThreshold { get { return _RContinousThreshold; } set { _RContinousThreshold = value; } }

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
            _HammingThreshold = pHamming;
            _RContinousThreshold = pRContinous;
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
            // Todo Debug
            #if debug
            String strBinary1 = String.Join("", pDetector1);
            String strBinary2 = String.Join("", pDetector2);
            #endif
            // calculate distance
            int HammingDistance = Hamming.Distance(pDetector1, pDetector2);
            // todo del int m = MaxHammingDistance.HammingMaxDistance(s1, s2);
            int RConDistance = RContiguous.MaxDistance(pDetector1, pDetector2);
            // use both Hamming and RCon
            if (_isUseHamming && _isRcontinous || !_isUseHamming && !_isRcontinous)
            {
                if (RConDistance >= _RContinousThreshold && HammingDistance <= _HammingThreshold)
                    return true;
            }
            // use Rcon
            if (!_isUseHamming && _isRcontinous)
                if (RConDistance >= _RContinousThreshold)
                    return true;
            // use hamming
            if (_isUseHamming && !_isRcontinous)
                if (HammingDistance <= _HammingThreshold)
                    return true;
            return false;
        }
    }
}
