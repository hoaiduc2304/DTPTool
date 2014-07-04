namespace ERPUpdater
{
    partial class frmBuildSource
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtRoot = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFindFolder = new System.Windows.Forms.Button();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFindToFolder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.rtLog = new System.Windows.Forms.RichTextBox();
            this.lblTotalFile = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtRoot
            // 
            this.txtRoot.Location = new System.Drawing.Point(114, 68);
            this.txtRoot.Name = "txtRoot";
            this.txtRoot.Size = new System.Drawing.Size(393, 20);
            this.txtRoot.TabIndex = 14;
            this.txtRoot.Text = "C:\\Project\\Thegoleg";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Parent Folder";
            // 
            // btnFindFolder
            // 
            this.btnFindFolder.Location = new System.Drawing.Point(524, 65);
            this.btnFindFolder.Name = "btnFindFolder";
            this.btnFindFolder.Size = new System.Drawing.Size(75, 23);
            this.btnFindFolder.TabIndex = 16;
            this.btnFindFolder.Text = "Browser";
            this.btnFindFolder.UseVisualStyleBackColor = true;
            this.btnFindFolder.Click += new System.EventHandler(this.btnFindFolder_Click);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(114, 147);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(393, 20);
            this.dtpFromDate.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "From Date";
            // 
            // btnFindToFolder
            // 
            this.btnFindToFolder.Location = new System.Drawing.Point(524, 106);
            this.btnFindToFolder.Name = "btnFindToFolder";
            this.btnFindToFolder.Size = new System.Drawing.Size(75, 23);
            this.btnFindToFolder.TabIndex = 21;
            this.btnFindToFolder.Text = "Browser";
            this.btnFindToFolder.UseVisualStyleBackColor = true;
            this.btnFindToFolder.Click += new System.EventHandler(this.btnFindToFolder_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "To Folder";
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(114, 109);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(393, 20);
            this.txtTo.TabIndex = 19;
            this.txtTo.Text = "C:\\Project\\Updater";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(41, 203);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(558, 43);
            this.button3.TabIndex = 22;
            this.button3.Text = "Build";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // rtLog
            // 
            this.rtLog.Location = new System.Drawing.Point(41, 265);
            this.rtLog.Name = "rtLog";
            this.rtLog.Size = new System.Drawing.Size(558, 225);
            this.rtLog.TabIndex = 23;
            this.rtLog.Text = "";
            // 
            // lblTotalFile
            // 
            this.lblTotalFile.AutoSize = true;
            this.lblTotalFile.Location = new System.Drawing.Point(539, 504);
            this.lblTotalFile.Name = "lblTotalFile";
            this.lblTotalFile.Size = new System.Drawing.Size(0, 13);
            this.lblTotalFile.TabIndex = 24;
            // 
            // frmBuildSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 526);
            this.Controls.Add(this.lblTotalFile);
            this.Controls.Add(this.rtLog);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnFindToFolder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.btnFindFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRoot);
            this.Name = "frmBuildSource";
            this.Text = "frmBuildSource";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRoot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFindFolder;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFindToFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox rtLog;
        private System.Windows.Forms.Label lblTotalFile;
    }
}