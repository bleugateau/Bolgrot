using System;
using System.Threading.Tasks;
using Bolgrot.Core.Common.Network;
using Bolgrot.Core.Common.Network.Events;
using EmbedIO.WebSockets;

namespace Bolgrot.Server.Auth.Network
{
    public class AuthServer : AbstractServer
    {
        public AuthServer(string urlPath) : base(urlPath, false)
        {
        }
        
        protected override Task OnClientConnectedAsync(IWebSocketContext context)
        {
            // Console.WriteLine($"Client {context.Id} connected");
            this._logger.Info($"Client {context.Id} connected");
            
            var client = new Client(context.Id, context);
            client.OnDisconnect += DisconnectEventHandler;
            client.SendMessage += SendMessageEventHandler;
            
            this.Clients.TryAdd(context.Id, client);

            SendAsync(context, "0{\"sid\":\"h-Tc6sbvNVUqwrImAL-o\",\"upgrades\":[],\"pingInterval\":25000,\"pingTimeout\":5000}");

            return Task.CompletedTask;
        }
    }
}