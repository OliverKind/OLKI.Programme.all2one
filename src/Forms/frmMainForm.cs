﻿/*
 * all2one - File mover
 * 
 * Copyright:   Oliver Kind - 2020
 * License:     LGPL
 * 
 * Desctiption:
 * The MainForm of the application
 * 
 * 
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the LGPL General Public License as published by
 * the Free Software Foundation; either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed WITHOUT ANY WARRANTY; without even the implied
 * warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * LGPL General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not check the GitHub-Repository.
 * 
 * */

using OLKI.Programme.all2one.Properties;
using OLKI.Programme.all2one.src;
using OLKI.Tools.CommonTools;
using OLKI.Tools.CommonTools.DirectoryAndFile;
using OLKI.Widgets.Invoke;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace OLKI.Programme.all2one
{
    public partial class MainForm : Form
    {
        #region Constants
        /// <summary>
        /// Format for progress percentage field
        /// </summary>
        private const string FORMAT_PERCENTAGE = "{0}%";
        /// <summary>
        /// Format for progress value field, while moving files
        /// </summary>
        private const string FORMAT_VALUE_MOVE = "{0} / {1}";
        /// <summary>
        /// Number format for value field
        /// </summary>
        private const string FORMAT_VALUE_NUMBER = "N0";
        #endregion

        #region Fields
        /// <summary>
        /// Backgroundworker for count and move files
        /// </summary>
        private readonly BackgroundWorker _bgwWorker;
        /// <summary>
        /// Locks to lock the BackgroundWorker
        /// </summary>
        private readonly ManualResetEvent _locker = new ManualResetEvent(true);
        /// <summary>
        /// Main object for file counting and moving
        /// </summary>
        private FileMover _fileMover;
        #endregion

        #region Methodes
        /// <summary>
        /// Initial a new MainForm
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            this._bgwWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            this._bgwWorker.DoWork += new DoWorkEventHandler(this.bgwWorker_DoWork);
            this._bgwWorker.ProgressChanged += new ProgressChangedEventHandler(this.bgwWorker_ProgressChanged);
            this._bgwWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgwWorker_RunWorkerCompleted);

            this.SetExistingFileTextBoxes(null);
        }

        /// <summary>
        /// Set existing file text boxes to selected actions
        /// </summary>
        /// <param name="handleFilesDialog">Referece form to get text from, if null it will be created</param>
        private void SetExistingFileTextBoxes(HandleExistingFilesForm handleFilesDialog)
        {
            if (handleFilesDialog is null) handleFilesDialog = new HandleExistingFilesForm(HandleExistingFilesForm.FormMode.DefaultSettings, null, null, (HandleExistingFiles.HowToHandleExistingItem)Settings.Default.ExistingFile_Handle, Settings.Default.ExistingFile_AddText, true);
            if (handleFilesDialog.ActionHandleExistingFiles == HandleExistingFiles.HowToHandleExistingItem.AddText)
            {
                this.txtAddTextToExistingFileText.Text = handleFilesDialog.ActionAddTextText;
                this.lblAddTextToExistingFileText.Visible = true;
                this.txtAddTextToExistingFileText.Visible = true;
            }
            else
            {
                this.txtAddTextToExistingFileText.Text = string.Empty;
                this.lblAddTextToExistingFileText.Visible = false;
                this.txtAddTextToExistingFileText.Visible = false;
            }
            this.txtHandleExistingFileText.Text = handleFilesDialog.GetActionAsText(handleFilesDialog.ActionHandleExistingFiles);
        }

        #region Form events
        private void MainForm_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            AboutForm AboutForm = new AboutForm();
            AboutForm.ShowDialog(this);
            AboutForm.Dispose();
            e.Cancel = true;
        }

        private void btnHandleExistingFile_SetDefault_Click(object sender, EventArgs e)
        {
            HandleExistingFilesForm HandleFilesDialog = new HandleExistingFilesForm(HandleExistingFilesForm.FormMode.DefaultSettings, null, null, (HandleExistingFiles.HowToHandleExistingItem)Settings.Default.ExistingFile_Handle, Settings.Default.ExistingFile_AddText, true);
            if (HandleFilesDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.ExistingFile_AddText = HandleFilesDialog.ActionAddTextText;
                Settings.Default.ExistingFile_Handle = (int)HandleFilesDialog.ActionHandleExistingFiles;
                Settings.Default.Save();
                this.SetExistingFileTextBoxes(HandleFilesDialog);
            }
        }

        private void FileMover_ExistingFileSettingsChanged(object sender, EventArgs e)
        {
            this.SetExistingFileTextBoxes(null);
        }


        #region Controle Buttons
        private void btnProcessCancel_Click(object sender, EventArgs e)
        {
            this.btnProcessStart.Enabled = true;
            this.btnProcessPause.Enabled = false;
            this.btnProcessCancel.Enabled = false;

            this._bgwWorker.CancelAsync();
            this._locker.Set();
        }

        private void btnProcessPause_Click(object sender, EventArgs e)
        {
            this.btnProcessStart.Enabled = true;
            this.btnProcessPause.Enabled = false;
            this.btnProcessCancel.Enabled = true;

            this._locker.Reset();
        }

        private void btnProcessStart_Click(object sender, EventArgs e)
        {
            this.btnProcessStart.Enabled = false;
            this.btnProcessPause.Enabled = true;
            this.btnProcessCancel.Enabled = true;

            this._locker.Set();
            if (!this._bgwWorker.IsBusy) this._bgwWorker.RunWorkerAsync();
        }
        #endregion
        #endregion

        #region BackgroundWorker events
        private void bgwWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this._fileMover = new FileMover(this.txtPathSource.Text, this.txtPathTarget.Text, this._locker, this);
            _fileMover.Count(this._bgwWorker, e);
            _fileMover.Move(this._bgwWorker, e);
        }

        private void bgwWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int Percentage;

            // Use the progress in percentage to differ the different steps.
            // It looks a little bit stange. The real progress is stored in an member of this class.
            // Try to save the step in an member, lead to glitches. I used the ProgressPercentage as work around
            bool ForceReport = false;
            if (e.UserState != null && e.UserState.GetType().Equals(typeof(bool))) ForceReport = (bool)e.UserState;

            // Report Progress by time Interval or if report is forced
            if (ForceReport || _fileMover.CheckUpdateInterval())
            {
                _fileMover.TimeLastReport = DateTime.Now;

                FileMover.ProcessStep ProcessStep = (FileMover.ProcessStep)e.ProgressPercentage;
                switch (ProcessStep)
                {
                    case FileMover.ProcessStep.Count_Start:
                        ProgressBarInv.Style(this.pbaProgress, ProgressBarStyle.Marquee);
                        TextBoxInv.Text(this.txtProgressPercent, "");
                        TextBoxInv.Text(this.txtProgressValue, "");
                        TextBoxInv.Text(this.txtRemainTime, "");
                        break;
                    case FileMover.ProcessStep.Count_Busy:
                        TextBoxInv.Text(this.txtProgressValue, this._fileMover.FileTotalCount.ToString(FORMAT_VALUE_NUMBER));
                        break;
                    case FileMover.ProcessStep.Count_Finish:
                        ProgressBarInv.Style(this.pbaProgress, ProgressBarStyle.Blocks);
                        ProgressBarInv.Value(this.pbaProgress, 0);
                        break;
                    case FileMover.ProcessStep.Move_Start:
                        ProgressBarInv.Style(this.pbaProgress, ProgressBarStyle.Blocks);
                        ProgressBarInv.Value(this.pbaProgress, 0);
                        TextBoxInv.Text(this.txtProgressPercent, "");
                        TextBoxInv.Text(this.txtProgressValue, string.Format(FORMAT_VALUE_MOVE, new object[] { 0.ToString(FORMAT_VALUE_NUMBER), _fileMover.FileTotalCount.ToString(FORMAT_VALUE_NUMBER) }));
                        TextBoxInv.Text(this.txtRemainTime, "");
                        break;
                    case FileMover.ProcessStep.Move_Busy:
                        Percentage = Convert.ToInt32(Matehmatics.Percentages(this._fileMover.TotalFilesHandled, this._fileMover.FileTotalCount));
                        ProgressBarInv.Value(this.pbaProgress, Percentage);
                        TextBoxInv.Text(this.txtProgressPercent, string.Format(FORMAT_PERCENTAGE, Percentage));
                        TextBoxInv.Text(this.txtProgressValue, string.Format(FORMAT_VALUE_MOVE, new object[] { this._fileMover.TotalFilesHandled.ToString(FORMAT_VALUE_NUMBER), this._fileMover.FileTotalCount.ToString(FORMAT_VALUE_NUMBER) }));

                        TimeSpan RemainingTime = Matehmatics.RemainingTime((DateTime.Now - this._fileMover.TimeProcessStart), (double)this._fileMover.TotalFilesHandled, (double)this._fileMover.FileTotalCount, out _);
                        if (RemainingTime.Days > 0)
                        {
                            TextBoxInv.Text(this.txtRemainTime, RemainingTime.ToString(Settings.Default.Move_RemainTimeDays));
                        }
                        else
                        {
                            TextBoxInv.Text(this.txtRemainTime, RemainingTime.ToString(Settings.Default.Move_RemainTimeNoDays));
                        }
                        break;
                    case FileMover.ProcessStep.Move_Finish:
                        Percentage = Convert.ToInt32(Matehmatics.Percentages(this._fileMover.FileMove, this._fileMover.FileTotalCount));
                        ProgressBarInv.Value(this.pbaProgress, Percentage);
                        TextBoxInv.Text(this.txtProgressPercent, string.Format(FORMAT_PERCENTAGE, Percentage));
                        TextBoxInv.Text(this.txtProgressValue, string.Format(FORMAT_VALUE_MOVE, new object[] { this._fileMover.FileMove.ToString(FORMAT_VALUE_NUMBER), this._fileMover.FileTotalCount.ToString(FORMAT_VALUE_NUMBER) }));
                        break;
                    case FileMover.ProcessStep.Cancel:
                    case FileMover.ProcessStep.Exception:
                        ProgressBarInv.Style(this.pbaProgress, ProgressBarStyle.Blocks);
                        TextBoxInv.Text(this.txtRemainTime, "");
                        break;
                    default:
                        throw new ArgumentException("MainForm->worker_ProgressChanged->Invalid value", nameof(ProcessStep));
                }
            }
        }

        private void bgwWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.btnProcessStart.Enabled = true;
            this.btnProcessPause.Enabled = false;
            this.btnProcessCancel.Enabled = false;

            MessageBox.Show(this, string.Format(Stringtable._0x0002m, new object[] { this._fileMover.FileTotalCount, this._fileMover.FileMove, this._fileMover.FileSkip, this._fileMover.FileExceptions }), Stringtable._0x0002c, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
        #endregion
    }
}