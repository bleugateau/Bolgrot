using System;
using System.Text;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmbedIO.WebSockets;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Bolgrot.Tools.MITM.Network
{
    public class WebSocketPrimusServer : WebSocketModule
    {
        public ClientTypeEnum ClientType { get; set; }

        public ConcurrentDictionary<string, DetourClient> DetourClients =
            new ConcurrentDictionary<string, DetourClient>();
        
        private Form1 _formRef;
        
        public WebSocketPrimusServer(string urlPath, ClientTypeEnum clientTypeEnum, Form1 formRef)
            : base(urlPath, false)
        {
            Console.WriteLine($"Primus module started on {this.BaseRoute} !");

            this._formRef = formRef;
            this.ClientType = clientTypeEnum;
        }

        /// <inheritdoc />
        protected override Task OnMessageReceivedAsync(IWebSocketContext context, byte[] rxBuffer,
            IWebSocketReceiveResult rxResult)
        {
            if (!this.DetourClients.TryGetValue(context.Id, out DetourClient client))
                return null;
            
            string message = Encoding.UTF8.GetString(rxBuffer);
            Console.WriteLine($"[{Enum.GetName(typeof(ClientTypeEnum), this.ClientType)}] -> {message}.");
            
            client.WebSocket.Send(message);
            this._formRef.AddMessageToDataGridView(this.ClientType, message);
            


            if (message.Contains("disconnecting"))
            {
                this.SendAsync(context, "4\"primus::server::close\"");
                client.WebSocket.Close();
                this.CloseAsync(context);

                this.DetourClients.TryRemove(context.Id, out DetourClient removedClient);
            }


            if (message.StartsWith("4{") && message.Contains("sendMessage"))
            {
                var messageObject = JsonConvert.DeserializeObject<JObject>(message.Substring(1, message.Length - 1));

                if (messageObject.TryGetValue("data", out JToken data))
                {
                    ProtocolBuilderManager.BuildSendMessage(data.ToString());
                }
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        protected override Task OnClientConnectedAsync(IWebSocketContext context)
        {
            Console.WriteLine($"Client {context.Id} connected !");
            
            if(this.ClientType == ClientTypeEnum.AUTH)
                this._formRef.ClearDataGridView();

            var client = new DetourClient(context.Id,
                this.ClientType == ClientTypeEnum.AUTH
                    ? "proxyconnection.touch.dofus.com"
                    : "oshimogameproxy.touch.dofus.com");
            client.ThresholdReached += EventCallback;
            this.DetourClients.TryAdd(context.Id, client);

            return Task.CompletedTask;
        }

        private void EventCallback(object sender, SendEventArg e)
        {
            var client = (DetourClient) sender;

            var context = this.ActiveContexts.FirstOrDefault(x => x.Id == client.ContextId);

            Console.WriteLine(e.Message);
            
            this._formRef.AddMessageToDataGridView(this.ClientType, e.Message);


            if (e.Message.StartsWith("4{"))
            {

                var messageObject = JsonConvert.DeserializeObject<JObject>(e.Message.Substring(1, e.Message.Length - 1));

                if(messageObject.TryGetValue("_messageType", out JToken messageName))
                {
                    ProtocolBuilderManager.BuildMessage(messageName.ToString(), e.Message.Substring(1, e.Message.Length - 1));
                }
            }


            this.SendAsync(context, e.Message);
        }

        /// <inheritdoc />
        protected override Task OnClientDisconnectedAsync(IWebSocketContext context)
        {
            Console.WriteLine($"Client {context.Id} disconnected !");

            return Task.CompletedTask;
        }

        private Task SendToOthersAsync(IWebSocketContext context, string payload)
            => BroadcastAsync(payload, c => c != context);
    }
}