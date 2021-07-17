﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Bolgrot.Core.Ankama.Protocol.Messages;
using Bolgrot.Core.Ankama.Protocol.SendMessages;
using Bolgrot.Core.Common.Entity;
using Bolgrot.Core.Common.Managers.Frames;
using Bolgrot.Core.Common.Network;
using Bolgrot.Core.Common.Repository;
using Bolgrot.Server.Auth.Managers;

namespace Bolgrot.Server.Auth.Frames
{
    public class ServerSelectionFrames
    {
        //private static readonly Object obj = new Object();
        [InterceptFrame("ServerSelectionMessage")]
        public void ServerSelectionMessage(Client client, ServerSelectionMessage serverSelectionMessage)
        {
            //lock (obj)
                Container.Instance().Resolve<IAccountRepository>().Entities().AddOrUpdate(client.Account.Id, client.Account,
                (i, account) =>
                {
                    account.Ticket = Guid.NewGuid().ToString();
                    account.IsEdited = true;
                    return account;
                });
            //lock (obj)
            Container.Instance().Resolve<AuthRepositoryPersistManager>().ForceSave();
            WorldServer server = Container.Instance().Resolve<IWorldServerManager>().Servers().FirstOrDefault(x => x.Id == serverSelectionMessage.serverId);
            if(server!=null)
                client.Send(new SelectedServerDataMessage(serverSelectionMessage.serverId, server.Address, server.Port, true, client.Account.Ticket, server.Access));
            //client.Send(new SelectedServerDataMessage(serverSelectionMessage.serverId, "localhost", 666, true, client.Account.Ticket, "http://localhost:666"));


        }
    }
}