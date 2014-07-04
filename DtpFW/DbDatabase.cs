using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
namespace DtpFW
{
    public class DbDatabase : BaseDBEntity
    {
        public string DbName { get; set; }
    }

    public class DbDatabaseCollection : BaseDBEntityCollection<DbDatabase> { }
    public class DbDatabaseManager
    {
        private static DbDatabase GetItemFromReader(IDataReader dataReader)
        {
            DbDatabase objItem = new DbDatabase();
            objItem.DbName = SqlHelper.GetString(dataReader, "Name");
            return objItem;
        }
        public static DbDatabaseCollection GetAllItem()
        {
            DbDatabaseCollection ItemCollection = new DbDatabaseCollection();
            Database db = SqlHelper.CreateConnection(ConnectionHelper.Connection);
            DbCommand dbCommand = db.GetSqlStringCommand("SELECT * FROM sys.databases");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    DbDatabase item = GetItemFromReader(dataReader);
                    ItemCollection.Add(item);
                }
            }
            return ItemCollection;
        }
    }

   

    public class DBTable : BaseDBEntity
    {
        public string TableName { get; set; }
        public string Type { get; set; }
    }
    public class DBTableCollection : BaseDBEntityCollection<DBTable> { }
    public class DBTableManager
    {
         private static DBTable GetItemFromReader(IDataReader dataReader)
        {
            DBTable objItem = new DBTable();
            objItem.TableName = SqlHelper.GetString(dataReader, "name");
            
            return objItem;
        }
         public static DBTableCollection GetAllItem(string tblName)
        {
            DBTableCollection ItemCollection = new DBTableCollection();
            Database db = SqlHelper.CreateConnection(ConnectionHelper.Connection);
            string strSql = " SELECT name FROM sys.Tables ";
            if (!string.IsNullOrEmpty(tblName) || tblName != "All")
            {
                strSql += " where [name] like '%" + tblName + "%' ";
            }
             
             strSql+=" order by name asc";
             DbCommand dbCommand = db.GetSqlStringCommand(strSql);
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    DBTable item = GetItemFromReader(dataReader);
                    ItemCollection.Add(item);
                }
            }
            return ItemCollection;
        }
    }
    public class DBColumn : BaseDBEntity
    {
        public string ColumnName { get; set; }
        public string Type { get; set; }
    }
    public class DBClumnCollection : BaseDBEntityCollection<DBColumn> { }

    public class DBClumnManager
    {
        private static DBColumn GetItemFromReader(IDataReader dataReader)
        {
            DBColumn objItem = new DBColumn();
            objItem.ColumnName = SqlHelper.GetString(dataReader, "ColName");
            objItem.Type = SqlHelper.GetString(dataReader, "ColType");
            return objItem;
        }
        public static DBClumnCollection GetAllItem(string tblName)
        {
            DBClumnCollection ItemCollection = new DBClumnCollection();
            Database db = SqlHelper.CreateConnection(ConnectionHelper.Connection);
            DbCommand dbCommand = db.GetSqlStringCommand("SELECT Column_Name as ColName,Data_type as ColType FROM  information_schema.columns WHERE  table_name = '" + tblName + "' ORDER  BY ordinal_position");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    DBColumn item = GetItemFromReader(dataReader);
                    ItemCollection.Add(item);
                }
            }
            return ItemCollection;
        }
    }

}
