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
using Accord.MachineLearning;
using VirusDetector.FormCustomize;

namespace VirusDetector
{
    public partial class FormMain : Form
    {

        #region Detecter Method
        private void _turnToWorkingStatus(bool working_)
        {
            if (working_)
            {
                // Set value
                startTime = DateTime.Now;
                txtTimeBox.Text = "";
                txtStatusBar.Text = "";
                // todo  progressBar.value = 0
                progressBar.EditValue = 0;

                // Set busy cursor
                this.Cursor = Cursors.WaitCursor;


                // Start timer
                _timer.Start();

                // ???
                this.Capture = true;

                // Set state
                _isWorking = true;
            }
            else
            {
                progressBar.EditValue = progressBar.Properties.Maximum;


                this.Cursor = Cursors.Default;

                // Stop timer
                _timer.Stop();

                // ???
                this.Capture = false;

                // Set state
                _isWorking = false;
            }
        }

        private List<byte[][]> Group(TrainingData TD, double _SelectionRate, int _numberOfCluster)
        {
            for (int i = 0; i < TD.Count; i++)
            {
                if (TD[i] == null) { TD.RemoveAt(i); i--; continue; }
            }
            double[][] temp = new double[TD.Count][];
            //double[][] temp = new double[TD.Count][];
            for (int i = 0; i < TD.Count; i++)
            {

                temp[i] = new double[TD[i].Length];
                for (int j = 0; j < temp[i].Length; j++)
                {
                    temp[i][j] = (double)TD[i][j];
                }
            }
            KMeans kmeans = new KMeans(_numberOfCluster);
            //KMeans kmeans = new KMeans(40);
            Label = kmeans.Compute(temp);
            List<int> label1 = new List<int>();
            for (int i = 0; i < Label.Length; i++)
            {
                bool flag = false;
                for (int j = 0; j < groups.Count; j++)
                {
                    if (groups[j].label == Label[i])
                    {
                        groups[j].Add(TD[i]);
                        flag = true;
                    }


                }
                if (!flag)
                {
                    Cluster s = new Cluster(Label[i]);
                    s.Add(TD[i]);
                    groups.Add(s);
                }

            }
            for (int i = 0; i < groups.Count; i++)
            {
                groups[i].rate = (double)groups[i].val.Count / TD.Count;
            }
            groups.Sort();
            List<byte[][]> tempnew = new List<byte[][]>();
            for (int i = 0; i < _SelectionRate * groups.Count; i++)
            {
                tempnew.Add(groups[i].val.ToArray());
            }
            return tempnew;

        }

        private void ShowDetectorDataTable(TrainingData TD, int[] state)
        {
            // Declare DataColumn and DataRow variables.
            DataColumn column;
            DataRow row;
            DataView view;
            NegativeSelectionData.Columns.Clear();

            // Create new DataColumn, set DataType, ColumnName and add to DataTable.    
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Virus Data Fragments";
            NegativeSelectionData.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Status";
            NegativeSelectionData.Columns.Add(column);
            NegativeSelectionData.Rows.Clear();

            for (int i = 0; i < TD.Count; i++)
            {
                row = NegativeSelectionData.NewRow();
                row["Virus Data Fragments"] = ConvertByteArrayToString(TD[i]);
                //row[0] = ConvertByteArrayToString(TD[i]);
                if (state[i] == 0)
                {
                    row["Status"] = "Passed";
                }
                else
                {
                    row["Status"] = "Failed";
                }
                NegativeSelectionData.Rows.Add(row);

            }
            view = new DataView(NegativeSelectionData);

            // Set a DataGrid control's DataSource to the DataView.
            dtNegativeSelection.DataSource = view;
        }

        private void ShowingData()
        {
            DataColumn column;
            DataRow row;
            DataView view;
            NegativeSelectionData.Columns.Clear();

            // Create new DataColumn, set DataType, ColumnName and add to DataTable.    
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Virus Data Fragments";
            NegativeSelectionData.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Status";
            NegativeSelectionData.Columns.Add(column);
            NegativeSelectionData.Rows.Clear();
            for (int i = 0; i < _virusFragments.Count; i++)
            {
                row = NegativeSelectionData.NewRow();
                row["Virus Data Fragments"] = ConvertByteArrayToString(_virusFragments[i]);
                row["Status"] = "Passed";
                NegativeSelectionData.Rows.Add(row);

            }
            for (int i = 0; i < _benignFragments.Count; i++)
            {
                break;
                row = NegativeSelectionData.NewRow();
                row["Virus Data Fragments"] = ConvertByteArrayToString(_benignFragments[i]);
                row["Status"] = "Fail";
                NegativeSelectionData.Rows.Add(row);

            }
            view = new DataView(NegativeSelectionData);

            // Set a DataGrid control's DataSource to the DataView.
            dtNegativeSelection.DataSource = view;


            // Show value to status
            String status = string.Format("Number of virus fragments: {0}      Number of benign fragments : {1}", _virusFragments.Count, _benignFragments.Count);

            this.txtStatusBar.BeginInvoke((MethodInvoker)delegate()
            {
                txtStatusBar.Text = status;
                this.txtStatusBar.Refresh();
            });

        }

        private string ConvertByteArrayToString(byte[] bytes)
        {
            string s = "";
            for (int i = 0; i < bytes.Length; i++)
                s += bytes[i].ToString();
            return s;
        }

        private void showDetectorResult()
        {
            //ShowDetectorDataTable(datageneration.VirusFragmentInput, datageneration.state);
            ShowDetectorDataTable(datageneration.VirusFragmentOutput, datageneration.state);
        }

