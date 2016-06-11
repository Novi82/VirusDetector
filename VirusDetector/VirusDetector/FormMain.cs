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
        public FormMain()
        {
            InitializeComponent();
            initDemo();
            _lkPatch();
            _initialize();
        }

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

        // Add patch for gui to show the program is working
        private void _lkPatch()
        {
            Utils.Utils.GUI_SUPPORT = new GuiSupport(this);
        }

        private void navAbout_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            MessageBox.Show("novi");
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

    }
}
