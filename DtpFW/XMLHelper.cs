using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace DtpFW
{
    public class XMLHelper
    {
        public static List<string> GetConnectionList()
        {
            string filename = "config.xml";

            XmlDocument xmlDoc = new XmlDocument();
            List<string> mylist = new List<string>();
            try
            {
                xmlDoc.Load(filename);
                XmlElement root = xmlDoc.DocumentElement;
                XmlNodeList nodes = root.SelectNodes("Connection"); // You can also use XPath here
                foreach (XmlNode node in nodes)
                {
                    string strServer = node.Attributes["Server"].Value;
                    if (strServer == ".")
                    {
                        strServer = "local";
                    }
                    mylist.Add(strServer + "/" + node.Attributes["DbName"].Value);
                    // use node variable here for your beeds
                }
            }
            catch (Exception objEx)
            {
            }
            return mylist;
        }
        public static void WriteXMLConnection(string strConnection,string strServer,string strDBName)
        {
            try
            {
                //pick whatever filename with .xml extension
                string filename = "config.xml";

                XmlDocument xmlDoc = new XmlDocument();

                try
                {
                    xmlDoc.Load(filename);
                    XmlNode node = xmlDoc.DocumentElement.SelectSingleNode("/Root");
                    node.RemoveAll();
                }
                catch (System.IO.FileNotFoundException)
                {
                    //if file is not found, create a new xml file
                    XmlTextWriter xmlWriter = new XmlTextWriter(filename, System.Text.Encoding.UTF8);
                    xmlWriter.Formatting = Formatting.Indented;
                    xmlWriter.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8'");
                    xmlWriter.WriteStartElement("Root");
                    //If WriteProcessingInstruction is used as above,
                    //Do not use WriteEndElement() here
                    //xmlWriter.WriteEndElement();
                    //it will cause the <Root> to be &ltRoot />
                    xmlWriter.Close();
                    xmlDoc.Load(filename);
                }
                XmlNode root = xmlDoc.DocumentElement;
                XmlElement xConnection = xmlDoc.CreateElement("Connection");
                
                //XmlText textNode = xmlDoc.CreateTextNode("hello");
                //textNode.Value = "hello, world";

                root.AppendChild(xConnection);
                xConnection.SetAttribute("dtpConnection", strConnection);
                xConnection.SetAttribute("Server", strServer);
                xConnection.SetAttribute("DbName", strDBName);
                //childNode2.AppendChild(textNode);
                xmlDoc.Save(filename);
            }
            catch (Exception ex)
            {
               
            }
        }
    }
}
