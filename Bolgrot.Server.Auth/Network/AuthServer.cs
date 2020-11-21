using System;
using System.Threading.Tasks;
using Bolgrot.Core.Common.Network;
using Bolgrot.Core.Common.Network.Events;
using EmbedIO.WebSockets;

namespace Bolgrot.Server.Auth.Network
{
    public class AuthServer : AbstractServer
    {
        public AuthServer(string urlPath) : base(urlPath, true)
        {

            this._logger.Info($"Primus module started on {this.BaseRoute} {urlPath}!");
        }

        protected /*async*/ override Task OnClientConnectedAsync(IWebSocketContext context)
        {
            // Console.WriteLine($"Client {context.Id} connected");
            this._logger.Info($"Client {context.Id} connected");

            var client = new Client(context.Id, context);
            client.OnDisconnect += DisconnectEventHandler;
            client.SendMessage += SendMessageEventHandler;

            this.Clients.TryAdd(context.Id, client);

            //await SendAsync(context, "0{\"sid\":\"h-Tc6sbvNVUqwrImAL-o\",\"upgrades\":[],\"pingInterval\":25000,\"pingTimeout\":5000}");

            SendAsync(context, "0{\"sid\":\"h-Tc6sbvNVUqwrImAL-o\",\"upgrades\":[],\"pingInterval\":25000,\"pingTimeout\":5000}");


            return Task.CompletedTask;
        }
        //protected override Task OnMessageReceivedAsync(IWebSocketContext context, byte[] buffer,
        //    IWebSocketReceiveResult result)
        //{
        //    this._logger.Info($"teste1");
        //    return base.OnMessageReceivedAsync(context, buffer,result);
        //}

    }
}