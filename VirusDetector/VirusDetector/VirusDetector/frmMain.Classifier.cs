using System;
using System.Threading;
using System.Windows.Forms;
using Accord.MachineLearning.VectorMachines.Learning;
using DevExpress.XtraCharts;
using VirusDetector.FileClassifier;
using VirusDetector.Properties;

namespace VirusDetector
{
    public partial class FormMain
    {
        #region Event Support
        private void _preprocesserFileClassifier()
        {
            string virusFolder = txtbFCVirusFolder.Text;
            string benignFolder = txtbFCBenignFolder.Text;
            string formatRange = txtbCFFormatRange.Text;

            _fileClassifierManager = new FileClassifierManager(
                virusFolder,
                benignFolder,
                _clusteringManager.DistanceNetwork,
                formatRange
                );
            _fileClassifierManager.BuildTrainingSetSvm();
            LoadStyleChart();
        }
        private void _startFileClassifier()
        {
            _currentProcessType = EProcessType.FileClassifier;
            _turnToWorkingStatus(true);
            _worker = new Thread(_fileClassifierThread);
            _worker.Start();
        }
        private void _fileClassifierThread()
        {
            try
            {
                double numSigma = double.Parse(txtSigma.EditValue.ToString());
                double numEpsilon = double.Parse(txtEpsilon.EditValue.ToString());
                double numComplexity = double.Parse(txtComplexity.EditValue.ToString());
                double numTolenace = double.Parse(txtTolenace.EditValue.ToString());
                int numCacheSize = Int32.Parse(txtCacheSize.EditValue.ToString());
                SelectionStrategy strategy = (SelectionStrategy)cbxStrategy.SelectedItem;

                //_fileClassifierManager.trainActiveNetwork(numOfHiddenNeuron,
                //    numOfOutputNeuron,
                //    numOfIterator,
                //    errorThresold);
                _fileClassifierManager.TrainSvm(numSigma,
                    numEpsilon,
                    numComplexity,
                    numTolenace,
                    numCacheSize,
                    strategy);

                MessageBox.Show(Resources.Message_Successful);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void _saveFileClassifier()
        {
            string fileName = txtbFCFileClassifierFile.Text;
            _fileClassifierManager.SaveActiveNetwork(fileName);
            MessageBox.Show(Resources.Message_Successful);
        }
        private void _loadFileClassifier()
        {
            if (_fileClassifierManager == null)
            {
                string virusFolder = txtbDVirusFolder.Text;
                string benignFolder = txtbDBenignFolder.Text;
                string formatRange = txtbCFFormatRange.Text;

                _fileClassifierManager = new FileClassifierManager(
                    virusFolder,
                    benignFolder,
                    _clusteringManager.DistanceNetwork,
                    formatRange
                    );
            }

            string fileName = txtbFCFileClassifierFile.Text;
            _fileClassifierManager.LoadActiveNetwork(fileName);

            MessageBox.Show(Resources.Message_Successful);
        }
        public void LoadStyleChart()
        {
            double tolerance = Utils.Utils.TOLERANCE;
            chartFC.Series.Clear();
            chartFC.Series.Add("Benign", ViewType.Point);
            chartFC.Series.Add("Virus", ViewType.Point);
            //Todo
            //chartFC.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
            //chartFC.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;
            for (int i = 0; i < _fileClassifierManager.GraphMap.Length; i++)
            {
                if (Math.Abs(_fileClassifierManager.GraphMap[i][1] - Utils.Utils.BENIGN_MARK) < tolerance)
                    chartFC.Series["Benign"].Points.Add(new SeriesPoint(i, _fileClassifierManager.GraphMap[i][0]));
                else if (Math.Abs(_fileClassifierManager.GraphMap[i][1] - Utils.Utils.VIRUS_MARK) < tolerance)
                    chartFC.Series["Virus"].Points.Add(new SeriesPoint(i, _fileClassifierManager.GraphMap[i][0]));
            }
        }
        #endregion
    }
}
