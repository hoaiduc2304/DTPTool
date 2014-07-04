using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ERPUpdater.Properties;
using System.IO;
using Ionic.Zip;
using DtpFW;
namespace ERPUpdater
{
    public partial class frmInstallment : Form
    {
        string strWebRoot = "";
        public frmInstallment()
        {
            InitializeComponent();
            txtConnectionStr.Text = SqlHelper.GetConnectionString("Config");
        }

        private void btnRleastRoot_Click(object sender, EventArgs e)
        {
            OpenFileDialog bdf = new OpenFileDialog();
            bdf.InitialDirectory = "d:\\";
            bdf.Filter = "zip files (*.zip)|*.zip;*.rar";
            bdf.FilterIndex = 2;
            bdf.RestoreDirectory = true;

            if (bdf.ShowDialog() == DialogResult.OK)
            {
                txtRelease.Text = bdf.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog bdf = new FolderBrowserDialog();
            if (bdf.ShowDialog() == DialogResult.OK)
            {
                txtWebRoot.Text = bdf.SelectedPath;

            }
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            // Validation information
            if (String.IsNullOrEmpty(txtRelease.Text)
                || String.IsNullOrEmpty(txtWebRoot.Text)
                || String.IsNullOrEmpty(txtConnectionStr.Text))
                Console.WriteLine(Resources.Input_all_infomration);

            string strFile = txtRelease.Text.Trim();
            string strOuput = txtWebRoot.Text.Trim();
            string strDatabase = strOuput +"\\Updater";
            string strWeb = strDatabase;
            string connPath = txtConnectionStr.Text.TrimEnd().TrimStart();
            string path = strOuput + "\\Install_Package\\Database\\";
            string fileScriptPath = strDatabase ;
            

            // Show message box to warning user about the system is processing
            //MessageBox.Show(Resources.Please_wait_update_is_processing, Resources.ERP_Updater, MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtLog.Text = "Unzip File.....\n\r";
            if (File.Exists(strFile))
            {
                // Extract zip file
                using (ZipFile zip = ZipFile.Read(strFile))
                {
                    int i = 0;
                    foreach (ZipEntry es in zip)
                    {
                        if (i == 0) { 
                            strWeb += "\\" + es.FileName.Replace("/","") + "\\Web";
                            fileScriptPath += "\\" + es.FileName.Replace("/", "") + "\\Database";
                            strWebRoot = strWeb;
                        }
                        
                        es.Extract(strDatabase, ExtractExistingFileAction.OverwriteSilently);
                        string b = txtLog.Text + "\n\r" + es.FileName + "\n\r";
                        txtLog.Text = b;
                        i++;
                    }
                }

                txtLog.Text += "------------------------------------\n\r";
                txtLog.Text += "Deploy Web.....\n\r";
                txtLog.Text += "To : "+ strWeb+"\n\r";
                
                txtLog.Text += "------------------------------------\n\r";



                CopyFolderContents(strWeb, strOuput);

                txtLog.Text += "------------------------------------\n\r";
                txtLog.Text += "Deploy Database.....\n\r";
                txtLog.Text += "------------------------------------\n\r";
                if (Directory.Exists(fileScriptPath))
                {
                    SqlHelper b = new SqlHelper();
                    b.ExecuteSqlScript(fileScriptPath);
                }
                    //Copy the file from sourcepath and place into mentioned target path, 
                //    //Overwrite the file if same file is exist in target path
                //    File.Copy(srcPath, srcPath.Replace(sourcePath, targetPath), true);
                
               /* MessageBox.Show(Resources.Source_Code_is_updated, Resources.ERP_Updater, MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Execute sql scripts
                if (Directory.Exists(path))
                {
                    SqlHelper b = new SqlHelper();
                    b.ExecuteSqlScript(connPath, fileScriptPath, fileViewPath);
                }

                MessageBox.Show(Resources.Database_is_updated, Resources.ERP_Updater, MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Close window form
                DialogResult result = MessageBox.Show(Resources.Update_Successful, Resources.ERP_Updater, MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (result == DialogResult.OK)
                {
                    Application.Exit();
                }*/
            }
        }
        private bool CopyFolderContents(string SourcePath, string DestinationPath)
        {
            SourcePath = SourcePath.EndsWith(@"\") ? SourcePath : SourcePath + @"\";
            DestinationPath = DestinationPath.EndsWith(@"\") ? DestinationPath : DestinationPath + @"\";

            try
            {
                if (Directory.Exists(SourcePath))
                {
                    if (Directory.Exists(DestinationPath) == false)
                    {
                        Directory.CreateDirectory(DestinationPath);
                    }

                    foreach (string files in Directory.GetFiles(SourcePath))
                    {
                        FileInfo fileInfo = new FileInfo(files);
                        fileInfo.CopyTo(string.Format(@"{0}\{1}", DestinationPath, fileInfo.Name), true);
                    }

                    foreach (string drs in Directory.GetDirectories(SourcePath))
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo(drs);
                        if (CopyFolderContents(drs, DestinationPath + directoryInfo.Name) == false)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void btnPublishWeb_Click(object sender, EventArgs e)
        {
            //MyWeb.Publish(strWebRoot);
            frmPublishWeb objPub = new frmPublishWeb();
            objPub.ShowDialog();
            
        }
        

    }
}
