using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Accord.MachineLearning.VectorMachines.Learning;
using VirusDetector.Properties;
using VirusDetector.Utils;
using VirusDetector.VirusScanner;

namespace VirusDetector
{
    public partial class FormMain
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
            txtbCClusteringFile.Text = CustomSettings.TRAINED_NETWORK_FILE;
            txtbFCFileClassifierFile.Text = CustomSettings.FILE_CLASSIFIER_FILE;

          //  cbxStrategy.Properties.DataSource = Enum.GetValues(typeof(SelectionStrategy));
            cbxStrategy.Properties.Items.AddRange(Enum.GetValues(typeof(SelectionStrategy)));
            cbxStrategy.SelectedIndex = 0;
        }
        /// <summary>
        /// setup variable
        /// </summary>
        private void InitVariable()
        {
            //todo debug xtcContent.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;

            _isTrainingDectector = false;

            _negativeSelectionData = new DataTable();
            _groupshowingDataTable = new DataTable();

            ////represetation
            //dataSet = new DataSet();

            // todo control it_doneScan = false;

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

        internal void UpdateProgressBarCallBack()
        {
            if (InvokeRequired)
            {
                MethodInvoker method = UpdateProgressBarCallBack;
                Invoke(method);
                return;
            }
            if ((int)progressBar.EditValue < progressBar.Properties.Maximum)
                progressBar.PerformStep();
        }

        /// <summary>
        /// Gui support call to initProgress
        /// </summary>
        internal void InitProgressBarCallBack()
        {
            if (InvokeRequired)
            {
                MethodInvoker method = InitProgressBarCallBack;
                Invoke(method);
                return;
            }

            progressBar.Properties.Maximum = (int)progressBar.EditValue + Utils.Utils.GLOBAL_PROGRESSBAR_COUNT_MAX;
            progressBar.Properties.Step = 1;
        }

        /// <summary>
        /// Update info bar
        /// </summary>
        internal void UpdateVirusFragmentCallBack()
        {
            if (InvokeRequired)
            {
                MethodInvoker method = UpdateVirusFragmentCallBack;
                Invoke(method);
                return;
            }

            // Show value to status
            string status = string.Format(Resources.Status_Message, Utils.Utils.GLOBAL_VIRUS_COUNT, Utils.Utils.GLOBAL_BENIGN_COUNT);

            txtStatusBar.BeginInvoke((MethodInvoker)delegate
            {
                txtStatusBar.Text = status;
                this.txtStatusBar.Refresh();
            });
        }

        #endregion
    }
}