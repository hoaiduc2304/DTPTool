using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

namespace DtpFW.Import
{

    public class SYProvider :BaseDBEntity
    {
        public int CompanyID { get; set; }
        public Guid ProviderID { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string ProviderType { get; set; }
        public int ObjectCntr { get; set; }
        public int ParameterCntr { get; set; }
        public int NoteID { get; set; }
        public Guid CreatedByID { get; set; }
        public string CreatedByScreenID { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Guid LastModifiedByID { get; set; }
        public string LastModifiedByScreenID { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public TimeSpan TStamp { get; set; }
        public byte[] CompanyMask { get; set; }
    }
    public class SYProviderCollection : BaseDBEntityCollection<SYProvider> { }
    public class SYProviderManager
    {
        private static SYProvider GetItemFromReader(IDataReader dataReader)
        {
            SYProvider objItem = new SYProvider();
            objItem.CompanyID = SqlHelper.GetInt(dataReader, "CompanyID");
            objItem.ProviderID = SqlHelper.GetGuid(dataReader, "ProviderID");
            objItem.Name = SqlHelper.GetString(dataReader, "Name");
            objItem.IsActive = SqlHelper.GetBoolean(dataReader, "IsActive");
            objItem.ProviderType = SqlHelper.GetString(dataReader, "ProviderType");
            objItem.ObjectCntr = SqlHelper.GetSmallInt(dataReader, "ObjectCntr");
            objItem.ParameterCntr = SqlHelper.GetSmallInt(dataReader, "ParameterCntr");
            objItem.NoteID = SqlHelper.GetInt(dataReader, "NoteID");
            objItem.CreatedByID = SqlHelper.GetGuid(dataReader, "CreatedByID");
            objItem.CreatedByScreenID = SqlHelper.GetString(dataReader, "CreatedByScreenID");
            objItem.CreatedDateTime = SqlHelper.GetDateTime(dataReader, "CreatedDateTime");
            objItem.LastModifiedByID = SqlHelper.GetGuid(dataReader, "LastModifiedByID");
            objItem.LastModifiedByScreenID = SqlHelper.GetString(dataReader, "LastModifiedByScreenID");
            objItem.LastModifiedDateTime = SqlHelper.GetDateTime(dataReader, "LastModifiedDateTime");
            objItem.TStamp = SqlHelper.GetTimeSpan(dataReader, "TStamp");
            objItem.CompanyMask = SqlHelper.GetBytes(dataReader, "CompanyMask");
            return objItem;
        }
        public static SYProvider getItemByID(string ProviderID,string companyID)
        {
            SYProvider item = null;
            Database db = SqlHelper.CreateConnection(ConnectionHelper.Connection);
            DbCommand dbCommand = db.GetSqlStringCommand("select * from SYProvider where ProviderID='" + ProviderID + "' and companyid="+companyID+"");
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
