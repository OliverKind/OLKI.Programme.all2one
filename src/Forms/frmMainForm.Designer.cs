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
            this.chkCopyFiles = new System.Windows.Forms.CheckBox();
            this.chkCreateIndex = new System.Windows.Forms.CheckBox();
            this.txtCreateIndex = new System.Windows.Forms.TextBox();
            this.grbHandleExistingFiles.SuspendLayout();
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
            this.btnHandleExistingFile_SetDefault.Image = ((System.Drawing.Image)(resources.GetObject("btnHandleExistingFile_SetDefault.Image")));
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
            this.btnProcessCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnProcessCancel.Image")));
            this.btnProcessCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProcessCancel.Location = new System.Drawing.Point(368, 217);
            this.btnProcessCancel.Name = "btnProcessCancel";
            this.btnProcessCancel.Size = new System.Drawing.Size(204, 68);
            this.btnProcessCancel.TabIndex = 10;
            this.btnProcessCancel.Text = "Abbrechen";
            this.btnProcessCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProcessCancel.UseVisualStyleBackColor = true;
            this.btnProcessCancel.Click += new System.EventHandler(this.btnProcessCancel_Click);
            // 
            // btnProcessStart
            // 
            this.btnProcessStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessStart.Image = ((System.Drawing.Image)(resources.GetObject("btnProcessStart.Image")));
            this.btnProcessStart.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProcessStart.Location = new System.Drawing.Point(12, 217);
            this.btnProcessStart.Name = "btnProcessStart";
            this.btnProcessStart.Size = new System.Drawing.Size(270, 68);
            this.btnProcessStart.TabIndex = 9;
            this.btnProcessStart.Text = "Daten verschieben";
            this.btnProcessStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProcessStart.UseVisualStyleBackColor = true;
            this.btnProcessStart.Click += new System.EventHandler(this.btnProcessStart_Click);
            // 
            // btnDirectorySource
            // 
            this.btnDirectorySource.Image = ((System.Drawing.Image)(resources.GetObject("btnDirectorySource.Image")));
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
            this.btnDirectoryTarget.Image = ((System.Drawing.Image)(resources.GetObject("btnDirectoryTarget.Image")));
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
            this.btnProcessPause.Image = ((System.Drawing.Image)(resources.GetObject("btnProcessPause.Image")));
            this.btnProcessPause.Location = new System.Drawing.Point(288, 217);
            this.btnProcessPause.Name = "btnProcessPause";
            this.btnProcessPause.Size = new System.Drawing.Size(74, 68);
            this.btnProcessPause.TabIndex = 14;
            this.btnProcessPause.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProcessPause.UseVisualStyleBackColor = true;
            this.btnProcessPause.Click += new System.EventHandler(this.btnProcessPause_Click);
            // 
            // epbProgress
            // 
            this.epbProgress.AutoByteDimension = false;
            this.epbProgress.ByteDimension = OLKI.Toolbox.DirectoryAndFile.FileSize.Dimension.NoDimension;
            this.epbProgress.DecimalDigits = ((uint)(0u));
            this.epbProgress.Location = new System.Drawing.Point(12, 291);
            this.epbProgress.MinimumSize = new System.Drawing.Size(300, 23);
            this.epbProgress.Name = "epbProgress";
            this.epbProgress.ShowDescriptionText = false;
            this.epbProgress.ShowDimensionComboBox = false;
            this.epbProgress.Size = new System.Drawing.Size(560, 23);
            this.epbProgress.TabIndex = 15;
            // 
            // chkCopyFiles
            // 
            this.chkCopyFiles.AutoSize = true;
            this.chkCopyFiles.Location = new System.Drawing.Point(12, 171);
            this.chkCopyFiles.Name = "chkCopyFiles";
            this.chkCopyFiles.Size = new System.Drawing.Size(193, 17);
            this.chkCopyFiles.TabIndex = 16;
            this.chkCopyFiles.Text = "Dateien im Zielverzeichnis kopieren";
            this.chkCopyFiles.UseVisualStyleBackColor = true;
            this.chkCopyFiles.CheckedChanged += new System.EventHandler(this.chkCopyFiles_CheckedChanged);
            // 
            // chkCreateIndex
            // 
            this.chkCreateIndex.AutoSize = true;
            this.chkCreateIndex.Location = new System.Drawing.Point(12, 194);
            this.chkCreateIndex.Name = "chkCreateIndex";
            this.chkCreateIndex.Size = new System.Drawing.Size(208, 17);
            this.chkCreateIndex.TabIndex = 17;
            this.chkCreateIndex.Text = "Index Datei im Zielverzeichnis erstellen";
            this.chkCreateIndex.UseVisualStyleBackColor = true;
            this.chkCreateIndex.CheckedChanged += new System.EventHandler(this.chkCreateIndex_CheckedChanged);
            // 
            // txtCreateIndex
            // 
            this.txtCreateIndex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCreateIndex.Location = new System.Drawing.Point(226, 191);
            this.txtCreateIndex.Name = "txtCreateIndex";
            this.txtCreateIndex.Size = new System.Drawing.Size(346, 20);
            this.txtCreateIndex.TabIndex = 18;
            this.txtCreateIndex.TextChanged += new System.EventHandler(this.txtCreateIndex_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 326);
            this.Controls.Add(this.txtCreateIndex);
            this.Controls.Add(this.chkCreateIndex);
            this.Controls.Add(this.chkCopyFiles);
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
            this.Name = "MainForm";
            this.Text = "all2One";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.MainForm_HelpButtonClicked);
            this.grbHandleExistingFiles.ResumeLayout(false);
            this.grbHandleExistingFiles.PerformLayout();
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
        private System.Windows.Forms.CheckBox chkCopyFiles;
        private System.Windows.Forms.CheckBox chkCreateIndex;
        private System.Windows.Forms.TextBox txtCreateIndex;
    }
}

