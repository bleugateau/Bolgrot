using System;
using System.Collections.Concurrent;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebSocketSharp;

namespace Bolgrot.Tools.MITM.Network
{
    public class SendEventArg : EventArgs
    {
        public string Message { get; set; }
        
        public SendEventArg(string message)
        {
            this.Message = message;
        }
    }
    
    public class DetourClient
    {
        public string ContextId { get; set; }

        public ConcurrentDictionary<long, string> MessagesQueues { get; set; }

        protected long InstanceId = 0;
        
        public WebSocket WebSocket { get; }
        
        public event EventHandler<SendEventArg> ThresholdReached;

        public DetourClient(string contextId, string address)
        {
            this.ContextId = contextId;
            this.MessagesQueues = new ConcurrentDictionary<long, string>();

            WebSocket = new WebSocket(
                "wss://"+address+"/primus/?STICKER=MzaXv8YYQgBSMcNa&_primuscb=NCGGIcA&EIO=3&transport=websocket&t=NCGGIcA&b64=1");
            //WebSocket.SslConfiguration.EnabledSslProtocols = System.Security.Authentication.SslProtocols.Default;
            WebSocket.OnMessage += (sender, args) =>
            {
                string message = args.Data;
                
                if (message.Contains("SelectedServerDataMessage"))
                {
                    var messageObject = JsonConvert.DeserializeObject<JObject>(message.Substring(1, message.Length - 1));
                    messageObject["_access"] = "http://localhost:667";
                    
                    message = "4"+JsonConvert.SerializeObject(messageObject);
                }

                this.Send(message);
                
                Console.WriteLine($"[RCV] -> {message}");
            };

            WebSocket.OnError += (sender, args) => { 
                Console.WriteLine("Error"); 
            };
            WebSocket.OnClose += (sender, e) =>
            {
                //TlsHandshakeFailure
                if (e.Code == 1015)
                {
                    //WebSocket.Connect();
                }
            };

            WebSocket.ConnectAsync();
        }

        public void Send(string message)
        {
            OnThresholdReached(message);
        }

        protected virtual void OnThresholdReached(string message)
        {
            ThresholdReached?.Invoke(this, new  SendEventArg(message));
        }
    }
}