using Accord.MachineLearning.VectorMachines;
using AForge.Neuro;
using System;
using VirusDetector.Clustering;
using VirusDetector.FileClassifier;
namespace VirusDetector.VirusScanner
{
    class VirusScannerManager
    {
        LkDistanceNetwork _pDistanceNetwork;
        // todo del ActivationNetwork _pActivationNetwork;
        KernelSupportVectorMachine _svm;

        int[] _formatRange;
        public VirusScannerManager()
        {

        }

        //public VirusScannerManager(LkDistanceNetwork pDistanceNetwork, ActivationNetwork pActivationNetwork, String pFormatRange)
        //{
        //    _pDistanceNetwork = pDistanceNetwork;
        //    _pActivationNetwork = pActivationNetwork;
        //    _formatRange = Utils.Utils.CalcFormatRange(pFormatRange);
        //}
        public VirusScannerManager(LkDistanceNetwork pDistanceNetwork, String pFormatRange)
        {
            _pDistanceNetwork = pDistanceNetwork;
            _formatRange = Utils.Utils.CalcFormatRange(pFormatRange);
        }public VirusScannerManager(LkDistanceNetwork pDistanceNetwork,KernelSupportVectorMachine pSvm, String pFormatRange)
        {
            _pDistanceNetwork = pDistanceNetwork;
            _svm  = pSvm;
            _formatRange = Utils.Utils.CalcFormatRange(pFormatRange);
        }

        public Boolean ScanFileSvm(String pFileName)
        {
            FileClassifierData data = new FileClassifierData(_pDistanceNetwork,_svm, pFileName, _formatRange);
            data._computeSvm();
            double[] formatData = data.GetRateFormatData();
            double result = _svm.Compute(formatData);
            //result = Math.Round(result, 4);'
            //result = Math.Sign(result);

            // Test
            Console.WriteLine(pFileName + ", [" + result+"]" );

            double thresold =0; 
            return (result >= thresold);
        }

    }
}
