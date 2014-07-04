namespace ERPUpdater
{
    partial class frmInstallment
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtConnectionStr = new System.Windows.Forms.TextBox();
            this.btnInstall = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRleastRoot = new System.Windows.Forms.Button();
            this.txtRelease = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWebRoot = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnPublishWeb = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(64, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "SQL Connection";
            this.label3.Visible = false;
            // 
            // txtConnectionStr
            // 
            this.txtConnectionStr.Enabled = false;
            this.txtConnectionStr.Location = new System.Drawing.Point(155, 162);
            this.txtConnectionStr.Name = "txtConnectionStr";
            this.txtConnectionStr.Size = new System.Drawing.Size(575, 20);
            this.txtConnectionStr.TabIndex = 17;
            this.txtConnectionStr.Visible = false;
            // 
            // btnInstall
            // 
            this.btnInstall.Location = new System.Drawing.Point(67, 188);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(656, 36);
            this.btnInstall.TabIndex = 16;
            this.btnInstall.Text = "Update";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Release Folder";
            // 
            // btnRleastRoot
            // 
            this.btnRleastRoot.Location = new System.Drawing.Point(655, 81);
            this.btnRleastRoot.Name = "btnRleastRoot";
            this.btnRleastRoot.Size = new System.Drawing.Size(75, 23);
            this.btnRleastRoot.TabIndex = 14;
            this.btnRleastRoot.Text = "Browser";
            this.btnRleastRoot.UseVisualStyleBackColor = true;
            this.btnRleastRoot.Click += new System.EventHandler(this.btnRleastRoot_Click);
            // 
            // txtRelease
            // 
            this.txtRelease.Location = new System.Drawing.Point(155, 84);
            this.txtRelease.Name = "txtRelease";
            this.txtRelease.Size = new System.Drawing.Size(494, 20);
            this.txtRelease.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Website Folder";
            // 
            // txtWebRoot
            // 
            this.txtWebRoot.Location = new System.Drawing.Point(155, 123);
            this.txtWebRoot.Name = "txtWebRoot";
            this.txtWebRoot.Size = new System.Drawing.Size(494, 20);
            this.txtWebRoot.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(655, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Browser";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(67, 249);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(656, 110);
            this.txtLog.TabIndex = 19;
            // 
            // btnPublishWeb
            // 
            this.btnPublishWeb.Location = new System.Drawing.Point(67, 458);
            this.btnPublishWeb.Name = "btnPublishWeb";
            this.btnPublishWeb.Size = new System.Drawing.Size(656, 41);
            this.btnPublishWeb.TabIndex = 20;
            this.btnPublishWeb.Text = "Publish Web";
            this.btnPublishWeb.UseVisualStyleBackColor = true;
            this.btnPublishWeb.Click += new System.EventHandler(this.btnPublishWeb_Click);
            // 
            // frmInstallment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 545);
            this.Controls.Add(this.btnPublishWeb);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtConnectionStr);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRleastRoot);
            this.Controls.Add(this.txtRelease);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtWebRoot);
            this.Controls.Add(this.button1);
            this.Name = "frmInstallment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Install Package";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtConnectionStr;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRleastRoot;
        private System.Windows.Forms.TextBox txtRelease;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWebRoot;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnPublishWeb;
    }
}