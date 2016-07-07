
using System;
using AForge.Neuro;

namespace VirusDetector.FileClassifier
{
    /// <summary>
    /// Activation layer.
    /// </summary>
    /// 
    /// <remarks>Activation layer is a layer of <see cref="ActivationNeuron">activation neurons</see>.
    /// The layer is usually used in multi-layer neural networks.</remarks>
    ///
    [Serializable]
    class LkActivationLayer : ActivationLayer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActivationLayer"/> class.
        /// </summary>
        /// 
        /// <param name="neuronsCount">Layer's neurons count.</param>
        /// <param name="inputsCount">Layer's inputs count.</param>
        /// <param name="function">Activation function of neurons of the layer.</param>
        /// 
        /// <remarks>The new layer is randomized (see <see cref="ActivationNeuron.Randomize"/>
        /// method) after it is created.</remarks>
        /// 
        public LkActivationLayer( int neuronsCount, int inputsCount, IActivationFunction function )
            : base( neuronsCount,  inputsCount,  function  )
        {
            // create each neuron
            for ( int i = 0; i < neurons.Length; i++ )
                neurons[i] = new LkActivationNeuron( inputsCount, function );
        }
    }
}
