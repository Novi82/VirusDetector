using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using VirusDetector.Detector;
using VirusDetector.Properties;

namespace VirusDetector
{
    public partial class FormMain
    {

        #region Detecter Method

        /// <summary>
        /// turn working [on|off]
        /// </summary>
        /// <param name="pIsWorking"></param>
        private void _turnToWorkingStatus(bool pIsWorking)
        {
            if (pIsWorking)
            {
                txtStatusBar.Text = "";
                progressBar.EditValue = 0;

                // Set busy cursor
                Cursor = Cursors.WaitCursor;

                // Start timer
                _timer.Start();

                // ???
                Capture = true;

                // Set pState
                _isTrainingDectector = true;
            }
            else
            {
                progressBar.EditValue = progressBar.Properties.Maximum;

                Cursor = Cursors.Default;

                // Stop timer
                _timer.Stop();

                // ???
                Capture = false;

                // Set pState
                _isTrainingDectector = false;
            }
        }

        /// <summary>
        /// show detector DataTable
        /// </summary>
        /// <param name="pTrainingData"></param>
        private void ShowDetectorDataTable(TrainingData pTrainingData)
        {
            // Declare DataColumn and DataRow variables.
            _negativeSelectionData.Columns.Clear();

            // Create new DataColumn, set DataType, ColumnName and add to DataTable.    
            var column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Data Fragments"
            };
            _negativeSelectionData.Columns.Add(column);

            // Create second column.
            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Status"
            };
            _negativeSelectionData.Columns.Add(column);
            _negativeSelectionData.Rows.Clear();

            foreach (byte[] data in pTrainingData)
            {
                var row = _negativeSelectionData.NewRow();
                row["Data Fragments"] = ConvertByteArrayToString(data);
                row["Status"] = "Virus";
                _negativeSelectionData.Rows.Add(row);
            }
            var view = new DataView(_negativeSelectionData);

