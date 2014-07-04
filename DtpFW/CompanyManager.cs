using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

namespace DtpFW
{

    public class DbCompany : BaseDBEntity
    {
        public string CompanyKey { get; set; }
        public int CompanyID { get; set; }
    }
    public class DbCompanyCollection : BaseDBEntityCollection<DbCompany> { }

    public class CompanyManager
    {
        private static DbCompany GetItemFromReader(IDataReader dataReader)
        {
            DbCompany objItem = new DbCompany();
            objItem.CompanyKey = SqlHelper.GetString(dataReader, "CompanyKey");
            objItem.CompanyID = SqlHelper.GetInt(dataReader, "CompanyID");
            return objItem;
        }
        public static DbCompanyCollection GetAllItem()
        {
            DbCompanyCollection ItemCollection = new DbCompanyCollection();
            Database db = SqlHelper.CreateConnection(ConnectionHelper.Connection);
            DbCommand dbCommand = db.GetSqlStringCommand("SELECT CompanyKey,CompanyID FROM Company where IsReadOnly=0 and companyid>0");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    DbCompany item = GetItemFromReader(dataReader);
                    ItemCollection.Add(item);
                }
            }
            return ItemCollection;
        }

        public static DbCompany GetItemByName(string CompanyKey)
        {
            DbCompany item = null;
            Database db = SqlHelper.CreateConnection(ConnectionHelper.Connection);
            DbCommand dbCommand = db.GetSqlStringCommand("SELECT CompanyKey,CompanyID FROM Company where IsReadOnly=0 and CompanyKey='" + CompanyKey + "'");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    item = GetItemFromReader(dataReader);
                }
            }
            return item;
        }
    }
}
