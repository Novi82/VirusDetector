using System;

namespace VirusDetector.Utils
{
    class CustomSettings
    {
        private static readonly String _DATA_FOLDER = @"..\..\..\..\Data\";

        private static readonly String _DETECTOR_FOLDER = _DATA_FOLDER; //+ @"DetectorTrainningSet\";
        private static readonly String _FILE_CLASSIFIER_FOLDER = _DATA_FOLDER; //+ @"FileClassifierTrainningSet\";
        public static readonly String TEST_VIRUS_FOLDER = _DATA_FOLDER;// + @"TestSet\";

        public static readonly String DETECTOR_VIRUS_FOLDER = _DETECTOR_FOLDER + @"Virus\";
        public static readonly String DETECTOR_BENIGN_FOLDER = _DETECTOR_FOLDER + @"Benign\";

        public static readonly String FILE_CLASSIFIER_VIRUS_FOLDER = _FILE_CLASSIFIER_FOLDER + @"Virus\";
        public static readonly String FILE_CLASSIFIER_BENIGN_FOLDER = _FILE_CLASSIFIER_FOLDER + @"Benign\";

        public static readonly String DETECTOR_FILE = _DATA_FOLDER + @"result\" + @"Detector.txt";
        public static readonly String BENIGN_FILE = _DATA_FOLDER + @"result\" + @"Benign.txt";
        public static readonly String MIX_DETECTOR_FILE = _DATA_FOLDER + @"result\" + @"MixedDetector.txt";
        public static readonly String TRAINED_NETWORK_FILE = _DATA_FOLDER + @"result\" + @"TrainedNetwork.txt";
        public static readonly String FILE_CLASSIFIER_FILE = _DATA_FOLDER + @"result\" + @"Classifier.txt";
    }
}
