using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Reflection;
namespace DtpFW.Import
{
    public class SyMappingManager
    {
    }

    public class DbSyMapping : BaseDBEntity
    {
        public int CompanyID { get; set; }
        public Guid MappingID { get; set; }
        public Guid InverseMappingID { get; set; }
        public string MappingName { get; set; }
        public bool IsActive	{get;set;}
        public string ScreenID	{get;set;}
        public string MappingType	{get;set;}
        public string GraphName	{get;set;}
        public string ViewName	{get;set;}
        public Guid ProviderID { get; set; }
        public string ProviderObject	{get;set;}
        public string SyncType	{get;set;}
        public string Status	{get;set;}
        public int FieldCntr	{get;set;}
        public int FieldOrderCntr	{get;set;}
        public int ImportConditionCntr	{get;set;}
        public int ConditionCntr	{get;set;}
        public int DataCntr	{get;set;}
        public int NbrRecords	{get;set;}
        public DateTime PreparedOn	{get;set;}
        public DateTime CompletedOn	{get;set;}
        public string ImportTimeStamp	{get;set;}
        public DateTime ExportTimeStamp	{get;set;}
        public int NoteID	{get;set;}
        public string FormatLocale	{get;set;}
        public Guid CreatedByID	{get;set;}
        public string CreatedByScreenID	{get;set;}
        public DateTime CreatedDateTime	{get;set;}
        public Guid LastModifiedByID	{get;set;}
        public string LastModifiedByScreenID	{get;set;}
        public DateTime LastModifiedDateTime	{get;set;}
        //public TimeSpan TStamp { get; set; }
        public byte[] CompanyMask	{get;set;}
        public Guid SitemapID { get; set; }

    }

