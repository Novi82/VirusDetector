using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace VirusDetector.Detector
{
    [Serializable]
    class TrainingData : List<byte[]>
    {
        public bool contains(byte[] elements)
        {
            if (this.Count == 0)
                return false;
            for (int i = 0; i < this.Count; i++)
            {
                if (Equals(this[i], elements))
                    return true;
            }
            return false;
        }
        private bool Equals(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
                return false;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                    return false;
            }
            return true;
        }
        public static TrainingData Load(string fileName)
        {
            TrainingData D;
            using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                D = Load(stream);
            }
            return D;
        }
        public static TrainingData Load(Stream stream)
        {
            IFormatter formatter = new BinaryFormatter();
            TrainingData HT = (TrainingData)formatter.Deserialize(stream);
            return HT;
        }
        /// <summary>
        /// write this objects into a new file
        /// </summary>
        /// <param name="fileName"></param>
        public void Write(string fileName)
        {
            Stream stream = File.Open(fileName, FileMode.Create);
            Write(stream);
            stream.Close();
        }
        public void Write(Stream stream)
        {
            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Serialize(stream, this);

        }
    }
}
