using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmbedIO.WebSockets;

namespace Bolgrot.Server.Auth.Network
{
    public class AuthServer : WebSocketModule
    {
        public AuthServer(string urlPath) : base(urlPath, false)
        {
        }

        protected override Task OnMessageReceivedAsync(IWebSocketContext context, byte[] buffer, IWebSocketReceiveResult result)
        {
            Console.WriteLine($"Client {context.Id} sent => {System.Text.Encoding.UTF8.GetString(buffer)}");
            
            return Task.CompletedTask;
        }

        protected override Task OnClientConnectedAsync(IWebSocketContext context)
        {
            Console.WriteLine($"Client {context.Id} connected");
            
            return Task.CompletedTask;
        }
        //
        // protected override Task OnFrameReceivedAsync(IWebSocketContext context, byte[] buffer, IWebSocketReceiveResult result)
        // {
        //     Console.WriteLine($"Client {context.Id} frame sent => {System.Text.Encoding.UTF8.GetString(buffer)}");
        //     
        //     return Task.CompletedTask;
        // }
        //

        protected override Task OnClientDisconnectedAsync(IWebSocketContext context)
        {
            Console.WriteLine($"Client {context.Id} disconnected");
            
            return Task.CompletedTask;
        }
    }
}