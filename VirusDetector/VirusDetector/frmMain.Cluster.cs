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
using DevExpress.XtraCharts;

namespace VirusDetector
{
    public partial class FormMain : Form
    {
        #region Clustering Method


        public void startClustering()
        {
            _clusteringManager.trainDistanceNetwork();
        }

        public void saveClusteringOutput(String fileName_)
        {
            _clusteringManager.saveDistanceNetwork(fileName_);
        }

        public void loadClusteringOutput(String fileName_)
        {
            _clusteringManager.loadDistanceNetwork(fileName_);
        }

        #endregion

        #region EventSupport
        private void _saveMixDetector()
        {
            String savePath = txtbCMixDetectorFile.Text;
            Utils.Utils.saveMixDetector(_detectorData, savePath);
            MessageBox.Show("Successful!");
        }
        private void _loadMixDetector()
        {
            String fileName = txtbCMixDetectorFile.Text;
            _detectorData = Utils.Utils.loadMixDetector(fileName);
            _calcNumOfDetector();
            MessageBox.Show("Successful!");
        }
        private void _calcNumOfDetector()
        {
            int[] detectorCount = Utils.Utils.calcNumOfDetector(_detectorData);
            txtbCVirusSize.Text = detectorCount[0].ToString();
            txtbCBenignSize.Text = detectorCount[1].ToString();
        }
        private void _startClustering()
        {
            _currentProcessType = EProcessType.Clustering;
            _turnToWorkingStatus(true);
            _worker = new Thread(_clusteringThread);
            _worker.Start();
        }
        private void _clusteringThread()
        {
            try
            {
                int inputCount = int.Parse(txtbCNumInputNeuron.Text);
                int maxInputRange = (inputCount == 4 ? 255 : 1);
                int numNeuronX = int.Parse(txtbCNumNeuronX.Text);
                int numNeuronY = int.Parse(txtbCNumNeuronY.Text);
                double learningRate = double.Parse(txtbCLearningRate.Text);
                double learningRadius = double.Parse(txtbCLearningRadius.Text);
                int numOfIterator = int.Parse(txtbCNumIterator.Text);
                double errorThresold = double.Parse(txtbCErrorThresold.Text);

                _clusteringManager = new ClusteringManager(
                    inputCount,
                    numNeuronX,
                    numNeuronY,
                    learningRate,
                    learningRadius,
                    numOfIterator,
                    errorThresold,
                    _detectorData,
                    maxInputRange
                    );

                _clusteringManager.trainDistanceNetwork();

                LoadDangerLevel();

                _clusteringManager.Test_PrintlnNeuron();

                MessageBox.Show("Successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void _loadClustering()
        {
            String fileName = txtbCClusteringFile.Text;

            if (_clusteringManager == null)
                _clusteringManager = new ClusteringManager();

            _clusteringManager.loadDistanceNetwork(fileName);
            txtbCNumInputNeuron.Text = _clusteringManager.NumInputNeuron.ToString();


            MessageBox.Show("Successful!");
        }
        private void _saveClustering()
        {
            String fileName = txtbCClusteringFile.Text;
            _clusteringManager.saveDistanceNetwork(fileName);
            MessageBox.Show("Successful!");
        }
        private void _mixDetector()
        {
            _correctDetectorData();
            _calcNumOfDetector();
            MessageBox.Show("Successful!");
        }
        private void LoadDangerLevel()
        {
            if (InvokeRequired)
            {
                MethodInvoker method = new MethodInvoker(LoadDangerLevel);
                Invoke(method);
                return;
            }
            _loadDangerLevel();
        }
        private void _loadDangerLevel()
        {
            dangerLevel.Series.Clear();
            dangerLevel.Series.Add("Benign",ViewType.Point);
            dangerLevel.Series.Add("Virus",ViewType.Point);
            //todo
            //dangerLevel.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
            //dangerLevel.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;

            ////dangerLevel.ChartAreas[0].Position.Y = 100;
            ////dangerLevel.ChartAreas[0].Position.Height = 60;
            ////dangerLevel.ChartAreas[0].AxisX.Maximum = 500;
            //dangerLevel.ChartAreas[0].AxisX.Minimum = 0;
            ////dangerLevel.ChartAreas[0].AxisY.Maximum = 500;
            //dangerLevel.ChartAreas[0].AxisY.Minimum = 0;
            double[][] cluster = _clusteringManager.DangerLevel();
            for (int i = 0; i < cluster.Length; i++)
            {
                if (cluster[i][1] == Utils.Utils.BENIGN_MARK)
                    dangerLevel.Series["Benign"].Points.Add(new SeriesPoint( i, cluster[i][0]));
                else if (cluster[i][1] == Utils.Utils.VIRUS_MARK)
                    dangerLevel.Series["Virus"].Points.Add(new SeriesPoint(i, cluster[i][0]));
            }
        }
        #endregion
    }
}
