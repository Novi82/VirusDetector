using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraNavBar;
using VirusDetector.Clustering;
using VirusDetector.Detector;
using VirusDetector.FileClassifier;
using VirusDetector.FormCustomize;
using VirusDetector.Properties;
using VirusDetector.VirusScanner;

namespace VirusDetector
{
    internal enum EDetectorType
    {
        BuildDetector,
        AdditionNegative
    }

    internal enum EProcessType
    {
        None,
        Detector,
        Clustering,
        FileClassifier,
        VirusScaner
    }

    internal enum EFragmentType
    {
        Benign,
        Virus
    }

    public partial class FormMain :Form
    {
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

        #region Timer Event

        /// <summary>
        ///     Tick event
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

        #region variable

        // Declare variable
        /// <summary>
        ///     is training detector
        /// </summary>
        private bool _isTrainingDectector;

        private DateTime startTime;
        private Thread _worker;

        // Data generation
        private DataGeneration _dataGeneration;

        // Virus Fragment output
        private TrainingData _virusFragments;
        // benign Fragment input
        private TrainingData _benignFragments;

        private double[][] _detectorData;
        //todo del private int[] _label;

        private DataTable _negativeSelectionData;
        private DataTable _groupshowingDataTable;

        ////represetation
        // todo del private DataSet dataSet;
        
        // LK Custom code
        private ClusteringManager _clusteringManager;
        private FileClassifierManager _fileClassifierManager;
        private VirusScannerManager _virusScannerManager;
        // todo del private StringCompareManager _stringCompareManager;

        // For scan vr stop button
        //todo control it Boolean _doneScan;

        // Scan vr support
        private List<FileScanInfo> _lFileScanInfo;

        // Thread
        private EProcessType _currentProcessType;

        #endregion

        #region Menu click event

        private void navAbout_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            xtcContent.SelectedTabPage = xtpAbout;
        }

