using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql.BackendMessages;
using System.Data;
using Npgsql;

namespace PiriChainWalletDataBridge.OOP
{

    
    public class PostgreSQL:IDatabase,ISQLExecutable
    {

        Npgsql.NpgsqlConnection posConn = new Npgsql.NpgsqlConnection();

        public string globalTableName
        {
            get;
            set;
        }

        public void newConnection()
        {
            throw new NotImplementedException();
        }

        public void connect(string host, string DB, string user, string password)
        {
            if (posConn != null)
            {
                posConn.Dispose();
                posConn = null;
            }
            posConn = new Npgsql.NpgsqlConnection();
            if (!String.IsNullOrEmpty(password))
                posConn.ConnectionString = String.Format("Server={0};Database={1};UID={2};Password={3};CommandTimeout=20;", host, DB, user, password);
            else
                posConn.ConnectionString = String.Format("Server={0};Database={1};Integrated Security=TrueCommandTimeout=20;", host, DB);

            posConn.Open();
            dbName = DB;
        }

        public void disConnect()
        {
            posConn.Close();
        }
        string dbName = "";
        public System.Data.DataTable getTables()
        {
            List<commonObjects.tableStructure> Tablenames = new List<commonObjects.tableStructure>();
            string query = @"SELECT
                                    table_schema || '.' || table_name
                                FROM
                                    information_schema.tables
                                WHERE
                                    table_type = 'BASE TABLE'
                                AND
                                    table_schema NOT IN ('pg_catalog', 'information_schema');";
            NpgsqlCommand command = new NpgsqlCommand(query, posConn);
            using (NpgsqlDataReader reader = command.ExecuteReader())
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
            return posConn;
        }

        public bool addTxColumn(string tableName, string dbName = "")
        {
            string sql = "ALTER TABLE "+tableName+" ADD COLUMN IF NOT EXISTS tx character (128);";
            using (NpgsqlCommand comm = new NpgsqlCommand())
            {
                comm.Connection = posConn;
                comm.CommandText = sql;
                return comm.ExecuteNonQuery() > 0;


            }
        }

        public void updateAndInsertColumn(string tableName, string tx, string firstFieldName, string firstFieldValue)
        {
            string sql = "update " + tableName + " set tx='" + tx + "' where \""+ firstFieldName + "\"='" + firstFieldValue + "'";
            using (Npgsql.NpgsqlCommand comm = new Npgsql.NpgsqlCommand())
            {
                comm.Connection = posConn;
                comm.CommandText = sql;
                comm.ExecuteNonQuery();
            }
        }

        public System.Data.DataTable listRecords(string tableName)
        {
            var adap = new Npgsql.NpgsqlDataAdapter("select * from " + tableName + " LIMIT 100", getConnectionObject() as Npgsql.NpgsqlConnection);
            var data = new DataTable();
            adap.Fill(data);
            globalTableName = tableName;
            return data;
        }

        public System.Data.DataTable listAllRecords()
        {
            var adap = new NpgsqlDataAdapter("select * from " + globalTableName + " ", getConnectionObject() as NpgsqlConnection);
            var data = new DataTable();
            adap.Fill(data);
            return data;
        }

        public System.Data.DataTable runSQL(string sql)
        {
            var changed = sql;
            var adap = new NpgsqlDataAdapter(changed, posConn);
            var data = new DataTable();
            adap.Fill(data);
            List<string> operands = changed.Split(' ').ToList();
            int indexFrom = operands.FindIndex(f => f.ToLower() == "from");
            string tableName = operands[indexFrom + 1];
            globalTableName = tableName;
            return data;
        }
    }
}
