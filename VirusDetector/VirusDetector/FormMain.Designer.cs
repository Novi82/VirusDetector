namespace VirusDetector
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            DevExpress.XtraCharts.XYDiagram xyDiagram7 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series7 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.XYDiagram xyDiagram8 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series8 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesView pointSeriesView4 = new DevExpress.XtraCharts.PointSeriesView();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navDetection = new DevExpress.XtraNavBar.NavBarGroup();
            this.navScan = new DevExpress.XtraNavBar.NavBarItem();
            this.navScanResult = new DevExpress.XtraNavBar.NavBarItem();
            this.navHome = new DevExpress.XtraNavBar.NavBarGroup();
            this.navAbout = new DevExpress.XtraNavBar.NavBarItem();
            this.navExit = new DevExpress.XtraNavBar.NavBarItem();
            this.navDectector = new DevExpress.XtraNavBar.NavBarGroup();
            this.navDecSetting = new DevExpress.XtraNavBar.NavBarItem();
            this.navDecResult = new DevExpress.XtraNavBar.NavBarItem();
            this.navClustering = new DevExpress.XtraNavBar.NavBarGroup();
            this.navCluSetting = new DevExpress.XtraNavBar.NavBarItem();
            this.navClusResult = new DevExpress.XtraNavBar.NavBarItem();
            this.navClassifier = new DevExpress.XtraNavBar.NavBarGroup();
            this.navClaSetting = new DevExpress.XtraNavBar.NavBarItem();
            this.navClaResult = new DevExpress.XtraNavBar.NavBarItem();
            this.panelFooter = new DevExpress.XtraEditors.PanelControl();
            this.progressBar = new DevExpress.XtraEditors.ProgressBarControl();
            this.styleMain = new DevExpress.XtraEditors.StyleController(this.components);
            this.txtStatusBar = new DevExpress.XtraEditors.TextEdit();
            this.txtTimeBox = new DevExpress.XtraEditors.TextEdit();
            this.xtcContent = new DevExpress.XtraTab.XtraTabControl();
            this.xtpDeSetting = new DevExpress.XtraTab.XtraTabPage();
            this.pnlDS = new DevExpress.XtraEditors.PanelControl();
            this.grpOutput = new DevExpress.XtraEditors.GroupControl();
            this.txtbDBenignFile = new DevExpress.XtraEditors.TextEdit();
            this.txtbDDetectorFile = new DevExpress.XtraEditors.TextEdit();
            this.btnDBenignFile = new DevExpress.XtraEditors.SimpleButton();
            this.btnDLoadDetector = new DevExpress.XtraEditors.SimpleButton();
            this.styleButon = new DevExpress.XtraEditors.StyleController(this.components);
            this.btnDSaveDetector = new DevExpress.XtraEditors.SimpleButton();
            this.btnDDetectorFile = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.grpParam = new DevExpress.XtraEditors.GroupControl();
            this.cbxDRContinuous = new DevExpress.XtraEditors.ToggleSwitch();
            this.cbxDHamming = new DevExpress.XtraEditors.ToggleSwitch();
            this.txtbDContinuous = new DevExpress.XtraEditors.TextEdit();
            this.txtbDHamming = new DevExpress.XtraEditors.TextEdit();
            this.txtDStepSize = new DevExpress.XtraEditors.TextEdit();
            this.txtDLength = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.grpInput = new DevExpress.XtraEditors.GroupControl();
            this.txtbDAdditionFolder = new DevExpress.XtraEditors.TextEdit();
            this.txtbDBenignFolder = new DevExpress.XtraEditors.TextEdit();
            this.txtbDVirusFolder = new DevExpress.XtraEditors.TextEdit();
            this.rbtnDBuildAddDetector = new DevExpress.XtraEditors.RadioGroup();
            this.btnDAdditionFolder = new DevExpress.XtraEditors.SimpleButton();
            this.btnDBenignFolder = new DevExpress.XtraEditors.SimpleButton();
            this.btnDStop = new DevExpress.XtraEditors.SimpleButton();
            this.btnDStart = new DevExpress.XtraEditors.SimpleButton();
            this.btnDVirusFolder = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.xtpDeResult = new DevExpress.XtraTab.XtraTabPage();
            this.pnlDR = new DevExpress.XtraEditors.PanelControl();
            this.dtNegativeSelection = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtpClusSetting = new DevExpress.XtraTab.XtraTabPage();
            this.pnlUS = new DevExpress.XtraEditors.PanelControl();
            this.grpMixFile = new DevExpress.XtraEditors.GroupControl();
            this.txtbCClusteringFile = new DevExpress.XtraEditors.TextEdit();
            this.btnCClusteringFile = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.btnCLoad = new DevExpress.XtraEditors.SimpleButton();
            this.btnCSave = new DevExpress.XtraEditors.SimpleButton();
            this.grpClustering = new DevExpress.XtraEditors.GroupControl();
            this.txtbCErrorThresold = new DevExpress.XtraEditors.TextEdit();
            this.txtbCNumIterator = new DevExpress.XtraEditors.TextEdit();
            this.txtbCLearningRadius = new DevExpress.XtraEditors.TextEdit();
            this.txtbCLearningRate = new DevExpress.XtraEditors.TextEdit();
            this.txtbCNumNeuronY = new DevExpress.XtraEditors.TextEdit();
            this.txtbCNumInputNeuron = new DevExpress.XtraEditors.TextEdit();
            this.txtbCNumNeuronX = new DevExpress.XtraEditors.TextEdit();
            this.btnCStopClustering = new DevExpress.XtraEditors.SimpleButton();
            this.btnCStartClustering = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.grpPreProc = new DevExpress.XtraEditors.GroupControl();
            this.txtbCMixDetectorFile = new DevExpress.XtraEditors.TextEdit();
            this.btnCMixDetectorFile = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.btnCMixDetector = new DevExpress.XtraEditors.SimpleButton();
            this.cbxCUseRate = new DevExpress.XtraEditors.ToggleSwitch();
            this.txtbCBenignSize = new DevExpress.XtraEditors.TextEdit();
            this.txtbCVirusSize = new DevExpress.XtraEditors.TextEdit();
            this.txtbCBenignVirusRate = new DevExpress.XtraEditors.TextEdit();
            this.btnCLoadMixDetector = new DevExpress.XtraEditors.SimpleButton();
            this.btnCSaveMixDetector = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.xtpClusReult = new DevExpress.XtraTab.XtraTabPage();
            this.pnlUR = new DevExpress.XtraEditors.PanelControl();
            this.dangerLevel = new DevExpress.XtraCharts.ChartControl();
            this.xtpClasSetting = new DevExpress.XtraTab.XtraTabPage();
            this.pnlAS = new DevExpress.XtraEditors.PanelControl();
            this.grpASFile = new DevExpress.XtraEditors.GroupControl();
            this.txtbFCFileClassifierFile = new DevExpress.XtraEditors.TextEdit();
            this.btnFCFileClassifierFile = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl25 = new DevExpress.XtraEditors.LabelControl();
            this.btnFCLoad = new DevExpress.XtraEditors.SimpleButton();
            this.btnFCSave = new DevExpress.XtraEditors.SimpleButton();
            this.grpASProc = new DevExpress.XtraEditors.GroupControl();
            this.txtbCFErrorThresold = new DevExpress.XtraEditors.TextEdit();
            this.txtbCFNumIterator = new DevExpress.XtraEditors.TextEdit();
            this.txtbFCNumHiddenNeuron = new DevExpress.XtraEditors.TextEdit();
            this.txtbCFNumOutputNeuron = new DevExpress.XtraEditors.TextEdit();
            this.labelControl29 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl30 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl31 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl32 = new DevExpress.XtraEditors.LabelControl();
            this.btnFCStop = new DevExpress.XtraEditors.SimpleButton();
            this.btnFCStartFileClassifier = new DevExpress.XtraEditors.SimpleButton();
            this.grpASPreProc = new DevExpress.XtraEditors.GroupControl();
            this.txtbCFFormatRange = new DevExpress.XtraEditors.TextEdit();
            this.txtbFCBenignFolder = new DevExpress.XtraEditors.TextEdit();
            this.txtbFCVirusFolder = new DevExpress.XtraEditors.TextEdit();
            this.btnFCBenignFolder = new DevExpress.XtraEditors.SimpleButton();
            this.btnFCPreprocesser = new DevExpress.XtraEditors.SimpleButton();
            this.btnFCVirusFolder = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl22 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl23 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl24 = new DevExpress.XtraEditors.LabelControl();
            this.xtpClassReult = new DevExpress.XtraTab.XtraTabPage();
            this.pnlAR = new DevExpress.XtraEditors.PanelControl();
            this.chartFC = new DevExpress.XtraCharts.ChartControl();
            this.xtpScan = new DevExpress.XtraTab.XtraTabPage();
            this.pnlScan = new DevExpress.XtraEditors.PanelControl();
            this.grpScanResult = new DevExpress.XtraEditors.GroupControl();
            this.txtbFCNumVirus = new DevExpress.XtraEditors.TextEdit();
            this.txtbFCNumBenign = new DevExpress.XtraEditors.TextEdit();
            this.labelControl33 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl34 = new DevExpress.XtraEditors.LabelControl();
            this.grpScan = new DevExpress.XtraEditors.GroupControl();
            this.txtbVSTestFolder = new DevExpress.XtraEditors.TextEdit();
            this.btnFCTestFolder = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl26 = new DevExpress.XtraEditors.LabelControl();
            this.btnVSStop = new DevExpress.XtraEditors.SimpleButton();
            this.btnFCScanVirus = new DevExpress.XtraEditors.SimpleButton();
            this.xtpScanRs = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.dgvVirus = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtpAbout = new DevExpress.XtraTab.XtraTabPage();
            this.imcNavIcon = new DevExpress.Utils.ImageCollection(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this._timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelFooter)).BeginInit();
            this.panelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatusBar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtcContent)).BeginInit();
            this.xtcContent.SuspendLayout();
            this.xtpDeSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDS)).BeginInit();
            this.pnlDS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpOutput)).BeginInit();
            this.grpOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbDBenignFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbDDetectorFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleButon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpParam)).BeginInit();
            this.grpParam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxDRContinuous.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxDHamming.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbDContinuous.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbDHamming.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDStepSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDLength.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpInput)).BeginInit();
            this.grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbDAdditionFolder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbDBenignFolder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbDVirusFolder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnDBuildAddDetector.Properties)).BeginInit();
            this.xtpDeResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDR)).BeginInit();
            this.pnlDR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtNegativeSelection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.xtpClusSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlUS)).BeginInit();
            this.pnlUS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpMixFile)).BeginInit();
            this.grpMixFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCClusteringFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpClustering)).BeginInit();
            this.grpClustering.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCErrorThresold.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCNumIterator.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCLearningRadius.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCLearningRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCNumNeuronY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCNumInputNeuron.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCNumNeuronX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPreProc)).BeginInit();
            this.grpPreProc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCMixDetectorFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxCUseRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCBenignSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCVirusSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCBenignVirusRate.Properties)).BeginInit();
            this.xtpClusReult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlUR)).BeginInit();
            this.pnlUR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dangerLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series7)).BeginInit();
            this.xtpClasSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAS)).BeginInit();
            this.pnlAS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpASFile)).BeginInit();
            this.grpASFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbFCFileClassifierFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpASProc)).BeginInit();
            this.grpASProc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCFErrorThresold.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCFNumIterator.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbFCNumHiddenNeuron.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCFNumOutputNeuron.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpASPreProc)).BeginInit();
            this.grpASPreProc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCFFormatRange.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbFCBenignFolder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbFCVirusFolder.Properties)).BeginInit();
            this.xtpClassReult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAR)).BeginInit();
            this.pnlAR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartFC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesView4)).BeginInit();
            this.xtpScan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlScan)).BeginInit();
            this.pnlScan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpScanResult)).BeginInit();
            this.grpScanResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbFCNumVirus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbFCNumBenign.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpScan)).BeginInit();
            this.grpScan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbVSTestFolder.Properties)).BeginInit();
            this.xtpScanRs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVirus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imcNavIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Appearance.BackColor = System.Drawing.Color.Gray;
            this.splitContainerControl1.Appearance.BackColor2 = System.Drawing.Color.DarkGray;
            this.splitContainerControl1.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.splitContainerControl1.Appearance.Options.UseBackColor = true;
            this.splitContainerControl1.Appearance.Options.UseBorderColor = true;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.navBarControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Appearance.BackColor = System.Drawing.Color.Gray;
            this.splitContainerControl1.Panel2.Appearance.Options.UseBackColor = true;
            this.splitContainerControl1.Panel2.Controls.Add(this.panelFooter);
            this.splitContainerControl1.Panel2.Controls.Add(this.xtcContent);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1024, 700);
            this.splitContainerControl1.SplitterPosition = 183;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navDetection;
            this.navBarControl1.Appearance.Background.BackColor = System.Drawing.Color.Gray;
            this.navBarControl1.Appearance.Background.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.navBarControl1.Appearance.Background.Font = new System.Drawing.Font("Tahoma", 10F);
            this.navBarControl1.Appearance.Background.Options.UseBackColor = true;
            this.navBarControl1.Appearance.Background.Options.UseBorderColor = true;
            this.navBarControl1.Appearance.Background.Options.UseFont = true;
            this.navBarControl1.Appearance.Button.Font = new System.Drawing.Font("Tahoma", 10F);
            this.navBarControl1.Appearance.Button.Options.UseFont = true;
            this.navBarControl1.Appearance.ButtonDisabled.Font = new System.Drawing.Font("Tahoma", 10F);
            this.navBarControl1.Appearance.ButtonDisabled.Options.UseFont = true;
            this.navBarControl1.Appearance.ButtonHotTracked.Font = new System.Drawing.Font("Tahoma", 10F);
            this.navBarControl1.Appearance.ButtonHotTracked.Options.UseFont = true;
            this.navBarControl1.Appearance.ButtonPressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.navBarControl1.Appearance.ButtonPressed.Options.UseFont = true;
            this.navBarControl1.Appearance.GroupBackground.Font = new System.Drawing.Font("Tahoma", 10F);
            this.navBarControl1.Appearance.GroupBackground.Options.UseFont = true;
            this.navBarControl1.Appearance.GroupHeader.Font = new System.Drawing.Font("Tahoma", 10F);
            this.navBarControl1.Appearance.GroupHeader.Options.UseFont = true;
            this.navBarControl1.Appearance.GroupHeaderActive.Font = new System.Drawing.Font("Tahoma", 10F);
            this.navBarControl1.Appearance.GroupHeaderActive.Options.UseFont = true;
            this.navBarControl1.Appearance.GroupHeaderHotTracked.Font = new System.Drawing.Font("Tahoma", 10F);
            this.navBarControl1.Appearance.GroupHeaderHotTracked.Options.UseFont = true;
            this.navBarControl1.Appearance.GroupHeaderPressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.navBarControl1.Appearance.GroupHeaderPressed.Options.UseFont = true;
            this.navBarControl1.Appearance.Hint.Font = new System.Drawing.Font("Tahoma", 10F);
            this.navBarControl1.Appearance.Hint.Options.UseFont = true;
            this.navBarControl1.Appearance.Item.Font = new System.Drawing.Font("Tahoma", 10F);
            this.navBarControl1.Appearance.Item.Options.UseFont = true;
            this.navBarControl1.Appearance.ItemActive.Font = new System.Drawing.Font("Tahoma", 10F);
            this.navBarControl1.Appearance.ItemActive.Options.UseFont = true;
            this.navBarControl1.Appearance.ItemDisabled.Font = new System.Drawing.Font("Tahoma", 10F);
            this.navBarControl1.Appearance.ItemDisabled.Options.UseFont = true;
            this.navBarControl1.Appearance.ItemHotTracked.Font = new System.Drawing.Font("Tahoma", 10F);
            this.navBarControl1.Appearance.ItemHotTracked.Options.UseFont = true;
            this.navBarControl1.Appearance.ItemPressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.navBarControl1.Appearance.ItemPressed.Options.UseFont = true;
            this.navBarControl1.Appearance.LinkDropTarget.Font = new System.Drawing.Font("Tahoma", 10F);
            this.navBarControl1.Appearance.LinkDropTarget.Options.UseFont = true;
            this.navBarControl1.Appearance.NavigationPaneHeader.Font = new System.Drawing.Font("Tahoma", 10F);
            this.navBarControl1.Appearance.NavigationPaneHeader.Options.UseFont = true;
            this.navBarControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navHome,
            this.navDectector,
            this.navClustering,
            this.navClassifier,
            this.navDetection});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navAbout,
            this.navExit,
            this.navCluSetting,
            this.navClusResult,
            this.navClaSetting,
            this.navClaResult,
            this.navScan,
            this.navDecSetting,
            this.navDecResult,
            this.navScanResult});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 183;
            this.navBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl1.Size = new System.Drawing.Size(183, 700);
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Text = "navBarControl1";
            this.navBarControl1.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinNavigationPaneViewInfoRegistrator("Office 2016 Dark");
            // 
            // navDetection
            // 
            this.navDetection.Caption = "Detection";
            this.navDetection.Expanded = true;
            this.navDetection.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsList;
            this.navDetection.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navScan),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navScanResult)});
            this.navDetection.Name = "navDetection";
            // 
            // navScan
            // 
            this.navScan.Caption = "Scan";
            this.navScan.LargeImage = global::VirusDetector.Properties.Resources.scan;
            this.navScan.Name = "navScan";
            this.navScan.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navScan_LinkClicked);
            // 
            // navScanResult
            // 
            this.navScanResult.Caption = "Scan Result";
            this.navScanResult.LargeImage = global::VirusDetector.Properties.Resources.result2;
            this.navScanResult.Name = "navScanResult";
            this.navScanResult.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navScanResult_LinkClicked);
            // 
            // navHome
            // 
            this.navHome.Caption = "Home";
            this.navHome.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsList;
            this.navHome.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navAbout),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navExit)});
            this.navHome.Name = "navHome";
            // 
            // navAbout
            // 
            this.navAbout.Caption = "About";
            this.navAbout.LargeImage = ((System.Drawing.Image)(resources.GetObject("navAbout.LargeImage")));
            this.navAbout.Name = "navAbout";
            this.navAbout.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navAbout_LinkClicked);
            // 
            // navExit
            // 
            this.navExit.Caption = "Exit";
            this.navExit.LargeImage = ((System.Drawing.Image)(resources.GetObject("navExit.LargeImage")));
            this.navExit.Name = "navExit";
            this.navExit.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navExit_LinkClicked);
            // 
            // navDectector
            // 
            this.navDectector.Caption = "Detector";
            this.navDectector.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsList;
            this.navDectector.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navDecSetting),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navDecResult)});
            this.navDectector.Name = "navDectector";
            // 
            // navDecSetting
            // 
            this.navDecSetting.Caption = "Setting";
            this.navDecSetting.LargeImage = global::VirusDetector.Properties.Resources.setting2;
            this.navDecSetting.Name = "navDecSetting";
            this.navDecSetting.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navDecSetting_LinkClicked);
            // 
            // navDecResult
            // 
            this.navDecResult.Caption = "Result";
            this.navDecResult.LargeImage = global::VirusDetector.Properties.Resources.result2;
            this.navDecResult.Name = "navDecResult";
            this.navDecResult.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navDecResult_LinkClicked);
            // 
            // navClustering
            // 
            this.navClustering.Caption = "Clustering";
            this.navClustering.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsList;
            this.navClustering.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navCluSetting),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navClusResult)});
            this.navClustering.Name = "navClustering";
            // 
            // navCluSetting
            // 
            this.navCluSetting.Caption = "Setting";
            this.navCluSetting.LargeImage = global::VirusDetector.Properties.Resources.setting2;
            this.navCluSetting.Name = "navCluSetting";
            this.navCluSetting.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navCluSetting_LinkClicked);
            // 
            // navClusResult
            // 
            this.navClusResult.Caption = "Result";
            this.navClusResult.LargeImage = global::VirusDetector.Properties.Resources.result2;
            this.navClusResult.Name = "navClusResult";
            this.navClusResult.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navClusResult_LinkClicked);
            // 
            // navClassifier
            // 
            this.navClassifier.Caption = "Classifier";
            this.navClassifier.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsList;
            this.navClassifier.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navClaSetting),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navClaResult)});
            this.navClassifier.Name = "navClassifier";
            // 
            // navClaSetting
            // 
            this.navClaSetting.Caption = "Setting";
            this.navClaSetting.LargeImage = global::VirusDetector.Properties.Resources.setting2;
            this.navClaSetting.Name = "navClaSetting";
            this.navClaSetting.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navClaSetting_LinkClicked);
            // 
            // navClaResult
            // 
            this.navClaResult.Caption = "Result";
            this.navClaResult.LargeImage = global::VirusDetector.Properties.Resources.result2;
            this.navClaResult.Name = "navClaResult";
            this.navClaResult.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navClaResult_LinkClicked);
            // 
            // panelFooter
            // 
            this.panelFooter.Appearance.BackColor = System.Drawing.Color.Gray;
            this.panelFooter.Appearance.BackColor2 = System.Drawing.Color.Gray;
            this.panelFooter.Appearance.BorderColor = System.Drawing.Color.Gray;
            this.panelFooter.Appearance.Options.UseBackColor = true;
            this.panelFooter.Appearance.Options.UseBorderColor = true;
            this.panelFooter.Controls.Add(this.progressBar);
            this.panelFooter.Controls.Add(this.txtStatusBar);
            this.panelFooter.Controls.Add(this.txtTimeBox);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 625);
            this.panelFooter.LookAndFeel.SkinName = "Office 2016 Dark";
            this.panelFooter.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(836, 75);
            this.panelFooter.TabIndex = 1;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(5, 40);
            this.progressBar.Name = "progressBar";
            this.progressBar.Properties.ShowTitle = true;
            this.progressBar.Properties.Step = 1;
            this.progressBar.Properties.TextOrientation = DevExpress.Utils.Drawing.TextOrientation.Horizontal;
            this.progressBar.Size = new System.Drawing.Size(826, 26);
            this.progressBar.StyleController = this.styleMain;
            this.progressBar.TabIndex = 2;
            // 
            // styleMain
            // 
            this.styleMain.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styleMain.Appearance.Options.UseFont = true;
            this.styleMain.LookAndFeel.SkinName = "Office 2016 Colorful";
            this.styleMain.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // txtStatusBar
            // 
            this.txtStatusBar.Location = new System.Drawing.Point(128, 7);
            this.txtStatusBar.Name = "txtStatusBar";
            this.txtStatusBar.Size = new System.Drawing.Size(703, 26);
            this.txtStatusBar.StyleController = this.styleMain;
            this.txtStatusBar.TabIndex = 1;
            // 
            // txtTimeBox
            // 
            this.txtTimeBox.Location = new System.Drawing.Point(5, 7);
            this.txtTimeBox.Name = "txtTimeBox";
            this.txtTimeBox.Size = new System.Drawing.Size(117, 26);
            this.txtTimeBox.StyleController = this.styleMain;
            this.txtTimeBox.TabIndex = 0;
            // 
            // xtcContent
            // 
            this.xtcContent.Appearance.BackColor = System.Drawing.Color.Gray;
            this.xtcContent.Appearance.Options.UseBackColor = true;
            this.xtcContent.AppearancePage.PageClient.BackColor = System.Drawing.Color.Gray;
            this.xtcContent.AppearancePage.PageClient.BackColor2 = System.Drawing.Color.Silver;
            this.xtcContent.AppearancePage.PageClient.BorderColor = System.Drawing.Color.Black;
            this.xtcContent.AppearancePage.PageClient.Options.UseBackColor = true;
            this.xtcContent.AppearancePage.PageClient.Options.UseBorderColor = true;
            this.xtcContent.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.xtcContent.BorderStylePage = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.xtcContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.xtcContent.Location = new System.Drawing.Point(0, 0);
            this.xtcContent.Name = "xtcContent";
            this.xtcContent.SelectedTabPage = this.xtpDeSetting;
            this.xtcContent.ShowTabHeader = DevExpress.Utils.DefaultBoolean.True;
            this.xtcContent.Size = new System.Drawing.Size(836, 641);
            this.xtcContent.TabIndex = 0;
            this.xtcContent.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtpDeSetting,
            this.xtpDeResult,
            this.xtpClusSetting,
            this.xtpClusReult,
            this.xtpClasSetting,
            this.xtpClassReult,
            this.xtpScan,
            this.xtpScanRs,
            this.xtpAbout});
            // 
            // xtpDeSetting
            // 
            this.xtpDeSetting.Appearance.PageClient.BackColor = System.Drawing.Color.DimGray;
            this.xtpDeSetting.Appearance.PageClient.BackColor2 = System.Drawing.Color.Gray;
            this.xtpDeSetting.Appearance.PageClient.BorderColor = System.Drawing.Color.Black;
            this.xtpDeSetting.Appearance.PageClient.Options.UseBackColor = true;
            this.xtpDeSetting.Appearance.PageClient.Options.UseBorderColor = true;
            this.xtpDeSetting.Controls.Add(this.pnlDS);
            this.xtpDeSetting.Name = "xtpDeSetting";
            this.xtpDeSetting.Size = new System.Drawing.Size(830, 613);
            this.xtpDeSetting.Text = "DS";
            // 
            // pnlDS
            // 
            this.pnlDS.Appearance.BackColor = System.Drawing.Color.Gray;
            this.pnlDS.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlDS.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlDS.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlDS.Appearance.Options.UseBackColor = true;
            this.pnlDS.Appearance.Options.UseBorderColor = true;
            this.pnlDS.Appearance.Options.UseFont = true;
            this.pnlDS.Controls.Add(this.grpOutput);
            this.pnlDS.Controls.Add(this.grpParam);
            this.pnlDS.Controls.Add(this.grpInput);
            this.pnlDS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDS.Location = new System.Drawing.Point(0, 0);
            this.pnlDS.LookAndFeel.SkinMaskColor = System.Drawing.Color.White;
            this.pnlDS.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.White;
            this.pnlDS.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.pnlDS.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlDS.Name = "pnlDS";
            this.pnlDS.Size = new System.Drawing.Size(830, 613);
            this.pnlDS.TabIndex = 0;
            // 
            // grpOutput
            // 
            this.grpOutput.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.grpOutput.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpOutput.Appearance.Options.UseBackColor = true;
            this.grpOutput.Appearance.Options.UseFont = true;
            this.grpOutput.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpOutput.AppearanceCaption.Options.UseFont = true;
            this.grpOutput.Controls.Add(this.txtbDBenignFile);
            this.grpOutput.Controls.Add(this.txtbDDetectorFile);
            this.grpOutput.Controls.Add(this.btnDBenignFile);
            this.grpOutput.Controls.Add(this.btnDLoadDetector);
            this.grpOutput.Controls.Add(this.btnDSaveDetector);
            this.grpOutput.Controls.Add(this.btnDDetectorFile);
            this.grpOutput.Controls.Add(this.labelControl9);
            this.grpOutput.Controls.Add(this.labelControl10);
            this.grpOutput.Location = new System.Drawing.Point(412, 179);
            this.grpOutput.Name = "grpOutput";
            this.grpOutput.Size = new System.Drawing.Size(400, 227);
            this.grpOutput.TabIndex = 0;
            this.grpOutput.Text = "Output";
            // 
            // txtbDBenignFile
            // 
            this.txtbDBenignFile.Location = new System.Drawing.Point(5, 127);
            this.txtbDBenignFile.Name = "txtbDBenignFile";
            this.txtbDBenignFile.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbDBenignFile.Properties.Appearance.Options.UseFont = true;
            this.txtbDBenignFile.Size = new System.Drawing.Size(338, 22);
            this.txtbDBenignFile.StyleController = this.styleMain;
            this.txtbDBenignFile.TabIndex = 4;
            // 
            // txtbDDetectorFile
            // 
            this.txtbDDetectorFile.Location = new System.Drawing.Point(5, 65);
            this.txtbDDetectorFile.Name = "txtbDDetectorFile";
            this.txtbDDetectorFile.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbDDetectorFile.Properties.Appearance.Options.UseFont = true;
            this.txtbDDetectorFile.Size = new System.Drawing.Size(338, 22);
            this.txtbDDetectorFile.StyleController = this.styleMain;
            this.txtbDDetectorFile.TabIndex = 1;
            // 
            // btnDBenignFile
            // 
            this.btnDBenignFile.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDBenignFile.Appearance.Options.UseFont = true;
            this.btnDBenignFile.Location = new System.Drawing.Point(349, 127);
            this.btnDBenignFile.Name = "btnDBenignFile";
            this.btnDBenignFile.Size = new System.Drawing.Size(46, 23);
            this.btnDBenignFile.StyleController = this.styleMain;
            this.btnDBenignFile.TabIndex = 5;
            this.btnDBenignFile.Text = "...";
            this.btnDBenignFile.Click += new System.EventHandler(this.btnDBenignFile_Click);
            // 
            // btnDLoadDetector
            // 
            this.btnDLoadDetector.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDLoadDetector.Appearance.Options.UseFont = true;
            this.btnDLoadDetector.Location = new System.Drawing.Point(124, 178);
            this.btnDLoadDetector.Name = "btnDLoadDetector";
            this.btnDLoadDetector.Size = new System.Drawing.Size(81, 34);
            this.btnDLoadDetector.StyleController = this.styleButon;
            this.btnDLoadDetector.TabIndex = 7;
            this.btnDLoadDetector.Text = "Load";
            this.btnDLoadDetector.Click += new System.EventHandler(this.btnDLoadDetector_Click);
            // 
            // styleButon
            // 
            this.styleButon.Appearance.BackColor = System.Drawing.Color.DarkCyan;
            this.styleButon.Appearance.BackColor2 = System.Drawing.Color.Cyan;
            this.styleButon.Appearance.BorderColor = System.Drawing.Color.White;
            this.styleButon.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.styleButon.Appearance.Options.UseBackColor = true;
            this.styleButon.Appearance.Options.UseBorderColor = true;
            this.styleButon.Appearance.Options.UseForeColor = true;
            this.styleButon.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.styleButon.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnDSaveDetector
            // 
            this.btnDSaveDetector.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDSaveDetector.Appearance.Options.UseFont = true;
            this.btnDSaveDetector.Location = new System.Drawing.Point(6, 178);
            this.btnDSaveDetector.Name = "btnDSaveDetector";
            this.btnDSaveDetector.Size = new System.Drawing.Size(85, 34);
            this.btnDSaveDetector.StyleController = this.styleButon;
            this.btnDSaveDetector.TabIndex = 6;
            this.btnDSaveDetector.Text = "Save";
            this.btnDSaveDetector.Click += new System.EventHandler(this.btnDSaveDetector_Click);
            // 
            // btnDDetectorFile
            // 
            this.btnDDetectorFile.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDDetectorFile.Appearance.Options.UseFont = true;
            this.btnDDetectorFile.Location = new System.Drawing.Point(349, 64);
            this.btnDDetectorFile.Name = "btnDDetectorFile";
            this.btnDDetectorFile.Size = new System.Drawing.Size(46, 23);
            this.btnDDetectorFile.StyleController = this.styleMain;
            this.btnDDetectorFile.TabIndex = 2;
            this.btnDDetectorFile.Text = "...";
            this.btnDDetectorFile.Click += new System.EventHandler(this.btnDDetectorFile_Click);
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Location = new System.Drawing.Point(6, 103);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(45, 18);
            this.labelControl9.StyleController = this.styleMain;
            this.labelControl9.TabIndex = 3;
            this.labelControl9.Text = "Benign";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl10.Location = new System.Drawing.Point(6, 41);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(33, 18);
            this.labelControl10.StyleController = this.styleMain;
            this.labelControl10.TabIndex = 0;
            this.labelControl10.Text = "Virus";
            // 
            // grpParam
            // 
            this.grpParam.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.grpParam.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpParam.Appearance.Options.UseBackColor = true;
            this.grpParam.Appearance.Options.UseFont = true;
            this.grpParam.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpParam.AppearanceCaption.Options.UseFont = true;
            this.grpParam.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpParam.Controls.Add(this.cbxDRContinuous);
            this.grpParam.Controls.Add(this.cbxDHamming);
            this.grpParam.Controls.Add(this.txtbDContinuous);
            this.grpParam.Controls.Add(this.txtbDHamming);
            this.grpParam.Controls.Add(this.txtDStepSize);
            this.grpParam.Controls.Add(this.txtDLength);
            this.grpParam.Controls.Add(this.labelControl7);
            this.grpParam.Controls.Add(this.labelControl4);
            this.grpParam.Controls.Add(this.labelControl5);
            this.grpParam.Controls.Add(this.labelControl6);
            this.grpParam.Location = new System.Drawing.Point(412, 6);
            this.grpParam.Name = "grpParam";
            this.grpParam.Size = new System.Drawing.Size(400, 167);
            this.grpParam.TabIndex = 1;
            this.grpParam.Text = "Parameters";
            // 
            // cbxDRContinuous
            // 
            this.cbxDRContinuous.Location = new System.Drawing.Point(243, 128);
            this.cbxDRContinuous.Name = "cbxDRContinuous";
            this.cbxDRContinuous.Properties.OffText = "Off";
            this.cbxDRContinuous.Properties.OnText = "On";
            this.cbxDRContinuous.Size = new System.Drawing.Size(95, 24);
            this.cbxDRContinuous.TabIndex = 9;
            // 
            // cbxDHamming
            // 
            this.cbxDHamming.Location = new System.Drawing.Point(243, 100);
            this.cbxDHamming.Name = "cbxDHamming";
            this.cbxDHamming.Properties.OffText = "Off";
            this.cbxDHamming.Properties.OnText = "On";
            this.cbxDHamming.Size = new System.Drawing.Size(95, 24);
            this.cbxDHamming.TabIndex = 6;
            // 
            // txtbDContinuous
            // 
            this.txtbDContinuous.Location = new System.Drawing.Point(117, 129);
            this.txtbDContinuous.Name = "txtbDContinuous";
            this.txtbDContinuous.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbDContinuous.Properties.Appearance.Options.UseFont = true;
            this.txtbDContinuous.Size = new System.Drawing.Size(114, 22);
            this.txtbDContinuous.TabIndex = 8;
            // 
            // txtbDHamming
            // 
            this.txtbDHamming.Location = new System.Drawing.Point(117, 101);
            this.txtbDHamming.Name = "txtbDHamming";
            this.txtbDHamming.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbDHamming.Properties.Appearance.Options.UseFont = true;
            this.txtbDHamming.Size = new System.Drawing.Size(114, 22);
            this.txtbDHamming.StyleController = this.styleMain;
            this.txtbDHamming.TabIndex = 5;
            // 
            // txtDStepSize
            // 
            this.txtDStepSize.Location = new System.Drawing.Point(117, 65);
            this.txtDStepSize.Name = "txtDStepSize";
            this.txtDStepSize.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDStepSize.Properties.Appearance.Options.UseFont = true;
            this.txtDStepSize.Size = new System.Drawing.Size(114, 22);
            this.txtDStepSize.StyleController = this.styleMain;
            this.txtDStepSize.TabIndex = 3;
            // 
            // txtDLength
            // 
            this.txtDLength.Location = new System.Drawing.Point(117, 39);
            this.txtDLength.Name = "txtDLength";
            this.txtDLength.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDLength.Properties.Appearance.Options.UseFont = true;
            this.txtDLength.Size = new System.Drawing.Size(114, 22);
            this.txtDLength.StyleController = this.styleMain;
            this.txtDLength.TabIndex = 1;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Location = new System.Drawing.Point(6, 131);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(92, 18);
            this.labelControl7.TabIndex = 7;
            this.labelControl7.Text = "R-Continuous";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(6, 103);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(64, 18);
            this.labelControl4.StyleController = this.styleMain;
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "Hamming";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Location = new System.Drawing.Point(5, 67);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(30, 18);
            this.labelControl5.StyleController = this.styleMain;
            this.labelControl5.TabIndex = 2;
            this.labelControl5.Text = "Step";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Location = new System.Drawing.Point(5, 41);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(44, 18);
            this.labelControl6.StyleController = this.styleMain;
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "Length";
            // 
            // grpInput
            // 
            this.grpInput.Appearance.BackColor = System.Drawing.Color.Gray;
            this.grpInput.Appearance.BackColor2 = System.Drawing.Color.Gray;
            this.grpInput.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpInput.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.grpInput.Appearance.Options.UseBackColor = true;
            this.grpInput.Appearance.Options.UseFont = true;
            this.grpInput.Appearance.Options.UseForeColor = true;
            this.grpInput.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpInput.AppearanceCaption.Options.UseFont = true;
            this.grpInput.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpInput.Controls.Add(this.txtbDAdditionFolder);
            this.grpInput.Controls.Add(this.txtbDBenignFolder);
            this.grpInput.Controls.Add(this.txtbDVirusFolder);
            this.grpInput.Controls.Add(this.rbtnDBuildAddDetector);
            this.grpInput.Controls.Add(this.btnDAdditionFolder);
            this.grpInput.Controls.Add(this.btnDBenignFolder);
            this.grpInput.Controls.Add(this.btnDStop);
            this.grpInput.Controls.Add(this.btnDStart);
            this.grpInput.Controls.Add(this.btnDVirusFolder);
            this.grpInput.Controls.Add(this.labelControl3);
            this.grpInput.Controls.Add(this.labelControl2);
            this.grpInput.Controls.Add(this.labelControl1);
            this.grpInput.Location = new System.Drawing.Point(6, 6);
            this.grpInput.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(400, 400);
            this.grpInput.TabIndex = 0;
            this.grpInput.Text = "Input";
            // 
            // txtbDAdditionFolder
            // 
            this.txtbDAdditionFolder.Location = new System.Drawing.Point(6, 200);
            this.txtbDAdditionFolder.Name = "txtbDAdditionFolder";
            this.txtbDAdditionFolder.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbDAdditionFolder.Properties.Appearance.Options.UseFont = true;
            this.txtbDAdditionFolder.Size = new System.Drawing.Size(327, 22);
            this.txtbDAdditionFolder.StyleController = this.styleMain;
            this.txtbDAdditionFolder.TabIndex = 7;
            // 
            // txtbDBenignFolder
            // 
            this.txtbDBenignFolder.Location = new System.Drawing.Point(6, 129);
            this.txtbDBenignFolder.Name = "txtbDBenignFolder";
            this.txtbDBenignFolder.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbDBenignFolder.Properties.Appearance.Options.UseFont = true;
            this.txtbDBenignFolder.Size = new System.Drawing.Size(328, 22);
            this.txtbDBenignFolder.StyleController = this.styleMain;
            this.txtbDBenignFolder.TabIndex = 4;
            // 
            // txtbDVirusFolder
            // 
            this.txtbDVirusFolder.Location = new System.Drawing.Point(6, 65);
            this.txtbDVirusFolder.Name = "txtbDVirusFolder";
            this.txtbDVirusFolder.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbDVirusFolder.Properties.Appearance.Options.UseFont = true;
            this.txtbDVirusFolder.Size = new System.Drawing.Size(329, 22);
            this.txtbDVirusFolder.StyleController = this.styleMain;
            this.txtbDVirusFolder.TabIndex = 1;
            // 
            // rbtnDBuildAddDetector
            // 
            this.rbtnDBuildAddDetector.Location = new System.Drawing.Point(6, 245);
            this.rbtnDBuildAddDetector.Name = "rbtnDBuildAddDetector";
            this.rbtnDBuildAddDetector.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rbtnDBuildAddDetector.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnDBuildAddDetector.Properties.Appearance.Options.UseBackColor = true;
            this.rbtnDBuildAddDetector.Properties.Appearance.Options.UseFont = true;
            this.rbtnDBuildAddDetector.Properties.Columns = 1;
            this.rbtnDBuildAddDetector.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Build Detector"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Addition Negative")});
            this.rbtnDBuildAddDetector.Size = new System.Drawing.Size(378, 88);
            this.rbtnDBuildAddDetector.StyleController = this.styleMain;
            this.rbtnDBuildAddDetector.TabIndex = 9;
            this.rbtnDBuildAddDetector.SelectedIndexChanged += new System.EventHandler(this.rbtnDBuildAddDetector_SelectedIndexChanged);
            // 
            // btnDAdditionFolder
            // 
            this.btnDAdditionFolder.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDAdditionFolder.Appearance.Options.UseFont = true;
            this.btnDAdditionFolder.Location = new System.Drawing.Point(340, 200);
            this.btnDAdditionFolder.Name = "btnDAdditionFolder";
            this.btnDAdditionFolder.Size = new System.Drawing.Size(46, 23);
            this.btnDAdditionFolder.StyleController = this.styleMain;
            this.btnDAdditionFolder.TabIndex = 8;
            this.btnDAdditionFolder.Text = "...";
            this.btnDAdditionFolder.Click += new System.EventHandler(this.btnDAdditionFolder_Click);
            // 
            // btnDBenignFolder
            // 
            this.btnDBenignFolder.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDBenignFolder.Appearance.Options.UseFont = true;
            this.btnDBenignFolder.Location = new System.Drawing.Point(340, 129);
            this.btnDBenignFolder.Name = "btnDBenignFolder";
            this.btnDBenignFolder.Size = new System.Drawing.Size(46, 23);
            this.btnDBenignFolder.StyleController = this.styleMain;
            this.btnDBenignFolder.TabIndex = 5;
            this.btnDBenignFolder.Text = "...";
            this.btnDBenignFolder.Click += new System.EventHandler(this.btnDBenignFolder_Click);
            // 
            // btnDStop
            // 
            this.btnDStop.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDStop.Appearance.Options.UseFont = true;
            this.btnDStop.Location = new System.Drawing.Point(121, 352);
            this.btnDStop.Name = "btnDStop";
            this.btnDStop.Size = new System.Drawing.Size(81, 34);
            this.btnDStop.StyleController = this.styleButon;
            this.btnDStop.TabIndex = 11;
            this.btnDStop.Text = "Stop";
            this.btnDStop.Click += new System.EventHandler(this.btnDStop_Click);
            // 
            // btnDStart
            // 
            this.btnDStart.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDStart.Appearance.Options.UseFont = true;
            this.btnDStart.Location = new System.Drawing.Point(6, 352);
            this.btnDStart.Name = "btnDStart";
            this.btnDStart.Size = new System.Drawing.Size(85, 34);
            this.btnDStart.StyleController = this.styleButon;
            this.btnDStart.TabIndex = 10;
            this.btnDStart.Text = "Start";
            this.btnDStart.Click += new System.EventHandler(this.btnDStart_Click);
            // 
            // btnDVirusFolder
            // 
            this.btnDVirusFolder.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDVirusFolder.Appearance.Options.UseFont = true;
            this.btnDVirusFolder.Location = new System.Drawing.Point(340, 65);
            this.btnDVirusFolder.Name = "btnDVirusFolder";
            this.btnDVirusFolder.Size = new System.Drawing.Size(46, 23);
            this.btnDVirusFolder.StyleController = this.styleMain;
            this.btnDVirusFolder.TabIndex = 2;
            this.btnDVirusFolder.Text = "...";
            this.btnDVirusFolder.Click += new System.EventHandler(this.btnDVirusFolder_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(6, 167);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(116, 18);
            this.labelControl3.StyleController = this.styleMain;
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Addition Directory";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(6, 103);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(117, 18);
            this.labelControl2.StyleController = this.styleMain;
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Benign Dicrectory";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(6, 41);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(97, 18);
            this.labelControl1.StyleController = this.styleMain;
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Virus Directory";
            // 
            // xtpDeResult
            // 
            this.xtpDeResult.Controls.Add(this.pnlDR);
            this.xtpDeResult.Name = "xtpDeResult";
            this.xtpDeResult.Size = new System.Drawing.Size(830, 613);
            this.xtpDeResult.Text = "DR";
            // 
            // pnlDR
            // 
            this.pnlDR.Appearance.BackColor = System.Drawing.Color.Gray;
            this.pnlDR.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlDR.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlDR.Appearance.Options.UseBackColor = true;
            this.pnlDR.Appearance.Options.UseBorderColor = true;
            this.pnlDR.Controls.Add(this.dtNegativeSelection);
            this.pnlDR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDR.Location = new System.Drawing.Point(0, 0);
            this.pnlDR.LookAndFeel.SkinMaskColor = System.Drawing.Color.White;
            this.pnlDR.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.White;
            this.pnlDR.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.pnlDR.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlDR.Name = "pnlDR";
            this.pnlDR.Size = new System.Drawing.Size(830, 613);
            this.pnlDR.TabIndex = 1;
            // 
            // dtNegativeSelection
            // 
            this.dtNegativeSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtNegativeSelection.Location = new System.Drawing.Point(3, 3);
            this.dtNegativeSelection.MainView = this.gridView2;
            this.dtNegativeSelection.Name = "dtNegativeSelection";
            this.dtNegativeSelection.Size = new System.Drawing.Size(824, 607);
            this.dtNegativeSelection.TabIndex = 0;
            this.dtNegativeSelection.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.dtNegativeSelection;
            this.gridView2.Name = "gridView2";
            // 
            // xtpClusSetting
            // 
            this.xtpClusSetting.Controls.Add(this.pnlUS);
            this.xtpClusSetting.Name = "xtpClusSetting";
            this.xtpClusSetting.Size = new System.Drawing.Size(830, 613);
            this.xtpClusSetting.Text = "US";
            // 
            // pnlUS
            // 
            this.pnlUS.Appearance.BackColor = System.Drawing.Color.Gray;
            this.pnlUS.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlUS.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlUS.Appearance.Options.UseBackColor = true;
            this.pnlUS.Appearance.Options.UseBorderColor = true;
            this.pnlUS.Controls.Add(this.grpMixFile);
            this.pnlUS.Controls.Add(this.grpClustering);
            this.pnlUS.Controls.Add(this.grpPreProc);
            this.pnlUS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUS.Location = new System.Drawing.Point(0, 0);
            this.pnlUS.LookAndFeel.SkinMaskColor = System.Drawing.Color.White;
            this.pnlUS.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.White;
            this.pnlUS.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.pnlUS.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlUS.Name = "pnlUS";
            this.pnlUS.Size = new System.Drawing.Size(830, 613);
            this.pnlUS.TabIndex = 1;
            // 
            // grpMixFile
            // 
            this.grpMixFile.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.grpMixFile.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpMixFile.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.grpMixFile.Appearance.Options.UseBackColor = true;
            this.grpMixFile.Appearance.Options.UseFont = true;
            this.grpMixFile.Appearance.Options.UseForeColor = true;
            this.grpMixFile.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpMixFile.AppearanceCaption.Options.UseFont = true;
            this.grpMixFile.Controls.Add(this.txtbCClusteringFile);
            this.grpMixFile.Controls.Add(this.btnCClusteringFile);
            this.grpMixFile.Controls.Add(this.labelControl20);
            this.grpMixFile.Controls.Add(this.btnCLoad);
            this.grpMixFile.Controls.Add(this.btnCSave);
            this.grpMixFile.Location = new System.Drawing.Point(412, 412);
            this.grpMixFile.Name = "grpMixFile";
            this.grpMixFile.Size = new System.Drawing.Size(400, 167);
            this.grpMixFile.TabIndex = 2;
            // 
            // txtbCClusteringFile
            // 
            this.txtbCClusteringFile.Location = new System.Drawing.Point(8, 72);
            this.txtbCClusteringFile.Name = "txtbCClusteringFile";
            this.txtbCClusteringFile.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCClusteringFile.Properties.Appearance.Options.UseFont = true;
            this.txtbCClusteringFile.Size = new System.Drawing.Size(308, 22);
            this.txtbCClusteringFile.StyleController = this.styleMain;
            this.txtbCClusteringFile.TabIndex = 1;
            // 
            // btnCClusteringFile
            // 
            this.btnCClusteringFile.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCClusteringFile.Appearance.Options.UseFont = true;
            this.btnCClusteringFile.Location = new System.Drawing.Point(322, 72);
            this.btnCClusteringFile.Name = "btnCClusteringFile";
            this.btnCClusteringFile.Size = new System.Drawing.Size(46, 23);
            this.btnCClusteringFile.StyleController = this.styleMain;
            this.btnCClusteringFile.TabIndex = 2;
            this.btnCClusteringFile.Text = "...";
            this.btnCClusteringFile.Click += new System.EventHandler(this.btnCClusteringFile_Click);
            // 
            // labelControl20
            // 
            this.labelControl20.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl20.Location = new System.Drawing.Point(8, 39);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(111, 18);
            this.labelControl20.StyleController = this.styleMain;
            this.labelControl20.TabIndex = 0;
            this.labelControl20.Text = "Mix Detector File";
            // 
            // btnCLoad
            // 
            this.btnCLoad.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCLoad.Appearance.Options.UseFont = true;
            this.btnCLoad.Location = new System.Drawing.Point(140, 118);
            this.btnCLoad.Name = "btnCLoad";
            this.btnCLoad.Size = new System.Drawing.Size(81, 34);
            this.btnCLoad.StyleController = this.styleButon;
            this.btnCLoad.TabIndex = 4;
            this.btnCLoad.Text = "Load";
            this.btnCLoad.Click += new System.EventHandler(this.btnCLoad_Click);
            // 
            // btnCSave
            // 
            this.btnCSave.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCSave.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCSave.Appearance.Options.UseBorderColor = true;
            this.btnCSave.Appearance.Options.UseFont = true;
            this.btnCSave.Appearance.Options.UseForeColor = true;
            this.btnCSave.Location = new System.Drawing.Point(8, 118);
            this.btnCSave.Name = "btnCSave";
            this.btnCSave.Size = new System.Drawing.Size(85, 34);
            this.btnCSave.StyleController = this.styleButon;
            this.btnCSave.TabIndex = 3;
            this.btnCSave.Text = "Save";
            this.btnCSave.Click += new System.EventHandler(this.btnCSave_Click);
            // 
            // grpClustering
            // 
            this.grpClustering.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.grpClustering.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpClustering.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.grpClustering.Appearance.Options.UseBackColor = true;
            this.grpClustering.Appearance.Options.UseFont = true;
            this.grpClustering.Appearance.Options.UseForeColor = true;
            this.grpClustering.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpClustering.AppearanceCaption.Options.UseFont = true;
            this.grpClustering.Controls.Add(this.txtbCErrorThresold);
            this.grpClustering.Controls.Add(this.txtbCNumIterator);
            this.grpClustering.Controls.Add(this.txtbCLearningRadius);
            this.grpClustering.Controls.Add(this.txtbCLearningRate);
            this.grpClustering.Controls.Add(this.txtbCNumNeuronY);
            this.grpClustering.Controls.Add(this.txtbCNumInputNeuron);
            this.grpClustering.Controls.Add(this.txtbCNumNeuronX);
            this.grpClustering.Controls.Add(this.btnCStopClustering);
            this.grpClustering.Controls.Add(this.btnCStartClustering);
            this.grpClustering.Controls.Add(this.labelControl21);
            this.grpClustering.Controls.Add(this.labelControl19);
            this.grpClustering.Controls.Add(this.labelControl18);
            this.grpClustering.Controls.Add(this.labelControl14);
            this.grpClustering.Controls.Add(this.labelControl15);
            this.grpClustering.Controls.Add(this.labelControl17);
            this.grpClustering.Controls.Add(this.labelControl16);
            this.grpClustering.Location = new System.Drawing.Point(412, 6);
            this.grpClustering.Name = "grpClustering";
            this.grpClustering.Size = new System.Drawing.Size(400, 400);
            this.grpClustering.TabIndex = 0;
            this.grpClustering.Text = "Clustering";
            // 
            // txtbCErrorThresold
            // 
            this.txtbCErrorThresold.Location = new System.Drawing.Point(140, 311);
            this.txtbCErrorThresold.Name = "txtbCErrorThresold";
            this.txtbCErrorThresold.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCErrorThresold.Properties.Appearance.Options.UseFont = true;
            this.txtbCErrorThresold.Size = new System.Drawing.Size(229, 22);
            this.txtbCErrorThresold.TabIndex = 13;
            // 
            // txtbCNumIterator
            // 
            this.txtbCNumIterator.Location = new System.Drawing.Point(140, 266);
            this.txtbCNumIterator.Name = "txtbCNumIterator";
            this.txtbCNumIterator.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCNumIterator.Properties.Appearance.Options.UseFont = true;
            this.txtbCNumIterator.Size = new System.Drawing.Size(229, 22);
            this.txtbCNumIterator.TabIndex = 11;
            // 
            // txtbCLearningRadius
            // 
            this.txtbCLearningRadius.Location = new System.Drawing.Point(140, 221);
            this.txtbCLearningRadius.Name = "txtbCLearningRadius";
            this.txtbCLearningRadius.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCLearningRadius.Properties.Appearance.Options.UseFont = true;
            this.txtbCLearningRadius.Size = new System.Drawing.Size(229, 22);
            this.txtbCLearningRadius.TabIndex = 9;
            // 
            // txtbCLearningRate
            // 
            this.txtbCLearningRate.EditValue = "";
            this.txtbCLearningRate.Location = new System.Drawing.Point(140, 176);
            this.txtbCLearningRate.Name = "txtbCLearningRate";
            this.txtbCLearningRate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCLearningRate.Properties.Appearance.Options.UseFont = true;
            this.txtbCLearningRate.Size = new System.Drawing.Size(229, 22);
            this.txtbCLearningRate.TabIndex = 7;
            // 
            // txtbCNumNeuronY
            // 
            this.txtbCNumNeuronY.Location = new System.Drawing.Point(140, 131);
            this.txtbCNumNeuronY.Name = "txtbCNumNeuronY";
            this.txtbCNumNeuronY.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCNumNeuronY.Properties.Appearance.Options.UseFont = true;
            this.txtbCNumNeuronY.Size = new System.Drawing.Size(229, 22);
            this.txtbCNumNeuronY.StyleController = this.styleMain;
            this.txtbCNumNeuronY.TabIndex = 5;
            // 
            // txtbCNumInputNeuron
            // 
            this.txtbCNumInputNeuron.Location = new System.Drawing.Point(140, 41);
            this.txtbCNumInputNeuron.Name = "txtbCNumInputNeuron";
            this.txtbCNumInputNeuron.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCNumInputNeuron.Properties.Appearance.Options.UseFont = true;
            this.txtbCNumInputNeuron.Size = new System.Drawing.Size(229, 22);
            this.txtbCNumInputNeuron.TabIndex = 1;
            // 
            // txtbCNumNeuronX
            // 
            this.txtbCNumNeuronX.Location = new System.Drawing.Point(140, 86);
            this.txtbCNumNeuronX.Name = "txtbCNumNeuronX";
            this.txtbCNumNeuronX.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCNumNeuronX.Properties.Appearance.Options.UseFont = true;
            this.txtbCNumNeuronX.Size = new System.Drawing.Size(229, 22);
            this.txtbCNumNeuronX.StyleController = this.styleMain;
            this.txtbCNumNeuronX.TabIndex = 3;
            // 
            // btnCStopClustering
            // 
            this.btnCStopClustering.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCStopClustering.Appearance.Options.UseFont = true;
            this.btnCStopClustering.Location = new System.Drawing.Point(140, 350);
            this.btnCStopClustering.Name = "btnCStopClustering";
            this.btnCStopClustering.Size = new System.Drawing.Size(81, 34);
            this.btnCStopClustering.StyleController = this.styleButon;
            this.btnCStopClustering.TabIndex = 15;
            this.btnCStopClustering.Text = "Stop";
            this.btnCStopClustering.Click += new System.EventHandler(this.btnCStop_Click);
            // 
            // btnCStartClustering
            // 
            this.btnCStartClustering.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCStartClustering.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCStartClustering.Appearance.Options.UseBorderColor = true;
            this.btnCStartClustering.Appearance.Options.UseFont = true;
            this.btnCStartClustering.Appearance.Options.UseForeColor = true;
            this.btnCStartClustering.Location = new System.Drawing.Point(8, 350);
            this.btnCStartClustering.Name = "btnCStartClustering";
            this.btnCStartClustering.Size = new System.Drawing.Size(85, 34);
            this.btnCStartClustering.StyleController = this.styleButon;
            this.btnCStartClustering.TabIndex = 14;
            this.btnCStartClustering.Text = "Start";
            this.btnCStartClustering.Click += new System.EventHandler(this.btnCStartClustering_Click);
            // 
            // labelControl21
            // 
            this.labelControl21.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl21.Location = new System.Drawing.Point(6, 313);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(96, 18);
            this.labelControl21.TabIndex = 12;
            this.labelControl21.Text = "Error Thresold";
            // 
            // labelControl19
            // 
            this.labelControl19.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl19.Location = new System.Drawing.Point(6, 268);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(82, 18);
            this.labelControl19.TabIndex = 10;
            this.labelControl19.Text = "Num Iterator";
            // 
            // labelControl18
            // 
            this.labelControl18.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl18.Location = new System.Drawing.Point(6, 223);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(106, 18);
            this.labelControl18.TabIndex = 8;
            this.labelControl18.Text = "Learning Radius";
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl14.Location = new System.Drawing.Point(6, 178);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(91, 18);
            this.labelControl14.TabIndex = 6;
            this.labelControl14.Text = "Learning Rate";
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl15.Location = new System.Drawing.Point(6, 133);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(98, 18);
            this.labelControl15.StyleController = this.styleMain;
            this.labelControl15.TabIndex = 4;
            this.labelControl15.Text = "Num Neuron Y";
            // 
            // labelControl17
            // 
            this.labelControl17.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl17.Location = new System.Drawing.Point(6, 43);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(128, 18);
            this.labelControl17.TabIndex = 0;
            this.labelControl17.Text = "Numb Input Neuron";
            // 
            // labelControl16
            // 
            this.labelControl16.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl16.Location = new System.Drawing.Point(6, 88);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(99, 18);
            this.labelControl16.StyleController = this.styleMain;
            this.labelControl16.TabIndex = 2;
            this.labelControl16.Text = "Num Neuron X";
            // 
            // grpPreProc
            // 
            this.grpPreProc.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.grpPreProc.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpPreProc.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.grpPreProc.Appearance.Options.UseBackColor = true;
            this.grpPreProc.Appearance.Options.UseFont = true;
            this.grpPreProc.Appearance.Options.UseForeColor = true;
            this.grpPreProc.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpPreProc.AppearanceCaption.Options.UseFont = true;
            this.grpPreProc.Controls.Add(this.txtbCMixDetectorFile);
            this.grpPreProc.Controls.Add(this.btnCMixDetectorFile);
            this.grpPreProc.Controls.Add(this.labelControl13);
            this.grpPreProc.Controls.Add(this.btnCMixDetector);
            this.grpPreProc.Controls.Add(this.cbxCUseRate);
            this.grpPreProc.Controls.Add(this.txtbCBenignSize);
            this.grpPreProc.Controls.Add(this.txtbCVirusSize);
            this.grpPreProc.Controls.Add(this.txtbCBenignVirusRate);
            this.grpPreProc.Controls.Add(this.btnCLoadMixDetector);
            this.grpPreProc.Controls.Add(this.btnCSaveMixDetector);
            this.grpPreProc.Controls.Add(this.labelControl8);
            this.grpPreProc.Controls.Add(this.labelControl11);
            this.grpPreProc.Controls.Add(this.labelControl12);
            this.grpPreProc.Location = new System.Drawing.Point(6, 6);
            this.grpPreProc.Name = "grpPreProc";
            this.grpPreProc.Size = new System.Drawing.Size(400, 400);
            this.grpPreProc.TabIndex = 0;
            this.grpPreProc.Text = "Pre-Process";
            // 
            // txtbCMixDetectorFile
            // 
            this.txtbCMixDetectorFile.Location = new System.Drawing.Point(130, 221);
            this.txtbCMixDetectorFile.Name = "txtbCMixDetectorFile";
            this.txtbCMixDetectorFile.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCMixDetectorFile.Properties.Appearance.Options.UseFont = true;
            this.txtbCMixDetectorFile.Size = new System.Drawing.Size(187, 22);
            this.txtbCMixDetectorFile.StyleController = this.styleMain;
            this.txtbCMixDetectorFile.TabIndex = 9;
            // 
            // btnCMixDetectorFile
            // 
            this.btnCMixDetectorFile.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCMixDetectorFile.Appearance.Options.UseFont = true;
            this.btnCMixDetectorFile.Location = new System.Drawing.Point(323, 221);
            this.btnCMixDetectorFile.Name = "btnCMixDetectorFile";
            this.btnCMixDetectorFile.Size = new System.Drawing.Size(46, 23);
            this.btnCMixDetectorFile.StyleController = this.styleMain;
            this.btnCMixDetectorFile.TabIndex = 10;
            this.btnCMixDetectorFile.Text = "...";
            this.btnCMixDetectorFile.Click += new System.EventHandler(this.btnCMixDetectorFile_Click);
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl13.Location = new System.Drawing.Point(6, 223);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(111, 18);
            this.labelControl13.StyleController = this.styleMain;
            this.labelControl13.TabIndex = 8;
            this.labelControl13.Text = "Mix Detector File";
            // 
            // btnCMixDetector
            // 
            this.btnCMixDetector.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCMixDetector.Appearance.Options.UseFont = true;
            this.btnCMixDetector.Location = new System.Drawing.Point(231, 170);
            this.btnCMixDetector.Name = "btnCMixDetector";
            this.btnCMixDetector.Size = new System.Drawing.Size(138, 34);
            this.btnCMixDetector.StyleController = this.styleButon;
            this.btnCMixDetector.TabIndex = 7;
            this.btnCMixDetector.Text = "Mix Detector";
            this.btnCMixDetector.Click += new System.EventHandler(this.btnCMixDetector_Click);
            // 
            // cbxCUseRate
            // 
            this.cbxCUseRate.Location = new System.Drawing.Point(8, 39);
            this.cbxCUseRate.Name = "cbxCUseRate";
            this.cbxCUseRate.Properties.OffText = "Off";
            this.cbxCUseRate.Properties.OnText = "On";
            this.cbxCUseRate.Size = new System.Drawing.Size(95, 24);
            this.cbxCUseRate.TabIndex = 0;
            // 
            // txtbCBenignSize
            // 
            this.txtbCBenignSize.Location = new System.Drawing.Point(130, 131);
            this.txtbCBenignSize.Name = "txtbCBenignSize";
            this.txtbCBenignSize.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCBenignSize.Properties.Appearance.Options.UseFont = true;
            this.txtbCBenignSize.Size = new System.Drawing.Size(239, 22);
            this.txtbCBenignSize.StyleController = this.styleMain;
            this.txtbCBenignSize.TabIndex = 6;
            // 
            // txtbCVirusSize
            // 
            this.txtbCVirusSize.Location = new System.Drawing.Point(130, 86);
            this.txtbCVirusSize.Name = "txtbCVirusSize";
            this.txtbCVirusSize.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCVirusSize.Properties.Appearance.Options.UseFont = true;
            this.txtbCVirusSize.Size = new System.Drawing.Size(239, 22);
            this.txtbCVirusSize.StyleController = this.styleMain;
            this.txtbCVirusSize.TabIndex = 4;
            // 
            // txtbCBenignVirusRate
            // 
            this.txtbCBenignVirusRate.EditValue = "2";
            this.txtbCBenignVirusRate.Location = new System.Drawing.Point(231, 39);
            this.txtbCBenignVirusRate.Name = "txtbCBenignVirusRate";
            this.txtbCBenignVirusRate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCBenignVirusRate.Properties.Appearance.Options.UseFont = true;
            this.txtbCBenignVirusRate.Size = new System.Drawing.Size(138, 22);
            this.txtbCBenignVirusRate.StyleController = this.styleMain;
            this.txtbCBenignVirusRate.TabIndex = 2;
            // 
            // btnCLoadMixDetector
            // 
            this.btnCLoadMixDetector.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCLoadMixDetector.Appearance.Options.UseFont = true;
            this.btnCLoadMixDetector.Location = new System.Drawing.Point(130, 260);
            this.btnCLoadMixDetector.Name = "btnCLoadMixDetector";
            this.btnCLoadMixDetector.Size = new System.Drawing.Size(81, 34);
            this.btnCLoadMixDetector.StyleController = this.styleButon;
            this.btnCLoadMixDetector.TabIndex = 12;
            this.btnCLoadMixDetector.Text = "Load";
            this.btnCLoadMixDetector.Click += new System.EventHandler(this.btnCLoadMixDetector_Click);
            // 
            // btnCSaveMixDetector
            // 
            this.btnCSaveMixDetector.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCSaveMixDetector.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCSaveMixDetector.Appearance.Options.UseBorderColor = true;
            this.btnCSaveMixDetector.Appearance.Options.UseFont = true;
            this.btnCSaveMixDetector.Appearance.Options.UseForeColor = true;
            this.btnCSaveMixDetector.Location = new System.Drawing.Point(8, 260);
            this.btnCSaveMixDetector.Name = "btnCSaveMixDetector";
            this.btnCSaveMixDetector.Size = new System.Drawing.Size(85, 34);
            this.btnCSaveMixDetector.StyleController = this.styleButon;
            this.btnCSaveMixDetector.TabIndex = 11;
            this.btnCSaveMixDetector.Text = "Save";
            this.btnCSaveMixDetector.Click += new System.EventHandler(this.btnCSaveMixDetector_Click);
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Location = new System.Drawing.Point(6, 133);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(78, 18);
            this.labelControl8.StyleController = this.styleMain;
            this.labelControl8.TabIndex = 5;
            this.labelControl8.Text = "Benign Size";
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl11.Location = new System.Drawing.Point(6, 88);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(66, 18);
            this.labelControl11.StyleController = this.styleMain;
            this.labelControl11.TabIndex = 3;
            this.labelControl11.Text = "Virus Size";
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl12.Location = new System.Drawing.Point(128, 40);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(82, 18);
            this.labelControl12.StyleController = this.styleMain;
            this.labelControl12.TabIndex = 1;
            this.labelControl12.Text = "Benign/Virus";
            // 
            // xtpClusReult
            // 
            this.xtpClusReult.Controls.Add(this.pnlUR);
            this.xtpClusReult.Name = "xtpClusReult";
            this.xtpClusReult.Size = new System.Drawing.Size(830, 613);
            this.xtpClusReult.Text = "UR";
            // 
            // pnlUR
            // 
            this.pnlUR.Appearance.BackColor = System.Drawing.Color.Gray;
            this.pnlUR.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlUR.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlUR.Appearance.Options.UseBackColor = true;
            this.pnlUR.Appearance.Options.UseBorderColor = true;
            this.pnlUR.Controls.Add(this.dangerLevel);
            this.pnlUR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUR.Location = new System.Drawing.Point(0, 0);
            this.pnlUR.LookAndFeel.SkinMaskColor = System.Drawing.Color.White;
            this.pnlUR.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.White;
            this.pnlUR.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.pnlUR.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlUR.Name = "pnlUR";
            this.pnlUR.Size = new System.Drawing.Size(830, 613);
            this.pnlUR.TabIndex = 1;
            // 
            // dangerLevel
            // 
            xyDiagram7.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram7.AxisY.VisibleInPanesSerializable = "-1";
            this.dangerLevel.Diagram = xyDiagram7;
            this.dangerLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dangerLevel.Location = new System.Drawing.Point(3, 3);
            this.dangerLevel.Name = "dangerLevel";
            series7.Name = "dangerLevel";
            this.dangerLevel.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series7};
            this.dangerLevel.Size = new System.Drawing.Size(824, 607);
            this.dangerLevel.TabIndex = 0;
            // 
            // xtpClasSetting
            // 
            this.xtpClasSetting.Controls.Add(this.pnlAS);
            this.xtpClasSetting.Name = "xtpClasSetting";
            this.xtpClasSetting.Size = new System.Drawing.Size(830, 613);
            this.xtpClasSetting.Text = "AS";
            // 
            // pnlAS
            // 
            this.pnlAS.Appearance.BackColor = System.Drawing.Color.Gray;
            this.pnlAS.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlAS.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlAS.Appearance.Options.UseBackColor = true;
            this.pnlAS.Appearance.Options.UseBorderColor = true;
            this.pnlAS.Controls.Add(this.grpASFile);
            this.pnlAS.Controls.Add(this.grpASProc);
            this.pnlAS.Controls.Add(this.grpASPreProc);
            this.pnlAS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAS.Location = new System.Drawing.Point(0, 0);
            this.pnlAS.LookAndFeel.SkinMaskColor = System.Drawing.Color.White;
            this.pnlAS.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.White;
            this.pnlAS.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.pnlAS.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlAS.Name = "pnlAS";
            this.pnlAS.Size = new System.Drawing.Size(830, 613);
            this.pnlAS.TabIndex = 1;
            // 
            // grpASFile
            // 
            this.grpASFile.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.grpASFile.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpASFile.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.grpASFile.Appearance.Options.UseBackColor = true;
            this.grpASFile.Appearance.Options.UseFont = true;
            this.grpASFile.Appearance.Options.UseForeColor = true;
            this.grpASFile.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpASFile.AppearanceCaption.Options.UseFont = true;
            this.grpASFile.Controls.Add(this.txtbFCFileClassifierFile);
            this.grpASFile.Controls.Add(this.btnFCFileClassifierFile);
            this.grpASFile.Controls.Add(this.labelControl25);
            this.grpASFile.Controls.Add(this.btnFCLoad);
            this.grpASFile.Controls.Add(this.btnFCSave);
            this.grpASFile.Location = new System.Drawing.Point(412, 309);
            this.grpASFile.Name = "grpASFile";
            this.grpASFile.Size = new System.Drawing.Size(400, 167);
            this.grpASFile.TabIndex = 3;
            this.grpASFile.Text = "Classifier File";
            // 
            // txtbFCFileClassifierFile
            // 
            this.txtbFCFileClassifierFile.Location = new System.Drawing.Point(8, 72);
            this.txtbFCFileClassifierFile.Name = "txtbFCFileClassifierFile";
            this.txtbFCFileClassifierFile.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbFCFileClassifierFile.Properties.Appearance.Options.UseFont = true;
            this.txtbFCFileClassifierFile.Size = new System.Drawing.Size(333, 22);
            this.txtbFCFileClassifierFile.StyleController = this.styleMain;
            this.txtbFCFileClassifierFile.TabIndex = 1;
            // 
            // btnFCFileClassifierFile
            // 
            this.btnFCFileClassifierFile.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFCFileClassifierFile.Appearance.Options.UseFont = true;
            this.btnFCFileClassifierFile.Location = new System.Drawing.Point(349, 72);
            this.btnFCFileClassifierFile.Name = "btnFCFileClassifierFile";
            this.btnFCFileClassifierFile.Size = new System.Drawing.Size(46, 23);
            this.btnFCFileClassifierFile.StyleController = this.styleMain;
            this.btnFCFileClassifierFile.TabIndex = 2;
            this.btnFCFileClassifierFile.Text = "...";
            this.btnFCFileClassifierFile.Click += new System.EventHandler(this.btnFCFileClassifierFile_Click);
            // 
            // labelControl25
            // 
            this.labelControl25.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl25.Location = new System.Drawing.Point(8, 39);
            this.labelControl25.Name = "labelControl25";
            this.labelControl25.Size = new System.Drawing.Size(88, 18);
            this.labelControl25.StyleController = this.styleMain;
            this.labelControl25.TabIndex = 0;
            this.labelControl25.Text = "Classifier File";
            // 
            // btnFCLoad
            // 
            this.btnFCLoad.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFCLoad.Appearance.Options.UseFont = true;
            this.btnFCLoad.Location = new System.Drawing.Point(140, 118);
            this.btnFCLoad.Name = "btnFCLoad";
            this.btnFCLoad.Size = new System.Drawing.Size(81, 34);
            this.btnFCLoad.StyleController = this.styleButon;
            this.btnFCLoad.TabIndex = 4;
            this.btnFCLoad.Text = "Load";
            this.btnFCLoad.Click += new System.EventHandler(this.btnFCLoad_Click);
            // 
            // btnFCSave
            // 
            this.btnFCSave.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFCSave.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnFCSave.Appearance.Options.UseBorderColor = true;
            this.btnFCSave.Appearance.Options.UseFont = true;
            this.btnFCSave.Appearance.Options.UseForeColor = true;
            this.btnFCSave.Location = new System.Drawing.Point(8, 118);
            this.btnFCSave.Name = "btnFCSave";
            this.btnFCSave.Size = new System.Drawing.Size(85, 34);
            this.btnFCSave.StyleController = this.styleButon;
            this.btnFCSave.TabIndex = 3;
            this.btnFCSave.Text = "Save";
            this.btnFCSave.Click += new System.EventHandler(this.btnFCSave_Click);
            // 
            // grpASProc
            // 
            this.grpASProc.Appearance.BackColor = System.Drawing.Color.Gray;
            this.grpASProc.Appearance.BackColor2 = System.Drawing.Color.Gray;
            this.grpASProc.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpASProc.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.grpASProc.Appearance.Options.UseBackColor = true;
            this.grpASProc.Appearance.Options.UseFont = true;
            this.grpASProc.Appearance.Options.UseForeColor = true;
            this.grpASProc.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpASProc.AppearanceCaption.Options.UseFont = true;
            this.grpASProc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpASProc.Controls.Add(this.txtbCFErrorThresold);
            this.grpASProc.Controls.Add(this.txtbCFNumIterator);
            this.grpASProc.Controls.Add(this.txtbFCNumHiddenNeuron);
            this.grpASProc.Controls.Add(this.txtbCFNumOutputNeuron);
            this.grpASProc.Controls.Add(this.labelControl29);
            this.grpASProc.Controls.Add(this.labelControl30);
            this.grpASProc.Controls.Add(this.labelControl31);
            this.grpASProc.Controls.Add(this.labelControl32);
            this.grpASProc.Controls.Add(this.btnFCStop);
            this.grpASProc.Controls.Add(this.btnFCStartFileClassifier);
            this.grpASProc.Location = new System.Drawing.Point(412, 3);
            this.grpASProc.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpASProc.Name = "grpASProc";
            this.grpASProc.Size = new System.Drawing.Size(400, 300);
            this.grpASProc.TabIndex = 2;
            this.grpASProc.Text = "Processer";
            // 
            // txtbCFErrorThresold
            // 
            this.txtbCFErrorThresold.EditValue = "";
            this.txtbCFErrorThresold.Location = new System.Drawing.Point(139, 198);
            this.txtbCFErrorThresold.Name = "txtbCFErrorThresold";
            this.txtbCFErrorThresold.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCFErrorThresold.Properties.Appearance.Options.UseFont = true;
            this.txtbCFErrorThresold.Size = new System.Drawing.Size(247, 22);
            this.txtbCFErrorThresold.TabIndex = 19;
            // 
            // txtbCFNumIterator
            // 
            this.txtbCFNumIterator.Location = new System.Drawing.Point(139, 144);
            this.txtbCFNumIterator.Name = "txtbCFNumIterator";
            this.txtbCFNumIterator.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCFNumIterator.Properties.Appearance.Options.UseFont = true;
            this.txtbCFNumIterator.Size = new System.Drawing.Size(247, 22);
            this.txtbCFNumIterator.StyleController = this.styleMain;
            this.txtbCFNumIterator.TabIndex = 17;
            // 
            // txtbFCNumHiddenNeuron
            // 
            this.txtbFCNumHiddenNeuron.Location = new System.Drawing.Point(139, 36);
            this.txtbFCNumHiddenNeuron.Name = "txtbFCNumHiddenNeuron";
            this.txtbFCNumHiddenNeuron.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbFCNumHiddenNeuron.Properties.Appearance.Options.UseFont = true;
            this.txtbFCNumHiddenNeuron.Size = new System.Drawing.Size(247, 22);
            this.txtbFCNumHiddenNeuron.TabIndex = 13;
            // 
            // txtbCFNumOutputNeuron
            // 
            this.txtbCFNumOutputNeuron.Location = new System.Drawing.Point(139, 90);
            this.txtbCFNumOutputNeuron.Name = "txtbCFNumOutputNeuron";
            this.txtbCFNumOutputNeuron.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCFNumOutputNeuron.Properties.Appearance.Options.UseFont = true;
            this.txtbCFNumOutputNeuron.Size = new System.Drawing.Size(247, 22);
            this.txtbCFNumOutputNeuron.StyleController = this.styleMain;
            this.txtbCFNumOutputNeuron.TabIndex = 15;
            // 
            // labelControl29
            // 
            this.labelControl29.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl29.Location = new System.Drawing.Point(5, 200);
            this.labelControl29.Name = "labelControl29";
            this.labelControl29.Size = new System.Drawing.Size(96, 18);
            this.labelControl29.TabIndex = 18;
            this.labelControl29.Text = "Error Thresold";
            // 
            // labelControl30
            // 
            this.labelControl30.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl30.Location = new System.Drawing.Point(5, 146);
            this.labelControl30.Name = "labelControl30";
            this.labelControl30.Size = new System.Drawing.Size(82, 18);
            this.labelControl30.StyleController = this.styleMain;
            this.labelControl30.TabIndex = 16;
            this.labelControl30.Text = "Num Iterator";
            // 
            // labelControl31
            // 
            this.labelControl31.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl31.Location = new System.Drawing.Point(5, 38);
            this.labelControl31.Name = "labelControl31";
            this.labelControl31.Size = new System.Drawing.Size(135, 18);
            this.labelControl31.TabIndex = 12;
            this.labelControl31.Text = "Num Hidden Neuron";
            // 
            // labelControl32
            // 
            this.labelControl32.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl32.Location = new System.Drawing.Point(5, 92);
            this.labelControl32.Name = "labelControl32";
            this.labelControl32.Size = new System.Drawing.Size(133, 18);
            this.labelControl32.StyleController = this.styleMain;
            this.labelControl32.TabIndex = 14;
            this.labelControl32.Text = "Num Output Neuron";
            // 
            // btnFCStop
            // 
            this.btnFCStop.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFCStop.Appearance.Options.UseFont = true;
            this.btnFCStop.Location = new System.Drawing.Point(121, 242);
            this.btnFCStop.Name = "btnFCStop";
            this.btnFCStop.Size = new System.Drawing.Size(81, 34);
            this.btnFCStop.StyleController = this.styleButon;
            this.btnFCStop.TabIndex = 11;
            this.btnFCStop.Text = "Stop";
            this.btnFCStop.Click += new System.EventHandler(this.btnFCStop_Click);
            // 
            // btnFCStartFileClassifier
            // 
            this.btnFCStartFileClassifier.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFCStartFileClassifier.Appearance.Options.UseFont = true;
            this.btnFCStartFileClassifier.Location = new System.Drawing.Point(5, 242);
            this.btnFCStartFileClassifier.Name = "btnFCStartFileClassifier";
            this.btnFCStartFileClassifier.Size = new System.Drawing.Size(85, 34);
            this.btnFCStartFileClassifier.StyleController = this.styleButon;
            this.btnFCStartFileClassifier.TabIndex = 10;
            this.btnFCStartFileClassifier.Text = "Start";
            this.btnFCStartFileClassifier.Click += new System.EventHandler(this.btnFCStartFileClassifier_Click);
            // 
            // grpASPreProc
            // 
            this.grpASPreProc.Appearance.BackColor = System.Drawing.Color.Gray;
            this.grpASPreProc.Appearance.BackColor2 = System.Drawing.Color.Gray;
            this.grpASPreProc.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpASPreProc.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.grpASPreProc.Appearance.Options.UseBackColor = true;
            this.grpASPreProc.Appearance.Options.UseFont = true;
            this.grpASPreProc.Appearance.Options.UseForeColor = true;
            this.grpASPreProc.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpASPreProc.AppearanceCaption.Options.UseFont = true;
            this.grpASPreProc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpASPreProc.Controls.Add(this.txtbCFFormatRange);
            this.grpASPreProc.Controls.Add(this.txtbFCBenignFolder);
            this.grpASPreProc.Controls.Add(this.txtbFCVirusFolder);
            this.grpASPreProc.Controls.Add(this.btnFCBenignFolder);
            this.grpASPreProc.Controls.Add(this.btnFCPreprocesser);
            this.grpASPreProc.Controls.Add(this.btnFCVirusFolder);
            this.grpASPreProc.Controls.Add(this.labelControl22);
            this.grpASPreProc.Controls.Add(this.labelControl23);
            this.grpASPreProc.Controls.Add(this.labelControl24);
            this.grpASPreProc.Location = new System.Drawing.Point(6, 3);
            this.grpASPreProc.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpASPreProc.Name = "grpASPreProc";
            this.grpASPreProc.Size = new System.Drawing.Size(400, 300);
            this.grpASPreProc.TabIndex = 1;
            this.grpASPreProc.Text = "Preprocesser";
            // 
            // txtbCFFormatRange
            // 
            this.txtbCFFormatRange.Location = new System.Drawing.Point(6, 200);
            this.txtbCFFormatRange.Name = "txtbCFFormatRange";
            this.txtbCFFormatRange.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCFFormatRange.Properties.Appearance.Options.UseFont = true;
            this.txtbCFFormatRange.Size = new System.Drawing.Size(337, 22);
            this.txtbCFFormatRange.StyleController = this.styleMain;
            this.txtbCFFormatRange.TabIndex = 7;
            // 
            // txtbFCBenignFolder
            // 
            this.txtbFCBenignFolder.Location = new System.Drawing.Point(6, 129);
            this.txtbFCBenignFolder.Name = "txtbFCBenignFolder";
            this.txtbFCBenignFolder.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbFCBenignFolder.Properties.Appearance.Options.UseFont = true;
            this.txtbFCBenignFolder.Size = new System.Drawing.Size(337, 22);
            this.txtbFCBenignFolder.StyleController = this.styleMain;
            this.txtbFCBenignFolder.TabIndex = 4;
            // 
            // txtbFCVirusFolder
            // 
            this.txtbFCVirusFolder.Location = new System.Drawing.Point(6, 65);
            this.txtbFCVirusFolder.Name = "txtbFCVirusFolder";
            this.txtbFCVirusFolder.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbFCVirusFolder.Properties.Appearance.Options.UseFont = true;
            this.txtbFCVirusFolder.Size = new System.Drawing.Size(337, 22);
            this.txtbFCVirusFolder.StyleController = this.styleMain;
            this.txtbFCVirusFolder.TabIndex = 1;
            // 
            // btnFCBenignFolder
            // 
            this.btnFCBenignFolder.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFCBenignFolder.Appearance.Options.UseFont = true;
            this.btnFCBenignFolder.Location = new System.Drawing.Point(349, 129);
            this.btnFCBenignFolder.Name = "btnFCBenignFolder";
            this.btnFCBenignFolder.Size = new System.Drawing.Size(46, 23);
            this.btnFCBenignFolder.StyleController = this.styleMain;
            this.btnFCBenignFolder.TabIndex = 5;
            this.btnFCBenignFolder.Text = "...";
            this.btnFCBenignFolder.Click += new System.EventHandler(this.btnFCBenignFolder_Click);
            // 
            // btnFCPreprocesser
            // 
            this.btnFCPreprocesser.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFCPreprocesser.Appearance.Options.UseFont = true;
            this.btnFCPreprocesser.Location = new System.Drawing.Point(5, 242);
            this.btnFCPreprocesser.Name = "btnFCPreprocesser";
            this.btnFCPreprocesser.Size = new System.Drawing.Size(133, 34);
            this.btnFCPreprocesser.StyleController = this.styleButon;
            this.btnFCPreprocesser.TabIndex = 10;
            this.btnFCPreprocesser.Text = "Preprocesser";
            this.btnFCPreprocesser.Click += new System.EventHandler(this.btnFCPreprocesser_Click);
            // 
            // btnFCVirusFolder
            // 
            this.btnFCVirusFolder.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFCVirusFolder.Appearance.Options.UseFont = true;
            this.btnFCVirusFolder.Location = new System.Drawing.Point(349, 65);
            this.btnFCVirusFolder.Name = "btnFCVirusFolder";
            this.btnFCVirusFolder.Size = new System.Drawing.Size(46, 23);
            this.btnFCVirusFolder.StyleController = this.styleMain;
            this.btnFCVirusFolder.TabIndex = 2;
            this.btnFCVirusFolder.Text = "...";
            this.btnFCVirusFolder.Click += new System.EventHandler(this.btnFCVirusFolder_Click);
            // 
            // labelControl22
            // 
            this.labelControl22.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl22.Location = new System.Drawing.Point(6, 167);
            this.labelControl22.Name = "labelControl22";
            this.labelControl22.Size = new System.Drawing.Size(95, 18);
            this.labelControl22.StyleController = this.styleMain;
            this.labelControl22.TabIndex = 6;
            this.labelControl22.Text = "Format Range";
            // 
            // labelControl23
            // 
            this.labelControl23.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl23.Location = new System.Drawing.Point(6, 103);
            this.labelControl23.Name = "labelControl23";
            this.labelControl23.Size = new System.Drawing.Size(117, 18);
            this.labelControl23.StyleController = this.styleMain;
            this.labelControl23.TabIndex = 3;
            this.labelControl23.Text = "Benign Dicrectory";
            // 
            // labelControl24
            // 
            this.labelControl24.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl24.Location = new System.Drawing.Point(6, 41);
            this.labelControl24.Name = "labelControl24";
            this.labelControl24.Size = new System.Drawing.Size(97, 18);
            this.labelControl24.StyleController = this.styleMain;
            this.labelControl24.TabIndex = 0;
            this.labelControl24.Text = "Virus Directory";
            // 
            // xtpClassReult
            // 
            this.xtpClassReult.Controls.Add(this.pnlAR);
            this.xtpClassReult.Name = "xtpClassReult";
            this.xtpClassReult.Size = new System.Drawing.Size(830, 613);
            this.xtpClassReult.Text = "AR";
            // 
            // pnlAR
            // 
            this.pnlAR.Appearance.BackColor = System.Drawing.Color.Gray;
            this.pnlAR.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlAR.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlAR.Appearance.Options.UseBackColor = true;
            this.pnlAR.Appearance.Options.UseBorderColor = true;
            this.pnlAR.Controls.Add(this.chartFC);
            this.pnlAR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAR.Location = new System.Drawing.Point(0, 0);
            this.pnlAR.LookAndFeel.SkinMaskColor = System.Drawing.Color.White;
            this.pnlAR.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.White;
            this.pnlAR.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.pnlAR.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlAR.Name = "pnlAR";
            this.pnlAR.Size = new System.Drawing.Size(830, 613);
            this.pnlAR.TabIndex = 1;
            // 
            // chartFC
            // 
            xyDiagram8.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram8.AxisY.VisibleInPanesSerializable = "-1";
            this.chartFC.Diagram = xyDiagram8;
            this.chartFC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartFC.Location = new System.Drawing.Point(3, 3);
            this.chartFC.Name = "chartFC";
            series8.Name = "chartFC";
            series8.View = pointSeriesView4;
            this.chartFC.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series8};
            this.chartFC.Size = new System.Drawing.Size(824, 607);
            this.chartFC.TabIndex = 0;
            // 
            // xtpScan
            // 
            this.xtpScan.Controls.Add(this.pnlScan);
            this.xtpScan.Name = "xtpScan";
            this.xtpScan.Size = new System.Drawing.Size(830, 613);
            this.xtpScan.Text = "Scan";
            // 
            // pnlScan
            // 
            this.pnlScan.Appearance.BackColor = System.Drawing.Color.Gray;
            this.pnlScan.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlScan.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlScan.Appearance.Options.UseBackColor = true;
            this.pnlScan.Appearance.Options.UseBorderColor = true;
            this.pnlScan.Controls.Add(this.grpScanResult);
            this.pnlScan.Controls.Add(this.grpScan);
            this.pnlScan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScan.Location = new System.Drawing.Point(0, 0);
            this.pnlScan.LookAndFeel.SkinMaskColor = System.Drawing.Color.White;
            this.pnlScan.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.White;
            this.pnlScan.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.pnlScan.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlScan.Name = "pnlScan";
            this.pnlScan.Size = new System.Drawing.Size(830, 613);
            this.pnlScan.TabIndex = 1;
            // 
            // grpScanResult
            // 
            this.grpScanResult.Appearance.BackColor = System.Drawing.Color.Gray;
            this.grpScanResult.Appearance.BackColor2 = System.Drawing.Color.Gray;
            this.grpScanResult.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpScanResult.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.grpScanResult.Appearance.Options.UseBackColor = true;
            this.grpScanResult.Appearance.Options.UseFont = true;
            this.grpScanResult.Appearance.Options.UseForeColor = true;
            this.grpScanResult.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpScanResult.AppearanceCaption.Options.UseFont = true;
            this.grpScanResult.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpScanResult.Controls.Add(this.txtbFCNumVirus);
            this.grpScanResult.Controls.Add(this.txtbFCNumBenign);
            this.grpScanResult.Controls.Add(this.labelControl33);
            this.grpScanResult.Controls.Add(this.labelControl34);
            this.grpScanResult.Location = new System.Drawing.Point(6, 179);
            this.grpScanResult.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpScanResult.Name = "grpScanResult";
            this.grpScanResult.Size = new System.Drawing.Size(400, 133);
            this.grpScanResult.TabIndex = 5;
            this.grpScanResult.Text = "Result";
            // 
            // txtbFCNumVirus
            // 
            this.txtbFCNumVirus.Location = new System.Drawing.Point(139, 36);
            this.txtbFCNumVirus.Name = "txtbFCNumVirus";
            this.txtbFCNumVirus.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbFCNumVirus.Properties.Appearance.Options.UseFont = true;
            this.txtbFCNumVirus.Size = new System.Drawing.Size(247, 22);
            this.txtbFCNumVirus.TabIndex = 13;
            // 
            // txtbFCNumBenign
            // 
            this.txtbFCNumBenign.Location = new System.Drawing.Point(139, 90);
            this.txtbFCNumBenign.Name = "txtbFCNumBenign";
            this.txtbFCNumBenign.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbFCNumBenign.Properties.Appearance.Options.UseFont = true;
            this.txtbFCNumBenign.Size = new System.Drawing.Size(247, 22);
            this.txtbFCNumBenign.StyleController = this.styleMain;
            this.txtbFCNumBenign.TabIndex = 15;
            // 
            // labelControl33
            // 
            this.labelControl33.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl33.Location = new System.Drawing.Point(5, 38);
            this.labelControl33.Name = "labelControl33";
            this.labelControl33.Size = new System.Drawing.Size(69, 18);
            this.labelControl33.TabIndex = 12;
            this.labelControl33.Text = "Num Virus";
            // 
            // labelControl34
            // 
            this.labelControl34.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl34.Location = new System.Drawing.Point(5, 92);
            this.labelControl34.Name = "labelControl34";
            this.labelControl34.Size = new System.Drawing.Size(81, 18);
            this.labelControl34.StyleController = this.styleMain;
            this.labelControl34.TabIndex = 14;
            this.labelControl34.Text = "Num Benign";
            // 
            // grpScan
            // 
            this.grpScan.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.grpScan.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpScan.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.grpScan.Appearance.Options.UseBackColor = true;
            this.grpScan.Appearance.Options.UseFont = true;
            this.grpScan.Appearance.Options.UseForeColor = true;
            this.grpScan.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpScan.AppearanceCaption.Options.UseFont = true;
            this.grpScan.Controls.Add(this.txtbVSTestFolder);
            this.grpScan.Controls.Add(this.btnFCTestFolder);
            this.grpScan.Controls.Add(this.labelControl26);
            this.grpScan.Controls.Add(this.btnVSStop);
            this.grpScan.Controls.Add(this.btnFCScanVirus);
            this.grpScan.Location = new System.Drawing.Point(6, 6);
            this.grpScan.Name = "grpScan";
            this.grpScan.Size = new System.Drawing.Size(400, 167);
            this.grpScan.TabIndex = 4;
            // 
            // txtbVSTestFolder
            // 
            this.txtbVSTestFolder.Location = new System.Drawing.Point(8, 72);
            this.txtbVSTestFolder.Name = "txtbVSTestFolder";
            this.txtbVSTestFolder.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbVSTestFolder.Properties.Appearance.Options.UseFont = true;
            this.txtbVSTestFolder.Size = new System.Drawing.Size(333, 22);
            this.txtbVSTestFolder.StyleController = this.styleMain;
            this.txtbVSTestFolder.TabIndex = 1;
            // 
            // btnFCTestFolder
            // 
            this.btnFCTestFolder.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFCTestFolder.Appearance.Options.UseFont = true;
            this.btnFCTestFolder.Location = new System.Drawing.Point(349, 72);
            this.btnFCTestFolder.Name = "btnFCTestFolder";
            this.btnFCTestFolder.Size = new System.Drawing.Size(46, 23);
            this.btnFCTestFolder.StyleController = this.styleMain;
            this.btnFCTestFolder.TabIndex = 2;
            this.btnFCTestFolder.Text = "...";
            this.btnFCTestFolder.Click += new System.EventHandler(this.btnTestFolder_Click);
            // 
            // labelControl26
            // 
            this.labelControl26.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl26.Location = new System.Drawing.Point(8, 39);
            this.labelControl26.Name = "labelControl26";
            this.labelControl26.Size = new System.Drawing.Size(75, 18);
            this.labelControl26.StyleController = this.styleMain;
            this.labelControl26.TabIndex = 0;
            this.labelControl26.Text = "Test Folder";
            // 
            // btnVSStop
            // 
            this.btnVSStop.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVSStop.Appearance.Options.UseFont = true;
            this.btnVSStop.Location = new System.Drawing.Point(140, 118);
            this.btnVSStop.Name = "btnVSStop";
            this.btnVSStop.Size = new System.Drawing.Size(81, 34);
            this.btnVSStop.StyleController = this.styleButon;
            this.btnVSStop.TabIndex = 4;
            this.btnVSStop.Text = "Stop";
            this.btnVSStop.Click += new System.EventHandler(this.btnVSStop_Click);
            // 
            // btnFCScanVirus
            // 
            this.btnFCScanVirus.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFCScanVirus.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnFCScanVirus.Appearance.Options.UseBorderColor = true;
            this.btnFCScanVirus.Appearance.Options.UseFont = true;
            this.btnFCScanVirus.Appearance.Options.UseForeColor = true;
            this.btnFCScanVirus.Location = new System.Drawing.Point(8, 118);
            this.btnFCScanVirus.Name = "btnFCScanVirus";
            this.btnFCScanVirus.Size = new System.Drawing.Size(85, 34);
            this.btnFCScanVirus.StyleController = this.styleButon;
            this.btnFCScanVirus.TabIndex = 3;
            this.btnFCScanVirus.Text = "Start";
            this.btnFCScanVirus.Click += new System.EventHandler(this.btnScanVirus_Click);
            // 
            // xtpScanRs
            // 
            this.xtpScanRs.Controls.Add(this.panelControl1);
            this.xtpScanRs.Name = "xtpScanRs";
            this.xtpScanRs.Size = new System.Drawing.Size(830, 613);
            this.xtpScanRs.Text = "ScanRS";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Gray;
            this.panelControl1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelControl1.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Appearance.Options.UseBorderColor = true;
            this.panelControl1.Controls.Add(this.dgvVirus);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.LookAndFeel.SkinMaskColor = System.Drawing.Color.White;
            this.panelControl1.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.White;
            this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(830, 613);
            this.panelControl1.TabIndex = 2;
            // 
            // dgvVirus
            // 
            this.dgvVirus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVirus.Location = new System.Drawing.Point(3, 3);
            this.dgvVirus.MainView = this.gridView1;
            this.dgvVirus.Name = "dgvVirus";
            this.dgvVirus.Size = new System.Drawing.Size(824, 607);
            this.dgvVirus.TabIndex = 0;
            this.dgvVirus.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.dgvVirus;
            this.gridView1.Name = "gridView1";
            // 
            // xtpAbout
            // 
            this.xtpAbout.Name = "xtpAbout";
            this.xtpAbout.Size = new System.Drawing.Size(830, 613);
            this.xtpAbout.Text = "About";
            // 
            // imcNavIcon
            // 
            this.imcNavIcon.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imcNavIcon.ImageStream")));
            this.imcNavIcon.Images.SetKeyName(0, "1465515724_Information.png");
            this.imcNavIcon.Images.SetKeyName(1, "1465515696_close_blue.png");
            this.imcNavIcon.Images.SetKeyName(2, "setting.png");
            this.imcNavIcon.Images.SetKeyName(3, "icon-results.png");
            // 
            // _timer
            // 
            this._timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1024, 700);
            this.Controls.Add(this.splitContainerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Virus Detector";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelFooter)).EndInit();
            this.panelFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatusBar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtcContent)).EndInit();
            this.xtcContent.ResumeLayout(false);
            this.xtpDeSetting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlDS)).EndInit();
            this.pnlDS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpOutput)).EndInit();
            this.grpOutput.ResumeLayout(false);
            this.grpOutput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbDBenignFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbDDetectorFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleButon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpParam)).EndInit();
            this.grpParam.ResumeLayout(false);
            this.grpParam.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxDRContinuous.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxDHamming.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbDContinuous.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbDHamming.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDStepSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDLength.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpInput)).EndInit();
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbDAdditionFolder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbDBenignFolder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbDVirusFolder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnDBuildAddDetector.Properties)).EndInit();
            this.xtpDeResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlDR)).EndInit();
            this.pnlDR.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtNegativeSelection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.xtpClusSetting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlUS)).EndInit();
            this.pnlUS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpMixFile)).EndInit();
            this.grpMixFile.ResumeLayout(false);
            this.grpMixFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCClusteringFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpClustering)).EndInit();
            this.grpClustering.ResumeLayout(false);
            this.grpClustering.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCErrorThresold.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCNumIterator.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCLearningRadius.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCLearningRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCNumNeuronY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCNumInputNeuron.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCNumNeuronX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPreProc)).EndInit();
            this.grpPreProc.ResumeLayout(false);
            this.grpPreProc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCMixDetectorFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxCUseRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCBenignSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCVirusSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCBenignVirusRate.Properties)).EndInit();
            this.xtpClusReult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlUR)).EndInit();
            this.pnlUR.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dangerLevel)).EndInit();
            this.xtpClasSetting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlAS)).EndInit();
            this.pnlAS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpASFile)).EndInit();
            this.grpASFile.ResumeLayout(false);
            this.grpASFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbFCFileClassifierFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpASProc)).EndInit();
            this.grpASProc.ResumeLayout(false);
            this.grpASProc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCFErrorThresold.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCFNumIterator.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbFCNumHiddenNeuron.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCFNumOutputNeuron.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpASPreProc)).EndInit();
            this.grpASPreProc.ResumeLayout(false);
            this.grpASPreProc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbCFFormatRange.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbFCBenignFolder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbFCVirusFolder.Properties)).EndInit();
            this.xtpClassReult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlAR)).EndInit();
            this.pnlAR.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartFC)).EndInit();
            this.xtpScan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlScan)).EndInit();
            this.pnlScan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpScanResult)).EndInit();
            this.grpScanResult.ResumeLayout(false);
            this.grpScanResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbFCNumVirus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbFCNumBenign.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpScan)).EndInit();
            this.grpScan.ResumeLayout(false);
            this.grpScan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbVSTestFolder.Properties)).EndInit();
            this.xtpScanRs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVirus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imcNavIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.Utils.ImageCollection imcNavIcon;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navClustering;
        private DevExpress.XtraNavBar.NavBarGroup navClassifier;
        private DevExpress.XtraNavBar.NavBarGroup navDetection;
        private DevExpress.XtraNavBar.NavBarGroup navHome;
        private DevExpress.XtraNavBar.NavBarItem navAbout;
        private DevExpress.XtraNavBar.NavBarItem navExit;
        private DevExpress.XtraNavBar.NavBarItem navCluSetting;
        private DevExpress.XtraNavBar.NavBarItem navClusResult;
        private DevExpress.XtraNavBar.NavBarItem navClaSetting;
        private DevExpress.XtraNavBar.NavBarItem navClaResult;
        private DevExpress.XtraNavBar.NavBarItem navScan;
        private DevExpress.XtraNavBar.NavBarGroup navDectector;
        private DevExpress.XtraNavBar.NavBarItem navDecSetting;
        private DevExpress.XtraNavBar.NavBarItem navDecResult;
        private DevExpress.XtraTab.XtraTabControl xtcContent;
        private DevExpress.XtraTab.XtraTabPage xtpDeSetting;
        private DevExpress.XtraTab.XtraTabPage xtpDeResult;
        private DevExpress.XtraTab.XtraTabPage xtpClusSetting;
        private DevExpress.XtraTab.XtraTabPage xtpClusReult;
        private DevExpress.XtraTab.XtraTabPage xtpClasSetting;
        private DevExpress.XtraTab.XtraTabPage xtpClassReult;
        private DevExpress.XtraTab.XtraTabPage xtpScan;
        private DevExpress.XtraEditors.PanelControl pnlDS;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraEditors.PanelControl pnlDR;
        private DevExpress.XtraEditors.PanelControl pnlUS;
        private DevExpress.XtraEditors.PanelControl pnlUR;
        private DevExpress.XtraEditors.PanelControl pnlAS;
        private DevExpress.XtraEditors.PanelControl pnlAR;
        private DevExpress.XtraEditors.PanelControl pnlScan;
        private DevExpress.XtraEditors.GroupControl grpInput;
        private DevExpress.XtraEditors.SimpleButton btnDVirusFolder;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.RadioGroup rbtnDBuildAddDetector;
        private DevExpress.XtraEditors.SimpleButton btnDAdditionFolder;
        private DevExpress.XtraEditors.SimpleButton btnDBenignFolder;
        private DevExpress.XtraEditors.SimpleButton btnDStop;
        private DevExpress.XtraEditors.SimpleButton btnDStart;
        private DevExpress.XtraEditors.TextEdit txtbDAdditionFolder;
        private DevExpress.XtraEditors.StyleController styleMain;
        private DevExpress.XtraEditors.TextEdit txtbDBenignFolder;
        private DevExpress.XtraEditors.TextEdit txtbDVirusFolder;
        private DevExpress.XtraEditors.GroupControl grpParam;
        private DevExpress.XtraEditors.TextEdit txtbDHamming;
        private DevExpress.XtraEditors.TextEdit txtDStepSize;
        private DevExpress.XtraEditors.TextEdit txtDLength;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.GroupControl grpOutput;
        private DevExpress.XtraEditors.TextEdit txtbDBenignFile;
        private DevExpress.XtraEditors.TextEdit txtbDDetectorFile;
        private DevExpress.XtraEditors.SimpleButton btnDBenignFile;
        private DevExpress.XtraEditors.SimpleButton btnDLoadDetector;
        private DevExpress.XtraEditors.SimpleButton btnDSaveDetector;
        private DevExpress.XtraEditors.SimpleButton btnDDetectorFile;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.ToggleSwitch cbxDRContinuous;
        private DevExpress.XtraEditors.ToggleSwitch cbxDHamming;
        private DevExpress.XtraEditors.TextEdit txtbDContinuous;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.StyleController styleButon;
        private DevExpress.XtraEditors.GroupControl grpPreProc;
        private DevExpress.XtraEditors.TextEdit txtbCMixDetectorFile;
        private DevExpress.XtraEditors.SimpleButton btnCMixDetectorFile;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.SimpleButton btnCMixDetector;
        private DevExpress.XtraEditors.ToggleSwitch cbxCUseRate;
        private DevExpress.XtraEditors.TextEdit txtbCBenignSize;
        private DevExpress.XtraEditors.TextEdit txtbCVirusSize;
        private DevExpress.XtraEditors.TextEdit txtbCBenignVirusRate;
        private DevExpress.XtraEditors.SimpleButton btnCLoadMixDetector;
        private DevExpress.XtraEditors.SimpleButton btnCSaveMixDetector;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.GroupControl grpClustering;
        private DevExpress.XtraEditors.TextEdit txtbCNumIterator;
        private DevExpress.XtraEditors.TextEdit txtbCLearningRadius;
        private DevExpress.XtraEditors.TextEdit txtbCLearningRate;
        private DevExpress.XtraEditors.TextEdit txtbCNumNeuronY;
        private DevExpress.XtraEditors.TextEdit txtbCNumInputNeuron;
        private DevExpress.XtraEditors.TextEdit txtbCNumNeuronX;
        private DevExpress.XtraEditors.SimpleButton btnCStopClustering;
        private DevExpress.XtraEditors.SimpleButton btnCStartClustering;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.GroupControl grpMixFile;
        private DevExpress.XtraEditors.TextEdit txtbCClusteringFile;
        private DevExpress.XtraEditors.SimpleButton btnCClusteringFile;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        private DevExpress.XtraEditors.SimpleButton btnCLoad;
        private DevExpress.XtraEditors.SimpleButton btnCSave;
        private DevExpress.XtraEditors.TextEdit txtbCErrorThresold;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraEditors.GroupControl grpASPreProc;
        private DevExpress.XtraEditors.TextEdit txtbCFFormatRange;
        private DevExpress.XtraEditors.TextEdit txtbFCBenignFolder;
        private DevExpress.XtraEditors.TextEdit txtbFCVirusFolder;
        private DevExpress.XtraEditors.SimpleButton btnFCBenignFolder;
        private DevExpress.XtraEditors.SimpleButton btnFCVirusFolder;
        private DevExpress.XtraEditors.LabelControl labelControl22;
        private DevExpress.XtraEditors.LabelControl labelControl23;
        private DevExpress.XtraEditors.LabelControl labelControl24;
        private DevExpress.XtraEditors.SimpleButton btnFCPreprocesser;
        private DevExpress.XtraEditors.GroupControl grpASProc;
        private DevExpress.XtraEditors.TextEdit txtbCFErrorThresold;
        private DevExpress.XtraEditors.TextEdit txtbCFNumIterator;
        private DevExpress.XtraEditors.TextEdit txtbFCNumHiddenNeuron;
        private DevExpress.XtraEditors.TextEdit txtbCFNumOutputNeuron;
        private DevExpress.XtraEditors.LabelControl labelControl29;
        private DevExpress.XtraEditors.LabelControl labelControl30;
        private DevExpress.XtraEditors.LabelControl labelControl31;
        private DevExpress.XtraEditors.LabelControl labelControl32;
        private DevExpress.XtraEditors.SimpleButton btnFCStop;
        private DevExpress.XtraEditors.SimpleButton btnFCStartFileClassifier;
        private DevExpress.XtraEditors.GroupControl grpASFile;
        private DevExpress.XtraEditors.TextEdit txtbFCFileClassifierFile;
        private DevExpress.XtraEditors.SimpleButton btnFCFileClassifierFile;
        private DevExpress.XtraEditors.LabelControl labelControl25;
        private DevExpress.XtraEditors.SimpleButton btnFCLoad;
        private DevExpress.XtraEditors.SimpleButton btnFCSave;
        private DevExpress.XtraEditors.GroupControl grpScanResult;
        private DevExpress.XtraEditors.TextEdit txtbFCNumVirus;
        private DevExpress.XtraEditors.TextEdit txtbFCNumBenign;
        private DevExpress.XtraEditors.LabelControl labelControl33;
        private DevExpress.XtraEditors.LabelControl labelControl34;
        private DevExpress.XtraEditors.GroupControl grpScan;
        private DevExpress.XtraEditors.TextEdit txtbVSTestFolder;
        private DevExpress.XtraEditors.SimpleButton btnFCTestFolder;
        private DevExpress.XtraEditors.LabelControl labelControl26;
        private DevExpress.XtraEditors.SimpleButton btnVSStop;
        private DevExpress.XtraEditors.SimpleButton btnFCScanVirus;
        private DevExpress.XtraNavBar.NavBarItem navScanResult;
        private DevExpress.XtraCharts.ChartControl dangerLevel;
        private DevExpress.XtraCharts.ChartControl chartFC;
        private DevExpress.XtraTab.XtraTabPage xtpScanRs;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl dgvVirus;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraGrid.GridControl dtNegativeSelection;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraTab.XtraTabPage xtpAbout;
        private System.Windows.Forms.Timer _timer;
        private DevExpress.XtraEditors.PanelControl panelFooter;
        private DevExpress.XtraEditors.ProgressBarControl progressBar;
        private DevExpress.XtraEditors.TextEdit txtStatusBar;
        private DevExpress.XtraEditors.TextEdit txtTimeBox;
    }
}

