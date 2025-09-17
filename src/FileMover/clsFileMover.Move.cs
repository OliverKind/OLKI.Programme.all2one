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
        /// Generates the target file name for a given source file based on the settings.
        /// </summary>
        /// <param name="sourceFile">The source file for which the target file name is being generated.</param>
        /// <param name="actualRelativePath">The actual relative path of the file.</param>
        /// <returns>The full path of the target file name.</returns>
        private string GetTargetFileName(FileInfo sourceFile, out string actualRelativePath)
        {
            actualRelativePath = GetRelativeDirectory(sourceFile.Directory);
            if (Settings.Default.CopyMoveKeepStructure)
            {
                return System.IO.Path.Combine(Settings.Default.DirectoryTarget, actualRelativePath.Replace('\\', REPLACE_FOR_BACKSLASH) + sourceFile.Name);
            }
            else
            {
                return Settings.Default.DirectoryTarget + @"\" + sourceFile.Name;
            }
        }

        /// <summary>
        /// Get the relative directory path of the specified source directory based on the configured source directory path.
        /// </summary>
        /// <returns>A string representing the relative directory path. Returns . if the source directory matches the source directory, relative path prefixed with.</returns>
        private string GetRelativeDirectory(DirectoryInfo SoruceDirecotry)
        {
            string actualRelativePath = SoruceDirecotry.FullName.Substring(Settings.Default.DirectorySource.Length, SoruceDirecotry.FullName.Length - Settings.Default.DirectorySource.Length);
            return (actualRelativePath.Length <= 0 ? "." : @".\" + actualRelativePath.Substring(1, actualRelativePath.Length - 1)) + @"\";
        }

        /// <summary>
        /// Move files from source directory to target directory
        /// </summary>
        /// <param name="worker">BackgroundWorker for move</param>
        /// <param name="e">Provides data for the BackgroundWorker</param>
        public void Move(BackgroundWorker worker, DoWorkEventArgs e)
        {
            this._supressException = false;
            worker.ReportProgress((int)ProcessStep.Move_Start, FORCE_REPORTING_FLAG);
            this.TimeProcessStart = DateTime.Now;

            if (Settings.Default.CreateIndex) this.WriteIndex("", false);
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

            if (Settings.Default.CreateIndex) this.WriteIndex(this.GetRelativeDirectory(directory), true);

            //Move files
            foreach (FileInfo File in directory.GetFiles().OrderBy(f => f.FullName))
            {
                if (worker.CancellationPending) { e.Cancel = true; return; }
                _locker.WaitOne();

                if (Settings.Default.CreateIndex) this.WriteIndex("\t" + File.Name, true);
                if (Settings.Default.CopyMoveFiles) this.MoveFile(File, worker, e);
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
            FileInfo TargetFile = new FileInfo(GetTargetFileName(sourceFile, out string ActualRelativePath));
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
                switch ((ProcessAction)Settings.Default.ProcessAction)
                {
                    case ProcessAction.Copy:
                        System.IO.File.Copy(sourceFile.FullName, TargetFile.FullName);
                        break;
                    case ProcessAction.Move:
                        System.IO.File.Move(sourceFile.FullName, TargetFile.FullName);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Settings.Default.ProcessAction", nameof(Settings.Default.ProcessAction));
                }

                this.FileMove++;
                return true;
            }
            catch (Exception ex)
            {
                this._mainForm.Invoke((Func<DialogResult>)(() => MessageBox.Show(this._mainForm, string.Format(Stringtable._0x0001m, new object[] { sourceFile.FullName, TargetFile.FullName, ex.Message }), Stringtable._0x0001c, MessageBoxButtons.OK, MessageBoxIcon.Error)));
                this.FileExceptions++;
                return false;
            }
        }

        /// <summary>
        /// Write to Logfile
        /// </summary>
        /// <param name="text">Text to write</param>
        /// <param name="writeLine">Ture if write to new line, otherwise false</param>
        private void WriteIndex(string text, bool writeLine)
        {
            try
            {
                if (Settings.Default.CreateIndex)
                {
                    using (StreamWriter outputFile = new StreamWriter(System.IO.Path.Combine(Settings.Default.DirectoryTarget, Settings.Default.CreateIndexTarget), true))
                    {
                        if (!writeLine) outputFile.Write(text);
                        if (writeLine) outputFile.WriteLine(text);
                    }
                }
            }
            catch (Exception ex)
            {
                if (this._supressException) return;
                this._mainForm.Invoke((Func<DialogResult>)(() => MessageBox.Show(this._mainForm, string.Format(Stringtable._0x0007m, new object[] { ex.Message }), Stringtable._0x0007c, MessageBoxButtons.OK, MessageBoxIcon.Error)));
                this._supressException = true;
            }
        }
    }
}