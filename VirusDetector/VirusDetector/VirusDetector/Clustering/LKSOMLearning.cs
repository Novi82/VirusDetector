using AForge.Neuro;
using AForge.Neuro.Learning;

namespace VirusDetector.Clustering
{
    class LksomLearning : SOMLearning
    {
        // neural network to train
        private LkDistanceNetwork network;

        public LksomLearning(LkDistanceNetwork network)
            : base(network)
        {
            // ok, we got it
            this.network = network;
        }

        public LksomLearning(LkDistanceNetwork network, int width, int height)
            : base(network, width, height)
        {
            this.network = network;
        }

        public void BeginRunLksom()
        {
            _resetLKNeuronMap();
        }

        public void EndRunLksom()
        {

        }

        private void _resetLKNeuronMap()
        {
            Layer layer = network.Layers[0];
            foreach (var neuron in layer.Neurons)
            {
                var item = (LkDistanceNeuron) neuron;
                item.ResetLabel();
            }
        }

        public void MapNeuronLabel(double[][] input, int mappingDataIndex = -1)
        {
            if (mappingDataIndex == -1)
                mappingDataIndex = input[0].GetLength(0) - 1;
            int len = input.GetLength(0);
            LkDistanceLayer layer = (LkDistanceLayer)network.Layers[0];
            for (int i = 0; i < len; i++)
            {
                network.Compute(input[i]);
                int w = network.GetWinner();

                if (Utils.Utils.CheckVirus(input[i][mappingDataIndex]))
                    ((LkDistanceNeuron)layer.Neurons[w]).DetectVirus();
                else
                    ((LkDistanceNeuron)layer.Neurons[w]).DetectBenign();
            }
        }
    }
}