    public class DbSyMappingCollection : BaseDBEntityCollection<DbSyMapping> { }
    public class DbSyMappingManager
    {
        private static DbSyMapping GetItemFromReader(IDataReader dataReader)
        {
            DbSyMapping objItem = new DbSyMapping();
            objItem.MappingName = SqlHelper.GetString(dataReader, "Name");
            objItem.MappingID = SqlHelper.GetGuid(dataReader, "MappingId");
            objItem.ProviderID = SqlHelper.GetGuid(dataReader, "ProviderID");
            objItem.CompanyID = SqlHelper.GetInt(dataReader, "CompanyID");

            objItem.InverseMappingID = SqlHelper.GetGuid(dataReader, "InverseMappingID");

            objItem.IsActive = SqlHelper.GetBoolean(dataReader, "IsActive");
            objItem.ScreenID = SqlHelper.GetString(dataReader, "ScreenID");
            objItem.MappingType = SqlHelper.GetString(dataReader, "MappingType");
            objItem.GraphName = SqlHelper.GetString(dataReader, "GraphName");
            objItem.ViewName = SqlHelper.GetString(dataReader, "ViewName");

            objItem.ProviderObject = SqlHelper.GetString(dataReader, "ProviderObject");
            objItem.SyncType = SqlHelper.GetString(dataReader, "SyncType");
            objItem.Status = SqlHelper.GetString(dataReader, "Status");
            objItem.FieldCntr = SqlHelper.GetSmallInt(dataReader, "FieldCntr");
            objItem.FieldOrderCntr = SqlHelper.GetSmallInt(dataReader, "FieldOrderCntr");
            objItem.ImportConditionCntr = SqlHelper.GetSmallInt(dataReader, "ImportConditionCntr");
            objItem.ConditionCntr = SqlHelper.GetSmallInt(dataReader, "ConditionCntr");
            objItem.DataCntr = SqlHelper.GetInt(dataReader, "DataCntr");
            objItem.NbrRecords = SqlHelper.GetInt(dataReader, "NbrRecords");
            objItem.PreparedOn = SqlHelper.GetDateTime(dataReader, "PreparedOn");
            objItem.CompletedOn = SqlHelper.GetDateTime(dataReader, "CompletedOn");
            objItem.ImportTimeStamp = SqlHelper.GetString(dataReader, "ImportTimeStamp");
            objItem.ExportTimeStamp = SqlHelper.GetDateTime(dataReader, "ExportTimeStamp");
            objItem.NoteID = SqlHelper.GetInt(dataReader, "NoteID");
            objItem.FormatLocale = SqlHelper.GetString(dataReader, "FormatLocale");
            objItem.CreatedByID = SqlHelper.GetGuid(dataReader, "CreatedByID");
            objItem.CreatedByScreenID = SqlHelper.GetString(dataReader, "CreatedByScreenID");
            objItem.CreatedDateTime = SqlHelper.GetDateTime(dataReader, "CreatedDateTime");
            objItem.LastModifiedByID = SqlHelper.GetGuid(dataReader, "LastModifiedByID");
            objItem.LastModifiedByScreenID = SqlHelper.GetString(dataReader, "LastModifiedByScreenID");
            objItem.LastModifiedDateTime = SqlHelper.GetDateTime(dataReader, "LastModifiedDateTime");
            //objItem.TStamp = SqlHelper.GetTimeSpan(dataReader, "TStamp");
            objItem.CompanyMask = SqlHelper.GetBytes(dataReader, "CompanyMask");
            objItem.SitemapID = SqlHelper.GetGuid(dataReader, "SitemapID");
            return objItem;
        }
        public static DbSyMappingCollection GetAllItem(string companyID)
        {
            DbSyMappingCollection ItemCollection = new DbSyMappingCollection();
            Database db = SqlHelper.CreateConnection(ConnectionHelper.Connection);
            DbCommand dbCommand = db.GetSqlStringCommand("SELECT * FROM SyMapping where CompanyID=" + companyID + " and MappingType='I'");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    DbSyMapping item = GetItemFromReader(dataReader);
                    ItemCollection.Add(item);
                }
            }
            return ItemCollection;
        }

        public static DbSyMapping GetSingleImportItem(string companyID, string MappingName)
        {
            DbSyMapping item = null;
            Database db = SqlHelper.CreateConnection(ConnectionHelper.Connection);
            DbCommand dbCommand = db.GetSqlStringCommand("SELECT Top 1 * FROM SyMapping where Name =N'" + MappingName + "' and  CompanyID=" + companyID + " and MappingType='I'");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                     item = GetItemFromReader(dataReader);
                   
                }
            }
            return item;
        }
        private static string BuildInsertTableScript(string tableName)
        {
            StringBuilder myScript = new StringBuilder();
            DBClumnCollection objCol =  DBClumnManager.GetAllItem(tableName);
            myScript.AppendLine("Insert Into " + tableName +"(");
            for (int i = 0; i < objCol.Count; i++)
            {
                DBColumn objItem = objCol[i];
                if (objItem.ColumnName != "TStamp")
                {
                    if (objCol.Count - 1 == i)
                    {
                        myScript.AppendLine("[" + objItem.ColumnName + "]");
                    }
                    else
                    {
                        myScript.AppendLine("[" + objItem.ColumnName + "],");
                    }
                }
            }
           
            myScript.AppendLine(")");


            return myScript.ToString();
        }
        public static string BuildTemplateScript(string MappingName,string companyID)
        {
            StringBuilder myscript = new StringBuilder();
            

            DbSyMapping objMappings = GetSingleImportItem(companyID, MappingName);
           

            string path = Path.GetDirectoryName(Assembly.GetAssembly(typeof(DbSyMappingManager)).CodeBase).Replace("file:\\","") +"\\Template\\ImportScenario.sql";
            string providerId ="N'"+ objMappings.ProviderID.ToString().ToUpper()+"'";
            string strProvideStatement = "CompanyID=" + companyID + " and providerID=''" + objMappings.ProviderID + "'' ";
            DbDataCollection objCols = DbDataManager.GetInserData("syProvider", strProvideStatement);
            SYProvider objProvider = SYProviderManager.getItemByID(objMappings.ProviderID.ToString(),companyID);
            string TemplateScript = FileHelper.GetTextContent("ImportScenario.sql");
            TemplateScript = TemplateScript.Replace("{#CompanyID}", companyID);
            TemplateScript = TemplateScript.Replace("{#ProviderName}", objProvider.Name);
            TemplateScript = TemplateScript.Replace("{#MappingName}", objMappings.MappingName);
            
            string replacementData = "";
            foreach (DbData objItem in objCols)
            {
                replacementData = objItem.MyInst.Replace(providerId, "@ProviderID");
                replacementData += "\n\r  \n\r";
            }
            TemplateScript = TemplateScript.Replace("{#SyProvider}", replacementData);
            


            
            
            //get value from syProviderParameter 
            objCols = DbDataManager.GetInserData("SYProviderParameter", strProvideStatement);
            replacementData = "";
            foreach (DbData objItem in objCols)
            {
                replacementData += objItem.MyInst.Replace(providerId, "@ProviderID") + "\n\r  \n\r";
            }
            TemplateScript = TemplateScript.Replace("{#SyProviderParam}", replacementData);


            //get value from SYProviderObject 
            objCols = DbDataManager.GetInserData("SYProviderObject", strProvideStatement);
            replacementData = "";
            foreach (DbData objItem in objCols)
            {
                replacementData += objItem.MyInst.Replace(providerId, "@ProviderID") + "\n\r  \n\r";
            }
            TemplateScript = TemplateScript.Replace("{#SyProviderObject}", replacementData);


            //get value from SYProviderObject 
            objCols = DbDataManager.GetInserData("SYProviderField", strProvideStatement);
            replacementData = "";
            foreach (DbData objItem in objCols)
            {
                replacementData += objItem.MyInst.Replace(providerId, "@ProviderID") + "\n\r  \n\r";
            }
            TemplateScript = TemplateScript.Replace("{#SYProviderField}", replacementData);

            
            
            
            
            



            ///{#SYMappingField}
            strProvideStatement = "CompanyID=" + companyID + " and MappingID=''" + objMappings.MappingID + "'' ";
            objCols = DbDataManager.GetInserData("SYMappingField", strProvideStatement);
            replacementData = "";
            foreach (DbData objItem in objCols)
            {
                replacementData += objItem.MyInst.Replace(providerId, "@ProviderID") + "\n\r  \n\r";
            }

            TemplateScript = TemplateScript.Replace("{#SYMappingField}", replacementData);
            TemplateScript = TemplateScript.Replace("N'" + objMappings.MappingID.ToString().ToUpper() + "'", "@MappingID") + "\n\r  \n\r";
            TemplateScript = TemplateScript.Replace("N'"+objMappings.ScreenID.ToString().ToUpper()+"'", "@UserID");
            TemplateScript = TemplateScript.Replace("(" + companyID, "(@CompanyID");
            TemplateScript = TemplateScript.Replace("NULL)", "@CompanyMask)");


            //get value from SYMapping 
            objCols = DbDataManager.GetInserData("SYMapping", strProvideStatement);
            replacementData = "";
            foreach (DbData objItem in objCols)
            {
                replacementData += objItem.MyInst.Replace(providerId, "@ProviderID") + "\n\r  \n\r";
            }
            TemplateScript = TemplateScript.Replace("{#SYMapping}", replacementData);
            TemplateScript = TemplateScript.Replace("(" + companyID, "(@CompanyID");
            TemplateScript = TemplateScript.Replace("NULL,NULL)", "@CompanyMask,NULL)");

            




            myscript.AppendLine(TemplateScript); 



            //myscript.AppendLine(ClassHelper.BuildClass("Company"));
         /*   foreach (DbSyMapping item in objMappings)
            {
                myscript.AppendLine(BuildInsertTableScript("SyMapping"));
                myscript.AppendLine(" values(");
                Type entityType = item.GetType();
                
                    int i = 0;
                foreach (var property in entityType.GetProperties())
                {
                    if (property.Name != "CompanyMask")
                    {
                        if (property.GetValue(item, null) != null)
                        {
                            myscript.AppendLine("'" + property.GetValue(item, null).ToString() + "'");
                        }
                        else
                        {
                            myscript.AppendLine("null");
                        }
                        if (i != entityType.GetProperties().Length - 1)
                        {
                            myscript.Append(",");
                        }
                    }
                    else
                    {
                        myscript.AppendLine("'0xAA308C'");
                    }
                    i++;
                }
                myscript.AppendLine(" )");
            }
            */
            return myscript.ToString();
        }
        private void ReplaceProvideTemp(DbSyMapping objMappings, string Template)
        {

        }
        public static int NonNullPropertiesCount(object entity)
        {
            if (entity == null) throw new ArgumentNullException("A null object was passed in");


            int nonNullPropertiesCount = 0;
            Type entityType = entity.GetType();

            foreach (var property in entityType.GetProperties())
            {
                if (property.GetValue(entity, null) != null)
                    nonNullPropertiesCount = nonNullPropertiesCount + 1;
            }


            return nonNullPropertiesCount;
        }

        

    }
}
