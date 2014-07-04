using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
namespace DtpFW
{
    public class FileHelper
    {
        public static string GetTemplateFile(string strFile)
        {
            string path = Path.GetDirectoryName(Assembly.GetAssembly(typeof(FileHelper)).CodeBase).Replace("file:\\", "") + "\\Template\\" + strFile;
            return path;
        }
        public static string GetTextContent(string strFile)
        {
            string file = GetTemplateFile(strFile);
            string TempScript = System.IO.File.ReadAllText(file);
            return TempScript;
        }
    }
}
