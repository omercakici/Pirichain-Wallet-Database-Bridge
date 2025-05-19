using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PiriChainWalletDataBridge.Data
{
    public class addressBook
    {

        public class _address
        {
        public string label { get; set; }
        public string address { get; set; }

        }

        public static List<_address> listAddress()
        {
            try
            {
                var allString = File.ReadAllText("./data/address.dat");
                var t= Newtonsoft.Json.JsonConvert.DeserializeObject<List<_address>>(allString);
                if (t == null)
                    return new List<_address>();
                else
                    return t;
            }
            catch {
                File.CreateText("./data/address.dat");
                return new List<_address>();
            }
        
        }
        public static void addAddress(string label, string add)
        {
            var list = listAddress();
            list.Add(new _address { label = label, address = add });
            File.WriteAllText("./data/address.dat",Newtonsoft.Json.JsonConvert.SerializeObject(list));
        }
        public static void editAddress(string oldAddress,string label, string add)
        {
            var list = listAddress();
            var old = list.First(v => v.address == oldAddress);
            old.address = add;
            old.label = label;
            File.WriteAllText("./data/address.dat", Newtonsoft.Json.JsonConvert.SerializeObject(list));
        }

        public static void remove(string add)
        {
            var list = listAddress();
            var tmp = list.Where(v => v.address != add);
            File.WriteAllText("./data/address.dat", Newtonsoft.Json.JsonConvert.SerializeObject(tmp));
        
        }

    }
}
