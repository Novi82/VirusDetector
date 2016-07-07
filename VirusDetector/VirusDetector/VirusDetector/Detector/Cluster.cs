using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace VirusDetector.Detector
{
    [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
    class Cluster : IComparable
    {
        public int Label;
        public List<byte[]> Val = new List<byte[]>();
        public double Rate = 0.0;
        public Cluster(byte[] val)
        {
            Val.Add(val);
        }
        public Cluster(int label)
        {
            Label = label;
        }
        public void Add(byte[] val)
        {
            Val.Add(val);
        }
        public int CompareTo(object o)
        {
            double r = ((Cluster)o).Rate;

            return (Rate == r) ? 0 : (Rate < r) ? 1 : -1;
        }
    }
}
