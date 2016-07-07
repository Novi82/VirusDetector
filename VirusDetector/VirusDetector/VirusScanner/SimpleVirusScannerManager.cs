//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Threading;
//using VirusDetector.StringCompare;

//namespace VirusDetector.VirusScanner
//{
//    class SimpleVirusScannerManager
//    {
//        readonly double _pThreshold;
//        private readonly StringCompareManager _pStringCompareManager;

//        // Scan virus support
//        int _totalCount;
//        String[] _scanFolder;
//        ManualResetEvent _event;
//        List<FileScanInfo> _lFileScanInfo;
//       //todo del bool _done;


//        public SimpleVirusScannerManager()
//        {
//            _initialize();
//        }

//        private void _initialize()
//        {
//            _totalCount = 0;
//            _scanFolder = new String[0];
//            lock (_lFileScanInfo)
//            {
//                _lFileScanInfo = new List<FileScanInfo>();
//            }
//            //todo del _done = false;
//        }

//        public SimpleVirusScannerManager(StringCompareManager pStringCompareManager, double pThreshold)
//        {
//            _pStringCompareManager = pStringCompareManager;
//            _pThreshold = pThreshold;
//            _initialize();
//        }

//        public FileScanInfo[] ScanVirus(String pScanFolder)
//        {
//            // todo del _done = false;

//            _scanFolder = Directory.GetFiles(pScanFolder, "*.*", SearchOption.AllDirectories);
//            _totalCount = _scanFolder.Length;
//            int len = _totalCount;

//            if (len > 0)
//            {
//                // Init progressbar here
//                Utils.Utils.GLOBAL_PROGRESSBAR_COUNT_MAX = _totalCount;
//                Utils.Utils.GUI_SUPPORT.InitProgressBar();

//                _event = new ManualResetEvent(false);


//                for (int i = 0; i < len; i++)
//                {
//                    ThreadPool.QueueUserWorkItem(_threadCallback, i);
//                }

//                _event.WaitOne();
//            }

//            FileScanInfo[] result = _lFileScanInfo.ToArray();
//            _lFileScanInfo.Clear();

//            return result;
//        }

//        public void StopScanVirus()
//        {
//            // todo del _done = true;
//            _event.Set();
//        }



//        private void _threadCallback(object state)
//        {
//            int index = (int)state;
//            String fileName = _scanFolder[index];
//            Boolean result = _scanFile(fileName);

//            FileScanInfo scanInfo = new FileScanInfo(fileName, result);

//            lock (_lFileScanInfo)
//            {
//                _lFileScanInfo.Add(scanInfo);
//            }

//            if (Interlocked.Decrement(ref _totalCount) == 0)
//            {
//                _event.Set();
//            }

//            // Update progressbar
//            Utils.Utils.GUI_SUPPORT.UpdateProgressBar();

//        }


//        private Boolean _scanFile(String pFileName)
//        {
//            // Doc file
//            // Lay tung chuoi so sanh voi cac detector
//            // Neu trung tang count
//            // Tinh ti le
//            // So sanh voi muc nguong va dua ra ket qua
//            StringCompareData stringCompareData = _pStringCompareManager.StringCompareData;
//            stringCompareData.Compute(pFileName);
//            double result = stringCompareData.getRateWithTotalFileString();

//            if (result >= _pThreshold)
//                return true;

//            return false;
//        }
//    }
//}
