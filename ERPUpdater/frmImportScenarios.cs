using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DtpFW;
using DtpFW.Import;
namespace ERPUpdater
{
    public partial class frmImportScenarios : Form
    {
        public frmImportScenarios()
        {
            InitializeComponent();
            LoadCompany();
        }
        private void LoadCompany()
        {

            ContextMenuStrip menuStrip = new ContextMenuStrip();
            menuStrip.Items.Add("Load Scenarios");
            TreeNode treeNode = new TreeNode("Company");

            DbCompanyCollection objComs = DtpFW.CompanyManager.GetAllItem();
            foreach (DbCompany ap in objComs) // Loop through List with foreach
            {
                TreeNode subNode = new TreeNode(ap.CompanyKey);
                treeNode.Nodes.Add(subNode);
            }
            trCompany.CollapseAll();
            trCompany.ContextMenuStrip = menuStrip;
            menuStrip.ItemClicked += new ToolStripItemClickedEventHandler(menuStrip_ItemClicked);
            trCompany.Nodes.Add(treeNode);
        }
        void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string strCompany = trCompany.SelectedNode.Text;
            if (!string.IsNullOrEmpty(strCompany))
            {
                DbCompany objCom = CompanyManager.GetItemByName(strCompany);
                if (objCom != null)
                {
                    DbSyMappingCollection objMappings = DbSyMappingManager.GetAllItem(objCom.CompanyID.ToString());
                    TreeNode treeNode = new TreeNode("Import Scenarios");
                    ContextMenuStrip menuStrip = new ContextMenuStrip();
                    menuStrip.Items.Add("Create Script");

                    foreach (DbSyMapping ap in objMappings) // Loop through List with foreach
                    {
                        TreeNode subNode = new TreeNode(ap.MappingName);
                        treeNode.Nodes.Add(subNode);
                    }
                    trScenarios.ContextMenuStrip = menuStrip;
                    menuStrip.ItemClicked += new ToolStripItemClickedEventHandler(menuStripImportScenaris_ItemClicked);
                    trScenarios.Nodes.Add(treeNode);
                }
            }
           
        }
        void menuStripImportScenaris_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string strMappingName = trScenarios.SelectedNode.Text;
            string strCompany = trCompany.SelectedNode.Text;
            DbCompany objCom = CompanyManager.GetItemByName(strCompany);
            rTexScript.Text = DbSyMappingManager.BuildTemplateScript(strMappingName, objCom.CompanyID.ToString());
        }
        private void LoadCurrentScenarios()
        {

        }
    }
}
