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

    public partial class FormMain : Form
    {
        #region variable

        // Declare variable
        private bool _isWorking;
        private DateTime startTime;
        private Thread _worker;

        // Data generation
        private DataGeneration datageneration;

        private TrainingData _virusFragments;
        private TrainingData _benignFragments;

        private double[][] _detectorData;

        private int[] Label;
        private List<byte[][]> GroupData;
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

        public FormMain()
        {
            InitializeComponent();
            initDemo();
            _lkPatch();
            _initialize();
        }

        #region Menu

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
        private void btnDDetectorFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                txtbDDetectorFile.Text = openFileDialog1.FileName;
            }
        }
        private void btnDAdditionFolder_Click(object sender, EventArgs e)
        {
            FolderSelectDialog folderSelectDialog = new FolderSelectDialog();
            folderSelectDialog.Title = "Select Folder";
            bool result = folderSelectDialog.ShowDialog();
            if (result)
            {
                txtbDAdditionFolder.Text = folderSelectDialog.FileName;
            }
        }
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
        private void btnDStart_Click(object sender, EventArgs e)
        {
            try
            {
                _startDetector();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnDLoadDetector_Click(object sender, EventArgs e)
        {
            try
            {
                _loadDetection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnDBenignFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                txtbDBenignFile.Text = openFileDialog1.FileName;
            }
        }
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
        private void cbxDHamming_Toggled(object sender, EventArgs e)
        {
            txtbDHamming.Enabled = cbxDHamming.IsOn;
        }
        private void cbxDRContinuous_Toggled(object sender, EventArgs e)
        {
            txtbDContinuous.Enabled = cbxDRContinuous.IsOn;
        }
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


    }
}
