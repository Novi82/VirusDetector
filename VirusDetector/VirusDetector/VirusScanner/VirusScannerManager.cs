using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusDetector.Clustering;
using VirusDetector.Detector;
using VirusDetector.FileClassifier;
using AForge;
using AForge.Neuro;

namespace VirusDetector.VirusScanner
{
    class VirusScannerManager
    {
        LKDistanceNetwork _distanceNetwork;
        ActivationNetwork _activationNetwork;
        int[] _formatRange;
        public VirusScannerManager()
        {

        }

        public VirusScannerManager(LKDistanceNetwork distanceNetwork_, ActivationNetwork activationNetwork_, String formatRange_)
        {
            _distanceNetwork = distanceNetwork_;
            _activationNetwork = activationNetwork_;
            _formatRange = Utils.Utils.calcFormatRange(formatRange_);
        }

        public Boolean scanFile(String fileName_)
        {
            FileClassifierData data = new FileClassifierData(_distanceNetwork, fileName_, _formatRange);
            double[] formatData = data.getRateFormatData();
            double[] output = _activationNetwork.Compute(formatData);
            double result = output[0];
            result = Math.Round(result, 4);

            // Test
            Console.WriteLine(fileName_ + ", " + result);

            double thresold = 0.5; // Thresold = 0.5 with BipolarSigmoidFunction and virus mark as 1, benign mark as -1
            return (result >= thresold);
        }

        public Boolean scanFile1(String fileName_)
        {
            FileClassifierData data = new FileClassifierData(_distanceNetwork, fileName_, _formatRange);
            double[] formatData = new double[1] { Utils.Utils.calcDangerousRate(data.getRateFormatData()) };
            double[] output = _activationNetwork.Compute(formatData);
            double result = output[0];
            result = Math.Round(result, 4);

            // Test
            Console.WriteLine(fileName_ + ", " + result);

            double thresold = 0.5; // Thresold = 0.5 with BipolarSigmoidFunction and virus mark as 1, benign mark as -1
            return (result >= thresold);
        }
    }
}
