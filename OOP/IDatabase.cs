using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiriChainWalletDataBridge.OOP
{
    interface IDatabase
    {
         string globalTableName { get; set; }
         void newConnection();
         void connect(string host, string DB, string user, string password);
         void disConnect();
         DataTable getTables();
         object getConnectionObject();
         bool addTxColumn(string tableName,string dbName="");
         void updateAndInsertColumn(string tableName, string tx, string firstFieldName, string firstFieldValue);
         DataTable listRecords(string tableName);
         DataTable listAllRecords();



    }
}
