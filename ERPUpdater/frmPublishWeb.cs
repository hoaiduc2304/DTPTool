using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DtpFW;
namespace ERPUpdater
{
    public partial class frmPublishWeb : Form
    {
        public frmPublishWeb()
        {
            InitializeComponent(); loadIIS();
        }
        void loadIIS()
        {
            List<string> iis =  MyWeb.getIISWebSite();
            foreach (string item in iis) // Loop through List with foreach
            {
                string strSite = item.Remove(item.IndexOf(":"));
                TreeNode treeNode = new TreeNode(item);
                
                List<string> apps = MyWeb.GetWebSiteApplication(strSite);
                
                foreach (string ap in apps) // Loop through List with foreach
                {
                    TreeNode subNode = new TreeNode(ap.Replace("/",""));
                    treeNode.Nodes.Add(subNode);
                }
                
                trWeb.Nodes.Add(treeNode);
            }
        }
        
        private void loadScenariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loadScenariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
