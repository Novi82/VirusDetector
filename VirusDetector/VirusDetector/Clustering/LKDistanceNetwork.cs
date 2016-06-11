using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Neuro;

namespace VirusDetector.Clustering
{
    [Serializable]
    class LKDistanceNetwork : DistanceNetwork
    {
        public LKDistanceNetwork(int inputsCount, int neuronsCount)
            : base(inputsCount, 1)
        {
            // create layer
            layers[0] = new LKDistanceLayer(neuronsCount, inputsCount);
        }

        public LKDistanceNeuron getWinnerNeuron()
        {
            int winner = this.GetWinner();
            return (LKDistanceNeuron)this.layers[0].Neurons[winner];
        }
    }
}
