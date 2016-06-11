using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusDetector.Detector
{
    class Cluster : IComparable
    {
        public int label;
        public List<byte[]> val = new List<byte[]>();
        public double rate = 0.0;
        public Cluster(byte[] _val)
        {
            val.Add(_val);
        }
        public Cluster(int _label)
        {
            label = _label;
        }
        public void Add(byte[] _val)
        {
            val.Add(_val);
        }
        public int CompareTo(object o)
        {
            double r = ((Cluster)o).rate;

            return (rate == r) ? 0 : (rate < r) ? 1 : -1;
        }
    }
}
