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
            this.txtPathSource = new System.Windows.Forms.TextBox();
            this.txtPathTarget = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grbHandleExistingFiles = new System.Windows.Forms.GroupBox();
            this.lblAddTextToExistingFileText = new System.Windows.Forms.Label();
            this.txtAddTextToExistingFileText = new System.Windows.Forms.TextBox();
            this.txtHandleExistingFileText = new System.Windows.Forms.TextBox();
            this.btnHandleExistingFile_SetDefault = new System.Windows.Forms.Button();
            this.btnProcessCancel = new System.Windows.Forms.Button();
            this.btnProcessStart = new System.Windows.Forms.Button();
            this.btnBrowseDirectorySource = new System.Windows.Forms.Button();
            this.btnBrowseDirectoryTarget = new System.Windows.Forms.Button();
            this.txtRemainTime = new System.Windows.Forms.TextBox();
            this.lblElapsedTime = new System.Windows.Forms.Label();
            this.btnProcessPause = new System.Windows.Forms.Button();
            this.txtProgressPercent = new System.Windows.Forms.TextBox();
            this.txtProgressValue = new System.Windows.Forms.TextBox();
            this.pbaProgress = new System.Windows.Forms.ProgressBar();
            this.grbHandleExistingFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPathSource
            // 
            this.txtPathSource.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtPathSource.Location = new System.Drawing.Point(82, 12);
            this.txtPathSource.Name = "txtPathSource";
            this.txtPathSource.Size = new System.Drawing.Size(354, 20);
            this.txtPathSource.TabIndex = 1;
            // 
            // txtPathTarget
            // 
            this.txtPathTarget.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtPathTarget.Location = new System.Drawing.Point(82, 38);
            this.txtPathTarget.Name = "txtPathTarget";
            this.txtPathTarget.Size = new System.Drawing.Size(354, 20);
            this.txtPathTarget.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quellordner:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Zielordner:";
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
            this.btnProcessCancel.Location = new System.Drawing.Point(368, 170);
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
            this.btnProcessStart.Location = new System.Drawing.Point(12, 170);
            this.btnProcessStart.Name = "btnProcessStart";
            this.btnProcessStart.Size = new System.Drawing.Size(270, 68);
            this.btnProcessStart.TabIndex = 9;
            this.btnProcessStart.Text = "Daten verschieben";
            this.btnProcessStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProcessStart.UseVisualStyleBackColor = true;
            this.btnProcessStart.Click += new System.EventHandler(this.btnProcessStart_Click);
            // 
            // btnBrowseDirectorySource
            // 
            this.btnBrowseDirectorySource.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowseDirectorySource.Image")));
            this.btnBrowseDirectorySource.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBrowseDirectorySource.Location = new System.Drawing.Point(442, 10);
            this.btnBrowseDirectorySource.Name = "btnBrowseDirectorySource";
            this.btnBrowseDirectorySource.Size = new System.Drawing.Size(130, 23);
            this.btnBrowseDirectorySource.TabIndex = 2;
            this.btnBrowseDirectorySource.Text = "Durchsuchen";
            this.btnBrowseDirectorySource.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBrowseDirectorySource.UseVisualStyleBackColor = true;
            this.btnBrowseDirectorySource.Click += new System.EventHandler(this.btnBrowseDirectorySource_Click);
            // 
            // btnBrowseDirectoryTarget
            // 
            this.btnBrowseDirectoryTarget.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowseDirectoryTarget.Image")));
            this.btnBrowseDirectoryTarget.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBrowseDirectoryTarget.Location = new System.Drawing.Point(442, 36);
            this.btnBrowseDirectoryTarget.Name = "btnBrowseDirectoryTarget";
            this.btnBrowseDirectoryTarget.Size = new System.Drawing.Size(130, 23);
            this.btnBrowseDirectoryTarget.TabIndex = 5;
            this.btnBrowseDirectoryTarget.Text = "Durchsuchen";
            this.btnBrowseDirectoryTarget.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBrowseDirectoryTarget.UseVisualStyleBackColor = true;
            this.btnBrowseDirectoryTarget.Click += new System.EventHandler(this.btnBrowseDirectoryTarget_Click);
            // 
            // txtRemainTime
            // 
            this.txtRemainTime.Location = new System.Drawing.Point(368, 144);
            this.txtRemainTime.Name = "txtRemainTime";
            this.txtRemainTime.ReadOnly = true;
            this.txtRemainTime.Size = new System.Drawing.Size(204, 20);
            this.txtRemainTime.TabIndex = 8;
            // 
            // lblElapsedTime
            // 
            this.lblElapsedTime.AutoSize = true;
            this.lblElapsedTime.Location = new System.Drawing.Point(368, 128);
            this.lblElapsedTime.Name = "lblElapsedTime";
            this.lblElapsedTime.Size = new System.Drawing.Size(105, 13);
            this.lblElapsedTime.TabIndex = 7;
            this.lblElapsedTime.Text = "Geschätzte Restzeit:";
            // 
            // btnProcessPause
            // 
            this.btnProcessPause.Enabled = false;
            this.btnProcessPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessPause.Image = ((System.Drawing.Image)(resources.GetObject("btnProcessPause.Image")));
            this.btnProcessPause.Location = new System.Drawing.Point(288, 170);
            this.btnProcessPause.Name = "btnProcessPause";
            this.btnProcessPause.Size = new System.Drawing.Size(74, 68);
            this.btnProcessPause.TabIndex = 14;
            this.btnProcessPause.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProcessPause.UseVisualStyleBackColor = true;
            this.btnProcessPause.Click += new System.EventHandler(this.btnProcessPause_Click);
            // 
            // txtProgressPercent
            // 
            this.txtProgressPercent.Location = new System.Drawing.Point(368, 247);
            this.txtProgressPercent.Name = "txtProgressPercent";
            this.txtProgressPercent.ReadOnly = true;
            this.txtProgressPercent.Size = new System.Drawing.Size(35, 20);
            this.txtProgressPercent.TabIndex = 12;
            // 
            // txtProgressValue
            // 
            this.txtProgressValue.Location = new System.Drawing.Point(409, 247);
            this.txtProgressValue.Name = "txtProgressValue";
            this.txtProgressValue.ReadOnly = true;
            this.txtProgressValue.Size = new System.Drawing.Size(163, 20);
            this.txtProgressValue.TabIndex = 13;
            // 
            // pbaProgress
            // 
            this.pbaProgress.Location = new System.Drawing.Point(12, 244);
            this.pbaProgress.Name = "pbaProgress";
            this.pbaProgress.Size = new System.Drawing.Size(350, 23);
            this.pbaProgress.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 279);
            this.Controls.Add(this.btnProcessPause);
            this.Controls.Add(this.lblElapsedTime);
            this.Controls.Add(this.txtRemainTime);
            this.Controls.Add(this.txtProgressPercent);
            this.Controls.Add(this.txtProgressValue);
            this.Controls.Add(this.pbaProgress);
            this.Controls.Add(this.btnBrowseDirectoryTarget);
            this.Controls.Add(this.btnBrowseDirectorySource);
            this.Controls.Add(this.btnProcessCancel);
            this.Controls.Add(this.btnProcessStart);
            this.Controls.Add(this.grbHandleExistingFiles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPathTarget);
            this.Controls.Add(this.txtPathSource);
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

        private System.Windows.Forms.TextBox txtPathSource;
        private System.Windows.Forms.TextBox txtPathTarget;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grbHandleExistingFiles;
        private System.Windows.Forms.Label lblAddTextToExistingFileText;
        private System.Windows.Forms.TextBox txtAddTextToExistingFileText;
        private System.Windows.Forms.TextBox txtHandleExistingFileText;
        private System.Windows.Forms.Button btnHandleExistingFile_SetDefault;
        internal System.Windows.Forms.Button btnProcessCancel;
        internal System.Windows.Forms.Button btnProcessStart;
        private System.Windows.Forms.Button btnBrowseDirectorySource;
        private System.Windows.Forms.Button btnBrowseDirectoryTarget;
        private System.Windows.Forms.TextBox txtRemainTime;
        private System.Windows.Forms.Label lblElapsedTime;
        internal System.Windows.Forms.Button btnProcessPause;
        internal System.Windows.Forms.TextBox txtProgressPercent;
        internal System.Windows.Forms.TextBox txtProgressValue;
        internal System.Windows.Forms.ProgressBar pbaProgress;
    }
}

