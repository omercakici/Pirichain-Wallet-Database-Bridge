using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiriChainWalletDataBridge.OOP
{
    class MSSQL :AbstractGlobal, IDatabase,ISQLExecutable
    {
        public void newConnection()
        { 
        
        }
        public string globalTableName { get; set; }
        public void connect(string host,string DB,string user,string password)
        {
            if (sqlConnect != null)
            {
                sqlConnect.Dispose();
                sqlConnect = null;
            }

            sqlConnect = new SqlConnection();
            if (!String.IsNullOrEmpty(password))
                sqlConnect.ConnectionString = String.Format("Server={0};Database={1};UID={2};PWD={3};", host, DB, user, password);
            else
                sqlConnect.ConnectionString = String.Format("Server={0};Database={1};Integrated Security=True", host, DB);
            sqlConnect.Open();
        }

        public DataTable getTables()
        {

            return sqlConnect.GetSchema("Tables");
        }

        public void disConnect()
        {
            sqlConnect.Close();
        }

        public object getConnectionObject()
        {
            return sqlConnect;
        }
        public void updateAndInsertColumn(string tableName, string tx, string firstFieldName, string firstFieldValue)
        {
            string sql = "update " + tableName + " set tx='" + tx + "' where " + firstFieldName + "='" + firstFieldValue + "'";
            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = sqlConnect;
                comm.CommandText = sql;
                comm.ExecuteNonQuery();


            }
        
        }
        public bool addTxColumn(string tableName,string dbName="")
        {
            string sql = @"IF NOT EXISTS(SELECT 1 FROM sys.columns 
                                      WHERE Name = N'tx'
                                      AND Object_ID = Object_ID(N'schemaName." + tableName + @"'))
                                    BEGIN
                                        ALTER TABLE " + tableName + @"  ADD tx VARCHAR (128) ;
                                    END ";
            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = sqlConnect;
                comm.CommandText = sql;
                return comm.ExecuteNonQuery() > 0;


            }
        
        }


        
        public SqlConnection sqlConnect = null;
        public DataTable runSQL(string sql)
        {
            newConnection();
            
            var changed = sql.ToLower().Replace("select", "select top 100 ");
            var adap = new SqlDataAdapter(changed, sqlConnect);
            var data = new DataTable();
            adap.Fill(data);
            List<string> operands = changed.Split(' ').ToList();
            int indexFrom = operands.FindIndex(f => f.ToLower() == "from");
            string tableName = operands[indexFrom + 1];
            globalTableName = tableName;
            return data;
        }

         public DataTable listAllRecords()
        {
            var adap = new SqlDataAdapter("select * from \"" + globalTableName + "\"", getConnectionObject() as SqlConnection);
            var data = new DataTable();
            adap.Fill(data);
            return data;
        }
    

        public DataTable listRecords(string tableName)
        {
            var adap = new SqlDataAdapter("select top 100 * from \"" + tableName + "\"", getConnectionObject() as SqlConnection);
            var data = new DataTable();
            adap.Fill(data);
            globalTableName = tableName;
            return data;
        }
    }
}
