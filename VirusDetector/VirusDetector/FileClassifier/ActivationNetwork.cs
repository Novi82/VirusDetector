using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge;

namespace VirusDetector.FileClassifier
{
   using AForge.Neuro;
    using System;

    /// <summary>
    /// Activation network.
    /// </summary>
    /// 
    /// <remarks><para>Activation network is a base for multi-layer neural network
    /// with activation functions. It consists of <see cref="ActivationLayer">activation
    /// layers</see>.</para>
    ///
    /// <para>Sample usage:</para>
    /// <code>
    /// // create activation network
    ///	ActivationNetwork network = new ActivationNetwork(
    ///		new SigmoidFunction( ), // sigmoid activation function
    ///		3,                      // 3 inputs
    ///		4, 1 );                 // 2 layers:
    ///                             // 4 neurons in the firs layer
    ///                             // 1 neuron in the second layer
    ///	</code>
    /// </remarks>
    /// 
    [Serializable]
    public class LKActivationNetwork : ActivationNetwork
    {


        /// <summary>
        /// Initializes a new instance of the <see cref="ActivationNetwork"/> class.
        /// </summary>
        /// 
        /// <param name="function">Activation function of neurons of the network.</param>
        /// <param name="inputsCount">Network's inputs count.</param>
        /// <param name="neuronsCount">Array, which specifies the amount of neurons in
        /// each layer of the neural network.</param>
        /// 
        /// <remarks>The new network is randomized (see <see cref="ActivationNeuron.Randomize"/>
        /// method) after it is created.</remarks>
        /// 
        public LKActivationNetwork(IActivationFunction function, int inputsCount, params int[] neuronsCount)
            : base(function, inputsCount, neuronsCount)
        {
            // create each layer
            for (int i = 0; i < layers.Length; i++)
            {
                layers[i] = new LKActivationLayer(
                    // neurons count in the layer
                    neuronsCount[i],
                    // inputs count of the layer
                    (i == 0) ? inputsCount : neuronsCount[i - 1],
                    // activation function of the layer
                    function);
            }
        }
    }
}
