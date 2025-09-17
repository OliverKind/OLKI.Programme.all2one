/*
 * all2one - File mover
 * 
 * Copyright:   Oliver Kind - 2020
 * License:     LGPL
 * 
 * Desctiption:
 * Functions to count files in source directories and move files from
 * source directories to target directory
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

using OLKI.Programme.all2one.src.Forms;
using System;
using System.Threading;

namespace OLKI.Programme.all2one.src.FileMover
{
    public partial class FileMover
    {
        #region Constants
        /// <summary>
        /// A flag that forces reporting the progress.
        /// </summary>
        public const bool FORCE_REPORTING_FLAG = true;

        /// <summary>
        /// Time intervall in seconds to update the progress
        /// </summary>
        private const double PROGRESS_UPDATE_INTERVALL = 0.1;

        /// <summary>
        /// Represents the character used to replace backslashes if keeping directory structure.
        /// </summary>
        private const char REPLACE_FOR_BACKSLASH = '@';
        #endregion

        #region Events
        /// <summary>
        /// Event to indicate that the settings for existing files have changed
        /// </summary>
        public event EventHandler ExistingFileSettingsChanged;
        #endregion

        #region Enums
        /// <summary>
        /// Specifies the type of action to perform on the main process
        /// </summary>
        internal enum ProcessAction
        {
            Copy,
            Move
        }

        /// <summary>
        /// An enomeration to indicate the step of an process
        /// </summary>
        internal enum ProcessStep
        {
            None,
            Count_Start,
            Count_Busy,
            Count_Finish,
            Move_Start,
            Move_Busy,
            Move_Finish,
            Cancel,
            Exception
        }
        #endregion

        #region Fields
        /// <summary>
        /// Locks to lock the BackgroundWorker
        /// </summary>
        private readonly ManualResetEvent _locker = new ManualResetEvent(true);

        /// <summary>
        /// Application MainForm to have it as owner for MessageBoxes
        /// </summary>
        private readonly MainForm _mainForm;

        /// <summary>
        /// Indicates whether exceptions should be suppressed during the operation.
        /// </summary>
        private bool _supressException = false;
        #endregion

        #region Properties
        /// <summary>
        /// Number of total counted files to move
        /// </summary>
        public int FileTotalCount { get; set; } = 0;
        /// <summary>
        /// Number of moved files
        /// </summary>
        public int FileMove { get; set; } = 0;
        /// <summary>
        /// Number of skiped files
        /// </summary>
        public int FileSkip { get; set; } = 0;
        /// <summary>
        /// Number of files with exception while moving
        /// </summary>
        public int FileExceptions { get; set; } = 0;
        /// <summary>
        /// Total handeld files while moving
        /// </summary>
        public int TotalFilesHandled
        {
            get
            {
                return this.FileMove + this.FileSkip + this.FileExceptions;
            }
        }
        /// <summary>
        /// Time of the last shown report
        /// </summary>
        public DateTime TimeLastReport { get; set; } = DateTime.Now;
        /// <summary>
        /// Time where the moving process started
        /// </summary>
        public DateTime TimeProcessStart { get; set; }
        #endregion

        #region Methodes
        /// <summary>
        /// Initial a new file mover object
        /// </summary>
        /// <param name="locker">Locks ofject to lcok the BackgroundWorker</param>
        /// <param name="mainForm">Application MainForm to have it as owner for MessageBoxes</param>
        public FileMover(ManualResetEvent locker, MainForm mainForm)
        {
            this._locker = locker;
            this._mainForm = mainForm;
        }

        /// <summary>
        /// Check time interval for reporting progress
        /// </summary>
        /// <returns>True if an update of the controles should been done</returns>
        public bool CheckUpdateInterval()
        {
            // Check by TimeSpan
            TimeSpan TimeSpan = DateTime.Now - this.TimeLastReport;
            double TimeSinceLastUpdate = TimeSpan.TotalMilliseconds / 1000;
            if (TimeSinceLastUpdate >= PROGRESS_UPDATE_INTERVALL) return true;

            //No update requested
            return false;
        }
        #endregion
    }
}