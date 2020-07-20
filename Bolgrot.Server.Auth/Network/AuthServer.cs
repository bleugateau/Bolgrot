using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bolgrot.Core.Common.Managers.Frames;
using Bolgrot.Core.Common.Network;
using EmbedIO.WebSockets;

namespace Bolgrot.Server.Auth.Network
{
    public class AuthServer : WebSocketModule
    {
        public ConcurrentDictionary<string, Client> Clients { get; set; }
        
        private readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public AuthServer(string urlPath) : base(urlPath, false)
        {
            this.Clients = new ConcurrentDictionary<string, Client>();
        }

        protected override Task OnClientConnectedAsync(IWebSocketContext context)
        {
            // Console.WriteLine($"Client {context.Id} connected");
            this._logger.Info($"Client {context.Id} connected");
            
            var client = new Client(context.Id, context);
            client.OnDisconnect += DisconnectEventHandler;
            
            this.Clients.TryAdd(context.Id, client);

            SendAsync(context, "0{\"sid\":\"h-Tc6sbvNVUqwrImAL-o\",\"upgrades\":[],\"pingInterval\":25000,\"pingTimeout\":5000}");
            
            return Task.CompletedTask;
        }

        protected override Task OnMessageReceivedAsync(IWebSocketContext context, byte[] buffer, IWebSocketReceiveResult result)
        {
            string message = System.Text.Encoding.UTF8.GetString(buffer);
            
            this._logger.Info($"[RCV] {message} from {context.Id}.");
            
            if (!this.Clients.ContainsKey(context.Id))
                return null;

            this.Clients.TryGetValue(context.Id, out Client client);


            //primus ping protocol
            if (message.StartsWith("2"))
            {
                SendAsync(context, "3");
            }
            
            FrameIntercepterManager.Intercept(client, message.Substring(1, message.Length - 1));

            
            foreach (var messageInQueue in client.MessagesQueues)
            {
                this._logger.Info($"[SND] {messageInQueue} to {context.Id}.");
                SendAsync(context, messageInQueue.Value);
            }
            
            
            client.MessagesQueues.Clear();
            
            
            

            return Task.CompletedTask;
            
        }

        protected override Task OnClientDisconnectedAsync(IWebSocketContext context)
        {
            return Disconnect(context.Id);
        }

        protected void DisconnectEventHandler(object sender, EventArgs eventArgs)
        {
            Disconnect(((Client)sender).ContextId);
        }

        private Task Disconnect(string contextId)
        {
            if (!this.Clients.ContainsKey(contextId))
                return null;

            this.Clients.TryRemove(contextId, out Client removedClient);
            SendAsync(removedClient.Context, "4\"primus::server::close\"");
            
            this.CloseAsync(removedClient.Context);

            this._logger.Info($"Client {removedClient.ContextId} disconnected.");
            
            return Task.CompletedTask;
        }
    }
}