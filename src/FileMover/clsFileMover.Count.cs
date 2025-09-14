/*
 * all2one - File mover
 * 
 * Copyright:   Oliver Kind - 2020
 * License:     LGPL
 * 
 * Desctiption:
 * Functions to count files in source directories
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

using System.ComponentModel;
using System.IO;
using System.Linq;

namespace OLKI.Programme.all2one.src.FileMover
{
    public partial class FileMover
    {
        /// <summary>
        /// Count files from source directory to target directory
        /// </summary>
        /// <param name="worker">BackgroundWorker for move</param>
        /// <param name="e">Provides data for the BackgroundWorker</param>
        public void Count(BackgroundWorker worker, DoWorkEventArgs e)
        {
            worker.ReportProgress((int)ProcessStep.Count_Start, FORCE_REPORTING_FLAG);
            this.CountRecursive(new DirectoryInfo(this._source), worker, e);
            worker.ReportProgress((int)ProcessStep.Count_Finish, FORCE_REPORTING_FLAG);
        }

        /// <summary>
        /// Count file from source directory and all sub directries to target directory
        /// </summary>
        /// <param name="directory">Directroy to move files and go to sub directories</param>
        /// <param name="worker">BackgroundWorker for move</param>
        /// <param name="e">Provides data for the BackgroundWorker</param>
        private void CountRecursive(DirectoryInfo directory, BackgroundWorker worker, DoWorkEventArgs e)
        {
            if (worker.CancellationPending) { e.Cancel = true; return; }

            //Get Files
            this.FileTotalCount += directory.GetFiles().Count();
            worker.ReportProgress((int)ProcessStep.Count_Busy);

            //Get sub directorys
            foreach (DirectoryInfo Directory in directory.GetDirectories().OrderBy(d => d.FullName))
            {
                if (worker.CancellationPending) { e.Cancel = true; return; }
                _locker.WaitOne();
                this.CountRecursive(Directory, worker, e);
            }
        }
    }
}