using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        #region init methods
        private void initDemo()
        {
            txtbDVirusFolder.Text = CustomSettings.DETECTOR_VIRUS_FOLDER;
            txtbDBenignFolder.Text = CustomSettings.DETECTOR_BENIGN_FOLDER;

            txtbVSTestFolder.Text = CustomSettings.TEST_VIRUS_FOLDER;

            txtbFCVirusFolder.Text = CustomSettings.FILE_CLASSIFIER_VIRUS_FOLDER;
            txtbFCBenignFolder.Text = CustomSettings.FILE_CLASSIFIER_BENIGN_FOLDER;

            txtbDDetectorFile.Text = CustomSettings.DETECTOR_FILE;
            txtbDBenignFile.Text = CustomSettings.BENIGN_FILE;
            txtbCMixDetectorFile.Text = CustomSettings.MIX_DETECTOR_FILE;
            txtbCClusteringFile.Text = CustomSettings.CLUSTERING_FILE;
            txtbFCFileClassifierFile.Text = CustomSettings.FILE_CLASSIFIER_FILE;

        }

        private void _initialize()
        {
            _isWorking = false;

            GroupData = new List<byte[][]>();
            groups = new List<Cluster>();

            NegativeSelectionData = new DataTable();
            groupshowingDataTable = new DataTable();

            //represetation
            dataSet = new DataSet();

            _doneScan = false;

            _lFileScanInfo = new List<FileScanInfo>();

            _currentProcessType = EProcessType.None;
        }

        #endregion

        #region Gui Support Method

        // Add patch for gui to show the program is working
        private void _lkPatch()
        {
            Utils.Utils.GUI_SUPPORT = new GuiSupport(this);
        }

        private void _patchForProgressBar()
        {
            //progressBar.Minimum = 0;
            //progressBar.Maximum = Utils.Utils.GLOBAL_PROGRESSBAR_COUNT_MAX;
            progressBar.Properties.Minimum= 0;
            progressBar.Properties.Maximum = Utils.Utils.GLOBAL_PROGRESSBAR_COUNT_MAX;
        }

        internal void updateProgressBarCallBack()
        {
            if (InvokeRequired)
            {
                MethodInvoker method = new MethodInvoker(updateProgressBarCallBack);
                Invoke(method);
                return;
            }
            if ((int)progressBar.EditValue < progressBar.Properties.Maximum)
                progressBar.PerformStep();
        }

        internal void initProgressBarCallBack()
        {
            if (InvokeRequired)
            {
                MethodInvoker method = new MethodInvoker(initProgressBarCallBack);
                Invoke(method);
                return;
            }
            // todo
            //progressBar.Maximum = progressBar.Value + Utils.Utils.GLOBAL_PROGRESSBAR_COUNT_MAX;
            //progressBar.Step = 1;
        }

        internal void updateVirusFragmentCallBack()
        {
            if (InvokeRequired)
            {
                MethodInvoker method = new MethodInvoker(updateVirusFragmentCallBack);
                Invoke(method);
                return;
            }

            // Show value to status
            String status = string.Format("Number of virus fragments: {0}      Number of benign fragments : {1}", Utils.Utils.GLOBAL_VIRUS_COUNT, Utils.Utils.GLOBAL_BENIGN_COUNT);

            this.txtStatusBar.BeginInvoke((MethodInvoker)delegate()
            {
                txtStatusBar.Text = status;
                this.txtStatusBar.Refresh();
            });
        }


        #endregion

        #region Methods
        private void _virusScannerThread_Stopped()
        {
            int virusCount = 0;
            int benignCount = 0;
            DataColumn column;
            DataRow row;
            DataView view;
            DataTable resultList = new DataTable();
            resultList.Columns.Clear();

            // Create new DataColumn, set DataType, ColumnName and add to DataTable.    
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "File";
            resultList.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Status";
            resultList.Columns.Add(column);
            resultList.Rows.Clear();

            foreach (FileScanInfo fileScanInfo in _lFileScanInfo)
            {
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

            txtbFCNumVirus.Text = virusCount.ToString();
            txtbFCNumBenign.Text = benignCount.ToString();

            view = new DataView(resultList);
            dgvVirus.DataSource = view;
        }

        private void _detectorThread_Stopped()
        {
            this._virusFragments = datageneration.VirusFragmentOutput;
            Boolean isBuild;
            isBuild = (rbtnDBuildAddDetector.SelectedIndex == 0);
            if (isBuild)
                this._benignFragments = datageneration.BenignFragmentInput;

            showDetectorResult();
        }
        #endregion
    }
}