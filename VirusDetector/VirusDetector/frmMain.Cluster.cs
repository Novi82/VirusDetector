using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using VirusDetector.Clustering;
using VirusDetector.Properties;

namespace VirusDetector
{
    [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
    public partial class FormMain
    {
        #region Clustering Method
        /// <summary>
        /// init param
        /// </summary>
        private void _initParamMixDetector()
        {
            int virusLen;
            int benignLen;
            if (cbxCUseRate.IsOn)
            {
                // output frament in step detector   
                virusLen = _virusFragments.Count;
                // load rate
                string strRate = txtbCBenignVirusRate.Text;
                double rate = double.Parse(strRate);
                // calculate benign len
                benignLen = Convert.ToInt32(virusLen * rate);
            }
            else
            {
                // load from 
                virusLen = _virusFragments.Count;
                // load from UI
                string strBenignLen = txtbCBenignSize.Text;
                benignLen = int.Parse(strBenignLen);
                txtbCBenignVirusRate.Text = Math.Round((double)benignLen / virusLen, 2).ToString(CultureInfo.CurrentCulture);
            }

            // Select algorithm
            int inputCount = int.Parse(txtbCNumInputNeuron.Text);
            // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
            if (inputCount == 4)
            {
                _detectorData = Utils.Utils.MixDetectorBase10(_virusFragments, virusLen, _benignFragments, benignLen);
            }
            else
            {
                _detectorData = Utils.Utils.MixDetectorBase2(_virusFragments, virusLen, _benignFragments, benignLen);
            }
        }

        public void StartClustering()
        {
            _clusteringManager.TrainDistanceNetwork();
        }

        public void SaveClusteringOutput(string pFileName)
        {
            _clusteringManager.SaveDistanceNetwork(pFileName);
        }

        public void LoadClusteringOutput(string pFileName)
        {
            _clusteringManager.LoadDistanceNetwork(pFileName);
        }

        #endregion

        #region Mix detector
        /// <summary>
        /// save mixed detector to text fife
        /// </summary>
        /// <param name="pInput"></param>
        /// <param name="pFileName"></param>
        public static void SaveMixDetector(double[][] pInput, string pFileName)
        {
            StreamWriter file = new StreamWriter(pFileName);
            int len0 = pInput.Length;
            int len1 = pInput[0].Length;

            for (int i = 0; i < len0 - 1; i++)
            {
                for (int j = 0; j < len1 - 1; j++)
                {
                    file.Write(pInput[i][j] + ",");
                }
                file.WriteLine(pInput[i][len1 - 1]);
            }

            // Write the last one
            for (int j = 0; j < len1 - 1; j++)
            {
                file.Write(pInput[len0 - 1][j] + ",");
            }
            file.Write(pInput[len0 - 1][len1 - 1]);

            // Close file
            file.Close();
        }

        /// <summary>
        /// load mixed detector from text file
        /// </summary>
        /// <param name="pFileName"></param>
        /// <returns></returns>
        public static double[][] LoadMixDetector(string pFileName)
        {
            var lines = File.ReadAllLines(pFileName);
            var len = lines.Length;
            var inputs = new double[len][];

            int countX = 0;
            foreach (var line in lines)
            {
                String[] raw = line.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                int countY = 0;
                inputs[countX] = new double[raw.Length];
                foreach (var item in raw)
                {
                    inputs[countX][countY] = double.Parse(item);
                    countY++;
                }
                countX++;
            }
            return inputs;
        }
        #endregion
        #region EventSupport
        private void _saveMixDetector()
        {
            string savePath = txtbCMixDetectorFile.Text;
            SaveMixDetector(_detectorData, savePath);
            MessageBox.Show(@"Save Mixed Detector " + Resources.Message_Successful);
        }
        private void _loadMixDetector()
        {
            string fileName = txtbCMixDetectorFile.Text;
            _detectorData = LoadMixDetector(fileName);
            _calcNumOfDetector();
            MessageBox.Show(@"Load Mixed Detector " + Resources.Message_Successful);
        }
        /// <summary>
        /// calculate numb of detector and show its to UI
        /// </summary>
        private void _calcNumOfDetector()
        {
            int[] detectorCount = Utils.Utils.CalcNumOfDetector(_detectorData);
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
                startTime = DateTime.Now;
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
                _clusteringManager.TrainDistanceNetwork();

                LoadDangerLevel();

                //MessageBox.Show(@"Train Network " + Resources.Message_Successful);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void _loadClustering()
        {
            string fileName = txtbCClusteringFile.Text;

            if (_clusteringManager == null)
                _clusteringManager = new ClusteringManager();

            _clusteringManager.LoadDistanceNetwork(fileName);
            txtbCNumInputNeuron.Text = _clusteringManager.NumPInputNeuron.ToString();
           // MessageBox.Show(Resources.Message_Successful);
        }
        private void _saveClustering()
        {
            string fileName = txtbCClusteringFile.Text;
            _clusteringManager.SaveDistanceNetwork(fileName);
            MessageBox.Show(Resources.Message_Successful);
        }
        /// <summary>
        /// start mix detector into 2side matrix
        /// </summary>
        private void _mixDetector()
        {
            _initParamMixDetector();
            _calcNumOfDetector();
            MessageBox.Show(@"Mixed " + Resources.Message_Successful);
        }

        private void LoadDangerLevel()
        {
            if (InvokeRequired)
            {
                MethodInvoker method = LoadDangerLevel;
                Invoke(method);
                return;
            }
            _loadDangerLevel();
        }
        private void _loadDangerLevel()
        {
            dangerLevel.Series.Clear();
            dangerLevel.Series.Add("Benign", ViewType.Point);
            dangerLevel.Series.Add("Virus", ViewType.Point);
            
            double[][] cluster = _clusteringManager.DangerLevel();
            for (var i = 0; i < cluster.Length; i++)
            {
                if (cluster[i][1] == Utils.Utils.BENIGN_MARK)
                    dangerLevel.Series["Benign"].Points.Add(new SeriesPoint(i+1, cluster[i][0]));
                else if (cluster[i][1] == Utils.Utils.VIRUS_MARK)
                    dangerLevel.Series["Virus"].Points.Add(new SeriesPoint(i+1, cluster[i][0]));
            }
        }
        #endregion
    }
}
