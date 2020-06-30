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
        
        public AuthServer(string urlPath) : base(urlPath, false)
        {
            this.Clients = new ConcurrentDictionary<string, Client>();
        }

        protected override Task OnClientConnectedAsync(IWebSocketContext context)
        {
            Console.WriteLine($"Client {context.Id} connected");
            this.Clients.TryAdd(context.Id, new Client(context.Id));

            SendAsync(context, "0{\"sid\":\"h-Tc6sbvNVUqwrImAL-o\",\"upgrades\":[],\"pingInterval\":25000,\"pingTimeout\":5000}");
            
            return Task.CompletedTask;
        }

        protected override Task OnMessageReceivedAsync(IWebSocketContext context, byte[] buffer, IWebSocketReceiveResult result)
        {
            string message = System.Text.Encoding.UTF8.GetString(buffer);
            
            Console.WriteLine($"Client {context.Id} sent => {message}");
            
            if (!this.Clients.ContainsKey(context.Id))
                return null;

            this.Clients.TryGetValue(context.Id, out Client client);

            FrameIntercepterManager.Intercept(client, message.Substring(1, message.Length - 1));

            
            foreach (var messageInQueue in client.MessagesQueues)
            {
                Console.WriteLine($"Send => {messageInQueue.Key}.");
                SendAsync(context, messageInQueue.Value);
            }
            
            
            client.MessagesQueues.Clear();
            
            
            

            return Task.CompletedTask;
            
        }

        protected override Task OnClientDisconnectedAsync(IWebSocketContext context)
        {
            if (!this.Clients.ContainsKey(context.Id))
                return null;
            
            this.Clients.TryRemove(context.Id, out Client removedClient);
            
            Console.WriteLine($"Client {context.Id} disconnected");
            
            return Task.CompletedTask;
        }
    }
}