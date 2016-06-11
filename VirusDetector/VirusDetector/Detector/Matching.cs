using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusDetector.Detector
{
    class Matching
    {
        private bool H = true;
        private bool RC = true;
        public bool UseHammingDistance { get { return H; } set { H = value; } }
        public bool UseR_continuous { get { return RC; } set { RC = value; } }
        private int d;
        private int r;
        public int D { get { return d; } set { d = value; } }
        public int R { get { return r; } set { r = value; } }
        public Matching(int _d, int _r, bool _h, bool _rc)
        {
            d = _d;
            r = _r;
            H = _h;
            RC = _rc;

        }
        public bool Match(byte[] s1, byte[] s2)
        {
            // Debug
            String strBinary1 = String.Join("", s1);
            String strBinary2 = String.Join("", s2);

            int m = MaxHammingDistance.HammingDistance(s1, s2);
            //int m = MaxHammingDistance.HammingMaxDistance(s1, s2);
            int n = RContiguous.ShiftRContiguous(s1, s2);
            if (H && RC || !H && !RC)
            {
                if (n >= r && m <= d)
                    return true;
            }
            if (!H && RC)
                if (n >= r)
                    return true;
            if (H && !RC)
                if (m <= d)
                    return true;
            return false;
        }
    }
}
