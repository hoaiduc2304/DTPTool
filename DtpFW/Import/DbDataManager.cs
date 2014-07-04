using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

namespace DtpFW.Import
{
    
    public class DbData : BaseDBEntity
    {
        public string MyInst { get; set; }
    }

    public class DbDataCollection : BaseDBEntityCollection<DbData> { }
    public class DbDataManager
    {
        private static DbData GetItemFromReader(IDataReader dataReader)
        {
            DbData objItem = new DbData();
            objItem.MyInst = SqlHelper.GetString(dataReader, "MyInst");
            return objItem;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strTable">company</param>
        /// <param name="Statement">CompanyID=10</param>
        /// <returns></returns>
        public static DbDataCollection GetInserData(string strTable, string Statement)
        {
            DbDataCollection ItemCollection = new DbDataCollection();
            Database db = SqlHelper.CreateConnection(ConnectionHelper.Connection);
            string strSql = FileHelper.GetTextContent("spu_generateInsert.sql");
            strSql = strSql.Replace("{#Table}", strTable);
            strSql = strSql.Replace("{#clause}", Statement);
            DbCommand dbCommand = db.GetSqlStringCommand(strSql);
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    DbData item = GetItemFromReader(dataReader);
                    ItemCollection.Add(item);
                }
            }
            return ItemCollection;
        }
    }
}
