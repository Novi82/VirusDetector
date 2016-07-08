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

        //Todo del
        //public Boolean ScanFile(String pFileName)
        //{
        //    FileClassifierData data = new FileClassifierData(_pDistanceNetwork, pFileName, _formatRange);
        //    double[] formatData = data.GetRateFormatData();
        //    double[] output = _pActivationNetwork.Compute(formatData);
        //    double result = output[0];
        //    result = Math.Round(result, 4);

        //    // Test
        //    Console.WriteLine(pFileName + ", " + result);

        //    double thresold = 0.5; // Thresold = 0.5 with BipolarSigmoidFunction and virus mark as 1, benign mark as -1
        //    return (result >= thresold);
        //}
        //public Boolean ScanFile1(String pFileName)
        //{
        //    FileClassifierData data = new FileClassifierData(_pDistanceNetwork, pFileName, _formatRange);
        //    double[] formatData = new double[1] { Utils.Utils.CalcDangerousRate(data.GetRateFormatData()) };
        //    double[] output = _pActivationNetwork.Compute(formatData);
        //    double result = output[0];
        //    result = Math.Round(result, 4);

        //    // Test
        //    Console.WriteLine(pFileName + ", " + result);

        //    double thresold = 0.5; // Thresold = 0.5 with BipolarSigmoidFunction and virus mark as 1, benign mark as -1
        //    return (result >= thresold);
        //}
    }
}
