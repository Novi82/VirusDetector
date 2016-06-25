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

        /// <summary>
        /// turn working [on|off]
        /// </summary>
        /// <param name="working_"></param>
        private void _turnToWorkingStatus(bool working_)
        {
            if (working_)
            {
                // Set value
                startTime = DateTime.Now;
                txtTimeBox.Text = "";
                txtStatusBar.Text = "";
                progressBar.EditValue = 0;

                // Set busy cursor
                this.Cursor = Cursors.WaitCursor;
                
                // Start timer
                _timer.Start();

                // ???
                this.Capture = true;

                // Set state
                _isTrainingDectector = true;
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
                _isTrainingDectector = false;
            }
        }

        //todo del it plz
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
        /// <summary>
        /// show detector DataTable
        /// </summary>
        /// <param name="TD"></param>
        /// <param name="state"></param>
        private void ShowDetectorDataTable(TrainingData TD, EFragmentType[] state)
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
                if (state[i] == EFragmentType.Benign)
                {
                    row["Status"] = "Benign";
                }
                else
                {
                    row["Status"] = "==========Virus=========";
                }
                NegativeSelectionData.Rows.Add(row);

            }
            view = new DataView(NegativeSelectionData);

            // Set a DataGrid control's DataSource to the DataView.
            dtNegativeSelection.DataSource = view;
        }
        /// <summary>
        /// show reult to datagridview
        /// </summary>
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
        /// <summary>
        /// show detector result
        /// </summary>
        private void showDetectorResult()
        {
            //ShowDetectorDataTable(datageneration.VirusFragmentInput, datageneration.state);
            ShowDetectorDataTable(datageneration.VirusFragmentInput, datageneration.state);
        }

        #endregion
        
        #region Event Support

        /// <summary>
        /// start training Detector
        /// </summary>
        private void _startDetector()
        {
            // check input path
            Boolean isOk = _checkForStartDetector();
            if (!isOk)
            {
                MessageBox.Show("Please check input!");
                return;
            }

            if (_isTrainingDectector)
                return;

            // clear data
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
            _isTrainingDectector = true;

            Boolean isBuild;
            isBuild = (rbtnDBuildAddDetector.SelectedIndex == 0);
            if (isBuild)
                _worker = new Thread(_detectorThread);
            else
                _worker = new Thread(_additionNegativeThread);

            _worker.Start();
        }

        /// <summary>
        /// thread for Building detector 
        /// </summary>
        private void _detectorThread()
        {
            try
            {
                // load param from UI
                int length = int.Parse(txtDLength.Text);
                int stepSize = int.Parse(txtDStepSize.Text);
                bool useHamming = cbxDHamming.IsOn;
                bool useR = cbxDRContinuous.IsOn;
                int HammingDistance = Math.Max(0, Math.Min(length * 8, int.Parse(txtbDHamming.Text)));
                int RContiguousDistance = Math.Max(0, Math.Min(length * 8, int.Parse(txtbDContinuous.Text)));
                String virusFolder = txtbDVirusFolder.Text;
                String benignFolder = txtbDBenignFolder.Text;

                datageneration = new DataGeneration(virusFolder, benignFolder, HammingDistance, RContiguousDistance, length, stepSize, useHamming, useR);

                datageneration.startBuildDetector();
                //MessageBox.Show("Successful!");

                //xtcContent.SelectedTabPage = xtpDeResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Thread Stopped
        /// </summary>
        private void _detectorThread_Stopped()
        {
            this._virusFragments = datageneration.VirusFragmentOutput;
            Boolean isBuild;
            isBuild = (rbtnDBuildAddDetector.SelectedIndex == 0);
            if (isBuild)
                this._benignFragments = datageneration.BenignFragmentInput;

            showDetectorResult();
        }

        /// <summary>
        /// stop thread for Building detector 
        /// </summary>
        /// <summary>
        /// thread for addition detector
        /// </summary>
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

        /// <summary>
        /// _updateDetectorType
        /// </summary>
        /// <param name="detectorType"></param>
        private void _updateDetectorType(EDetectorType detectorType)
        {
            switch (detectorType)
            {
                case EDetectorType.BuildDetector:
                    txtbDAdditionFolder.Enabled = false;
                    txtbDBenignFolder.Enabled = true;
                    txtbDVirusFolder.Enabled = true;
                    btnDVirusFolder.Enabled = true;
                    btnDBenignFolder.Enabled = true;
                    btnDAdditionFolder.Enabled = false;
                    break;
                case EDetectorType.AdditionNegative:
                    txtbDAdditionFolder.Enabled = true;
                    txtbDBenignFolder.Enabled = false;
                    txtbDVirusFolder.Enabled = false;
                    btnDVirusFolder.Enabled = false;
                    btnDBenignFolder.Enabled = false;
                    btnDAdditionFolder.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Save detector into file
        /// </summary>
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

        /// <summary>
        /// Load detector from file
        /// </summary>
        private void _loadDetector()
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

        #endregion

        #region Check Error
        /// <summary>
        /// check detector input path
        /// </summary>
        /// <returns></returns>
        private bool _checkForStartDetector()
        {
            Boolean isBuild;
            isBuild = (rbtnDBuildAddDetector.SelectedIndex == 0);
            // in the case of Build new
            if (isBuild)
            {
                if (String.IsNullOrEmpty(txtbDVirusFolder.Text) || String.IsNullOrEmpty(txtbDBenignFolder.Text))
                    return false;
                return true;
            }
            // in the case of Addition
            if (String.IsNullOrEmpty(txtbDAdditionFolder.Text))
                return false;
            return true;
        }

        /// <summary>
        /// Check befor save detector
        /// </summary>
        /// <returns></returns>
        private bool _checkForSaveDetector()
        {
            if (String.IsNullOrEmpty(txtbDDetectorFile.Text) || _virusFragments == null || _benignFragments == null || _virusFragments.Count + _benignFragments.Count == 0)
                return false;
            return true;
        }

        /// <summary>
        /// check error befor Load detector
        /// </summary>
        /// <returns></returns>
        private bool _checkForLoadDetector()
        {
            if (String.IsNullOrEmpty(txtbDDetectorFile.Text))
                return false;
            return true;
        }
        #endregion
    }
}
