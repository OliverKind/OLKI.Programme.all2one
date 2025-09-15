/*
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
using static OLKI.Programme.all2one.src.FileMover.FileMover;
using OLKI.Toolbox.Common;
using OLKI.Toolbox.DirectoryAndFile;
using OLKI.Toolbox.Widgets.AboutForm;
using OLKI.Toolbox.Widgets.Invoke;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace OLKI.Programme.all2one.src.Forms
{
    public partial class MainForm : Form
    {
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
        private FileMover.FileMover _fileMover;

        /// <summary>
        /// Changes are system intern
        /// </summary>
        private bool _systemChanged = false;
        #endregion

        #region Methodes
        /// <summary>
        /// Initial a new MainForm
        /// </summary>
        public MainForm()
        {
            this._systemChanged = true;
            InitializeComponent();

            this._bgwWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            this._bgwWorker.DoWork += new DoWorkEventHandler(this.bgwWorker_DoWork);
            this._bgwWorker.ProgressChanged += new ProgressChangedEventHandler(this.bgwWorker_ProgressChanged);
            this._bgwWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgwWorker_RunWorkerCompleted);

            this.chkCopyMoveFiles.Checked = Settings.Default.CopyMoveFiles;
            this.chkCreateIndex.Checked = Settings.Default.CreateIndex;
            this.chkCopyMoveKeepStucture.Checked = Settings.Default.CopyMoveKeepStructure;
            this.txtCreateIndex.Enabled = Settings.Default.CreateIndex;
            this.txtCreateIndex.Text = Settings.Default.CreateIndexTarget;
            this.txtDirectorySource.Text = Settings.Default.DirectorySource;
            this.txtDirectoryTarget.Text = Settings.Default.DirectoryTarget;

            switch ((ProcessAction)Settings.Default.ProcessAction)
            {
                case ProcessAction.Copy:
                    this.rabCopyFiles.Checked = true;
                    break;
                case ProcessAction.Move:
                    this.rabMoveFiles.Checked = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Settings.Default.ProcessAction", nameof(Settings.Default.ProcessAction));
            }

            this.chkCopyMoveFiles_CheckedChanged(this, new EventArgs());

            this.SetExistingFileTextBoxes(null);
            this._systemChanged = false;
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
        private void btnDirectorySource_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FolderBrowserDialog = new FolderBrowserDialog
            {
                Description = Stringtable._0x0003,
                SelectedPath = this.txtDirectorySource.Text
            };
            if (FolderBrowserDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.txtDirectorySource.Text = FolderBrowserDialog.SelectedPath;
            }
        }

        private void btnDirectoryTarget_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FolderBrowserDialog = new FolderBrowserDialog
            {
                Description = Stringtable._0x0004,
                SelectedPath = this.txtDirectoryTarget.Text
            };
            if (FolderBrowserDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.txtDirectoryTarget.Text = FolderBrowserDialog.SelectedPath;
            }
        }

        private void MainForm_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            System.Reflection.Assembly Assembly = System.Reflection.Assembly.GetExecutingAssembly();
            Image AppImage = Resources.program_symbol_256;
            Image ProImage = null;
            AboutForm AboutForm = new AboutForm(Assembly, AppImage, ProImage)
            {
                Credits = Resources.Credits,
                LicenseDirectory = System.IO.Path.GetDirectoryName(Assembly.Location) + @"\Licenses\",
                ShowUpdateControles = true,
                UpdateOnStartup = Settings.Default.AppUpdate_CheckAtStartUp
            };
            AboutForm.CheckForUpdate += new LinkLabelLinkClickedEventHandler(delegate (object s, LinkLabelLinkClickedEventArgs ea)
            {
                Program.CheckForUpdate(this, false);
            });
            AboutForm.UpdateOnStartupChanged += new EventHandler(delegate (object s, EventArgs ea)
            {
                Settings.Default.AppUpdate_CheckAtStartUp = AboutForm.UpdateOnStartup;
                Settings.Default.Save();
            });
            AboutForm.Show(this);
            e.Cancel = true;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            // Check for Updates for the Apllication
            if (Settings.Default.AppUpdate_CheckAtStartUp) Program.CheckForUpdate(this, true);
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

        private void chkCopyMoveFiles_CheckedChanged(object sender, EventArgs e)
        {
            this.chkCopyMoveKeepStucture.Enabled = this.chkCopyMoveFiles.Checked;
            this.rabCopyFiles.Enabled = this.chkCopyMoveFiles.Checked;
            this.rabMoveFiles.Enabled = this.chkCopyMoveFiles.Checked;

            if (this._systemChanged) return;
            Settings.Default.CopyMoveFiles = this.chkCopyMoveFiles.Checked;
            Settings.Default.Save();
        }
        private void chkCopyMoveKeepStucture_CheckedChanged(object sender, EventArgs e)
        {
            if (this._systemChanged) return;
            Settings.Default.CopyMoveKeepStructure = this.chkCopyMoveKeepStucture.Checked;
            Settings.Default.Save();
        }

        private void chkCreateIndex_CheckedChanged(object sender, EventArgs e)
        {
            if (this._systemChanged) return;
            this.txtCreateIndex.Enabled = this.chkCreateIndex.Checked;

            Settings.Default.CreateIndex = this.chkCreateIndex.Checked;
            Settings.Default.Save();
        }

        private void rabCopyFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (this._systemChanged) return;
            this.rabMoveFiles.Checked = !this.rabCopyFiles.Checked;

            if (this.rabCopyFiles.Checked)
            {
                Settings.Default.ProcessAction = (int)ProcessAction.Copy;
                Settings.Default.Save();
            }
        }

        private void rabMoveFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (this._systemChanged) return;
            this.rabCopyFiles.Checked = !this.rabMoveFiles.Checked;

            if (this.rabMoveFiles.Checked)
            {
                Settings.Default.ProcessAction = (int)ProcessAction.Move;
                Settings.Default.Save();
            }
        }

        private void txtCreateIndex_TextChanged(object sender, EventArgs e)
        {
            if (this._systemChanged) return;
            Settings.Default.CreateIndexTarget = this.txtCreateIndex.Text;
            Settings.Default.Save();
        }

        private void txtDirectorySource_TextChanged(object sender, EventArgs e)
        {
            if (this._systemChanged) return;
            Settings.Default.DirectorySource = this.txtDirectorySource.Text;
            Settings.Default.Save();
        }

        private void txtDirectoryTarget_TextChanged(object sender, EventArgs e)
        {
            if (this._systemChanged) return;
            Settings.Default.DirectoryTarget = this.txtDirectoryTarget.Text;
            Settings.Default.Save();
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
            if (!this.chkCopyMoveFiles.Checked && !this.chkCreateIndex.Checked)
            {
                MessageBox.Show(this, Stringtable._0x0005m, Stringtable._0x0005c, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
            this._fileMover = new FileMover.FileMover(this._locker, this);
            this._fileMover.ExistingFileSettingsChanged += new EventHandler(this.FileMover_ExistingFileSettingsChanged);
            this._fileMover.Count(this._bgwWorker, e);
            this._fileMover.Move(this._bgwWorker, e);
        }

        private void bgwWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Use the progress in percentage to differ the different steps.
            // It looks a little bit stange. The real progress is stored in an member of this class.
            // Try to save the step in an member, lead to glitches. I used the ProgressPercentage as work around
            bool ForceReport = false;
            if (e.UserState != null && e.UserState.GetType().Equals(typeof(bool))) ForceReport = (bool)e.UserState;

            // Report Progress by time Interval or if report is forced
            if (ForceReport || this._fileMover.CheckUpdateInterval())
            {
                this._fileMover.TimeLastReport = DateTime.Now;

                FileMover.FileMover.ProcessStep ProcessStep = (FileMover.FileMover.ProcessStep)e.ProgressPercentage;
                switch (ProcessStep)
                {
                    case FileMover.FileMover.ProcessStep.Count_Start:
                        ExtProgrBarInv.Style(this.epbProgress, ProgressBarStyle.Marquee);
                        TextBoxInv.Text(this.txtRemainTime, "");
                        break;
                    case FileMover.FileMover.ProcessStep.Count_Busy:
                        ExtProgrBarInv.Value(this.epbProgress, this._fileMover.FileTotalCount);
                        break;
                    case FileMover.FileMover.ProcessStep.Count_Finish:
                        ExtProgrBarInv.Style(this.epbProgress, ProgressBarStyle.Blocks);
                        ExtProgrBarInv.Value(this.epbProgress, 0);
                        break;
                    case FileMover.FileMover.ProcessStep.Move_Start:
                        ExtProgrBarInv.MaxValue(this.epbProgress, this._fileMover.FileTotalCount);
                        ExtProgrBarInv.Style(this.epbProgress, ProgressBarStyle.Blocks);
                        ExtProgrBarInv.Value(this.epbProgress, 0);
                        TextBoxInv.Text(this.txtRemainTime, "");
                        break;
                    case FileMover.FileMover.ProcessStep.Move_Busy:
                        ExtProgrBarInv.Value(this.epbProgress, this._fileMover.TotalFilesHandled);

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
                    case FileMover.FileMover.ProcessStep.Move_Finish:
                        ExtProgrBarInv.Value(this.epbProgress, this._fileMover.FileMove);
                        break;
                    case FileMover.FileMover.ProcessStep.Cancel:
                    case FileMover.FileMover.ProcessStep.Exception:
                        ExtProgrBarInv.Style(this.epbProgress, ProgressBarStyle.Blocks);
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

        private void FileMover_ExistingFileSettingsChanged(object sender, EventArgs e)
        {
            this.SetExistingFileTextBoxes(null);
        }
        #endregion
        #endregion
    }
}