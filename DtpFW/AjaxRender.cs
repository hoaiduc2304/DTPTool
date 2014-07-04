using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DtpFW
{
    public class AjaxRender
    {
        public static string PageAjaxRender(string tableName, string strNamespace)
        {
            StringBuilder sp = new StringBuilder();
            string[] strPK = ClassHelper.GetTablePK(tableName);
            string TemplateScript = FileHelper.GetTextContent("AjaxTemp.aspx");
            TemplateScript = TemplateScript.Replace("{#Table}", "DB"+tableName);
            TemplateScript = TemplateScript.Replace("{#Namespace}", @"<%@ Import Namespace="""+strNamespace+@""" %>");
            TemplateScript = TemplateScript.Replace("{#Parameter}", AddParameter(tableName));
            TemplateScript = TemplateScript.Replace("{#ListParam}", ListParam(tableName));
            TemplateScript = TemplateScript.Replace("{#PKID}", strPK[0]);
            TemplateScript = TemplateScript.Replace("{#paraField}", ListParamFiled(tableName));
            TemplateScript = TemplateScript.Replace("{#JsonItem}", ListJson(tableName));
            TemplateScript = TemplateScript.Replace(",)", ")");
            sp.AppendLine(TemplateScript);
            return sp.ToString();
        }
        public static string ListJson(String tableName)
        {

            StringBuilder sp = new StringBuilder();
            string[] strPK = ClassHelper.GetTablePK(tableName);
            string strParameter = "";
            DBClassCollection objLists = ClassHelper.GetDbClass(tableName);

            for (int i = 0; i < objLists.Count; i++)
            {
                DBClass objItem = objLists[i];
                sp.AppendLine(@"jsonWriter.WritePropertyName("""+objItem.ColName+@""");");
                sp.AppendLine(@"jsonWriter.WriteValue(objItem."+objItem.ColName+@".ToString());");
            }
            //sp.Append(strParameter);
            return sp.ToString();
        }
        public static string ListParamFiled(string tableName)
        {
            StringBuilder sp = new StringBuilder();
            string[] strPK = ClassHelper.GetTablePK(tableName);
            string strParameter = "";
            DBClassCollection objLists = ClassHelper.GetDbClass(tableName);

            for (int i = 0; i < objLists.Count; i++)
            {
                DBClass objItem = objLists[i];

                strParameter += objItem.ColName;
                if (i != objLists.Count - 1) { strParameter += ","; }

            }
            sp.Append(strParameter);
            return sp.ToString();
        }
        public static string ListParam(string tableName)
        {
            StringBuilder sp = new StringBuilder();
            string[] strPK = ClassHelper.GetTablePK(tableName);
            string strParameter = "";
            DBClassCollection objLists = ClassHelper.GetDbClass(tableName);

            for (int i = 0; i < objLists.Count; i++)
            {
                DBClass objItem = objLists[i];
                if (objItem.ColType != "xml" && objItem.ColType != "XmlDocument")
                {
                    strParameter += objItem.ColType + " " + objItem.ColName;
                    if (i != objLists.Count - 1) { strParameter += ","; }
                }
            }
            sp.Append(strParameter);
            return sp.ToString();
        }
        public static string AddParameter(string tableName)
        {
            StringBuilder sp = new StringBuilder();
            string[] strPK = ClassHelper.GetTablePK(tableName);
            DBClassCollection objLists = ClassHelper.GetSmallClass(tableName);
            
            for (int i = 0; i < objLists.Count; i++)
            {
                DBClass objItem = objLists[i];
                if (objItem.ColName == strPK[0])
                {
                    sp.Append(@"int.Parse(Context.Request[""" + strPK[0] + @"""].ToString())");
                }
                else
                {
                    if (objItem.ColType != "xml")
                    {
                        if (objItem.ColType == "int" || objItem.ColType == "Int64")
                        {
                            sp.Append(objItem.ColType + @".Parse(Context.Request[""" + objItem.ColName + @"""].ToString())");
                        }
                        else
                        {
                            sp.Append(@"Context.Request[""" + objItem.ColName + @"""].ToString()");
                        }
                    }

                }
                if (objItem.ColType != "xml")
                {
                    if (i != objLists.Count - 1)
                    {
                        sp.Append(", \n");
                    }
                }
            }
            return sp.ToString();
        }
    }
}