        private void navExit_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Application.Exit();
        }

        private void navClaResult_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            xtcContent.SelectedTabPage = xtpClassReult;
        }

        private void navClaSetting_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            xtcContent.SelectedTabPage = xtpClasSetting;
        }

        private void navCluSetting_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            xtcContent.SelectedTabPage = xtpClusSetting;
        }

        private void navClusResult_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            xtcContent.SelectedTabPage = xtpClusReult;
        }

        private void navDecSetting_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            xtcContent.SelectedTabPage = xtpDeSetting;
        }

        private void navDecResult_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            xtcContent.SelectedTabPage = xtpDeResult;
        }

        private void navScan_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            xtcContent.SelectedTabPage = xtpScan;
        }

        private void navScanResult_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            xtcContent.SelectedTabPage = xtpScanRs;
        }

        #endregion

        #region Detector Event

        /// <summary>
        ///     Browse Virus Folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDVirusFolder_Click(object sender, EventArgs e)
        {
            var folderSelectDialog = new FolderSelectDialog {Title = Resources.Title_Select_Folder};
            if (folderSelectDialog.ShowDialog())
            {
                txtbDVirusFolder.Text = folderSelectDialog.FileName;
            }
        }

        /// <summary>
        ///     browse Benign Folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDBenignFolder_Click(object sender, EventArgs e)
        {
            var folderSelectDialog = new FolderSelectDialog {Title = Resources.Title_Select_Folder};
            if (folderSelectDialog.ShowDialog())
            {
                txtbDBenignFolder.Text = folderSelectDialog.FileName;
            }
        }

        /// <summary>
        ///     Browse Addition Folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDAdditionFolder_Click(object sender, EventArgs e)
        {
            // Show the dialog.
            var folderSelectDialog = new FolderSelectDialog {Title = Resources.Title_Select_Folder};
            if (folderSelectDialog.ShowDialog())
            {
                txtbDAdditionFolder.Text = folderSelectDialog.FileName;
            }
        }

        /// <summary>
        ///     Change Build | Addition
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnDBuildAddDetector_SelectedIndexChanged(object sender, EventArgs e)
        {
            var isBuild = (rbtnDBuildAddDetector.SelectedIndex == 0);
            var detectorType = isBuild ? EDetectorType.BuildDetector : EDetectorType.AdditionNegative;

            _updateDetectorType(detectorType);
        }

        /// <summary>
        ///     Start training detector button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDStart_Click(object sender, EventArgs e)
        {
            try
            {
                txtTimeBox.Text = @"Processing...";
                _startDetector();
                // init path to classifier
                txtbFCBenignFolder.Text = txtbDBenignFolder.Text;
                txtbFCVirusFolder.Text = txtbDVirusFolder.Text;
                // show result
                xtcContent.SelectedTabPage = xtpDeResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        ///     Buton Stop Training
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDStop_Click(object sender, EventArgs e)
        {
            try
            {
                _dataGeneration.StopBuildDetector();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        ///     Browse Detector File
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDDetectorFile_Click(object sender, EventArgs e)
        {
            // Show the dialog.
            var openFileDialog1 = new OpenFileDialog {Title = Resources.Title_Select_Folder};
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtbDDetectorFile.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        ///     Browser Benign File
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDBenignFile_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog();
            if ( openFileDialog1.ShowDialog() == DialogResult.OK) // Test result.
            {
                txtbDBenignFile.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        ///     btn Load detector
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDLoadDetector_Click(object sender, EventArgs e)
        {
            try
            {
                startTime = DateTime.Now;
                _loadDetector();
                // init path to classifier
                txtbFCBenignFolder.Text = txtbDBenignFolder.Text;
                txtbFCVirusFolder.Text = txtbDVirusFolder.Text;
                // show result
                xtcContent.SelectedTabPage = xtpDeResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                txtTimeBox.Text = (DateTime.Now - startTime).ToString(@"hh\:mm\:ss");
            }
        }

        /// <summary>
        ///     Browser Save Folder Event
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
        ///     Toggle Hamming Distance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxDHamming_Toggled(object sender, EventArgs e)
        {
            txtbDHamming.Enabled = cbxDHamming.IsOn;
        }

        /// <summary>
        ///     Toggle R-Contiguous distance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxDRContinuous_Toggled(object sender, EventArgs e)
        {
            txtbDContinuous.Enabled = cbxDRContinuous.IsOn;
        }

        /// <summary>
        ///     Toogle Use rate Percent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxCUseRate_Toggled(object sender, EventArgs e)
        {
            txtbCBenignVirusRate.ReadOnly = !cbxCUseRate.IsOn;

            //txtbCVirusSize.ReadOnly = cbxCUseRate.IsOn;
            txtbCBenignSize.ReadOnly = cbxCUseRate.IsOn;
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
        ///     clustering click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCStartClustering_Click(object sender, EventArgs e)
        {
            try
            {
                _startClustering();
                // show result
                xtcContent.SelectedTabPage = xtpClusReult;
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
                _clusteringManager.StopTrainDistanceNetwork();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        ///     mix detector click
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
            var openFileDialog1 = new OpenFileDialog {RestoreDirectory = true,CheckFileExists = false};
            if (openFileDialog1.ShowDialog() == DialogResult.OK) // Test result.
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
                // show result
                xtcContent.SelectedTabPage = xtpClusReult;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCMixDetectorFile_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK) // Test result.
            {
                txtbCMixDetectorFile.Text = openFileDialog1.FileName;
            }
        }

        #endregion

        #region Classifier Event

        private void btnFCVirusFolder_Click(object sender, EventArgs e)
        {
            var folderSelectDialog = new FolderSelectDialog {Title = Resources.Title_Select_Folder};
            if (folderSelectDialog.ShowDialog())
            {
                txtbFCVirusFolder.Text = folderSelectDialog.FileName;
            }
        }

        private void btnFCBenignFolder_Click(object sender, EventArgs e)
        {
            var folderSelectDialog = new FolderSelectDialog {Title = Resources.Title_Select_Folder};
            if (folderSelectDialog.ShowDialog())
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
                _fileClassifierManager.StopTrainActiveNetwork();
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
            var openFileDialog1 = new OpenFileDialog { RestoreDirectory = true, CheckFileExists = false };
            if (openFileDialog1.ShowDialog() == DialogResult.OK) // Test result.
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
            var folderSelectDialog = new FolderSelectDialog {Title = Resources.Title_Select_Folder};
            if (folderSelectDialog.ShowDialog())
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

        private void btnSvmStart_Click(object sender, EventArgs e)
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

        private void btnSvmStop_Click(object sender, EventArgs e)
        {
            try
            {
                _fileClassifierManager.StopTrainActiveNetwork();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}