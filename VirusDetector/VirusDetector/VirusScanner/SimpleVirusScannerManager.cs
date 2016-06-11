using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VirusDetector.Detector;
using VirusDetector.StringCompare;

namespace VirusDetector.VirusScanner
{
    class SimpleVirusScannerManager
    {
        double _thresold;
        private StringCompareManager _stringCompareManager;

        // Scan virus support
        int _totalCount;
        String[] _scanFolder;
        ManualResetEvent _event;
        List<FileScanInfo> _lFileScanInfo;
        bool _done;


        public SimpleVirusScannerManager()
        {
            _initialize();
        }

        private void _initialize()
        {
            _totalCount = 0;
            _scanFolder = new String[0];
            _lFileScanInfo = new List<FileScanInfo>();
            _done = false;
        }

        public SimpleVirusScannerManager(StringCompareManager stringCompareManager_, double thresold_)
        {
            _stringCompareManager = stringCompareManager_;
            _thresold = thresold_;
            _initialize();
        }

        public FileScanInfo[] scanVirus(String scanFolder_)
        {
            _done = false;

            _scanFolder = Directory.GetFiles(scanFolder_, "*.*", SearchOption.AllDirectories);
            _totalCount = _scanFolder.Length;
            int len = _totalCount;

            if (len > 0)
            {
                // Init progressbar here
                Utils.Utils.GLOBAL_PROGRESSBAR_COUNT_MAX = _totalCount;
                Utils.Utils.GUI_SUPPORT.initProgressBar();

                _event = new ManualResetEvent(false);


                for (int i = 0; i < len; i++)
                {
                    ThreadPool.QueueUserWorkItem(_threadCallback, i);
                }

                _event.WaitOne();
            }

            FileScanInfo[] result = _lFileScanInfo.ToArray();
            _lFileScanInfo.Clear();

            return result;
        }

        public void stopScanVirus()
        {
            _done = true;
            _event.Set();
        }



        private void _threadCallback(object state)
        {
            int index = (int)state;
            String fileName = _scanFolder[index];
            Boolean result = this._scanFile(fileName);

            FileScanInfo scanInfo = new FileScanInfo(fileName, result);

            lock (_lFileScanInfo)
            {
                _lFileScanInfo.Add(scanInfo);
            }

            if (Interlocked.Decrement(ref _totalCount) == 0)
            {
                _event.Set();
            }

            // Update progressbar
            Utils.Utils.GUI_SUPPORT.updateProgressBar();

        }


        private Boolean _scanFile(String fileName_)
        {
            // Doc file
            // Lay tung chuoi so sanh voi cac detector
            // Neu trung tang count
            // Tinh ti le
            // So sanh voi muc nguong va dua ra ket qua
            StringCompareData stringCompareData = _stringCompareManager.StringCompareData;
            stringCompareData.Compute(fileName_);
            double result = stringCompareData.getRateWithTotalFileString();

            if (result >= _thresold)
                return true;

            return false;
        }
    }
}
