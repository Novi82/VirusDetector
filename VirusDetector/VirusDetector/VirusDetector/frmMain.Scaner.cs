using System;
using System.Data;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using VirusDetector.Properties;
using VirusDetector.VirusScanner;

namespace VirusDetector
{
    public partial class FormMain
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
                //_virusScannerManager = new VirusScannerManager(
                //_fileClassifierManager.DistancePDistanceNetwork,
                //_fileClassifierManager.ActivationNetwork,
                //txtbCFFormatRange.Text
                //);
                _virusScannerManager = new VirusScannerManager(
                    _fileClassifierManager.DistancePDistanceNetwork,
                _fileClassifierManager.Svm,
                txtbCFFormatRange.Text
                );


                String testFileFolder = txtbVSTestFolder.Text;
                String[] testFile = Directory.GetFiles(testFileFolder, "*.*", SearchOption.AllDirectories);

                // Init progressbar here
                Utils.Utils.GLOBAL_PROGRESSBAR_COUNT_MAX = testFile.Length;
                Utils.Utils.GUI_SUPPORT.InitProgressBar();

                _lFileScanInfo.Clear();
                foreach (String file in testFile)
                {
                    Boolean result = _virusScannerManager.ScanFileSvm(file);
                    //Boolean result = _virusScannerManager.scanFileSvm(file);
                    FileScanInfo scanInfo = new FileScanInfo(file, result);
                    _lFileScanInfo.Add(scanInfo);

                    // Update progressbar
                    Utils.Utils.GUI_SUPPORT.UpdateProgressBar();
                }

                MessageBox.Show(Resources.Message_Successful);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void _virusScannerThread_Stopped()
        {
            int virusCount = 0;
            int benignCount = 0;
            DataTable resultList = new DataTable();
            resultList.Columns.Clear();

            // Create new DataColumn, set DataType, ColumnName and add to DataTable.    
            var column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "File"
            };
            resultList.Columns.Add(column);

            // Create second column.
            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Status"
            };
            resultList.Columns.Add(column);
            resultList.Rows.Clear();

            foreach (FileScanInfo fileScanInfo in _lFileScanInfo)
            {
                DataRow row;
                if (fileScanInfo.Result)
                {
                    row = resultList.NewRow();
                    row["File"] = fileScanInfo.FileName;
                    row["Status"] = "Virus";
                    resultList.Rows.Add(row);

                    virusCount++;
                }
                else
                {
                    row = resultList.NewRow();
                    row["File"] = fileScanInfo.FileName;
                    row["Status"] = "Benign";
                    resultList.Rows.Add(row);

                    benignCount++;
                }
            }

            //txtbFCNumVirus.Text = virusCount.ToString();
            //txtbFCNumBenign.Text = benignCount.ToString();
            chartScan.Series.Clear();
            chartScan.Series.Add("Scaner", ViewType.Pie3D);
            //chartScan.Series.Add("Virus", ViewType.Pie3D);
            chartScan.Series["Scaner"].Points.Add(new SeriesPoint("Virus", virusCount+10));
            chartScan.Series["Scaner"].Points.Add(new SeriesPoint("Benign", benignCount+10));
            chartScan.Series["Scaner"].LegendTextPattern = @"{A}: {V}";
            var view = new DataView(resultList);
            dgvVirus.DataSource = view;
        }

        #endregion
    }
}
