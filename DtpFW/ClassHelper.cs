using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

namespace DtpFW
{
    public class DBClass :BaseDBEntity
    {
        public string DefClass { get; set; }
        public string MappingObject { get; set; }
        public string AddParameter { get; set; }
        public string UpdateParameter { get; set; }
        public string ColName { get; set; }
        public string ColType { get; set; }
        public string ColLength { get; set; }
        
    }


    public class DBClassCollection : BaseDBEntityCollection<DBClass> { }
    public class ClassHelper
    {
        private static DBClass GetItemFromReader(IDataReader dataReader)
        {
            DBClass objItem = new DBClass();
            objItem.DefClass = SqlHelper.GetString(dataReader, "DefClass");
            objItem.MappingObject = SqlHelper.GetString(dataReader, "MappingObject");
            objItem.AddParameter = SqlHelper.GetString(dataReader, "AddParameter");
            objItem.UpdateParameter = SqlHelper.GetString(dataReader, "UpdateParameter");
            objItem.ColName = SqlHelper.GetString(dataReader, "ColName");
            objItem.ColType = SqlHelper.GetString(dataReader, "ColType");
            return objItem;
        }
        private static DBClass GetItemSmallReader(IDataReader dataReader)
        {
            DBClass objItem = new DBClass();
            objItem.ColName = SqlHelper.GetString(dataReader, "ColName");
            objItem.ColType = SqlHelper.GetString(dataReader, "ColType");
            objItem.ColLength = SqlHelper.GetString(dataReader, "ColLength");

            return objItem;
        }
        public static DBClassCollection GetSmallClass(string tableName)
        {
            DBClassCollection ItemCollection = new DBClassCollection();
            Database db = SqlHelper.CreateConnection(ConnectionHelper.Connection);
            string sqlScript = @"select 
ColName = Column_name,
ColType =Data_type,
ColLength= CAST(ISNULL(CHARACTER_MAXIMUM_LENGTH,'') AS NVARCHAR(200))

from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='" + tableName+"'";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlScript);
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    DBClass item = GetItemSmallReader(dataReader);
                    ItemCollection.Add(item);
                }
            }
            return ItemCollection;
        }
        public static string SPBuilder(string tableName)
        {
            StringBuilder sp = new StringBuilder();
            sp.AppendLine(GetAllSP(tableName));
            sp.AppendLine(GetByIDSP(tableName));
            sp.AppendLine(DeleteSP(tableName));
            sp.AppendLine(GetAddSP(tableName));
            sp.AppendLine(GetUpdateSP(tableName));
            sp.AppendLine(GetPagingSP(tableName));
            
            
            return sp.ToString();
        }

      
        public static string BuildClass(string tableName,string strNameSpace)
        {

            DBClassCollection objItem = GetDbClass(tableName);
            string strPKID = GetTablePK(tableName)[0];
            string PKType = GetTablePK(tableName)[1];
            string strObjClass = "";
            string strMappClass = "";
            string strAddClass="";
            string strUpdateClass="";
            string strParameter = "";
            string strInsertParameter = "";
            int i = 0;
            foreach (DBClass item in objItem)
            {
                strObjClass += item.DefClass + "\n\r";
                strMappClass += item.MappingObject + "\n\r";
                strAddClass+=item.AddParameter +"\n\r";
                strUpdateClass+=item.UpdateParameter +"\n\r";
                strParameter += item.ColType +" " + item.ColName ;
                if (item.ColName != strPKID)
                {
                    strInsertParameter += item.ColType + " " + item.ColName;
                    if (i != objItem.Count - 1) { strInsertParameter += ","; }
                }
                if (i != objItem.Count - 1) { strParameter += ","; }
                i++;
            }
            StringBuilder script = new StringBuilder();
            script.AppendLine(@"using Microsoft.Practices.EnterpriseLibrary.Data;
                    using System.Text;
                    using Newtonsoft.Json;");
            script.AppendLine("using System.Data;");
            script.AppendLine("using System.Data.Common;");
            script.AppendLine("using System;");
            script.AppendLine("using dtp.Web.Caching;");
            
            script.AppendLine("namespace "+strNameSpace);
            script.AppendLine("{");
            script.AppendLine("public class DB" + tableName + " :BaseDBEntity");
            script.AppendLine("{");

            script.AppendLine(strObjClass);
            script.AppendLine("}");
            script.AppendLine("public class DB" + tableName + "Collection : BaseDBEntityCollection<DB" + tableName + "> { }");
            script.AppendLine("public class DB" + tableName + "Manager");
            script.AppendLine("{");
            //----
            //----Constants-----//
            script.AppendLine(@" #region Constants
        private const string SETTINGS_ALL_KEY = """+strNameSpace+@"."+tableName+@".all"";
        private const string SETTINGS_ID_KEY = """ + strNameSpace + @"." + tableName + @".{0}"";
       
        #endregion");
            script.AppendLine("private static DB" + tableName + " GetItemFromReader(IDataReader dataReader)");
            script.AppendLine("{");
            script.AppendLine("DB" + tableName + " objItem = new DB" + tableName + "();"); 
            script.AppendLine(strMappClass);
            script.AppendLine("return objItem;");
            script.AppendLine("}");

            //---Khai Bao ham GetElementByID --//
            script.AppendLine(@" public static DB" + tableName + " GetItemByID(" + PKType + " " + strPKID + @")
        {
            string key = String.Format(SETTINGS_ID_KEY, " + strPKID + @");
            object obj2 = dtpCache.Get(key);
            if (obj2 != null) { return (DB" + tableName + @")obj2; }


            DB" + tableName + @" item = null;
            Database db = SqlHelper.CreateConnection(SqlHelper.MyConnection);
            DbCommand dbCommand = db.GetStoredProcCommand(""" + tableName + @"_GetByID"");
            db.AddInParameter(dbCommand, """ + strPKID + @""", DbType." + PKType + @", " + strPKID + @");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    item = GetItemFromReader(dataReader);
                }
            }
            dtpCache.Max(key, item); 
            return item;
           
        }");
            //------------------------------------//
            //---Khai bao ham Add New

            script.AppendLine(@"public static DB" + tableName + @" AddItem(" + strInsertParameter + @")
        {
            DB" + tableName + @" item = null;
            Database db = SqlHelper.CreateConnection(SqlHelper.MyConnection);
            DbCommand dbCommand = db.GetStoredProcCommand(""" + tableName + @"_Add"");
           " +strAddClass+@"
            if (db.ExecuteNonQuery(dbCommand) > 0)
            {
                ");
            if(PKType.ToLower()=="guid"){
                script.AppendLine(@"Guid itemID = (Guid)(db.GetParameterValue(dbCommand, ""@" + strPKID + @"""));");
            }else{
                script.AppendLine(@"int itemID = Convert.ToInt32(db.GetParameterValue(dbCommand, ""@"+strPKID+ @"""));");
            }
                script.AppendLine(@"item = GetItemByID(itemID);
                dtpCache.RemoveByPattern(SETTINGS_ALL_KEY);
                dtpCache.RemoveByPattern(string.Format(SETTINGS_ID_KEY, item."+strPKID+@"));
            }
            return item;
        }");

            //------------------------------------//
            //-----Update -----//
            script.AppendLine(@"public static  DB" + tableName + @" UpdateItem(" + strParameter + @")
    {
       DB" + tableName + @" item = null;
      Database db = SqlHelper.CreateConnection(SqlHelper.MyConnection);
      DbCommand dbCommand = db.GetStoredProcCommand(""" + tableName + @"_Update"");
     " + strUpdateClass + @"
      if (db.ExecuteNonQuery(dbCommand) > 0)
        item = GetItemByID("+strPKID+ @");
        dtpCache.RemoveByPattern(SETTINGS_ALL_KEY); 
        dtpCache.RemoveByPattern(string.Format(SETTINGS_ID_KEY, " + strPKID + @"));
      return item;
    }");
            //------------------//
            //---------------Ham Pagging-------//
            script.AppendLine(@"public static DB" + tableName + @"Collection GetItemPagging(int page, int rec, string strSearch, out int TotalRecords)
        {
            TotalRecords = 0;
            DB" + tableName + @"Collection ItemCollection = new DB" + tableName + @"Collection();
            Database db = SqlHelper.CreateConnection(SqlHelper.MyConnection);
            DbCommand dbCommand = db.GetStoredProcCommand("""+tableName+@"_Paging"");
            db.AddInParameter(dbCommand, ""Page"", DbType.Int32, page);
            db.AddInParameter(dbCommand, ""RecsPerPage"", DbType.Int32, rec);
            db.AddInParameter(dbCommand, ""SearchValue"", DbType.String, strSearch);
            db.AddOutParameter(dbCommand, ""TotalRecords"", DbType.Int32, 0);
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    DB" + tableName + @" item = GetItemFromReader(dataReader);
                    ItemCollection.Add(item);
                }
            }
            TotalRecords = Convert.ToInt32(db.GetParameterValue(dbCommand, ""@TotalRecords""));
            return ItemCollection;
        }");
            //----------------------------------//
            //--Khai Bao ham getAll--//
            script.AppendLine(@" public static DB"+tableName+@"Collection GetAllItem()
        {
            string key = SETTINGS_ALL_KEY;
            object obj2 = dtpCache.Get(key);
            if ((obj2 != null))
            {
                return (DB"+tableName+@"Collection)obj2;
            }
            DB"+tableName+@"Collection ItemCollection = new DB"+tableName+@"Collection();
            Database db = SqlHelper.CreateConnection(SqlHelper.MyConnection);
            DbCommand dbCommand = db.GetStoredProcCommand(""" + tableName + @"_GetAll"");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    DB" + tableName + @" item = GetItemFromReader(dataReader);
                    ItemCollection.Add(item);
                }
            }

            dtpCache.Max(key, ItemCollection);
            
            return ItemCollection;
        }");
            //--Khai bao ham tra ve JSon--//
            script.AppendLine(@"public static string GetJson(DB" + tableName + @"Collection itemCollection)
        {
            StringBuilder builder = new StringBuilder();
            if (itemCollection.Count > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                System.IO.StringWriter sw = new System.IO.StringWriter(sb);
                using (JsonWriter jsonWriter = new JsonTextWriter(sw))
                {
                    jsonWriter.Formatting = Formatting.Indented;
                    jsonWriter.WriteStartObject();
                    jsonWriter.WritePropertyName(""results"");
                    jsonWriter.WriteStartArray();
                    itemCollection.ForEach(delegate(DB" + tableName + @" objItem)
                    {
jsonWriter.WriteStartObject();
                       " + ListJson(tableName) + @"
jsonWriter.WriteEndObject();
                    });
                    jsonWriter.WriteEndArray();

                    jsonWriter.WriteEndObject();
                    builder.AppendLine(sw.ToString());

                }
            }
            else
            {
                builder.AppendLine(""{'results':[{id:'-1'}]}"");

            }
            return builder.ToString();
        }
");
            //-----//
            script.AppendLine(@"
            public static int DeleteItem(int ItemId)
        {
            Database db = SqlHelper.CreateConnection(SqlHelper.MyConnection);
            DbCommand dbCommand = db.GetStoredProcCommand(""" + tableName + @"_Delete"");
            db.AddInParameter(dbCommand,  """ + strPKID + @""", DbType.Int32, ItemId);
            dtpCache.RemoveByPattern(SETTINGS_ALL_KEY);
            dtpCache.RemoveByPattern(string.Format(SETTINGS_ID_KEY, ItemId));
            return db.ExecuteNonQuery(dbCommand);
        }");
            //----//
            script.AppendLine("}");
            //--End Namespace--//
            script.AppendLine("}");
            return script.ToString();
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
                sp.AppendLine(@"jsonWriter.WritePropertyName(""" + objItem.ColName + @""");");
                sp.AppendLine(@"jsonWriter.WriteValue(objItem." + objItem.ColName + @".ToString());");
            }
            //sp.Append(strParameter);
            return sp.ToString();
        }
        public static string[] GetTablePK(string tableName)
        {
            string[] PK= new string[3];
            DBClassCollection ItemCollection = new DBClassCollection();
            Database db = SqlHelper.CreateConnection(ConnectionHelper.Connection);
            string sqlScript = @"DECLARE @ColPK NVARCHAR(400),
@TableName NVARCHAR(300)
SET @TableName='"+tableName+ @"'
SELECT @ColPK = column_name
FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
WHERE OBJECTPROPERTY(OBJECT_ID(constraint_name), 'IsPrimaryKey') = 1
AND table_name = @TableName



select 
	PKColName = COLUMN_NAME,
    Data_type,
	ColType = Replace(
						Replace(
						Replace(
						Replace(
						Replace(
						Replace(
						Replace(
						Replace(
						Replace(
							Replace(Data_type,'int','Int32')
							,'bigint','Int64'),
							'uniqueidentifier','Guid'),
							'bit','Boolean'),
							'nvarchar','String'),
							'varchar','String'),
							 'datetime','DateTime'),
							 'char','String'),
							 'varbinary','Bytes'),'timestamp','TimeSpan')
	
 from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME=@TableName
and COLUMN_NAME=@ColPK";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlScript);
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    PK[0] = SqlHelper.GetString(dataReader, "PKColName");
                    PK[1] = SqlHelper.GetString(dataReader, "ColType");
                    PK[2] = SqlHelper.GetString(dataReader, "Data_type");
                    
                }
            }
            return PK;
        }
        public static DBClassCollection GetDbClass(string tableName)
        {
            DBClassCollection ItemCollection = new DBClassCollection();
            Database db = SqlHelper.CreateConnection(ConnectionHelper.Connection);
            string sqlScript = @"DECLARE @ColPK NVARCHAR(400),
@TableName NVARCHAR(300)
SET @TableName='"+tableName+ @"'
SELECT @ColPK = column_name
FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
WHERE OBJECTPROPERTY(OBJECT_ID(constraint_name), 'IsPrimaryKey') = 1
AND table_name = @TableName

select 
ColName = Column_name,
ColType = Replace( 
				Replace( 
				Replace( 
				Replace( 
				Replace(
				Replace(
				Replace(
				Replace(
				Replace(
Replace(
                Replace(
			    Replace(Data_type,'uniqueidentifier','Guid'),'bit','bool'),'nvarchar','string'),'varchar','string'),
                'ntext','string'),
			     'smallint','int'),'bigint','int'),'datetime','DateTime'),'char','string'),'varbinary','byte[]'),'xml','XmlDocument'),
                'timestamp','TimeSpan'),
DefClass='public '+
				Replace( 
				Replace( 
				Replace( 
				Replace( 
				Replace(
				Replace(
				Replace(
				Replace(
				Replace(
Replace(
Replace(
			    Replace(Data_type,'uniqueidentifier','Guid'),'bit','bool'),'nvarchar','string'),'varchar','string'),
                'ntext','String'),
'xml','XmlDocument'),
			     'smallint','int'),'bigint','int'),'datetime','DateTime'),'char','string'),'varbinary','byte[]'),'timestamp','TimeSpan')
 +' ' + Column_name  + '{ get; set; }',
MappingObject ='objItem.'+Column_name+' = SqlHelper.Get'+

		Replace( 
				Replace( 
				Replace( 
				Replace( 
				Replace(
				Replace(
				Replace(
				Replace(
				Replace(
				Replace(
                Replace(
                Replace(
			    Replace(Data_type,'uniqueidentifier','Guid'),'bit','Boolean'),'nvarchar','String'),'varchar','String'),
                'ntext','String'),
                'xml','XML'),
			     'smallint','SmallInt'),'bigint','Int'),'int','Int'),
			     'datetime','DateTime'),'char','String'),'varbinary','Bytes'),'timestamp','TimeSpan')
+'(dataReader, ""'+Column_name+'"");' ,

AddParameter=CASE
				WHEN Column_name = @ColPK THEN 'db.AddOutParameter(dbCommand, ""'+Column_name+'"", DbType.'+
				Replace(Replace(Replace(Data_type,'uniqueidentifier','Guid'),'bigint','Int64'),'int','Int32')+', 0);'
				ELSE 'db.AddInParameter(dbCommand, ""'+Column_name+'"", DbType.'+
						Replace(
						Replace(
						Replace(
						Replace(
						Replace(
						Replace(
						Replace(
						Replace(
						Replace(
                        Replace(
Replace(
							Replace(Data_type,'int','Int32'),
                            'xml','Xml'),
                            'ntext','String'),
							'bigint','Int64'),
							'uniqueidentifier','Guid'),
							'bit','Boolean'),
							'nvarchar','String'),
							'varchar','String'),
							 'datetime','DateTime'),
							 'char','String'),
							 'varbinary','Bytes'),'timestamp','TimeSpan')+', '+Column_name+');'
				END,
UpdateParameter=CASE
				WHEN Column_name = @ColPK 
				THEN 'db.AddInParameter(dbCommand, ""'+Column_name+'"", DbType.'+
				Replace(Replace(Replace(Data_type,'uniqueidentifier','Guid'),'bigint','Int64'),'int','Int32')+', '+Column_name+');'
				ELSE 'db.AddInParameter(dbCommand, ""'+Column_name+'"", DbType.'+
						Replace(
						Replace(
						Replace(
						Replace(
						Replace(
						Replace(
						Replace(
						Replace(
						Replace(
                        Replace(
                        Replace(
							Replace(Data_type,'int','Int32'),
                            'xml','Xml'),
                            'ntext','String')
							,'bigint','Int64'),
							'uniqueidentifier','Guid'),
							'bit','Boolean'),
							'nvarchar','String'),
							'varchar','String'),
							 'datetime','DateTime'),
							 'char','String'),
							 'varbinary','Bytes'),'timestamp','TimeSpan')+', '+Column_name+');'
				END
from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME=@TableName";

            DbCommand dbCommand = db.GetSqlStringCommand(sqlScript);
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    DBClass item = GetItemFromReader(dataReader);
                    ItemCollection.Add(item);
                }
            }
            return ItemCollection;
        }
        public static string GeneralClass(){
            return "Copyright by Duc Nguyen Hoai \n Email: hoaiduc2304@gmail.com";
    }

        #region Store Procs 
        private static string DeleteSP(string tableName)
        {
            StringBuilder sp = new StringBuilder();
            string[] strPKField = GetTablePK(tableName);
            sp.AppendLine(@"IF object_id('[dbo].[" + tableName + @"_Delete]') IS NOT NULL
                                DROP PROCEDURE [dbo].[" + tableName + @"_Delete]
                            GO");
            sp.AppendLine(@"CREATE PROCEDURE [dbo].[" + tableName + @"_Delete]
                @" + strPKField[0] + @" " + strPKField[2] + @"
                        AS
                    Delete  FROM " + tableName + @" where " + strPKField[0] + @"=@" + strPKField[0] + @";
                    GO");
            return sp.ToString();
        }

        private static string GetAllSP(string tableName)
        {
            StringBuilder sp = new StringBuilder();
            sp.AppendLine(@"IF object_id('[dbo].[" + tableName + @"_GetAll]') IS NOT NULL
                                DROP PROCEDURE [dbo].[" + tableName + @"_GetAll]
                            GO");
            sp.AppendLine(@"CREATE PROCEDURE [dbo].[" + tableName + @"_GetAll]

                        AS
                    SELECT * FROM " + tableName + @";
                    GO");
            return sp.ToString();
        }

        private static string GetByIDSP(string tableName)
        {
            StringBuilder sp = new StringBuilder();
            string[] strPKField = GetTablePK(tableName);
            sp.AppendLine(@"IF object_id('[dbo].[" + tableName + @"_GetByID]') IS NOT NULL
                                DROP PROCEDURE [dbo].[" + tableName + @"_GetByID]
                            GO");
            sp.AppendLine(@"CREATE PROCEDURE [dbo].[" + tableName + @"_GetByID]
                @" + strPKField[0] + @" " + strPKField[2] + @"
                        AS
                    SELECT * FROM " + tableName + @" where " + strPKField[0] + @"=@" + strPKField[0] + @";
                    GO");
            return sp.ToString();
        }
        private static string GetPagingSP(string tableName)
        {
            StringBuilder sp = new StringBuilder();
            string[] strPKField = GetTablePK(tableName);
            string strParameter = "";
            string strFields = "";
            string TemplateScript = FileHelper.GetTextContent("classPaging.sql");
            TemplateScript = TemplateScript.Replace("{#table}", tableName);
            TemplateScript = TemplateScript.Replace("{#PKID}", strPKField[0]);
            
            DBClassCollection objLists = GetSmallClass(tableName);
            for (int i = 0; i < objLists.Count; i++)
            {
                DBClass objItem = objLists[i];
                strFields += objItem.ColName;
                strParameter +=  objItem.ColName + " " + objItem.ColType;
                if (int.Parse(objItem.ColLength) > 0 && int.Parse(objItem.ColLength) < 4000)
                {
                    strParameter += "(" + objItem.ColLength + ")";
                }
                if (i != objLists.Count - 1)
                {
                    strParameter += ",";
                    strFields += ",";
                }
                strParameter += "\n";
                strFields += "\n";
            }
            TemplateScript = TemplateScript.Replace("{#Fields}", strParameter);
            TemplateScript = TemplateScript.Replace("{#Param}", strFields);
            sp.Append(TemplateScript);
            return sp.ToString();
        }
        private static string GetUpdateSP(string tableName)
        {
            StringBuilder sp = new StringBuilder();
            string[] strPKField = GetTablePK(tableName);
            DBClassCollection objLists = GetSmallClass(tableName);
            string strParameter = "";
            string strUpdate = "";
            for (int i = 0; i < objLists.Count; i++)
            {
                DBClass objItem = objLists[i];
                strParameter += "@" + objItem.ColName + " " + objItem.ColType;
                if (int.Parse(objItem.ColLength) > 0 && int.Parse(objItem.ColLength) < 4000)
                {
                    strParameter += "(" + objItem.ColLength + ")";
                }

                if (objItem.ColName != strPKField[0])
                {
                    strUpdate += objItem.ColName + "= @" + objItem.ColName;
                    if (i != objLists.Count - 1)
                    {
                        strUpdate += ",";
                    }
                }
                
               
                if (i != objLists.Count - 1)
                {
                    strParameter += ",";
                }
                strParameter += "\n";
                strUpdate += "\n";
            }
            sp.AppendLine(@"IF object_id('[dbo].[" + tableName + @"_Update]') IS NOT NULL
                                DROP PROCEDURE [dbo].[" + tableName + @"_Update]
                            GO");
            sp.AppendLine(@"CREATE PROCEDURE [dbo].[" + tableName + @"_Update]");
            sp.AppendLine(strParameter);
            sp.AppendLine("AS");
            sp.AppendLine("UPDATE "+ tableName);
            sp.AppendLine("SET");
            sp.AppendLine(strUpdate);
            sp.AppendLine("Where " + strPKField[0] + "= @" + strPKField[0]);
            sp.AppendLine("GO");
            return sp.ToString();
        }
        private static string GetAddSP(string tableName)
        {
            StringBuilder sp = new StringBuilder();
            string[] strPKField = GetTablePK(tableName);
            DBClassCollection objLists = GetSmallClass(tableName);
            string strParameter = "";
            string strInsert = "Insert Into " + tableName + "(";
            string strSelect = "Values(";
            for (int i = 0; i < objLists.Count; i++)
            {
                DBClass objItem = objLists[i];
                if (objItem.ColName != strPKField[0])
                {
                    strInsert += objItem.ColName;
                    strSelect += "@" + objItem.ColName;
                }
                else
                {
                    if (objItem.ColType == "uniqueidentifier")
                    {
                        strInsert += objItem.ColName +",";
                        strSelect += "@New" + objItem.ColName +",";

                    }
                }
                if(objItem.ColName!=strPKField[0]){
                strParameter += "@"+objItem.ColName + " " + objItem.ColType;
                }else{
                    strParameter += "@" + objItem.ColName + " " + objItem.ColType +"=null output";
                }

                if (int.Parse(objItem.ColLength) > 0 && int.Parse(objItem.ColLength) <4000)
                {
                    strParameter += "("+objItem.ColLength+")";
                }

                if (i != objLists.Count - 1)
                {
                    strParameter += ",";
                    if (objItem.ColName != strPKField[0])
                    {
                        
                        strSelect += ",";
                        strInsert += ",";
                    }
                }
                else
                {
                    strSelect += ")";
                    strInsert += ")";
                }
                strParameter += "\n\r";
            }
            sp.AppendLine(@"IF object_id('[dbo].[" + tableName + @"_Add]') IS NOT NULL
                                DROP PROCEDURE [dbo].[" + tableName + @"_Add]
                            GO");
            sp.AppendLine(@"CREATE PROCEDURE [dbo].[" + tableName + @"_Add]
                " + strParameter+ @"
                        AS ");
            if (strPKField[2] == "uniqueidentifier")
            {
                sp.AppendLine(@" DECLARE @New"+strPKField[0]+@" AS uniqueidentifier
                         SET @New" + strPKField[0] + @"  =NEWID()");
            }
            sp.AppendLine( strInsert ) ;
            sp.AppendLine(strSelect);
            if (strPKField[2] == "uniqueidentifier")
            {
                sp.AppendLine("SELECT @" + strPKField[0] + @" = @New" + strPKField[0]);
            }
            else
            {
                sp.AppendLine("SELECT @" + strPKField[0] + @" = @@Identity ");
            }
            sp.AppendLine("GO");
            return sp.ToString();
        }
        #endregion
    }
}
