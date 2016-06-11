using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Neuro;
namespace VirusDetector.Clustering
{
        [Serializable]
    class LKDistanceLayer : DistanceLayer
    {
        public LKDistanceLayer(int neuronsCount, int inputsCount)
            : base(neuronsCount, inputsCount)
        {
            // create each neuron
            for (int i = 0; i < neuronsCount; i++)
                neurons[i] = new LKDistanceNeuron(inputsCount);
        }

        public void printNeuron()
        {
            for (int i = 0; i < neuronsCount; i++)
            {
                Console.WriteLine(i + "," + ((LKDistanceNeuron)neurons[i]).VirusDetectedCount + "," + ((LKDistanceNeuron)neurons[i]).BenignDetectedCount);
            }
        }
    }
}
