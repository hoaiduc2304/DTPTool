namespace ERPUpdater
{
    partial class frmImportScenarios
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.trCompany = new System.Windows.Forms.TreeView();
            this.trScenarios = new System.Windows.Forms.TreeView();
            this.rTexScript = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rTexScript);
            this.splitContainer1.Size = new System.Drawing.Size(859, 558);
            this.splitContainer1.SplitterDistance = 286;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.trCompany);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.trScenarios);
            this.splitContainer2.Size = new System.Drawing.Size(286, 558);
            this.splitContainer2.SplitterDistance = 257;
            this.splitContainer2.TabIndex = 0;
            // 
            // trCompany
            // 
            this.trCompany.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trCompany.Location = new System.Drawing.Point(0, 0);
            this.trCompany.Name = "trCompany";
            this.trCompany.Size = new System.Drawing.Size(286, 257);
            this.trCompany.TabIndex = 0;
            // 
            // trScenarios
            // 
            this.trScenarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trScenarios.Location = new System.Drawing.Point(0, 0);
            this.trScenarios.Name = "trScenarios";
            this.trScenarios.Size = new System.Drawing.Size(286, 297);
            this.trScenarios.TabIndex = 1;
            // 
            // rTexScript
            // 
            this.rTexScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTexScript.Location = new System.Drawing.Point(0, 0);
            this.rTexScript.Name = "rTexScript";
            this.rTexScript.Size = new System.Drawing.Size(569, 558);
            this.rTexScript.TabIndex = 0;
            this.rTexScript.Text = "";
            // 
            // frmImportScenarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 558);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmImportScenarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmImportScenarios";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView trCompany;
        private System.Windows.Forms.TreeView trScenarios;
        private System.Windows.Forms.RichTextBox rTexScript;
    }
}