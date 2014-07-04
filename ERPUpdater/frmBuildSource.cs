using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERPUpdater
{
    public partial class frmBuildSource : Form
    {
        public frmBuildSource()
        {
            InitializeComponent();
        }

        private void btnFindFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog bdf = new FolderBrowserDialog();
            if (bdf.ShowDialog() == DialogResult.OK)
            {
                txtRoot.Text = bdf.SelectedPath;

            }
        }

        private void btnFindToFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog bdf = new FolderBrowserDialog();
            if (bdf.ShowDialog() == DialogResult.OK)
            {
                txtTo.Text = bdf.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Root = txtRoot.Text.Trim();
            string strTo = txtTo.Text.Trim();
            DateTime frmDate = dtpFromDate.Value.Date;
            int CountFile = 0;
            ERPUpdater.Helper.FileHelper.CopyFolderContents(Root, strTo, frmDate, rtLog, ref CountFile);
            lblTotalFile.Text = "Total File Copy :" + CountFile.ToString();
            MessageBox.Show("Finished");
        }
    }
}
