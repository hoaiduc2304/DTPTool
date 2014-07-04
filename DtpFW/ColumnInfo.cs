using System;
using System.Runtime.CompilerServices;

namespace DtpFW
{
    

    public class ColumnInfo
    {
        public ColumnInfo(string Name)
        {
            this.ColummName = Name;
        }

        public ColumnInfo(string Name, Type Tp, string SqlTypeName, int Leng, bool IsColumnNull)
        {
            this.ColummType = Tp;
            this.ColummName = Name;
            this.ColummMaxLenght = Leng;
            this.ColumnSqlType = SqlTypeName;
            this.IsNull = IsColumnNull;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(ColumnInfo))
            {
                return false;
            }
            ColumnInfo info = (ColumnInfo)obj;
            if (string.Compare(this.ColummName, info.ColummName, true) != 0)
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int ColummMaxLenght { get; set; }

        public string ColummName { get; set; }

        public Type ColummType { get; set; }

        public int ColumnOrdinal { get; set; }

        public string ColumnSqlType { get; set; }

        public string CopyFrom { get; set; }

        public bool CustomColumn { get; set; }

        public bool HasDefault { get; set; }

        public bool IsDublicated { get; set; }

        public bool IsIdentity { get; set; }

        public bool IsKey { get; set; }

        public bool IsMax
        {
            get
            {
                return (this.ColummMaxLenght == 0x7fffffff);
            }
        }

        public bool IsNull { get; set; }
    }
}
