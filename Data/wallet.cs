using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using PiriChainWalletDataBridge.Library;




namespace PiriChainWalletDataBridge.Data
{
    public class Data
    {
        
        public class Wallet
        {
            public string base58 { get; set; }

            public string publicKey { get; set; }
            public string privateKey { get; set; }

            public bool active{get;set;}

            public Wallet()
            {
               
            
            }

            static void checkWalletDir()
            {
                if (!Directory.Exists("./data"))
                    Directory.CreateDirectory("./data");

                if (!File.Exists("./data/wallets.dat"))
                {
                    File.Create("./data/wallets.dat");
                }
            }

            public static List<Wallet> listWallet()
            {
                checkWalletDir();
                var allString=File.ReadAllText("./data/wallets.dat");
                

                try
                {
                    List<Wallet> list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Wallet>>(allString);
                        if (list == null) return new List<Wallet>();
                            else
                                return list;
                            }
                            catch
                            {
                                return new List<Wallet>();
                            }

            }


            public static List<Wallet> removeWallet(string address)
            {
                checkWalletDir();
                var allString = File.ReadAllText("./data/wallets.dat");
                try
                {
                    List<Wallet> pureWallet = new List<Wallet>();
                    List<Wallet> list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Wallet>>(allString);
                    if (list == null) return new List<Wallet>();
                    else
                    { 
                        foreach (Wallet w in list)
                        {
                            if (w.base58 != address)
                                pureWallet.Add(w);

                        }
                            File.WriteAllText("./data/wallets.dat",Newtonsoft.Json.JsonConvert.SerializeObject(pureWallet));
                            return pureWallet;


                    }
                }
                catch
                {
                    return new List<Wallet>();
                }

            }

            

            public static void addWallet(string publicKey,string base58,string privateKey)
            {
                checkWalletDir();
                /*var allWallets=listWallet();
                var wallet=new Wallet{active=true,publicKey=publicKey,privateKey=privateKey,base58=base58};
                allWallets.Add(wallet);
                string text =Newtonsoft.Json.JsonConvert.SerializeObject(allWallets);
                byte[] data = Encoding.ASCII.GetBytes(text);
                File.WriteAllBytes("./data/wallets.dat", data);*/
                var allWallets = listWallet();
                var wallet = new Wallet { active = true, publicKey = publicKey, privateKey = privateKey, base58 = base58 };
                if (allWallets.Exists(v => v.active == true))
                    wallet.active = false;

                allWallets.Add(wallet);
                string text = Newtonsoft.Json.JsonConvert.SerializeObject(allWallets);
                File.WriteAllText("./data/wallets.dat",text);
                
            }
            public static void deleteWallet(string base58)
            {
                checkWalletDir();
                var deletedWallet = listWallet().Find(v=>v.base58==base58);
                var allWallets = listWallet();
                allWallets.Remove(deletedWallet);
                File.WriteAllText("./data/wallets.dat", Newtonsoft.Json.JsonConvert.SerializeObject(allWallets));
            }

            public class balanceData
            {

                
                public string address{get;set;}
                public string name { get; set; }

                public string tokenName { set{this.name=value;} }
                public int error{get;set;}
                public string symbol{get;set;}
                public string logo{get;set;}
                public frozenData[] frozen{get;set;}
                public float balance{get;set;}
                public int assetID { get; set; }
            
            }

            

            public static List<balanceData> listBalanceList (string address)
            {
                var newDic=new Dictionary<string,string>();
                newDic.Add("address",address);
                return Request.Req<List<balanceData>>(newDic, "getBalanceList");
            
            }

            public class frozenData
            {
                public string _id { get; set; }
                public float? totalFrozen { get; set; }
            }

            public class balanceSaltData
            {
                public int error { get; set; }
                public string assetID { get; set; }
                public frozenData[] frozen { get; set; }
                public float balance { get; set; }
                
            
            }

            public static balanceSaltData getBalance(string address, int assetID = -1)
            {

                var newDic = new Dictionary<string, string>();
                    newDic.Add("address", address);
                
                    newDic.Add("assetID", assetID.ToString());
                return Request.Req<balanceSaltData>(newDic, "getBalance");
            }

