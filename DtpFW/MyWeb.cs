using System;
using System.Text;
using Microsoft.Web.Administration;
using System.Collections.Generic;
namespace DtpFW
{
    public class MyWeb
    {
        public static void Publish(string WebRoot)
        {
            using (ServerManager serverManager = new ServerManager())
            {
                Configuration config = serverManager.GetApplicationHostConfiguration();
                ConfigurationSection sitesSection = config.GetSection("system.applicationHost/sites");
                ConfigurationElementCollection sitesCollection = sitesSection.GetCollection();
                ConfigurationElement siteElement = FindElement(sitesCollection, "site", "name", @"Contoso");

                if (siteElement == null) throw new InvalidOperationException("Element not found!");

                ConfigurationElementCollection siteCollection = siteElement.GetCollection();
                ConfigurationElement applicationElement = siteCollection.CreateElement("application");

                applicationElement["path"] = @"/ShoppingCart";
                ConfigurationElementCollection applicationCollection = applicationElement.GetCollection();
                ConfigurationElement virtualDirectoryElement = applicationCollection.CreateElement("virtualDirectory");
                virtualDirectoryElement["path"] = @"/";
                //virtualDirectoryElement["physicalPath"] = @"C:\Inetpub\Contoso\ShoppingCart";
                virtualDirectoryElement["physicalPath"] = WebRoot;
                applicationCollection.Add(virtualDirectoryElement);
                siteCollection.Add(applicationElement);

                serverManager.CommitChanges();
            }
        }
        public static List<string> getIISWebSite()
        {
            List<string> myList = new List<string>();
            using (ServerManager serverManager = new ServerManager())
            {
                Configuration config = serverManager.GetApplicationHostConfiguration();
                ConfigurationSection sitesSection = config.GetSection("system.applicationHost/sites");
                ConfigurationElementCollection sitesCollection = sitesSection.GetCollection();
                foreach (ConfigurationElement element in sitesCollection)
                {
                    if (String.Equals(element.ElementTagName, "site", StringComparison.OrdinalIgnoreCase))
                    {
                        object o = element.GetAttributeValue("name");
                        if (o != null)
                        {
                            string strSiteName = o.ToString();
                            Site currSite = serverManager.Sites[strSiteName];
                            string port = "";
                            foreach (Binding binding in currSite.Bindings)
                            {
                                if (binding.Protocol == "http")
                                {
                                    port = binding.BindingInformation.Replace("*","");
                                    break;
                                }
                            }
                            myList.Add(strSiteName + port);
                        }
                    }
                }
            }

            return myList;
        }
        public static List<string> GetWebSiteApplication(string strSite)
        {
            List<string> myList = new List<string>();
            ServerManager manager = new ServerManager();
            Site curSite = manager.Sites[strSite];
            foreach (Application b in curSite.Applications)
            {
                myList.Add(b.Path);
            }
           // ApplicationPool blogPool = manager.ApplicationPools.Add("BlogApplicationPool");
          //  Application app = defaultSite.Applications.Add("/blogs", @"C:\inetpub\wwwroot\blogs");
            //manager.CommitChanges();

            return myList;
        }
        private static ConfigurationElement FindElement(ConfigurationElementCollection collection, string elementTagName, params string[] keyValues)
        {
            foreach (ConfigurationElement element in collection)
            {
                if (String.Equals(element.ElementTagName, elementTagName, StringComparison.OrdinalIgnoreCase))
                {
                    bool matches = true;
                    for (int i = 0; i < keyValues.Length; i += 2)
                    {
                        object o = element.GetAttributeValue(keyValues[i]);
                        string value = null;
                        if (o != null)
                        {
                            value = o.ToString();
                        }
                        if (!String.Equals(value, keyValues[i + 1], StringComparison.OrdinalIgnoreCase))
                        {
                            matches = false;
                            break;
                        }
                    }
                    if (matches)
                    {
                        return element;
                    }
                }
            }
            return null;
        }
    }



}

