using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
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
        /// <summary>
        /// init param
        /// </summary>
        private void _initParamMixDetector()
        {
            // todo
            int virusLen = 0;
            // todo 
            int benignLen = 0;

            if (cbxCUseRate.IsOn)
            {
                // output frament in step detector   
                virusLen = _virusFragments.Count;
                // load rate
                String strRate = txtbCBenignVirusRate.Text;
                int rate = int.Parse(strRate);
                // calculate benign len
                benignLen = virusLen * rate;
            }
            else
            {
                // load from UI
                String strVirusLen = txtbCVirusSize.Text;
                virusLen = int.Parse(strVirusLen);
                // load from UI
                String strBenignLen = txtbCBenignSize.Text;
                benignLen = int.Parse(strBenignLen);
            }

            // Select algorithm
            int inputCount = int.Parse(txtbCNumInputNeuron.Text);
            if (inputCount == 4)
            {
                _detectorData = Utils.Utils.mixDetectorBase10(_virusFragments, virusLen, _benignFragments, benignLen);
            }
            else
            {
                _detectorData = Utils.Utils.mixDetectorBase2(_virusFragments, virusLen, _benignFragments, benignLen);
            }

        }

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
        #region Mix detector
        /// <summary>
        /// save mixed detector to text fife
        /// </summary>
        /// <param name="input_"></param>
        /// <param name="fileName_"></param>
        public static void saveMixDetector(double[][] input_, String fileName_)
        {
            StreamWriter file = new StreamWriter(fileName_);
            int len0 = input_.Length;
            int len1 = input_[0].Length;

            for (int i = 0; i < len0 - 1; i++)
            {
                for (int j = 0; j < len1 - 1; j++)
                {
                    file.Write(input_[i][j] + ",");
                }
                file.WriteLine(input_[i][len1 - 1]);
            }

            // Write the last one
            for (int j = 0; j < len1 - 1; j++)
            {
                file.Write(input_[len0 - 1][j] + ",");
            }
            file.Write(input_[len0 - 1][len1 - 1]);

            // Close file
            file.Close();
        }

        /// <summary>
        /// load mixed detector from text file
        /// </summary>
        /// <param name="fileName_"></param>
        /// <returns></returns>
        public static double[][] loadMixDetector(String fileName_)
        {
            double[][] _input;
            var lines = File.ReadAllLines(fileName_);
            var len = lines.Length;
            _input = new double[len][];
            int countX = 0;
            foreach (var line in lines)
            {
                String[] raw = line.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                int countY = 0;
                _input[countX] = new double[raw.Length];
                foreach (var item in raw)
                {
                    _input[countX][countY] = double.Parse(item);
                    countY++;
                }
                countX++;
            }
            return _input;
        }
        #endregion
        #region EventSupport
        private void _saveMixDetector()
        {
            String savePath = txtbCMixDetectorFile.Text;
            saveMixDetector(_detectorData, savePath);
            MessageBox.Show("Successful!");
        }
        private void _loadMixDetector()
        {
            String fileName = txtbCMixDetectorFile.Text;
            _detectorData = loadMixDetector(fileName);
            _calcNumOfDetector();
            MessageBox.Show("Successful!");
        }
        /// <summary>
        /// calculate numb of detector and show its to UI
        /// </summary>
        private void _calcNumOfDetector()
        {
            int[] detectorCount = Utils.Utils.calcNumOfDetector(_detectorData);
            txtbCVirusSize.Text = detectorCount[0].ToString();
            txtbCBenignSize.Text = detectorCount[1].ToString();
        }
        /// <summary>
        /// start clustering
        /// </summary>
        private void _startClustering()
        {
            _currentProcessType = EProcessType.Clustering;
            _turnToWorkingStatus(true);
            _worker = new Thread(_clusteringThread);
            _worker.Start();
        }
        /// <summary>
        /// clustering Thread
        /// </summary>
        private void _clusteringThread()
        {
            try
            {
                int inputCount = int.Parse(txtbCNumInputNeuron.Text);
                // 4 neuron ->dec -> value 0 ~ 255
                // else 0 ~ 1
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
                // training
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
        /// <summary>
        /// start mix detector into 2side matrix
        /// </summary>
        private void _mixDetector()
        {
            _initParamMixDetector();
            _calcNumOfDetector();
            // todo del msg
            MessageBox.Show("Mix Detector.\nSuccessful!");
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
            //dangerLevel.Series["ChartArea1"].
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
