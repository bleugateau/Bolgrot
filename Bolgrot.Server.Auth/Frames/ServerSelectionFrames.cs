using System;
using Autofac;
using Bolgrot.Core.Ankama.Protocol.Messages;
using Bolgrot.Core.Ankama.Protocol.SendMessages;
using Bolgrot.Core.Common.Managers.Frames;
using Bolgrot.Core.Common.Network;
using Bolgrot.Core.Common.Repository;

namespace Bolgrot.Server.Auth.Frames
{
    public class ServerSelectionFrames
    {
        [InterceptFrame("ServerSelectionMessage")]
        public void ServerSelectionMessage(Client client, ServerSelectionMessage serverSelectionMessage)
        {
            Container.Instance().Resolve<IAccountRepository>().Entities().AddOrUpdate(client.Account.Id, client.Account,
                (i, account) =>
                {
                    account.Ticket = Guid.NewGuid().ToString();
                    account.IsEdited = true;
                    return account;
                });

            client.Send(new SelectedServerDataMessage(serverSelectionMessage.serverId, "localhost", 666, true, client.Account.Ticket, "http://localhost:666"));
        }
    }
}