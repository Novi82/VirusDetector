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
        /// <summary>
        /// load default data
        /// </summary>
        private void LoadDefaultData()
        {
            //setting length = 32 bits
            txtDLength.EditValue = Utils.Utils.GLOBAL_LENGTH;
            // setting overlap step = 16 bits
            txtDStepSize.EditValue = Utils.Utils.GLOBAL_STEP_SIZE;

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
        /// <summary>
        /// setup variable
        /// </summary>
        private void InitVariable()
        {
           //todo debug xtcContent.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;

            _isTrainingDectector = false;

            //todo GroupData = new List<byte[][]>();
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

        /// <summary>
        /// Gui support call to initProgress
        /// </summary>
        internal void initProgressBarCallBack()
        {
            if (InvokeRequired)
            {
                MethodInvoker method = new MethodInvoker(initProgressBarCallBack);
                Invoke(method);
                return;
            }

            progressBar.Properties.Maximum = (int)progressBar.EditValue + Utils.Utils.GLOBAL_PROGRESSBAR_COUNT_MAX;
            progressBar.Properties.Step = 1;
        }

        /// <summary>
        /// Update info bar
        /// </summary>
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
    }
}