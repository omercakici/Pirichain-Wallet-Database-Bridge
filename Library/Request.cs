using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Microsoft.CSharp;
namespace PiriChainWalletDataBridge.Library
{
    public static class Request
    {
        public static string baseURL = "https://testnet.pirichain.com";

        public class returnObject
        {
            public int error { get; set; }
            public string data { get; set; }
        
        
        }
        public class addresResponse
        {
            public string pub { get; set; }
            public string publicKey { get; set; }
            public string words { get; set; }
            public string pri { get; set; }
        }
        public static T Req<T>(Dictionary<string, string> dic = null, string reqName = null) 
        {

            try
            {

            
            using (WebClient wb=new WebClient())
            {
                wb.Encoding = ASCIIEncoding.UTF8;
                wb.BaseAddress = String.Concat(baseURL, "/", reqName);
                var param="";
                if (dic!=null && dic.Keys!=null)
                foreach (var i in dic.Keys)
                { 
                    string val="";
                    dic.TryGetValue(i, out val);
                    if (!String.IsNullOrEmpty(val))
                        param += String.Concat("&", i, "=", val);
                }
                wb.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded; charset=UTF-8";

                var result = wb.UploadString(String.Concat(baseURL, "/", reqName), param);
                var json = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(result);
                return json;
                
            }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>("{}");
            }
            
        }

        public class valuePair
        {
            public string key { get; set; }
            public string val { get; set; }

        }
        public static T Req<T>(List<valuePair> dic = null, string reqName = null)
        {

            using (WebClient wb = new WebClient())
            {
                wb.Encoding = ASCIIEncoding.UTF8;
                wb.BaseAddress = String.Concat(baseURL, "/", reqName);
                var param = "";
                if (dic != null)
                    foreach (var i in dic)
                    {

                        if (!String.IsNullOrEmpty(i.key))
                            param += String.Concat("&", i.key, "=", i.val);
                    }
                wb.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded; charset=UTF-8";
                try
                {
                    var result = wb.UploadString(String.Concat(baseURL, "/", reqName), param);
                    var json = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(result);
                    return json;
                }
                catch (Exception ex)
                {
                    
                    throw ex;
                }
               

            }

        }
    }
}
