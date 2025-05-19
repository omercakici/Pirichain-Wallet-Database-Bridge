using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PiriChainWalletDataBridge.OOP
{
    partial class MYSQL :  IDatabase, ISQLExecutable
    {
        MySql.Data.MySqlClient.MySqlConnection mySql;

        public string globalTableName { get; set; }
        public void newConnection()
        {
            throw new NotImplementedException();
        }
        string dbName = "";
        public void connect(string host, string DB, string user, string password)
        {
             if (mySql != null)
            {
                mySql.Dispose();
                mySql = null;
            }
            if (!String.IsNullOrEmpty(password))
                mySql=new MySql.Data.MySqlClient.MySqlConnection(String.Format("server={0};uid={1};pwd={2};database={3}",host,user,password,DB));
            else
                mySql=new MySql.Data.MySqlClient.MySqlConnection(String.Format("server={0};uid={1};database={2}",host,user,DB));

            mySql.Open();
            dbName = DB;
        }

        public void disConnect()
        {
            mySql.Close();
        }
        
        public System.Data.DataTable getTables()
        {
            List<commonObjects.tableStructure> Tablenames = new List<commonObjects.tableStructure>();
            string query = "show tables from "+dbName;
            MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(query, mySql);
            using (MySql.Data.MySqlClient.MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Tablenames.Add(new commonObjects.tableStructure().add("", "", reader.GetString(0)));
                }

            }

            return statics.ToDataTable<commonObjects.tableStructure>(Tablenames);
            

        }

        public object getConnectionObject()
        {
            return mySql;
        }

        public bool addTxColumn(string tableName,string dbName="")
        {
            string sql = @"IF NOT EXISTS( SELECT NULL
                                    FROM INFORMATION_SCHEMA.COLUMNS
                                   WHERE table_name = '"+tableName+@"'
                                     AND table_schema = '"+dbName+@"'
                                     AND column_name = 'tx')  THEN

                          ALTER TABLE `"+tableName+@"` ADD `tx` varchar(128);

                        END IF; ";
            using (MySql.Data.MySqlClient.MySqlCommand comm = new MySql.Data.MySqlClient.MySqlCommand())
            {
                comm.Connection = mySql;
                comm.CommandText = sql;
                return comm.ExecuteNonQuery() > 0;
            }
        }

        public void updateAndInsertColumn(string tableName, string tx, string firstFieldName, string firstFieldValue)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable runSQL(string sql)
        {

            var changed = sql;
            var adap = new MySql.Data.MySqlClient.MySqlDataAdapter(changed, mySql);
            var data = new DataTable();
            adap.Fill(data);
            List<string> operands = changed.Split(' ').ToList();
            int indexFrom = operands.FindIndex(f => f.ToLower() == "from");
            string tableName = operands[indexFrom + 1];
            globalTableName = tableName;
            return data;
        }


        public DataTable listRecords(string tableName)
        {
            var adap = new MySqlDataAdapter("select * from `" + tableName + "` LIMIT 100", getConnectionObject() as MySqlConnection);
            var data = new DataTable();
            adap.Fill(data);
            globalTableName = tableName;
            return data;
        }


        public DataTable listAllRecords()
        {
            var adap = new MySqlDataAdapter("select * from `" + globalTableName + "` ", getConnectionObject() as MySqlConnection);
            var data = new DataTable();
            adap.Fill(data);
            return data;
        }
    }
}
