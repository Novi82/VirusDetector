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
using VirusDetector.FormCustomize;

namespace VirusDetector
{
    enum EDetectorType
    {
        BuildDetector,
        AdditionNegative
    }

    enum EProcessType
    {
        None,
        Detector,
        Clustering,
        FileClassifier,
        VirusScaner
    }
    enum EFragmentType
    {
        Benign,
        Virus
    }
    public partial class FormMain : Form
    {
        #region variable

        // Declare variable
        /// <summary>
        /// is training detector
        /// </summary>
        private bool _isTrainingDectector;
        private DateTime startTime;
        private Thread _worker;

        // Data generation
        private DataGeneration datageneration;

        // Virus Fragment output
        private TrainingData _virusFragments;
        // benign Fragment input
        private TrainingData _benignFragments;

        private double[][] _detectorData;
        private int[] Label;

        private List<Cluster> groups;

        private DataTable NegativeSelectionData;
        private DataTable groupshowingDataTable;

        //represetation
        private DataSet dataSet;


        // LK Custom code
        ClusteringManager _clusteringManager;
        FileClassifierManager _fileClassifierManager;
        VirusScannerManager _virusScannerManager;
        StringCompareManager _stringCompareManager;

        // For scan vr stop button
        Boolean _doneScan;

        // Scan vr support
        List<FileScanInfo> _lFileScanInfo;

        // Thread
        EProcessType _currentProcessType;

        #endregion

        #region Form Event
        public FormMain()
        {
            // default init layout
            InitializeComponent();
            // load data
            LoadDefaultData();
            // init gui support
            _lkPatch();
            // init variable
            InitVariable();
        }
        #endregion

        #region Menu click event

        private void navAbout_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtcContent.SelectedTabPage = xtpAbout;
        }

