using System;
using AForge.Neuro;

namespace VirusDetector.Clustering
{
        [Serializable]
    class LkDistanceLayer : DistanceLayer
    {
        public LkDistanceLayer(int neuronsCount, int inputsCount)
            : base(neuronsCount, inputsCount)
        {
            // create each neuron
            for (int i = 0; i < neuronsCount; i++)
                neurons[i] = new LkDistanceNeuron(inputsCount);
        }

        public void printNeuron()
        {
            for (int i = 0; i < neuronsCount; i++)
            {
                Console.WriteLine(i + "," + ((LkDistanceNeuron)neurons[i]).VirusDetectedCount + "," + ((LkDistanceNeuron)neurons[i]).BenignDetectedCount);
            }
        }
    }
}
