/*
 * all2one - File mover
 * 
 * Copyright:   Oliver Kind - 2020
 * License:     LGPL
 * 
 * Desctiption:
 * Functions to move files from source directories to target directory
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
using OLKI.Toolbox.DirectoryAndFile;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OLKI.Programme.all2one.src.FileMover
{
    public partial class FileMover
    {
        /// <summary>
        /// Move files from source directory to target directory
        /// </summary>
        /// <param name="worker">BackgroundWorker for move</param>
        /// <param name="e">Provides data for the BackgroundWorker</param>
        public void Move(BackgroundWorker worker, DoWorkEventArgs e)
        {
            worker.ReportProgress((int)ProcessStep.Move_Start, FORCE_REPORTING_FLAG);
            this.TimeProcessStart = DateTime.Now;
            this.MoveRecursive(new DirectoryInfo(Settings.Default.DirectorySource), worker, e);
            worker.ReportProgress((int)ProcessStep.Move_Finish, FORCE_REPORTING_FLAG);
        }

        /// <summary>
        /// Move file from source directory and all sub directries to target directory
        /// </summary>
        /// <param name="directory">Directroy to move files and go to sub directories</param>
        /// <param name="worker">BackgroundWorker for move</param>
        /// <param name="e">Provides data for the BackgroundWorker</param>
        private void MoveRecursive(DirectoryInfo directory, BackgroundWorker worker, DoWorkEventArgs e)
        {
            if (worker.CancellationPending) { e.Cancel = true; return; }

            //Move files
            foreach (FileInfo File in directory.GetFiles().OrderBy(f => f.FullName))
            {
                if (worker.CancellationPending) { e.Cancel = true; return; }
                _locker.WaitOne();

                this.MoveFile(File, worker, e);
                worker.ReportProgress((int)ProcessStep.Move_Busy);
            }

            //Move file in sub directorys
            foreach (DirectoryInfo Directory in directory.GetDirectories().OrderBy(d => d.FullName))
            {
                if (worker.CancellationPending) { e.Cancel = true; return; }
                _locker.WaitOne();

                this.MoveRecursive(Directory, worker, e);
            }
        }

        /// <summary>
        /// Move the specified file to target directroy
        /// </summary>
        /// <param name="sourceFile">Soruce file to move to target directroy</param>
        /// <param name="worker">BackgroundWorker for move</param>
        /// <param name="e">Provides data for the BackgroundWorker</param>
        /// <returns>True if files was moves sucessfull</returns>
        private bool MoveFile(FileInfo sourceFile, BackgroundWorker worker, DoWorkEventArgs e)
        {
            FileInfo TargetFile = new FileInfo(Settings.Default.DirectoryTarget + @"\" + sourceFile.Name);
            try
            {
                if (TargetFile.Exists)
                {
                    HandleExistingFiles.CheckResult HandleFile = HandleExistingFiles.GetOverwriteByAction(sourceFile, TargetFile, Settings.Default.ExistingFile_DateFormat, (HandleExistingFiles.HowToHandleExistingItem)Settings.Default.ExistingFile_Handle, Settings.Default.ExistingFile_AddText, false, out _, this._mainForm);

                    if (HandleFile.FormResult == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                        worker.CancelAsync();
                        return false;
                    }

                    if (HandleFile.RememberAction)
                    {
                        Settings.Default.ExistingFile_AddText = HandleFile.AddText;
                        Settings.Default.ExistingFile_Handle = (int)HandleFile.SelectedAction;
                        Settings.Default.Save();

                        this.ExistingFileSettingsChanged?.Invoke(this, new EventArgs());
                    }

                    //Handle overwrite state
                    switch (HandleFile.OverwriteFile)
                    {
                        case HandleExistingFiles.ExistingFile.Exception:
                            this.FileExceptions++;
                            return false;
                        case HandleExistingFiles.ExistingFile.Overwrite:
                            TargetFile.Delete();
                            break;
                        case HandleExistingFiles.ExistingFile.Rename:
                            //Nothing to do, rename done by "HandleExistingFiles"
                            break;
                        case HandleExistingFiles.ExistingFile.Skip:
                            this.FileSkip++;
                            return false;
                    }
                }

                // Move file
                //TODO: System.IO.File.Move(sourceFile.FullName, TargetFile.FullName);
                this.FileMove++;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this._mainForm, string.Format(Stringtable._0x0001m, new object[] { sourceFile.FullName, TargetFile.FullName, ex.Message }), Stringtable._0x0001c, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.FileExceptions++;
                return false;
            }
        }
    }
}