            // Set a DataGrid control's DataSource to the DataView.
            dtNegativeSelection.DataSource = view;
        }
        /// <summary>
        /// show reult to datagridview
        /// </summary>
        private void ShowingData()
        {
            _negativeSelectionData.Columns.Clear();

            // Create new DataColumn, set DataType, ColumnName and add to DataTable.    
            var column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Data Fragments"
            };
            _negativeSelectionData.Columns.Add(column);

            // Create second column.
            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Status"
            };
            _negativeSelectionData.Columns.Add(column);

            _negativeSelectionData.Rows.Clear();

            foreach (byte[] frag in _virusFragments)
            {
                var row = _negativeSelectionData.NewRow();
                row["Data Fragments"] = ConvertByteArrayToString(frag);
                row["Status"] = "Virus";
                _negativeSelectionData.Rows.Add(row);
            }

            var view = new DataView(_negativeSelectionData);
            // Set a DataGrid control's DataSource to the DataView.
            dtNegativeSelection.DataSource = view;

            // Show value to status
            string status = string.Format(Resources.Status_Message, _virusFragments.Count, _benignFragments.Count);
            txtStatusBar.BeginInvoke((MethodInvoker)delegate
            {
                txtStatusBar.Text = status;
                this.txtStatusBar.Refresh();
            });

        }

        private static string ConvertByteArrayToString(byte[] bytes)
        {
            return bytes.Aggregate("", (current, t) => current + t.ToString());
        }

        /// <summary>
        /// show detector result
        /// </summary>
        private void ShowDetectorResult()
        {
            ShowDetectorDataTable(_dataGeneration.VirusFragmentOutput);
        }

        #endregion

        #region Event Support

        /// <summary>
        /// start training Detector
        /// </summary>
        private void _startDetector()
        {
            // check input path
            var isOk = _checkForStartDetector();
            if (!isOk)
            {
                MessageBox.Show(Resources.Message_input_error);
                return;
            }

            if (_isTrainingDectector)
                return;

            // clear data
            _negativeSelectionData.Rows.Clear();
            _groupshowingDataTable.Rows.Clear();

            // Show value to status
            var status = string.Format(Resources.Status_Message, 0, Utils.Utils.GLOBAL_BENIGN_COUNT);
            txtStatusBar.BeginInvoke((MethodInvoker)delegate
            {
                txtStatusBar.Text = status;
                this.txtStatusBar.Refresh();
            });

            _currentProcessType = EProcessType.Detector;

            _turnToWorkingStatus(true);
            _isTrainingDectector = true;

            var isBuild = (rbtnDBuildAddDetector.SelectedIndex == 0);
            _worker = isBuild ? new Thread(_detectorThread) : new Thread(_additionNegativeThread);

            _worker.Start();
        }

        /// <summary>
        /// thread for Building detector 
        /// </summary>
        private void _detectorThread()
        {
            try
            {
                startTime = DateTime.Now;
                
                // load param from UI
                int length = int.Parse(txtDLength.Text);
                int stepSize = int.Parse(txtDStepSize.Text);
                bool useHamming = cbxDHamming.IsOn;
                bool useR = cbxDRContinuous.IsOn;
                int hammingDistance = Math.Max(0, Math.Min(length * 8, int.Parse(txtbDHamming.Text)));
                int rContiguousDistance = Math.Max(0, Math.Min(length * 8, int.Parse(txtbDContinuous.Text)));
                string virusFolder = txtbDVirusFolder.Text;
                string benignFolder = txtbDBenignFolder.Text;
                _dataGeneration = new DataGeneration(virusFolder, benignFolder, hammingDistance, rContiguousDistance, length, stepSize, useHamming, useR);
                _dataGeneration.StartBuildDetector();
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
            _virusFragments = _dataGeneration.VirusFragmentOutput;
            var isBuild = (rbtnDBuildAddDetector.SelectedIndex == 0);
            if (isBuild)
            {
                _benignFragments = _dataGeneration.BenignFragmentInput;
            }
            txtTimeBox.Text = (DateTime.Now - startTime).ToString(@"hh\:mm\:ss");
            txtbCVirusSize.EditValue = _dataGeneration.VirusFragmentOutput.Count;
            ShowDetectorResult();
        }

        /// <summary>
        /// stop thread for Building detector 
        /// </summary> <summary>
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
                string benignFolder = txtbDAdditionFolder.Text;
                //string virusFolder = null;
                _dataGeneration = new DataGeneration(null, benignFolder, d, r, length, stepSize, useHamming, useR);

                _dataGeneration.StartAdditionNegative(_virusFragments);
                MessageBox.Show(Resources.Message_Successful);
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
            }
        }

        /// <summary>
        /// Save detector into file
        /// </summary>
        private void _saveDetector()
        {
            bool isOk = _checkForSaveDetector();
            if (!isOk)
            {
                MessageBox.Show(@"Empty input or data!");
                return;
            }

            string virusSavePath = txtbDDetectorFile.Text;
            string benignSavePath = txtbDBenignFile.Text;
            Utils.Utils.SaveDetector(_virusFragments, virusSavePath, _benignFragments, benignSavePath);
            MessageBox.Show(@"Save Detector. " + Resources.Message_Successful);
        }

        /// <summary>
        /// Load detector from file
        /// </summary>
        private void _loadDetector()
        {

            bool isOk = _checkForLoadDetector();
            if (!isOk)
            {
                MessageBox.Show(@"Empty input!");
                return;
            }
            var virusSavePath = txtbDDetectorFile.Text;
            string benignSavePath = txtbDBenignFile.Text;
            Utils.Utils.LoadDetector(ref _virusFragments, virusSavePath, ref _benignFragments, benignSavePath);
            txtbCVirusSize.EditValue = _virusFragments.Count;
            txtbCBenignSize.EditValue = _virusFragments.Count * Convert.ToDouble(txtbCBenignVirusRate.EditValue);
            ShowingData();
        }

        #endregion

        #region Check Error
        /// <summary>
        /// check detector input path
        /// </summary>
        /// <returns></returns>
        private bool _checkForStartDetector()
        {
            var isBuild = (rbtnDBuildAddDetector.SelectedIndex == 0);
            // in the case of Build new
            if (isBuild)
            {
                return !string.IsNullOrEmpty(txtbDVirusFolder.Text) && !string.IsNullOrEmpty(txtbDBenignFolder.Text);
            }
            // in the case of Addition
            return !string.IsNullOrEmpty(txtbDAdditionFolder.Text);
        }

        /// <summary>
        /// Check befor save detector
        /// </summary>
        /// <returns></returns>
        private bool _checkForSaveDetector()
        {
            return !string.IsNullOrEmpty(txtbDDetectorFile.Text) && _virusFragments != null && _benignFragments != null && _virusFragments.Count + _benignFragments.Count != 0;
        }

        /// <summary>
        /// check error befor Load detector
        /// </summary>
        /// <returns></returns>
        private bool _checkForLoadDetector()
        {
            return !string.IsNullOrEmpty(txtbDDetectorFile.Text);
        }

        #endregion
    }
}
