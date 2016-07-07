namespace VirusDetector.Detector
{
    class Hamming
    {
        /// <summary>
        /// calculate Distance between 2 detector
        /// </summary>
        /// <param name="s1">detector 1</param>
        /// <param name="s2">detector 2</param>
        /// <returns></returns>
        public static int Distance(byte[] s1, byte[] s2)
        {
            int rs = 0;
            for (int i = 0; i < s1.Length && i < s2.Length; i++)
            {
                if (s1[i] != s2[i])
                    rs += 1;
            }
            return rs;
        }
        /// <summary>
        /// calculate Distance between 2 detector
        /// </summary>
        /// <param name="s1">detector 1</param>
        /// <param name="start1">start index 1</param>
        /// <param name="s2">detector 2</param>
        /// <param name="start2">start index 2</param>
        /// <returns></returns>
        public static int Distance(byte[] s1, int start1, byte[] s2, int start2)
        {
            int rs = 0;
            for (int i = start1, j = start2; i < s1.Length && j < s2.Length; i++, j++)
            {
                if (s1[i] != s2[j])
                    rs += 1;
            }
            return rs;
        }
        /// <summary>
        /// calculate max Hamming Distance between 2 detector
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <remarks>shift 8 bits of 2 detector and find max distance</remarks>
        /// <returns></returns>
        public static int MaxDistance(byte[] s1, byte[] s2)
        {
            int start1 = 0;
            int start2 = 0;
            int stepSize = 8;
            int maxDistance = 0;
            // shift detector 1  by 8 bits, then compare with detector 2
            while (start1 <= s1.Length - stepSize)
            {
                int distance = Distance(s1, start1, s2, start2);
                if (maxDistance < distance)
                    maxDistance = distance;
                start1 += stepSize;
            }
            //reset start1 index
            start1 = 0;
            // shift detector 2  by 8 bits, then compare with detector 1 (start at 0)
            while (start2 <= s2.Length - stepSize)
            {
                start2 += stepSize;
                int temp = Distance(s1, start1, s2, start2);
                if (maxDistance < temp)
                    maxDistance = temp;

            }
            return maxDistance;
        }
    }
}