        private void _correctDetectorData()
        {

            int virusLen = 0;
            int benignLen = 0;

            if (cbxCUseRate.IsOn)
            {
                virusLen = _virusFragments.Count;

                String strRate = txtbCBenignVirusRate.Text;
                int rate = int.Parse(strRate);
                benignLen = virusLen * rate;
            }
            else
            {
                String strVirusLen = txtbCVirusSize.Text;
                virusLen = int.Parse(strVirusLen);

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

        #endregion

        #region Event Support
        private void _startDetector()
        {
            Boolean isOk = _checkForStartDetector();
            if (!isOk)
            {
                MessageBox.Show("Please check input!");
                return;
            }

            if (_isWorking)
                return;

            // Do job
            NegativeSelectionData.Rows.Clear();
            groupshowingDataTable.Rows.Clear();

            // Show value to status
            String status = string.Format("Number of virus fragments: {0}      Number of benign fragments : {1}", 0, Utils.Utils.GLOBAL_BENIGN_COUNT);
            this.txtStatusBar.BeginInvoke((MethodInvoker)delegate()
            {
                txtStatusBar.Text = status;
                this.txtStatusBar.Refresh();
            });

            _currentProcessType = EProcessType.Detector;

            _turnToWorkingStatus(true);
            _isWorking = true;

            Boolean isBuild;
            isBuild = (rbtnDBuildAddDetector.SelectedIndex == 0);
            if (isBuild)
                _worker = new Thread(_detectorThread);
            else
                _worker = new Thread(_additionNegativeThread);

            _worker.Start();
        }

        private void _additionNegativeThread()
        {
            try
            {
                int length = Utils.Utils.GLOBAL_LENGTH;
                int stepSize = Utils.Utils.GLOBAL_STEP_SIZE;
                bool useHamming = cbxDHamming.IsOn;
                bool useR = cbxDRContinuous.IsOn;
                int d = Math.Max(0, Math.Min(length * 8, int.Parse(txtbDHamming.Text)));
                int r = Math.Max(0, Math.Min(length * 8, int.Parse(txtbDContinuous.Text)));
                String virusFolder = null;
                String benignFolder = txtbDAdditionFolder.Text;

                datageneration = new DataGeneration(virusFolder, benignFolder, d, r, length, stepSize, useHamming, useR);

                datageneration.startAdditionNegative(_virusFragments);
                MessageBox.Show("Successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _detectorThread()
        {
            try
            {
                int length = Utils.Utils.GLOBAL_LENGTH;
                int stepSize = Utils.Utils.GLOBAL_STEP_SIZE;
                bool useHamming = cbxDHamming.IsOn;
                bool useR = cbxDRContinuous.IsOn;
                int d = Math.Max(0, Math.Min(length * 8, int.Parse(txtbDHamming.Text)));
                int r = Math.Max(0, Math.Min(length * 8, int.Parse(txtbDContinuous.Text)));
                String virusFolder = txtbDVirusFolder.Text;
                String benignFolder = txtbDBenignFolder.Text;

                datageneration = new DataGeneration(virusFolder, benignFolder, d, r, length, stepSize, useHamming, useR);

                datageneration.startBuildDetector();
                MessageBox.Show("Successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool _checkForStartDetector()
        {
            Boolean isBuild;
            isBuild = (rbtnDBuildAddDetector.SelectedIndex == 0);
            if (isBuild)
            {
                if (String.IsNullOrEmpty(txtbDVirusFolder.Text) || String.IsNullOrEmpty(txtbDBenignFolder.Text))
                    return false;
                return true;
            }

            if (String.IsNullOrEmpty(txtbDAdditionFolder.Text))
                return false;
            return true;
        }

        private void _saveDetector()
        {
            Boolean isOk = _checkForSaveDetector();
            if (!isOk)
            {
                MessageBox.Show("Empty input or data!");
                return;
            }

            String virusSavePath = txtbDDetectorFile.Text;
            String benignSavePath = txtbDBenignFile.Text;
            Utils.Utils.saveDetector(_virusFragments, virusSavePath, _benignFragments, benignSavePath);
            MessageBox.Show("Successful!");
        }

        private bool _checkForSaveDetector()
        {
            if (String.IsNullOrEmpty(txtbDDetectorFile.Text) || _virusFragments == null || _benignFragments == null || _virusFragments.Count + _benignFragments.Count == 0)
                return false;
            return true;
        }

        private void _loadDetection()
        {

            Boolean isOk = _checkForLoadDetector();
            if (!isOk)
            {
                MessageBox.Show("Empty input!");
                return;
            }
            String virusSavePath = txtbDDetectorFile.Text;
            String benignSavePath = txtbDBenignFile.Text;
            Utils.Utils.loadDetector(ref _virusFragments, virusSavePath, ref _benignFragments, benignSavePath);

            ShowingData();
            MessageBox.Show("Successful!");
        }

        private bool _checkForLoadDetector()
        {
            if (String.IsNullOrEmpty(txtbDDetectorFile.Text))
                return false;
            return true;
        }
        private void _updateDetectorType(EDetectorType detectorType)
        {
            switch (detectorType)
            {
                case EDetectorType.BuildDetector:
                    txtbDAdditionFolder.ReadOnly = true;
                    txtbDBenignFolder.ReadOnly = false;
                    txtbDVirusFolder.ReadOnly = false;
                    break;
                case EDetectorType.AdditionNegative:
                    txtbDAdditionFolder.ReadOnly = false;
                    txtbDBenignFolder.ReadOnly = true;
                    txtbDVirusFolder.ReadOnly = true;
                    break;
                default:
                    break;
            }
        }
        #endregion

    }          
}
