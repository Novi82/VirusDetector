using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusDetector.Detector
{
    class MaxHammingDistance
    {
        public static int HammingDistance(byte[] s1, byte[] s2)
        {
            int h = 0;
            for (int i = 0; i < s1.Length && i < s2.Length; i++)
            {
                if (s1[i] != s2[i])
                    h += 1;
            }
            return h;
        }
        public static int HammingDistance(byte[] s1, int start1, byte[] s2, int start2)
        {
            int h = 0;
            for (int i = start1, j = start2; i < s1.Length && j < s2.Length; i++, j++)
            {
                if (s1[i] != s2[j])
                    h += 1;
            }
            return h;
        }
        public static int HammingMaxDistance(byte[] s1, byte[] s2)
        {
            int start1 = 0;
            int start2 = 0;
            int k = 8;// step size
            int max = 0;
            while (start1 <= s1.Length - k)
            {

                int temp = HammingDistance(s1, start1, s2, start2);
                if (max < temp)
                    max = temp;
                start1 += k;
            }
            start1 = 0;
            while (start2 <= s2.Length - k)
            {
                start2 += k;
                int temp = HammingDistance(s1, start1, s2, start2);
                if (max < temp)
                    max = temp;

            }
            return max;
        }
    }
}
