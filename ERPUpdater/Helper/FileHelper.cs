using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ERPUpdater.Helper
{
    public class FileHelper
    {
        public static bool CopyFolderContents(string SourcePath, string DestinationPath, DateTime fromDate,System.Windows.Forms.RichTextBox rTLog, ref int CountFile)
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

                        if (DateTime.Compare(fileInfo.CreationTime, fromDate) >= 0 || DateTime.Compare(fileInfo.LastWriteTime, fromDate) >= 0)
                         {
                             fileInfo.CopyTo(string.Format(@"{0}\{1}", DestinationPath, fileInfo.Name), true);
                             rTLog.AppendText(DestinationPath + fileInfo.Name + "\n");
                             CountFile++;
                         }
                       
                    }

                    foreach (string drs in Directory.GetDirectories(SourcePath))
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo(drs);
                        if (CopyFolderContents(drs, DestinationPath + directoryInfo.Name, fromDate, rTLog,ref CountFile) == false)
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
    }
}