            public class transactionItem
            {
                public class _validator
                {
                    public string nodeName { get; set; }
                    public string message { get; set; }
                    public DateTime dateTime { get; set; }
                    public int result { get; set; }

                }

                public class _customData
                {
                    public string txID { get; set; }
                    public string from { get; set; }
                    public string to { get; set; }
                    public string key { get; set; }
                    public string value { get; set; }
                    public int enc { get; set; }
                    public int blockHeight { get; set; }
                }

                public List<_validator> validatorNodes { get; set; }
                public string _id { get; set; }
                public string transactionHash { get; set; }
                public float amount { get; set; }
                public int blockHeight { get; set; }
                public int confirmationCount { get; set; }
                public bool confirmed { get; set; }
                public string from { get; set; }
                public string to { get; set; }
                public string symbol { get; set; }
                public int type { get; set; }
                public long timeStamp { get; set; }
                public List<_customData> customData { get; set; }

                public string pub { get; set; }
                public string signature { get; set; }

                public int assetID { get; set; }
                public float fee { get; set; }




            }

            public class transactionList
            {

                public List<transactionItem> doc { get; set; }
                public List<transactionItem> docs { get; set; }
                public int count { get; set; }
                public int txCountTotal { get; set; }
            
            }
            public static transactionList listTransactions(string address, int skip = 0, int limit = 20)
            {
                var newDic = new Dictionary<string, string>();
                newDic.Add("address", address);
                newDic.Add("limit", limit.ToString());
                newDic.Add("skip", skip.ToString());

                var list = Request.Req<transactionList>(newDic, "listTransactionsByAddr");
                return list;

            }


            public static transactionItem getTransaction(string txHash)
            {
                var newDic = new Dictionary<string, string>();
                newDic.Add("tx", txHash);
                var list = Request.Req<transactionItem>(newDic, "getTransaction");
                return list;
            }

            public static transactionList listTransactions(int skip = 0, int limit = 20)
            {
                var newDic = new Dictionary<string, string>();
                
                newDic.Add("limit", limit.ToString());
                newDic.Add("skip", skip.ToString());

                var list = Request.Req<transactionList>(newDic, "listTransactions");
                return list;

            }
            public class mnemonicResponse
            {
                public byte error { get; set; }
                public string mnemonic { get; set; }
            }
            public static mnemonicResponse getMnemonic(string privateKey)
            {
                try
                {
                    var newDic = new Dictionary<string, string>();
                    newDic.Add("privateKey", privateKey);
                    var result = Request.Req<mnemonicResponse>(newDic, "getMnemonic");
                    return result;

                }
                catch (Exception ex)
                {
                    return null;
                    
                }
            
            }

            
           

            public class transferResult
            {
                public int error { get; set; }
                public string data { get; set; }
                public string tx { get; set; }
                public string sign { get; set; }
                public long timeStamp { get; set; }
                public string message { set { if (error==1) this.data = value; } }

            }

            public static transferResult transferAsset(string privateKey, string senderAddress, int assetID, string to, decimal amount)
            {
                var newDic = new Dictionary<string, string>();
                newDic.Add("address", senderAddress);
                newDic.Add("privateKey", privateKey.ToString());
                newDic.Add("to", to.ToString());
                newDic.Add("amount", amount.ToString().Replace(",","."));
                newDic.Add("assetID", assetID.ToString());
                var result = Request.Req<transferResult>(newDic, "sendToken");
                return result;
            }

            public static transferResult pushData(string privateKey, string senderAddress, int assetID, string to, decimal amount,List<Request.valuePair> values,string toPubKey=null)
            {
                var newDic = new List<Request.valuePair>();
                newDic.Add(new Request.valuePair { key = "address", val = senderAddress });
                newDic.Add(new Request.valuePair { key = "privateKey", val = privateKey.ToString() });
                //newDic.Add("to", to.ToString());
                /*for (int i=1;i<50;i++)
                    newDic.Add(new Request.valuePair { key = "customData[]", val = "{\"key\":\"field_" + i + "\",\"value\":\"" + Guid.NewGuid() + "-" + Guid.NewGuid() + "\"}" });
                */
                newDic.AddRange(values);

                var result = Request.Req<transferResult>(newDic, "pushData");
                return result;
            }

            
        }

       

 
        

    }
}
