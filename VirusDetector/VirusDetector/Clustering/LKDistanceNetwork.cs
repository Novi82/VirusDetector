using System;
using AForge.Neuro;

namespace VirusDetector.Clustering
{
    [Serializable]
    class LkDistanceNetwork : DistanceNetwork
    {
        public LkDistanceNetwork(int inputsCount, int neuronsCount)
            : base(inputsCount, 1)
        {
            // create layer
            layers[0] = new LkDistanceLayer(neuronsCount, inputsCount);
        }

        public LkDistanceNeuron GetWinnerNeuron()
        {
            int winner = GetWinner();
            return (LkDistanceNeuron)layers[0].Neurons[winner];
        }
    }
}
