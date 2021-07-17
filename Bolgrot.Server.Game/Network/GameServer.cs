﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Bolgrot.Core.Common.Network;
using Bolgrot.Server.Game.Managers;
using EmbedIO.WebSockets;

namespace Bolgrot.Server.Game.Network
{

    public class GameServer : AbstractServer
    {
        public GameServer(string urlPath) : base("/primus/", false)
        {
            
        }

        protected override Task OnClientConnectedAsync(IWebSocketContext context)
        {
            // Console.WriteLine($"Client {context.Id} connected");
            this._logger.Info($"Client {context.Id} connected");
            
            var client = new GameClient(context.Id, context);
            client.OnDisconnect += DisconnectEventHandler;
            client.SendMessage += SendMessageEventHandler;
            
            this.Clients.TryAdd(context.Id, client);
            Container.Instance().Resolve<IWorldManager>().TryaddClients(context.Id, client);

            SendAsync(context, "0{\"sid\":\"h-Tc6sbvNVUqwrImAL-o\",\"upgrades\":[],\"pingInterval\":25000,\"pingTimeout\":5000}");            

            return Task.CompletedTask;
        }
        protected override Task Disconnect(string contextId)
        {
            Container.Instance().Resolve<IWorldManager>().TryremoveClients(contextId);
            return base.Disconnect(contextId);
        }
       
    }
}