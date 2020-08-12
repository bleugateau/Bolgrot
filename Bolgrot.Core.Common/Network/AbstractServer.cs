using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Bolgrot.Core.Common.Managers.Frames;
using EmbedIO.WebSockets;

namespace Bolgrot.Core.Common.Network
{
    public abstract class AbstractServer : WebSocketModule
    {
        public ConcurrentDictionary<string, Client> Clients { get; set; }
        protected readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        
        public AbstractServer(string urlPath, bool enableConnectionWatchdog) : base(urlPath, enableConnectionWatchdog)
        {
            this.Clients = new ConcurrentDictionary<string, Client>();
            
            this._logger.Info($"{this.GetType().Name} initialized !");
        }

        protected override Task OnMessageReceivedAsync(IWebSocketContext context, byte[] buffer, IWebSocketReceiveResult result)
        {
            string message = System.Text.Encoding.UTF8.GetString(buffer);
            
            this._logger.Info($"Receive -> {message} from {context.Id}.");
            
            if (!this.Clients.ContainsKey(context.Id))
                return null;

            this.Clients.TryGetValue(context.Id, out Client client);


            //primus ping protocol
            if (message.StartsWith("2"))
            {
                SendAsync(context, "3");
                this._logger.Info($"Sent -> pong primus protocol.");
            }
            
            FrameIntercepterManager.Intercept(client, message.Substring(1, message.Length - 1));

            
            foreach (var messageInQueue in client.MessagesQueues)
            {
                this._logger.Info($"Sent -> {messageInQueue.Value} to {context.Id}.");
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