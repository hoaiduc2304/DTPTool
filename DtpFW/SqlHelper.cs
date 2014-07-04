using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Configuration;
using System.Xml;
using System.Data.Common;
namespace DtpFW
{
    public class SqlHelper
    {
        /// <summary>
        /// Creates a connection to a data soruce
        /// </summary>
        /// <param name="ConnectionString">Connection string</param>
        /// <returns>Database instance</returns>
        public static string CheckConnection(string ConnectionString)
        {
            Database db = CreateConnection(ConnectionString);
            string val = "Connect";
            DbCommand dbCommand = db.GetSqlStringCommand("SELECT Top 1 Name FROM master.sys.databases");
            try
            {
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    if (dataReader.Read())
                    {
                    }
                }
            }
            catch(Exception objEx) {

                val= objEx.Message;
            }

            return val;
        }


        /// <summary>
        /// Execute SQL Scripts
        /// </summary>
        /// <param name="connectionStr">Connection String</param>
        /// <param name="fileScriptPath">File Scripts path</param>
        /// <param name="fileViewPath">File Views path</param>
        public void ExecuteSqlScript(string fileScriptPath)
        {
            
            

            //if (!string.IsNullOrEmpty(fileScripts.ToString()) || !string.IsNullOrEmpty(fileViews.ToString()))
            //{
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.Connection))
                {
                    conn.Open();

                    SqlCommand command = conn.CreateCommand();

                    // Start a local transaction.
                    SqlTransaction transaction = conn.BeginTransaction();

                    // Must assign both transaction object and connection 
                    // to Command object for a pending local transaction
                    command.Connection = conn;
                    command.Transaction = transaction;

                    try
                    {
                        //for (int i = 0; i < fileScripts.Length; i++)
                        //{
                        //    // Excute scripts
                        //    ExcecuteSQLScript(fileScripts[i], command);
                        //}

                        //for (int i = 0; i < fileViews.Length; i++)
                        //{
                        //    // Excute view
                        //    ExcecuteSQLScript(fileViews[i], command);
                        //}
                        ExcuteSQLInFolder(fileScriptPath, command);
                        // Attempt to commit the transaction.
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {

                        // Attempt to roll back the transaction. 
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception ex2)
                        {
                            // This catch block will handle any errors that may have occurred 
                            // on the server that would cause the rollback to fail, such as closed connection
                        }
                    }

                    conn.Close();
                }
            //}
        }

        private bool ExcuteSQLInFolder(string SourcePath, SqlCommand command)
        {
            SourcePath = SourcePath.EndsWith(@"\") ? SourcePath : SourcePath + @"\";
            try
            {
                if (Directory.Exists(SourcePath))
                {
                    string[] fileScripts = Directory.GetFiles(SourcePath);

                    for (int i = 0; i < fileScripts.Length; i++)
                    {
                        // Excute scripts
                        ExcecuteSQLScript(fileScripts[i], command);
                    }

                    foreach (string drs in Directory.GetDirectories(SourcePath))
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo(drs);
                        if (ExcuteSQLInFolder(SourcePath+"\\"+directoryInfo.Name, command) == false)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// Execute sql script
        /// </summary>
        /// <param name="fileStr">The script file</param>
        /// <param name="command">The sql command</param>
        private void ExcecuteSQLScript(string fileStr, SqlCommand command)
        {
            FileInfo file = new FileInfo(fileStr);

            string script = file.OpenText().ReadToEnd();

            //Server server = new Server(new ServerConnection(conn));
            //server.ConnectionContext.ExecuteNonQuery(script);

            // Execute sql scripts
            command.CommandText = script;
            command.ExecuteNonQuery();

            file.OpenText().Close();
        }

        #region Methods

        public static string GetConnectionString(string ConnectionStringName)
        {
            string connectionString = null;
            XmlDocument doc = new XmlDocument();
            doc.Load("config.xml");
            XmlNode node = doc.DocumentElement.SelectSingleNode("/Root/Connection");
            string attr = node.Attributes[ConnectionStringName].InnerText;
            //ConnectionStringSettings settings = WebConfigurationManager.ConnectionStrings[ConnectionStringName];
            //if (settings != null)
            //{
            //    connectionString = settings.ConnectionString;
            //}
            connectionString = attr;
            return connectionString;
        }

        /// <summary>
        /// Creates a connection to a data soruce
        /// </summary>
        /// <param name="ConnectionString">Connection string</param>
        /// <returns>Database instance</returns>
        public static Database CreateConnection(string ConnectionString)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            return db;
        }

        /// <summary>
        /// Gets a boolean value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A boolean value</returns>
        public static bool GetBoolean(IDataReader rdr, string columnName)
        {
            try
            {
                int index = rdr.GetOrdinal(columnName);
                if (rdr.IsDBNull(index))
                {
                    return false;
                }
                return Convert.ToBoolean(rdr[index]);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a byte array of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A byte array</returns>
        public static byte[] GetBytes(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (byte[])rdr[index];
        }

        /// <summary>
        /// Gets a datetime value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A date time</returns>
        public static DateTime GetDateTime(IDataReader rdr, string columnName)
        {
            try
            {
                int index = rdr.GetOrdinal(columnName);
                if (rdr.IsDBNull(index))
                {
                    return DateTime.MinValue;
                }
                return (DateTime)rdr[index];
            }
            catch (Exception objEx)
            {
                return DateTime.Now;
            }
        }

        public static TimeSpan GetTimeSpan(IDataReader rdr, string columnName)
        {
            try
            {
                int index = rdr.GetOrdinal(columnName);
                if (rdr.IsDBNull(index))
                {
                    return new TimeSpan(0, 3, 0);
                }
                return (TimeSpan)rdr[index];
            }
            catch (Exception o)
            {
                return new TimeSpan(0, 3, 0);
            }
        }

        /// <summary>
        /// Gets an UTC datetime value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A date time</returns>
        public static DateTime GetUtcDateTime(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return DateTime.MinValue;
            }
            return DateTime.SpecifyKind((DateTime)rdr[index], DateTimeKind.Utc);
        }

        /// <summary>
        /// Gets a nullable datetime value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A date time if exists; otherwise, null</returns>
        public static DateTime? GetNullableDateTime(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (DateTime)rdr[index];
        }

        /// <summary>
        /// Gets a nullable UTC datetime value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A date time if exists; otherwise, null</returns>
        public static DateTime? GetNullableUtcDateTime(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return DateTime.SpecifyKind((DateTime)rdr[index], DateTimeKind.Utc);
        }

        /// <summary>
        /// Gets a decimal value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A decimal value</returns>
        public static decimal GetDecimal(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return decimal.Zero;
            }
            return Convert.ToDecimal(rdr[index]);
        }

        /// <summary>
        /// Gets a double value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A double value</returns>
        public static double GetDouble(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return 0.0;
            }
            return (double)rdr[index];
        }

        /// <summary>
        /// Gets a GUID value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A GUID value</returns>
        public static Guid GetGuid(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return Guid.Empty;
            }
            return (Guid)rdr[index];
        }

        /// <summary>
        /// Gets an integer value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>An integer value</returns>
        public static int GetInt(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return 0;
            }
            try
            {

                return (int)rdr[index];
            }
            catch (Exception objEx)
            {
                Int64 value = (Int64)rdr[index];
                return int.Parse(value.ToString());
            }
        }

        /// <summary>
        /// Gets an integer value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>An integer value</returns>
        public static Int16 GetSmallInt(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return 0;
            }
            try
            {

                return (Int16)rdr[index];
            }
            catch (Exception objEx)
            {
                int value = (int)rdr[index];
                return Int16.Parse(value.ToString());
            }
        }

        /// <summary>
        /// Gets a nullable integer value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A nullable integer value</returns>
        public static int? GetNullableInt(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (int)rdr[index];
        }

        /// <summary>
        /// Gets a string of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A string value</returns>
        public static string GetString(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return string.Empty;
            }
            return (string)rdr[index];
        }
        public static long Getlong(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return 0;
            }
            return (long)rdr[index];
        }
        public static Int64 GetInt64(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return 0;
            }
            return (Int64)rdr[index];
        }
        #endregion
    }
}
