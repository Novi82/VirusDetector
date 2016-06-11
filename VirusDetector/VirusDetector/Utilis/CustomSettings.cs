using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusDetector.Utils
{
    class CustomSettings
    {
        private static String _DATA_FOLDER = @"..\..\TestData\";

        private static String _DETECTOR_FOLDER = _DATA_FOLDER + @"DetectorTrainningSet\";
        private static String _FILE_CLASSIFIER_FOLDER = _DATA_FOLDER + @"FileClassifierTrainningSet\";
        public static String TEST_VIRUS_FOLDER = _DATA_FOLDER + @"TestSet\";

        public static String DETECTOR_VIRUS_FOLDER = _DETECTOR_FOLDER + @"Virus\";
        public static String DETECTOR_BENIGN_FOLDER = _DETECTOR_FOLDER + @"Benign\";

        public static String FILE_CLASSIFIER_VIRUS_FOLDER = _FILE_CLASSIFIER_FOLDER + @"Virus\";
        public static String FILE_CLASSIFIER_BENIGN_FOLDER = _FILE_CLASSIFIER_FOLDER + @"Benign\";

        public static String DETECTOR_FILE = _DATA_FOLDER + @"Detector.txt";
        public static String BENIGN_FILE = _DATA_FOLDER + @"Benign.txt";
        public static String MIX_DETECTOR_FILE = _DATA_FOLDER + @"MixDetector.txt";
        public static String CLUSTERING_FILE = _DATA_FOLDER + @"Clustering.txt";
        public static String FILE_CLASSIFIER_FILE = _DATA_FOLDER + @"FileClassifier.txt";
    }
}
