using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DtpFW
{
    public class HtmlPageHelper
    {
        public static string PageHTMLRender(string tableName, string strNamespace)
        {
            StringBuilder sp = new StringBuilder();
            string[] strPK = ClassHelper.GetTablePK(tableName);
            string TemplateScript = FileHelper.GetTextContent("PageFrm.ascx");
            TemplateScript = TemplateScript.Replace("{#Table}", "DB" + tableName);
            TemplateScript = TemplateScript.Replace("{#Namespace}", @"<%@ Import Namespace=""" + strNamespace + @""" %>");
            TemplateScript = TemplateScript.Replace("{#Parameter}", AddParameter(tableName));
            TemplateScript = TemplateScript.Replace("{#paraField}", ListParamFiled(tableName,false));
            TemplateScript = TemplateScript.Replace("{#AddparaField}", ListParamFiled(tableName,true));
            TemplateScript = TemplateScript.Replace("{#ListKhaiBao}", KhaiBaoHam(tableName));
            TemplateScript = TemplateScript.Replace("{#updatekhaibao}", UpdateKhaiBao(tableName));
            TemplateScript = TemplateScript.Replace("{$khaibaofield}", KhaiBaofield(tableName));

            
            sp.AppendLine(TemplateScript);
            return sp.ToString();
        }
        public static string KhaiBaofield(string tableName)
        {
            StringBuilder sp = new StringBuilder();
            string[] strPK = ClassHelper.GetTablePK(tableName);
            StringBuilder strParameter = new StringBuilder();
            DBClassCollection objLists = ClassHelper.GetDbClass(tableName);

            for (int i = 0; i < objLists.Count; i++)
            {
                DBClass objItem = objLists[i];
                if (objItem.ColName != strPK[0])
                {
                    strParameter.AppendLine( @"<%=AdminForm.TextField(new TextFieldAttribute(){
                                    FieldValue = objDB" + tableName + @"." + objItem.ColName + @".ToString(),
                                    FieldID = ""dtp" + objItem.ColName + @""",
                                    FieldName = ""dtp" + objItem.ColName + @""",
                                    LabelName=ngonngu(""gl." + objItem.ColName + @"objItem.ColName"")})%>");
                }

            }
            sp.Append(strParameter);
            return sp.ToString();
        }
        public static string UpdateKhaiBao(string tableName)
        {
            StringBuilder sp = new StringBuilder();
            string[] strPK = ClassHelper.GetTablePK(tableName);
            string strParameter = "";
            DBClassCollection objLists = ClassHelper.GetDbClass(tableName);

            for (int i = 0; i < objLists.Count; i++)
            {
                DBClass objItem = objLists[i];
                
                sp.AppendLine( objItem.ColType +" " + objItem.ColName + " = FormQuery.QueryString" + (objItem.ColType != "string" ? ChangeType(objItem.ColType) : "") + @"(""dtp" + objItem.ColName + @""");");
                //if (i != objLists.Count - 1) { sp.Append( ";"); }


            }
            sp.Append(strParameter);
            return sp.ToString();
        }
        public static string ChangeType(string strType)
        {
            string value = strType;
            switch (strType){
                case "int":
                    value = "Int";
                    break;

            }
            return value;
        }
        public static string KhaiBaoHam(string tableName)
        {
            StringBuilder sp = new StringBuilder();
            string[] strPK = ClassHelper.GetTablePK(tableName);
            
            sp.AppendLine(strPK[0] +"=0,");
            DBClassCollection objLists = ClassHelper.GetDbClass(tableName);

            for (int i = 0; i < objLists.Count; i++)
            {
                DBClass objItem = objLists[i];
                if (objItem.ColName != strPK[0])
                {
                    sp.AppendLine(objItem.ColName + " = FormQuery.QueryString" + (objItem.ColType != "string" ? ChangeType(objItem.ColType) : "") + @"(""dtp" + objItem.ColName + @""")");
                    if (i != objLists.Count - 1) {sp.Append(","); }
                }

            }
            return sp.ToString();
        }
        public static string ListParamFiled(string tableName,bool isAdd)
        {
            StringBuilder sp = new StringBuilder();
            string[] strPK = ClassHelper.GetTablePK(tableName);
            string strParameter = "";
            DBClassCollection objLists = ClassHelper.GetDbClass(tableName);

            for (int i = 0; i < objLists.Count; i++)
            {
                DBClass objItem = objLists[i];
                if (isAdd)
                {
                    if (objItem.ColName != strPK[0])
                    {
                        strParameter += objItem.ColName;
                        if (i != objLists.Count - 1) { strParameter += ","; }
                    }
                }
                else
                {
                    strParameter += objItem.ColName;
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
