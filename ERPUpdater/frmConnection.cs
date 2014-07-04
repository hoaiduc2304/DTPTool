using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DtpFW;

namespace ERPUpdater
{
    public partial class frmConnection : Form
    {
        private Main MainFrame;
        public frmConnection()
        {
            InitializeComponent();
            cmbAuth.Text = "Window Authentication";
          //  loadDBSever();
            CheckCmbAuth();
            btnGetDatabase.Visible = false;
        }
        public frmConnection(Main objMain)
        {
            InitializeComponent();
            cmbAuth.Text = "Window Authentication";
            //  loadDBSever();
            CheckCmbAuth();
            btnGetDatabase.Visible = false;

            MainFrame = objMain;
        }

        void LoadDatabase()
        {
            try
            {
                DbDatabaseCollection objDatas = DbDatabaseManager.GetAllItem();
                if (objDatas.Count > 0)
                {
                    objDatas.ForEach(delegate(DbDatabase objItem)
                    {
                        cmbDatabase.Items.Add(objItem.DbName);
                    });
                    cmbDatabase.Enabled = true;
                    btnConnection.Enabled = false;
                    btnGetDatabase.Visible = true;
                }
            }
            catch (Exception objEx)
            {
                MessageBox.Show(objEx.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void loadDBSever()
        {
            string myServer = Environment.MachineName;

            DataTable servers = SqlDataSourceEnumerator.Instance.GetDataSources();
            string connection = "server=.\\SQLEXPRESS;Integrated Security = sspi";
            if (SqlHelper.CheckConnection(connection) == "Connect")
            {
                cmbServerName.Items.Add(".\\SQLEXPRESS");
                //cmbServerName.Text = ".\\SQLEXPRESS";
                ConnectionHelper.Connection = connection;
                //LoadDatabase();
            }
            
            for (int i = 0; i < servers.Rows.Count; i++)
            {
                if ((servers.Rows[i]["InstanceName"] as string) != null)
                    cmbServerName.Items.Add(servers.Rows[i]["ServerName"] + "\\" + servers.Rows[i]["InstanceName"]);

                //if (myServer == servers.Rows[i]["ServerName"].ToString()) ///// used to get the servers in the local machine////
                //{
                //    string b = servers.Rows[i]["InstanceName"].ToString();
                //    if ((servers.Rows[i]["InstanceName"] as string) != null)
                //        cmbServerName.Items.Add(servers.Rows[i]["ServerName"] + "\\" + servers.Rows[i]["InstanceName"]);
                //    else
                //        cmbServerName.Items.Add(servers.Rows[i]["ServerName"]);
                //}
            }
        }
        string buildConnection()
        {
            string connection = "";
            string strServerName = cmbServerName.Text;
            string strUsername = txtUSer.Text.Trim();
            string strPass = txtPass.Text.Trim();
            string strDatabaseName = cmbDatabase.Text.Trim();
            if (strServerName != "")
            {
                cmbServerName.BackColor = Color.White;
                connection += "server=" + strServerName + ";";
                if (string.IsNullOrEmpty(strUsername))
                {
                    connection += "Integrated Security = sspi;";
                }
                else
                {
                    connection += "Integrated Security=False;User ID=" + strUsername + ";Password=" + strPass + ";";
                }

                if (!string.IsNullOrEmpty(strDatabaseName))
                {

                    connection += "Initial Catalog=" + strDatabaseName + ";";
                    
                }
                
            }
            else
            {
                cmbServerName.Focus();
                cmbServerName.BackColor = Color.Red;

            }
            return connection;
        }
        private void btnConnection_Click(object sender, EventArgs e)
        {
            string strServerName = cmbServerName.Text;
            string strUsername = txtUSer.Text.Trim();
            string strPass = txtPass.Text.Trim();
            string strDatabaseName = cmbDatabase.Text.Trim();
            if (strServerName != "")
            {
                cmbServerName.BackColor = Color.White;
                //if (!string.IsNullOrEmpty(strDatabaseName))
               // {

                    string connection = "server=" + strServerName + ";";
                    if(string.IsNullOrEmpty(strUsername)){
                        connection +="Integrated Security = sspi;";
                    }else{
                        connection += "Integrated Security=False;User ID="+strUsername+";Password="+strPass+";";
                    }
                    string message = SqlHelper.CheckConnection(connection);
                    if (message == "Connect")
                    {
                        ConnectionHelper.Connection = connection;
                        LoadDatabase();
                        plLogin.Enabled = false;
                        
                        //this.Close();
                    }
                    else
                    {
                        MessageBox.Show(message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
               // }
               // else
               // {
               // /    cmbDatabase.Focus();
                //    cmbDatabase.BackColor = Color.Red;
               // }
            }
            else
            {
                cmbServerName.Focus();
                cmbServerName.BackColor = Color.Red;

            }

        }

        private void cmbAuth_SelectedIndexChanged(object sender, EventArgs e)
        {

            CheckCmbAuth();
        }
        void CheckCmbAuth()
        {
            string strAuth = cmbAuth.Text.Trim();

            if (strAuth == "SQL Server Authentication")
            {
                TextEnable(true);
            }
            else
            {
                TextEnable(false);
            }
        }
        void TextEnable(bool value)
        {
            txtPass.Enabled = value;
            txtUSer.Enabled = value;
            if (!value)
            {
                RemoveText();
            }
        }
        void RemoveText()
        {
            txtPass.Text = "";
            txtUSer.Text = "";
        }

        private void cmbServerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbAuth.Text == "Window Authentication")
            //{
            //    string strConcet =  buildConnection();
            //    if( strConcet!=""){
            //    ConnectionHelper.Connection = strConcet;

            //    cmbDatabase.Items.Clear();
            //    cmbDatabase.SelectedIndex = -1;
            //    LoadDatabase();
            //    }
            //}

        }

        private void txtPass_MouseUp(object sender, MouseEventArgs e)
        {
            //if (cmbAuth.Text == "SQL Server Authentication")
            //{
            //    string strConcet = buildConnection();
            //    if (strConcet != "")
            //    {
            //        ConnectionHelper.Connection = strConcet;

            //        cmbDatabase.Items.Clear();
            //        cmbDatabase.SelectedIndex = -1;
            //        LoadDatabase();
            //    }
            //}
        }

        private void btnGetDatabase_Click(object sender, EventArgs e)
        {
            string strDatabaseName = cmbDatabase.Text.Trim();
            string strServerName = cmbServerName.Text.Trim();
            if (!string.IsNullOrEmpty(strDatabaseName))
            {
                string connection  = ConnectionHelper.Connection + "Initial Catalog = " + strDatabaseName + ";";
                string message = SqlHelper.CheckConnection(connection);
                if (message == "Connect")
                {
                    ConnectionHelper.Connection = connection;
                    XMLHelper.WriteXMLConnection(connection, strServerName, strDatabaseName);
                    if (MainFrame != null)
                    {
                        MainFrame.installmentToolStripMenuItem.Enabled = true;
                        MainFrame.developerToolStripMenuItem1.Enabled = true;
                    }
                    this.Close();
                }
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            loadDBSever();
        }
    }
}
