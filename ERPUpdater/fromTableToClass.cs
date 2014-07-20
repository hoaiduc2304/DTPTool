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
    public partial class fromTableToClass : Form
    {
        string strTable = "";
        public fromTableToClass()
        {
            InitializeComponent();
            getTable("");
        }
        void getTable(string Search)
        {
            trTable.Nodes.Clear();
            DBTableCollection objTables = DBTableManager.GetAllItem(Search);
            ContextMenuStrip menuStrip = new ContextMenuStrip();
            menuStrip.Items.Add("Create Class");
            TreeNode treeNode = new TreeNode("Table List");
            foreach (DBTable ap in objTables) // Loop through List with foreach
            {
                TreeNode subNode = new TreeNode(ap.TableName);
                treeNode.Nodes.Add(subNode);
            }
            
            
            trTable.ContextMenuStrip = menuStrip;
            menuStrip.ItemClicked += new ToolStripItemClickedEventHandler(menuStrip_ItemClicked);
            trTable.Nodes.Add(treeNode);
            trTable.ExpandAll();

        }
        void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            txtNameSpace.Text = "dtp.Web.Website.GL";
            btnRebuild.Enabled = true;
            strTable = trTable.SelectedNode.Text;
           
        }

        private void btnExcuteSP_Click(object sender, EventArgs e)
        {
            string exScript = sqlscript.Text.Trim();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strNamespace = txtNameSpace.Text;
            if (!string.IsNullOrEmpty(strNamespace)) {
                string script = ClassHelper.BuildClass(strTable, strNamespace);
                string SpScript = ClassHelper.SPBuilder(strTable);
                string AjaxScript = AjaxRender.PageAjaxRender(strTable, strNamespace);
                string htmlScript = HtmlPageHelper.PageHTMLRender(strTable, strNamespace);
                txtScripts.Text = script;
                sqlscript.Text = SpScript;
                txtAjax.Text = AjaxScript;
                rchHTML.Text = htmlScript;
            }
            
        }

        private void txtTableSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            string search = txtTableSearch.Text.Trim();
            getTable(search);
        }


    }
}
