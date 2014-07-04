namespace ERPUpdater
{
    partial class frmConnection
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
            this.cmbServerName = new System.Windows.Forms.ComboBox();
            this.btnConnection = new System.Windows.Forms.Button();
            this.cmbAuth = new System.Windows.Forms.ComboBox();
            this.lblSever = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUSer = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDatabase = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGetDatabase = new System.Windows.Forms.Button();
            this.plLogin = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.plLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbServerName
            // 
            this.cmbServerName.FormattingEnabled = true;
            this.cmbServerName.Location = new System.Drawing.Point(91, 15);
            this.cmbServerName.Name = "cmbServerName";
            this.cmbServerName.Size = new System.Drawing.Size(188, 21);
            this.cmbServerName.TabIndex = 0;
            this.cmbServerName.Text = ".";
            this.cmbServerName.SelectedIndexChanged += new System.EventHandler(this.cmbServerName_SelectedIndexChanged);
            // 
            // btnConnection
            // 
            this.btnConnection.Location = new System.Drawing.Point(339, 33);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(75, 23);
            this.btnConnection.TabIndex = 1;
            this.btnConnection.Text = "Connect";
            this.btnConnection.UseVisualStyleBackColor = true;
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // cmbAuth
            // 
            this.cmbAuth.FormattingEnabled = true;
            this.cmbAuth.Items.AddRange(new object[] {
            "SQL Server Authentication",
            "Window Authentication"});
            this.cmbAuth.Location = new System.Drawing.Point(91, 51);
            this.cmbAuth.Name = "cmbAuth";
            this.cmbAuth.Size = new System.Drawing.Size(188, 21);
            this.cmbAuth.TabIndex = 2;
            this.cmbAuth.SelectedIndexChanged += new System.EventHandler(this.cmbAuth_SelectedIndexChanged);
            // 
            // lblSever
            // 
            this.lblSever.AutoSize = true;
            this.lblSever.Location = new System.Drawing.Point(17, 15);
            this.lblSever.Name = "lblSever";
            this.lblSever.Size = new System.Drawing.Size(69, 13);
            this.lblSever.TabIndex = 3;
            this.lblSever.Text = "Server Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Authentication";
            // 
            // txtUSer
            // 
            this.txtUSer.Location = new System.Drawing.Point(91, 88);
            this.txtUSer.Name = "txtUSer";
            this.txtUSer.Size = new System.Drawing.Size(188, 20);
            this.txtUSer.TabIndex = 5;
            this.txtUSer.Text = "sa";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(91, 124);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(188, 20);
            this.txtPass.TabIndex = 6;
            this.txtPass.Text = "@Cb12345";
            this.txtPass.UseSystemPasswordChar = true;
            this.txtPass.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtPass_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "User";
            // 
            // cmbDatabase
            // 
            this.cmbDatabase.Enabled = false;
            this.cmbDatabase.FormattingEnabled = true;
            this.cmbDatabase.Location = new System.Drawing.Point(103, 188);
            this.cmbDatabase.Name = "cmbDatabase";
            this.cmbDatabase.Size = new System.Drawing.Size(188, 21);
            this.cmbDatabase.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Database";
            // 
            // btnGetDatabase
            // 
            this.btnGetDatabase.Location = new System.Drawing.Point(339, 186);
            this.btnGetDatabase.Name = "btnGetDatabase";
            this.btnGetDatabase.Size = new System.Drawing.Size(75, 23);
            this.btnGetDatabase.TabIndex = 11;
            this.btnGetDatabase.Text = "Choice ";
            this.btnGetDatabase.UseVisualStyleBackColor = true;
            this.btnGetDatabase.Click += new System.EventHandler(this.btnGetDatabase_Click);
            // 
            // plLogin
            // 
            this.plLogin.Controls.Add(this.pictureBox1);
            this.plLogin.Controls.Add(this.cmbServerName);
            this.plLogin.Controls.Add(this.cmbAuth);
            this.plLogin.Controls.Add(this.lblSever);
            this.plLogin.Controls.Add(this.label1);
            this.plLogin.Controls.Add(this.label3);
            this.plLogin.Controls.Add(this.txtUSer);
            this.plLogin.Controls.Add(this.label2);
            this.plLogin.Controls.Add(this.txtPass);
            this.plLogin.Location = new System.Drawing.Point(12, 20);
            this.plLogin.Name = "plLogin";
            this.plLogin.Size = new System.Drawing.Size(321, 162);
            this.plLogin.TabIndex = 12;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ERPUpdater.Properties.Resources.Button_Refresh_icon;
            this.pictureBox1.Location = new System.Drawing.Point(285, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 26);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(339, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 224);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.plLogin);
            this.Controls.Add(this.btnGetDatabase);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbDatabase);
            this.Controls.Add(this.btnConnection);
            this.Name = "frmConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmConnection";
            this.plLogin.ResumeLayout(false);
            this.plLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbServerName;
        private System.Windows.Forms.Button btnConnection;
        private System.Windows.Forms.ComboBox cmbAuth;
        private System.Windows.Forms.Label lblSever;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUSer;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDatabase;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGetDatabase;
        private System.Windows.Forms.Panel plLogin;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}