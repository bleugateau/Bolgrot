using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using Bolgrot.Core.Ankama.Protocol.Messages;
using Bolgrot.Core.Ankama.Protocol.SendMessages;
using Bolgrot.Core.Ankama.Protocol.Types;
using Bolgrot.Core.Common.Managers.Frames;
using Bolgrot.Core.Common.Network;
using Bolgrot.Core.Common.Repository;
using Bolgrot.Server.Auth.Managers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServiceStack.Text;

namespace Bolgrot.Server.Auth.Frames
{
    public class AuthenticationFrames
    {
        
        [InterceptCall("connecting")]
        public void ConnectingCallFrame(Client client, JObject message)
        {
            client.Send(new ProtocolRequired(1594, 1554));
            client.Send(new HelloConnectMessage("kbgvrb5aYZa&udoTr&~z3JACZDKTe&.F", new int[] { }));
            //var connectingMessage = JsonConvert.DeserializeObject<ConnectingMessage>(message["data"].ToString());
            //client.Language = connectingMessage.language;
        }

        [InterceptCall("disconnecting")]
        public void DisconnectingCallFrame(Client client, JObject message)
        {
            client.Disconnect();
        }
        [InterceptCall("reconnecting")]
        public void ReConnectingCallFrame(Client client, JObject message)
        {
            client.Send(new sessionReconnected());
            client.Disconnect();
        }

        [InterceptCall("login")]
        public async Task LoginCallFrame(Client client, JObject message)
        {
            if (!message.ContainsKey("data"))
                return;


            var loginMessage = JsonConvert.DeserializeObject<LoginMessage>(message["data"].ToString());

            var account = await Container.Instance().Resolve<IAccountRepository>().GetAccountByLogin(loginMessage.username);

            if (account == null || account.Token != loginMessage.token)
            {
                client.Send(new AuthenticationTicketRefusedMessage());
                client.Disconnect();
                return;
            }

            //check for already connected

            client.Account = account;

            client.Send(new CredentialsAcknowledgementMessage());
            client.Send(new IdentificationSuccessMessage(account.Login, account.Nickname, 141231, 0, true, "DELETE ?", 0, false, account.CreationDate.ToUnixTime(), true, "", ""));


            //do IPC + characters number
            ;
            List<GameServerInformations> server_inf = new List<GameServerInformations>();
            foreach (var server in Container.Instance().Resolve<IWorldServerManager>().Servers())
            {
                server_inf.Add(new GameServerInformations(server.Id, server.Status, server.Completion, server.ServerSelectable, server.CharsCount, server.CreationDate.ToUnixTime(), server.Name, server.Type));
            }
            client.Send(new ServersListMessage(server_inf.ToArray()));
            //client.Send(new ServersListMessage(new GameServerInformations[]
            //{
            //    new GameServerInformations(405, 3, 0, true, 1, 1583348790936, "Bolgrot", 0)
            //}));
        }
    }
}