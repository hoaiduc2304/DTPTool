namespace ERPUpdater
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.developerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.developerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.codeGenerationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scenariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.installmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.packageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildUpdaterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.developerToolStripMenuItem,
            this.developerToolStripMenuItem1,
            this.installmentToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(919, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // developerToolStripMenuItem
            // 
            this.developerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionToolStripMenuItem});
            this.developerToolStripMenuItem.Name = "developerToolStripMenuItem";
            this.developerToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.developerToolStripMenuItem.Text = "File";
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.connectionToolStripMenuItem.Text = "Connection";
            this.connectionToolStripMenuItem.Click += new System.EventHandler(this.connectionToolStripMenuItem_Click);
            // 
            // developerToolStripMenuItem1
            // 
            this.developerToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.codeGenerationToolStripMenuItem,
            this.sourceToolStripMenuItem});
            this.developerToolStripMenuItem1.Enabled = false;
            this.developerToolStripMenuItem1.Name = "developerToolStripMenuItem1";
            this.developerToolStripMenuItem1.Size = new System.Drawing.Size(72, 20);
            this.developerToolStripMenuItem1.Text = "Developer";
            // 
            // codeGenerationToolStripMenuItem
            // 
            this.codeGenerationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.classToolStripMenuItem});
            this.codeGenerationToolStripMenuItem.Name = "codeGenerationToolStripMenuItem";
            this.codeGenerationToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.codeGenerationToolStripMenuItem.Text = "Code Generation";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scenariosToolStripMenuItem});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // scenariosToolStripMenuItem
            // 
            this.scenariosToolStripMenuItem.Name = "scenariosToolStripMenuItem";
            this.scenariosToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.scenariosToolStripMenuItem.Text = "Scenarios";
            this.scenariosToolStripMenuItem.Click += new System.EventHandler(this.scenariosToolStripMenuItem_Click);
            // 
            // classToolStripMenuItem
            // 
            this.classToolStripMenuItem.Name = "classToolStripMenuItem";
            this.classToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.classToolStripMenuItem.Text = "Class";
            this.classToolStripMenuItem.Click += new System.EventHandler(this.classToolStripMenuItem_Click);
            // 
            // installmentToolStripMenuItem
            // 
            this.installmentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.packageToolStripMenuItem});
            this.installmentToolStripMenuItem.Enabled = false;
            this.installmentToolStripMenuItem.Name = "installmentToolStripMenuItem";
            this.installmentToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.installmentToolStripMenuItem.Text = "Installment";
            // 
            // packageToolStripMenuItem
            // 
            this.packageToolStripMenuItem.Name = "packageToolStripMenuItem";
            this.packageToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.packageToolStripMenuItem.Text = "Package";
            this.packageToolStripMenuItem.Click += new System.EventHandler(this.packageToolStripMenuItem_Click);
            // 
            // sourceToolStripMenuItem
            // 
            this.sourceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildUpdaterToolStripMenuItem});
            this.sourceToolStripMenuItem.Name = "sourceToolStripMenuItem";
            this.sourceToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.sourceToolStripMenuItem.Text = "Source";
            // 
            // buildUpdaterToolStripMenuItem
            // 
            this.buildUpdaterToolStripMenuItem.Name = "buildUpdaterToolStripMenuItem";
            this.buildUpdaterToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.buildUpdaterToolStripMenuItem.Text = "Build Updater";
            this.buildUpdaterToolStripMenuItem.Click += new System.EventHandler(this.buildUpdaterToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 580);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Duc Nguyen Application";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem developerToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem developerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem codeGenerationToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem installmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem packageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scenariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildUpdaterToolStripMenuItem;
    }
}

