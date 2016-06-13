using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirusDetector.Clustering;
using VirusDetector.Detector;
using VirusDetector.FileClassifier;
using VirusDetector.VirusScanner;
using VirusDetector.StringCompare;
using VirusDetector.Utils;

namespace VirusDetector
{
    public partial class FormMain : Form
    {
        #region Event Support

        private void _startVirusScanner()
        {
            // Do job
            _currentProcessType = EProcessType.VirusScaner;

            _turnToWorkingStatus(true);

            _worker = new Thread(_virusScannerThread);

            _worker.Start();
        }
        private void _virusScannerThread()
        {

            try
            {
                _virusScannerManager = new VirusScannerManager(
                _fileClassifierManager.DistanceNetwork,
                _fileClassifierManager.ActivationNetwork,
                txtbCFFormatRange.Text
                );


                String testFileFolder = txtbVSTestFolder.Text;
                String[] testFile = Directory.GetFiles(testFileFolder, "*.*", SearchOption.AllDirectories);

                // Init progressbar here
                Utils.Utils.GLOBAL_PROGRESSBAR_COUNT_MAX = testFile.Length;
                Utils.Utils.GUI_SUPPORT.initProgressBar();

                _lFileScanInfo.Clear();
                foreach (String file in testFile)
                {
                    Boolean result = _virusScannerManager.scanFile(file);
                    //Boolean result = _virusScannerManager.scanFile1(file);
                    FileScanInfo scanInfo = new FileScanInfo(file, result);
                    _lFileScanInfo.Add(scanInfo);

                    // Update progressbar
                    Utils.Utils.GUI_SUPPORT.updateProgressBar();
                }

                MessageBox.Show("Successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        #endregion
    }
}
