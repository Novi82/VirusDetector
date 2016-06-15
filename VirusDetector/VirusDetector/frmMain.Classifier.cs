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
        #region Event Support
        private void _preprocesserFileClassifier()
        {

            String virusFolder = txtbFCVirusFolder.Text;
            String benignFolder = txtbFCBenignFolder.Text;
            String formatRange = txtbCFFormatRange.Text;

            _fileClassifierManager = new FileClassifierManager(
                virusFolder,
                benignFolder,
                _clusteringManager.DistanceNetwork,
                formatRange
                );
            _fileClassifierManager.buildTrainingSet();
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
                int numOfHiddenNeuron = int.Parse(txtbFCNumHiddenNeuron.Text);
                int numOfOutputNeuron = int.Parse(txtbCFNumOutputNeuron.Text);
                int numOfIterator = int.Parse(txtbCFNumIterator.Text);
                double errorThresold = double.Parse(txtbCFErrorThresold.Text);

                _fileClassifierManager.trainActiveNetwork(numOfHiddenNeuron,
                    numOfOutputNeuron,
                    numOfIterator,
                    errorThresold);

                MessageBox.Show("Successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void _saveFileClassifier()
        {
            String fileName = txtbFCFileClassifierFile.Text;
            _fileClassifierManager.saveActiveNetwork(fileName);
            MessageBox.Show("Successful!");
        }
        private void _loadFileClassifier()
        {
            if (_fileClassifierManager == null)
            {
                String virusFolder = txtbDVirusFolder.Text;
                String benignFolder = txtbDBenignFolder.Text;
                String formatRange = txtbCFFormatRange.Text;

                _fileClassifierManager = new FileClassifierManager(
                    virusFolder,
                    benignFolder,
                    _clusteringManager.DistanceNetwork,
                    formatRange
                    );
            }

            String fileName = txtbFCFileClassifierFile.Text;
            _fileClassifierManager.loadActiveNetwork(fileName);

            MessageBox.Show("Successful!");
        }
        public void LoadStyleChart()
        {
            chartFC.Series.Clear();
            chartFC.Series.Add("Benign", ViewType.Point);
            chartFC.Series.Add("Virus",ViewType.Point);
            //Todo
            //chartFC.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
            //chartFC.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;
            for (int i = 0; i < _fileClassifierManager._graphMap.Length; i++)
            {
                if (_fileClassifierManager._graphMap[i][1] == Utils.Utils.BENIGN_MARK)
                    chartFC.Series["Benign"].Points.Add(new SeriesPoint(i, _fileClassifierManager._graphMap[i][0]));
                else if (_fileClassifierManager._graphMap[i][1] == Utils.Utils.VIRUS_MARK)
                    chartFC.Series["Virus"].Points.Add(new SeriesPoint(i, _fileClassifierManager._graphMap[i][0]));
            }
        }
        #endregion
    }
}