        private void navExit_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void navClaResult_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtcContent.SelectedTabPage = xtpClassReult;
        }

        private void navClaSetting_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtcContent.SelectedTabPage = xtpClasSetting;
        }

        private void navCluSetting_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtcContent.SelectedTabPage = xtpClusSetting;
        }

        private void navClusResult_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtcContent.SelectedTabPage = xtpClusReult;
        }

        private void navDecSetting_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtcContent.SelectedTabPage = xtpDeSetting;
        }

        private void navDecResult_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtcContent.SelectedTabPage = xtpDeResult;
        }

        private void navScan_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtcContent.SelectedTabPage = xtpScan;
        }

        private void navScanResult_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtcContent.SelectedTabPage = xtpScanRs;
        }
        #endregion

        #region Detector Event
        /// <summary>
        /// Browse Virus Folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDVirusFolder_Click(object sender, EventArgs e)
        {
            FolderSelectDialog folderSelectDialog = new FolderSelectDialog();
            folderSelectDialog.Title = "Select Folder";
            bool result = folderSelectDialog.ShowDialog();
            if (result)
            {
                txtbDVirusFolder.Text = folderSelectDialog.FileName;
            }
        }
        /// <summary>
        /// browse Benign Folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDBenignFolder_Click(object sender, EventArgs e)
        {
            FolderSelectDialog folderSelectDialog = new FolderSelectDialog();
            folderSelectDialog.Title = "Select Folder";
            bool result = folderSelectDialog.ShowDialog();
            if (result)
            {
                txtbDBenignFolder.Text = folderSelectDialog.FileName;
            }
        }
        /// <summary>
        /// Browse Addition Folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDAdditionFolder_Click(object sender, EventArgs e)
        {
            // Show the dialog.
            FolderSelectDialog folderSelectDialog = new FolderSelectDialog();
            folderSelectDialog.Title = "Select Folder";
            // get result.
            bool result = folderSelectDialog.ShowDialog();
            if (result)
            {
                txtbDAdditionFolder.Text = folderSelectDialog.FileName;
            }
        }
        /// <summary>
        /// Change Build | Addition
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnDBuildAddDetector_SelectedIndexChanged(object sender, EventArgs e)
        {
            EDetectorType detectorType = EDetectorType.BuildDetector;
            Boolean isBuild;
            isBuild = (rbtnDBuildAddDetector.SelectedIndex == 0);
            if (isBuild)
            {
                detectorType = EDetectorType.BuildDetector;
            }
            else
            {
                detectorType = EDetectorType.AdditionNegative;
            }

            _updateDetectorType(detectorType);
        }
        /// <summary>
        /// Start training detector button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDStart_Click(object sender, EventArgs e)
        {
            try
            {
                _startDetector();

                txtbFCBenignFolder.Text = txtbDBenignFolder.Text;
                txtbFCVirusFolder.Text = txtbDVirusFolder.Text;
                xtcContent.SelectedTabPage = xtpDeResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Buton Stop Training
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDStop_Click(object sender, EventArgs e)
        {
            try
            {
                datageneration.stopBuildDetector();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Browse Detector File
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDDetectorFile_Click(object sender, EventArgs e)
        {
            // Show the dialog.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            openFileDialog1.Title = "Select Folder";
            // get result.
            if (result == DialogResult.OK) 
            {
                txtbDDetectorFile.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Browser Benign File
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDBenignFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                txtbDBenignFile.Text = openFileDialog1.FileName;
            }
        }
        /// <summary>
        /// btn Load detector
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDLoadDetector_Click(object sender, EventArgs e)
        {
            try
            {
                _loadDetector();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }     

        /// <summary>
        /// Browser Save Folder Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDSaveDetector_Click(object sender, EventArgs e)
        {
            try
            {
                _saveDetector();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Toggle Hamming Distance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxDHamming_Toggled(object sender, EventArgs e)
        {
            txtbDHamming.Enabled = cbxDHamming.IsOn;
        }

        /// <summary>
        /// Toggle R-Contiguous distance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxDRContinuous_Toggled(object sender, EventArgs e)
        {
            txtbDContinuous.Enabled = cbxDRContinuous.IsOn;
        }

        /// <summary>
        /// Toogle Use rate Percent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxCUseRate_Toggled(object sender, EventArgs e)
        {
            txtbCBenignVirusRate.ReadOnly = cbxCUseRate.IsOn;

            txtbCVirusSize.ReadOnly = !cbxCUseRate.IsOn;
            txtbCBenignSize.ReadOnly = !cbxCUseRate.IsOn;
        }
        #endregion

        #region Clustering Event
        private void btnCSaveMixDetector_Click(object sender, EventArgs e)
        {

            try
            {
                _saveMixDetector();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnCLoadMixDetector_Click(object sender, EventArgs e)
        {
            try
            {
                _loadMixDetector();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        /// <summary>
        /// clustering click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCStartClustering_Click(object sender, EventArgs e)
        {
            try
            {
                _startClustering();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnCStop_Click(object sender, EventArgs e)
        {

            try
            {
                _clusteringManager.stopTrainDistanceNetwork();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void cbxCUseRate_CheckedChanged(object sender, EventArgs e)
        {
            txtbCBenignVirusRate.ReadOnly = !txtbCBenignVirusRate.ReadOnly;

            txtbCVirusSize.ReadOnly = !txtbCVirusSize.ReadOnly;
            txtbCBenignSize.ReadOnly = !txtbCBenignSize.ReadOnly;
        }
        /// <summary>
        /// mix detector click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCMixDetector_Click(object sender, EventArgs e)
        {
            try
            {
                _mixDetector();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnCClusteringFile_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.RestoreDirectory = true;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                txtbCClusteringFile.Text = openFileDialog1.FileName;
            }

        }
        private void btnCSave_Click(object sender, EventArgs e)
        {
            try
            {
                _saveClustering();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnCLoad_Click(object sender, EventArgs e)
        {
            try
            {
                _loadClustering();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnCMixDetectorFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                txtbCMixDetectorFile.Text = openFileDialog1.FileName;
            }
        }

        #endregion

        #region Classifier Event
        private void btnFCVirusFolder_Click(object sender, EventArgs e)
        {
            FolderSelectDialog folderSelectDialog = new FolderSelectDialog();
            folderSelectDialog.Title = "Select Folder";
            bool result = folderSelectDialog.ShowDialog();
            if (result)
            {
                txtbFCVirusFolder.Text = folderSelectDialog.FileName;
            }
        }
        private void btnFCBenignFolder_Click(object sender, EventArgs e)
        {
            FolderSelectDialog folderSelectDialog = new FolderSelectDialog();
            folderSelectDialog.Title = "Select Folder";
            bool result = folderSelectDialog.ShowDialog();
            if (result)
            {
                txtbFCBenignFolder.Text = folderSelectDialog.FileName;
            }

        }
        private void btnFCPreprocesser_Click(object sender, EventArgs e)
        {
            try
            {
                _preprocesserFileClassifier();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnFCStop_Click(object sender, EventArgs e)
        {
            try
            {
                _fileClassifierManager.stopTrainActiveNetwork();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnFCStartFileClassifier_Click(object sender, EventArgs e)
        {
            try
            {
                _startFileClassifier();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnFCSave_Click(object sender, EventArgs e)
        {
            try
            {
                _saveFileClassifier();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void btnFCLoad_Click(object sender, EventArgs e)
        {
            try
            {
                _loadFileClassifier();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnFCFileClassifierFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.RestoreDirectory = true;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                txtbFCFileClassifierFile.Text = openFileDialog1.FileName;
            }
        }
        #endregion

        #region Scaner Event

        private void btnScanVirus_Click(object sender, EventArgs e)
        {
            try
            {
                _startVirusScanner();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnTestFolder_Click(object sender, EventArgs e)
        {
            FolderSelectDialog folderSelectDialog = new FolderSelectDialog();
            folderSelectDialog.Title = "Select Folder";
            bool result = folderSelectDialog.ShowDialog();
            if (result)
            {
                txtbVSTestFolder.Text = folderSelectDialog.FileName;
            }
        }
        private void btnVSStop_Click(object sender, EventArgs e)
        {
            try
            {
                _worker.Abort();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        #endregion

        #region Timer Event
        /// <summary>
        /// Tick event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                // Return if thead working
                if (_worker == null || _worker.IsAlive)
                    return;

                _turnToWorkingStatus(false);

                switch (_currentProcessType)
                {
                    case EProcessType.Detector:
                        _detectorThread_Stopped();
                        break;
                    case EProcessType.Clustering:
                        break;
                    case EProcessType.FileClassifier:
                        break;

                    case EProcessType.VirusScaner:
                        _virusScannerThread_Stopped();
                        break;
                    default:
                        break;
                }

                _currentProcessType = EProcessType.None;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _turnToWorkingStatus(false);
                _currentProcessType = EProcessType.None;
            }

        }

        #endregion
    }
}
