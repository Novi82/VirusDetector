using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace VirusDetector.Detector
{
    /// <summary>
    /// A list byte
    /// </summary>
    [Serializable]
    class TrainingData : List<byte[]>
    {
        /// <summary>
        /// is IsContains elements in list
        /// </summary>
        /// <param name="pElements"></param>
        /// <returns></returns>
        public bool IsContains(byte[] pElements)
        {
            if (Count == 0)
            {
                return false;
            }
            for (int i = 0; i < Count; i++)
            {
                if (Equals(this[i], pElements))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// is pObject1 equals to pObject2
        /// </summary>
        /// <param name="pObject1"></param>
        /// <param name="pObject2"></param>
        /// <returns></returns>
        private bool Equals(byte[] pObject1, byte[] pObject2)
        {
            if (pObject1.Length != pObject2.Length)
            {
                return false;
            }
            for (int i = 0; i < pObject1.Length; i++)
            {
                if (pObject1[i] != pObject2[i])
                    return false;
            }
            return true;
        }

        /// <summary>
        ///  Read objects from file
        /// </summary>
        /// <param name="pFileName"></param>
        /// <returns></returns>
        public static TrainingData Read(string pFileName)
        {
            TrainingData pTrainningData;
            using (FileStream stream = new FileStream(pFileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                pTrainningData = Read(stream);
            }
            return pTrainningData;
        }

        /// <summary>
        /// Read objects from stream
        /// </summary>
        /// <param name="pStream"></param>
        /// <returns></returns>
        public static TrainingData Read(Stream pStream)
        {
            IFormatter formatter = new BinaryFormatter();
            TrainingData data = (TrainingData)formatter.Deserialize(pStream);
            return data;
        }

        /// <summary>
        /// write this objects into a new file
        /// </summary>
        /// <param name="pFileName">Target File Name</param>
        public void Write(string pFileName)
        {
            Stream stream = File.Open(pFileName, FileMode.Create);
            Write(stream);
            stream.Close();
        }

        /// <summary>
        /// write this objects into stream
        /// </summary>
        /// <param name="pStream">Target File</param>
        public void Write(Stream pStream)
        {
            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Serialize(pStream, this);
        }
    }
}
