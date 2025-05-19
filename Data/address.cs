using PiriChainWalletDataBridge.Library;
using System;
using System.Collections.Generic;
using System.Text;


namespace PiriChainWalletDataBridge.Data
{
    public class address
    {

        public static T generateAddress<T>(string lang="english")
        {
            var result = Request.Req<T>(new Dictionary<string,string>(), reqName: "createNewAddress");
            return result;
        }

    }
}
