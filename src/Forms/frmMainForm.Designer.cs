namespace OLKI.Programme.all2one.src.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtDirectorySource = new System.Windows.Forms.TextBox();
            this.txtDirectoryTarget = new System.Windows.Forms.TextBox();
            this.lblDirectorySource = new System.Windows.Forms.Label();
            this.lblDirectoryTarget = new System.Windows.Forms.Label();
            this.grbHandleExistingFiles = new System.Windows.Forms.GroupBox();
            this.lblAddTextToExistingFileText = new System.Windows.Forms.Label();
            this.txtAddTextToExistingFileText = new System.Windows.Forms.TextBox();
            this.txtHandleExistingFileText = new System.Windows.Forms.TextBox();
            this.btnHandleExistingFile_SetDefault = new System.Windows.Forms.Button();
            this.btnProcessCancel = new System.Windows.Forms.Button();
            this.btnProcessStart = new System.Windows.Forms.Button();
            this.btnDirectorySource = new System.Windows.Forms.Button();
            this.btnDirectoryTarget = new System.Windows.Forms.Button();
            this.txtRemainTime = new System.Windows.Forms.TextBox();
            this.lblRemainTime = new System.Windows.Forms.Label();
            this.btnProcessPause = new System.Windows.Forms.Button();
            this.epbProgress = new OLKI.Toolbox.Widgets.ExtProgressBar();
            this.chkCopyMoveFiles = new System.Windows.Forms.CheckBox();
            this.chkCreateIndex = new System.Windows.Forms.CheckBox();
            this.txtCreateIndex = new System.Windows.Forms.TextBox();
            this.rabCopyFiles = new System.Windows.Forms.RadioButton();
            this.rabMoveFiles = new System.Windows.Forms.RadioButton();
            this.chkCopyMoveKeepStucture = new System.Windows.Forms.CheckBox();
            this.grbExceptions = new System.Windows.Forms.GroupBox();
            this.lsvExceptions = new OLKI.Toolbox.Widgets.SortListView();
            this.chLsvExceptionsSource = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLsvExceptionsTarget = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLsvExceptionsException = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grbHandleExistingFiles.SuspendLayout();
            this.grbExceptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDirectorySource
            // 
            this.txtDirectorySource.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDirectorySource.Location = new System.Drawing.Point(82, 12);
            this.txtDirectorySource.Name = "txtDirectorySource";
            this.txtDirectorySource.Size = new System.Drawing.Size(354, 20);
            this.txtDirectorySource.TabIndex = 1;
            this.txtDirectorySource.TextChanged += new System.EventHandler(this.txtDirectorySource_TextChanged);
            // 
            // txtDirectoryTarget
            // 
            this.txtDirectoryTarget.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDirectoryTarget.Location = new System.Drawing.Point(82, 38);
            this.txtDirectoryTarget.Name = "txtDirectoryTarget";
            this.txtDirectoryTarget.Size = new System.Drawing.Size(354, 20);
            this.txtDirectoryTarget.TabIndex = 4;
            this.txtDirectoryTarget.TextChanged += new System.EventHandler(this.txtDirectoryTarget_TextChanged);
            // 
            // lblDirectorySource
            // 
            this.lblDirectorySource.AutoSize = true;
            this.lblDirectorySource.Location = new System.Drawing.Point(12, 15);
            this.lblDirectorySource.Name = "lblDirectorySource";
            this.lblDirectorySource.Size = new System.Drawing.Size(64, 13);
            this.lblDirectorySource.TabIndex = 0;
            this.lblDirectorySource.Text = "Quellordner:";
            // 
            // lblDirectoryTarget
            // 
            this.lblDirectoryTarget.AutoSize = true;
            this.lblDirectoryTarget.Location = new System.Drawing.Point(12, 41);
            this.lblDirectoryTarget.Name = "lblDirectoryTarget";
            this.lblDirectoryTarget.Size = new System.Drawing.Size(57, 13);
            this.lblDirectoryTarget.TabIndex = 3;
            this.lblDirectoryTarget.Text = "Zielordner:";
            // 
            // grbHandleExistingFiles
            // 
            this.grbHandleExistingFiles.Controls.Add(this.lblAddTextToExistingFileText);
            this.grbHandleExistingFiles.Controls.Add(this.txtAddTextToExistingFileText);
            this.grbHandleExistingFiles.Controls.Add(this.txtHandleExistingFileText);
            this.grbHandleExistingFiles.Controls.Add(this.btnHandleExistingFile_SetDefault);
            this.grbHandleExistingFiles.Location = new System.Drawing.Point(12, 64);
            this.grbHandleExistingFiles.Name = "grbHandleExistingFiles";
            this.grbHandleExistingFiles.Size = new System.Drawing.Size(350, 100);
            this.grbHandleExistingFiles.TabIndex = 6;
            this.grbHandleExistingFiles.TabStop = false;
            this.grbHandleExistingFiles.Text = "Verhalten bei vorhandenen Dateien";
            // 
            // lblAddTextToExistingFileText
            // 
            this.lblAddTextToExistingFileText.AutoSize = true;
            this.lblAddTextToExistingFileText.Location = new System.Drawing.Point(6, 77);
            this.lblAddTextToExistingFileText.Name = "lblAddTextToExistingFileText";
            this.lblAddTextToExistingFileText.Size = new System.Drawing.Size(82, 13);
            this.lblAddTextToExistingFileText.TabIndex = 2;
            this.lblAddTextToExistingFileText.Text = "Text anhängen:";
            // 
            // txtAddTextToExistingFileText
            // 
            this.txtAddTextToExistingFileText.Location = new System.Drawing.Point(94, 74);
            this.txtAddTextToExistingFileText.Name = "txtAddTextToExistingFileText";
            this.txtAddTextToExistingFileText.ReadOnly = true;
            this.txtAddTextToExistingFileText.Size = new System.Drawing.Size(250, 20);
            this.txtAddTextToExistingFileText.TabIndex = 3;
            // 
            // txtHandleExistingFileText
            // 
            this.txtHandleExistingFileText.Location = new System.Drawing.Point(6, 48);
            this.txtHandleExistingFileText.Name = "txtHandleExistingFileText";
            this.txtHandleExistingFileText.ReadOnly = true;
            this.txtHandleExistingFileText.Size = new System.Drawing.Size(338, 20);
            this.txtHandleExistingFileText.TabIndex = 1;
            // 
            // btnHandleExistingFile_SetDefault
            // 
            this.btnHandleExistingFile_SetDefault.Image = global::OLKI.Programme.all2one.Properties.Resources.HandleExistingFile;
            this.btnHandleExistingFile_SetDefault.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHandleExistingFile_SetDefault.Location = new System.Drawing.Point(6, 19);
            this.btnHandleExistingFile_SetDefault.Name = "btnHandleExistingFile_SetDefault";
            this.btnHandleExistingFile_SetDefault.Size = new System.Drawing.Size(338, 23);
            this.btnHandleExistingFile_SetDefault.TabIndex = 0;
            this.btnHandleExistingFile_SetDefault.Text = "Standardaktion auswählen";
            this.btnHandleExistingFile_SetDefault.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHandleExistingFile_SetDefault.UseVisualStyleBackColor = true;
            this.btnHandleExistingFile_SetDefault.Click += new System.EventHandler(this.btnHandleExistingFile_SetDefault_Click);
            // 
            // btnProcessCancel
            // 
            this.btnProcessCancel.Enabled = false;
            this.btnProcessCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnProcessCancel.Image = global::OLKI.Programme.all2one.Properties.Resources.Cancel;
            this.btnProcessCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProcessCancel.Location = new System.Drawing.Point(368, 286);
            this.btnProcessCancel.Name = "btnProcessCancel";
            this.btnProcessCancel.Size = new System.Drawing.Size(204, 68);
            this.btnProcessCancel.TabIndex = 17;
            this.btnProcessCancel.Text = "Abbrechen";
            this.btnProcessCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProcessCancel.UseVisualStyleBackColor = true;
            this.btnProcessCancel.Click += new System.EventHandler(this.btnProcessCancel_Click);
            // 
            // btnProcessStart
            // 
            this.btnProcessStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessStart.Image = global::OLKI.Programme.all2one.Properties.Resources.Start;
            this.btnProcessStart.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProcessStart.Location = new System.Drawing.Point(12, 286);
            this.btnProcessStart.Name = "btnProcessStart";
            this.btnProcessStart.Size = new System.Drawing.Size(270, 68);
            this.btnProcessStart.TabIndex = 15;
            this.btnProcessStart.Text = "Daten verschieben";
            this.btnProcessStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProcessStart.UseVisualStyleBackColor = true;
            this.btnProcessStart.Click += new System.EventHandler(this.btnProcessStart_Click);
            // 
            // btnDirectorySource
            // 
            this.btnDirectorySource.Image = global::OLKI.Programme.all2one.Properties.Resources.Browse;
            this.btnDirectorySource.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDirectorySource.Location = new System.Drawing.Point(442, 10);
            this.btnDirectorySource.Name = "btnDirectorySource";
            this.btnDirectorySource.Size = new System.Drawing.Size(130, 23);
            this.btnDirectorySource.TabIndex = 2;
            this.btnDirectorySource.Text = "Durchsuchen";
            this.btnDirectorySource.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDirectorySource.UseVisualStyleBackColor = true;
            this.btnDirectorySource.Click += new System.EventHandler(this.btnDirectorySource_Click);
            // 
            // btnDirectoryTarget
            // 
            this.btnDirectoryTarget.Image = global::OLKI.Programme.all2one.Properties.Resources.Browse;
            this.btnDirectoryTarget.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDirectoryTarget.Location = new System.Drawing.Point(442, 36);
            this.btnDirectoryTarget.Name = "btnDirectoryTarget";
            this.btnDirectoryTarget.Size = new System.Drawing.Size(130, 23);
            this.btnDirectoryTarget.TabIndex = 5;
            this.btnDirectoryTarget.Text = "Durchsuchen";
            this.btnDirectoryTarget.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDirectoryTarget.UseVisualStyleBackColor = true;
            this.btnDirectoryTarget.Click += new System.EventHandler(this.btnDirectoryTarget_Click);
            // 
            // txtRemainTime
            // 
            this.txtRemainTime.Location = new System.Drawing.Point(368, 144);
            this.txtRemainTime.Name = "txtRemainTime";
            this.txtRemainTime.ReadOnly = true;
            this.txtRemainTime.Size = new System.Drawing.Size(204, 20);
            this.txtRemainTime.TabIndex = 8;
            // 
            // lblRemainTime
            // 
            this.lblRemainTime.AutoSize = true;
            this.lblRemainTime.Location = new System.Drawing.Point(368, 128);
            this.lblRemainTime.Name = "lblRemainTime";
            this.lblRemainTime.Size = new System.Drawing.Size(105, 13);
            this.lblRemainTime.TabIndex = 7;
            this.lblRemainTime.Text = "Geschätzte Restzeit:";
            // 
            // btnProcessPause
            // 
            this.btnProcessPause.Enabled = false;
            this.btnProcessPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessPause.Image = global::OLKI.Programme.all2one.Properties.Resources.Pause;
            this.btnProcessPause.Location = new System.Drawing.Point(288, 286);
            this.btnProcessPause.Name = "btnProcessPause";
            this.btnProcessPause.Size = new System.Drawing.Size(74, 68);
            this.btnProcessPause.TabIndex = 16;
            this.btnProcessPause.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProcessPause.UseVisualStyleBackColor = true;
            this.btnProcessPause.Click += new System.EventHandler(this.btnProcessPause_Click);
            // 
            // epbProgress
            // 
            this.epbProgress.AutoByteDimension = false;
            this.epbProgress.ByteDimension = OLKI.Toolbox.DirectoryAndFile.FileSize.Dimension.NoDimension;
            this.epbProgress.DecimalDigits = ((uint)(0u));
            this.epbProgress.Location = new System.Drawing.Point(12, 360);
            this.epbProgress.MinimumSize = new System.Drawing.Size(300, 23);
            this.epbProgress.Name = "epbProgress";
            this.epbProgress.ShowDescriptionText = false;
            this.epbProgress.ShowDimensionComboBox = false;
            this.epbProgress.Size = new System.Drawing.Size(560, 23);
            this.epbProgress.TabIndex = 18;
            // 
            // chkCopyMoveFiles
            // 
            this.chkCopyMoveFiles.AutoSize = true;
            this.chkCopyMoveFiles.Location = new System.Drawing.Point(12, 171);
            this.chkCopyMoveFiles.Name = "chkCopyMoveFiles";
            this.chkCopyMoveFiles.Size = new System.Drawing.Size(256, 17);
            this.chkCopyMoveFiles.TabIndex = 9;
            this.chkCopyMoveFiles.Text = "Dateien im Zielverzeichnis verschieben/kopieren";
            this.chkCopyMoveFiles.UseVisualStyleBackColor = true;
            this.chkCopyMoveFiles.CheckedChanged += new System.EventHandler(this.chkCopyMoveFiles_CheckedChanged);
            // 
            // chkCreateIndex
            // 
            this.chkCreateIndex.AutoSize = true;
            this.chkCreateIndex.Location = new System.Drawing.Point(12, 263);
            this.chkCreateIndex.Name = "chkCreateIndex";
            this.chkCreateIndex.Size = new System.Drawing.Size(259, 17);
            this.chkCreateIndex.TabIndex = 13;
            this.chkCreateIndex.Text = "Index Datei der Quelle im Zielverzeichnis erstellen";
            this.chkCreateIndex.UseVisualStyleBackColor = true;
            this.chkCreateIndex.CheckedChanged += new System.EventHandler(this.chkCreateIndex_CheckedChanged);
            // 
            // txtCreateIndex
            // 
            this.txtCreateIndex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCreateIndex.Location = new System.Drawing.Point(277, 260);
            this.txtCreateIndex.Name = "txtCreateIndex";
            this.txtCreateIndex.Size = new System.Drawing.Size(295, 20);
            this.txtCreateIndex.TabIndex = 14;
            this.txtCreateIndex.TextChanged += new System.EventHandler(this.txtCreateIndex_TextChanged);
            // 
            // rabCopyFiles
            // 
            this.rabCopyFiles.AutoSize = true;
            this.rabCopyFiles.Location = new System.Drawing.Point(36, 217);
            this.rabCopyFiles.Name = "rabCopyFiles";
            this.rabCopyFiles.Size = new System.Drawing.Size(106, 17);
            this.rabCopyFiles.TabIndex = 11;
            this.rabCopyFiles.TabStop = true;
            this.rabCopyFiles.Text = "Dateien kopieren";
            this.rabCopyFiles.UseVisualStyleBackColor = true;
            this.rabCopyFiles.CheckedChanged += new System.EventHandler(this.rabCopyFiles_CheckedChanged);
            // 
            // rabMoveFiles
            // 
            this.rabMoveFiles.AutoSize = true;
            this.rabMoveFiles.Location = new System.Drawing.Point(36, 240);
            this.rabMoveFiles.Name = "rabMoveFiles";
            this.rabMoveFiles.Size = new System.Drawing.Size(123, 17);
            this.rabMoveFiles.TabIndex = 12;
            this.rabMoveFiles.TabStop = true;
            this.rabMoveFiles.Text = "Dateien verschieben";
            this.rabMoveFiles.UseVisualStyleBackColor = true;
            this.rabMoveFiles.CheckedChanged += new System.EventHandler(this.rabMoveFiles_CheckedChanged);
            // 
            // chkCopyMoveKeepStucture
            // 
            this.chkCopyMoveKeepStucture.AutoSize = true;
            this.chkCopyMoveKeepStucture.Location = new System.Drawing.Point(36, 194);
            this.chkCopyMoveKeepStucture.Name = "chkCopyMoveKeepStucture";
            this.chkCopyMoveKeepStucture.Size = new System.Drawing.Size(324, 17);
            this.chkCopyMoveKeepStucture.TabIndex = 10;
            this.chkCopyMoveKeepStucture.Text = "Ordnerstruktur im Dateinamen behlaten (\\ wird ersetzt druch @)";
            this.chkCopyMoveKeepStucture.UseVisualStyleBackColor = true;
            this.chkCopyMoveKeepStucture.CheckedChanged += new System.EventHandler(this.chkCopyMoveKeepStucture_CheckedChanged);
            // 
            // grbExceptions
            // 
            this.grbExceptions.Controls.Add(this.lsvExceptions);
            this.grbExceptions.Location = new System.Drawing.Point(12, 389);
            this.grbExceptions.Name = "grbExceptions";
            this.grbExceptions.Size = new System.Drawing.Size(560, 260);
            this.grbExceptions.TabIndex = 19;
            this.grbExceptions.TabStop = false;
            this.grbExceptions.Text = "Fehlerliste";
            // 
            // lsvExceptions
            // 
            this.lsvExceptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lsvExceptions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chLsvExceptionsSource,
            this.chLsvExceptionsTarget,
            this.chLsvExceptionsException});
            this.lsvExceptions.ColumnWidths = ((System.Collections.Generic.List<int>)(resources.GetObject("lsvExceptions.ColumnWidths")));
            this.lsvExceptions.GridLines = true;
            this.lsvExceptions.HideSelection = false;
            this.lsvExceptions.Location = new System.Drawing.Point(0, 19);
            this.lsvExceptions.Name = "lsvExceptions";
            this.lsvExceptions.Size = new System.Drawing.Size(554, 226);
            this.lsvExceptions.TabIndex = 0;
            this.lsvExceptions.UseCompatibleStateImageBehavior = false;
            this.lsvExceptions.View = System.Windows.Forms.View.Details;
            // 
            // chLsvExceptionsSource
            // 
            this.chLsvExceptionsSource.Text = "Quelledatei";
            this.chLsvExceptionsSource.Width = 180;
            // 
            // chLsvExceptionsTarget
            // 
            this.chLsvExceptionsTarget.Text = "Zieldatei";
            this.chLsvExceptionsTarget.Width = 180;
            // 
            // chLsvExceptionsException
            // 
            this.chLsvExceptionsException.Text = "Fehler";
            this.chLsvExceptionsException.Width = 180;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 661);
            this.Controls.Add(this.grbExceptions);
            this.Controls.Add(this.chkCopyMoveKeepStucture);
            this.Controls.Add(this.rabMoveFiles);
            this.Controls.Add(this.rabCopyFiles);
            this.Controls.Add(this.txtCreateIndex);
            this.Controls.Add(this.chkCreateIndex);
            this.Controls.Add(this.chkCopyMoveFiles);
            this.Controls.Add(this.epbProgress);
            this.Controls.Add(this.btnProcessPause);
            this.Controls.Add(this.lblRemainTime);
            this.Controls.Add(this.txtRemainTime);
            this.Controls.Add(this.btnDirectoryTarget);
            this.Controls.Add(this.btnDirectorySource);
            this.Controls.Add(this.btnProcessCancel);
            this.Controls.Add(this.btnProcessStart);
            this.Controls.Add(this.grbHandleExistingFiles);
            this.Controls.Add(this.lblDirectoryTarget);
            this.Controls.Add(this.lblDirectorySource);
            this.Controls.Add(this.txtDirectoryTarget);
            this.Controls.Add(this.txtDirectorySource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 700);
            this.Name = "MainForm";
            this.Text = "all2One";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.MainForm_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.grbHandleExistingFiles.ResumeLayout(false);
            this.grbHandleExistingFiles.PerformLayout();
            this.grbExceptions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDirectorySource;
        private System.Windows.Forms.TextBox txtDirectoryTarget;
        private System.Windows.Forms.Label lblDirectorySource;
        private System.Windows.Forms.Label lblDirectoryTarget;
        private System.Windows.Forms.GroupBox grbHandleExistingFiles;
        private System.Windows.Forms.Label lblAddTextToExistingFileText;
        private System.Windows.Forms.TextBox txtAddTextToExistingFileText;
        private System.Windows.Forms.TextBox txtHandleExistingFileText;
        private System.Windows.Forms.Button btnHandleExistingFile_SetDefault;
        internal System.Windows.Forms.Button btnProcessCancel;
        internal System.Windows.Forms.Button btnProcessStart;
        private System.Windows.Forms.Button btnDirectorySource;
        private System.Windows.Forms.Button btnDirectoryTarget;
        private System.Windows.Forms.TextBox txtRemainTime;
        private System.Windows.Forms.Label lblRemainTime;
        internal System.Windows.Forms.Button btnProcessPause;
        private Toolbox.Widgets.ExtProgressBar epbProgress;
        private System.Windows.Forms.CheckBox chkCopyMoveFiles;
        private System.Windows.Forms.CheckBox chkCreateIndex;
        private System.Windows.Forms.TextBox txtCreateIndex;
        private System.Windows.Forms.RadioButton rabCopyFiles;
        private System.Windows.Forms.RadioButton rabMoveFiles;
        private System.Windows.Forms.CheckBox chkCopyMoveKeepStucture;
        private System.Windows.Forms.GroupBox grbExceptions;
        private System.Windows.Forms.ColumnHeader chLsvExceptionsSource;
        private System.Windows.Forms.ColumnHeader chLsvExceptionsTarget;
        private System.Windows.Forms.ColumnHeader chLsvExceptionsException;
        public Toolbox.Widgets.SortListView lsvExceptions;
    }
}

