using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusDetector.Detector
{
    class RContiguous
    {
        public static int RContiguos(byte[] s1, int start1, byte[] s2, int start2)
        {
            int length = 0;
            int max = 0;
            for (int i = start1, j = start2; i < s1.Length && j < s2.Length; i++, j++)
            {

                if (s1[i] == s2[j])
                    length += 1;
                else
                    length = 0;
                if (max < length)
                    max = length;
            }
            return max;
        }
        public static int ShiftRContiguous(byte[] s1, byte[] s2)
        {
            int start1 = 0;
            int start2 = 0;
            int k = 8;// step size
            int max = 0;
            while (start1 <= s1.Length - k)
            {

                int temp = RContiguos(s1, start1, s2, start2);
                if (max < temp)
                    max = temp;
                start1 += k;
            }
            start1 = 0;
            while (start2 <= s2.Length - k)
            {
                start2 += k;
                int temp = RContiguos(s1, start1, s2, start2);
                if (max < temp)
                    max = temp;

            }
            return max;
        }
    }
}
