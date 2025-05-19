using H.Socket.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiriChainWalletDataBridge
{
   public class PiriSocket
    {

        public  string initialize()
        { 
           var client = new SocketIoClient();

        client.Connected += (sender, args) => Console.WriteLine("Connected:"+ args.Namespace);
        client.Disconnected += (sender, args) => Console.WriteLine("Disconnected. Reason:"+args.Reason+" Status:" +args.Status);
        client.EventReceived += (sender, args) => Console.WriteLine("EventReceived: Namespace:" +args.Namespace+" Value: "+ args.Value+" IsHandled: "+args.IsHandled);
        client.HandledEventReceived += (sender, args) => Console.WriteLine("HandledEventReceived: Namespace:"+args.Namespace+" Value: "+args.Value);
        client.UnhandledEventReceived += (sender, args) => Console.WriteLine("UnhandledEventReceived: Namespace: "+ args.Namespace+"  Value: "+args.Value);
        client.ErrorReceived += (sender, args) => Console.WriteLine("ErrorReceived: Namespace: "+args.Namespace+" Value:"+ args.Value);
        client.ExceptionOccurred += (sender, args) => Console.WriteLine("ExceptionOccurred: "+args.Value);
    
        client.On("mine", (data) =>
        {
            Console.WriteLine("Mining Data has come ");
        },"community");

        client.On("newValidator",json =>
        {
            Console.WriteLine("NewValidator has come. Json: \"" + json);
        }, "community");

        //client.DefaultNamespace = "community";
       var result= client.ConnectAsync(new Uri("wss://testnet.pirichain.com/"),new TimeSpan(0,0,10)).GetAwaiter();
       var sonuc=result.GetResult();
       return "";
}
}
    
}
