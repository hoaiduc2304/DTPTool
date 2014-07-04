using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using Ionic.Zip;
using ERPUpdater.Properties;
using DtpFW;
using System.Collections.Generic;
namespace ERPUpdater
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            LoadXmlConnection();

            
        }

        private void LoadXmlConnection()
        {
            List<string> myConnections = XMLHelper.GetConnectionList();
            foreach (string con in myConnections)
            {
                ToolStripItem item = new ToolStripMenuItem();
                //Name that will apear on the menu
                item.Text = con;
                //Put in the Name property whatever neccessery to retrive your data on click event
                item.Name = con;
                //On-Click event
                item.Click += new EventHandler(Connection_Click);
                //Add the submenu to the parent menu
                connectionToolStripMenuItem.DropDownItems.Add(item);
            }


        }
        void Connection_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnection = SqlHelper.GetConnectionString("dtpConnection");
                ConnectionHelper.Connection = myConnection;
                installmentToolStripMenuItem.Enabled = true;
                developerToolStripMenuItem1.Enabled = true;
            }
            catch (Exception objEx)
            {
                MessageBox.Show("Don't have last Connection");
            }
        }

        private void connectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form[] child = this.MdiChildren;
            foreach (Form aForm in child)
            {
                aForm.Close();
            }
            frmConnection b = new frmConnection(this);
            b.ShowDialog();
        }

        private void packageToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmInstallment newMDIChild = new frmInstallment();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void scenariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImportScenarios newMDIChild = new frmImportScenarios();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void classToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            fromTableToClass newMDIChild = new fromTableToClass();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)       
            {
                // do what you want here
                MessageBox.Show(ClassHelper.GeneralClass());
            }
        }

        private void buildUpdaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBuildSource newMDIChild = new frmBuildSource();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }
    }
}
