using System.Threading.Tasks;
using Autofac;
using Bolgrot.Core.Ankama.Protocol.Messages;
using Bolgrot.Core.Ankama.Protocol.SendMessages;
using Bolgrot.Core.Ankama.Protocol.Types;
using Bolgrot.Core.Common.Managers.Frames;
using Bolgrot.Core.Common.Network;
using Bolgrot.Core.Common.Repository;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bolgrot.Server.Auth.Frames
{
    public class AuthenticationFrames
    {
        
        [InterceptCall("connecting")]
        public void ConnectingCallFrame(Client client, JObject message)
        {
            client.Send(new ProtocolRequired(1594, 1594));
            client.Send(new HelloConnectMessage("kbgvrb5aYZa&udoTr&~z3JACZDKTe&.F", new int[] { }));
        }
        
        [InterceptCall("disconnecting")]
        public void DisconnectingCallFrame(Client client, JObject message)
        {
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
                return;
            }
            
            //check for already connected
            
            client.Account = account;
            
            client.Send(new CredentialsAcknowledgementMessage());
            client.Send(new IdentificationSuccessMessage(account.Login, account.Nickname, 141231, 0, true, "DELETE ?", 0, false, 1577995402000, true, "", ""));

            //do IPC + characters number
            client.Send(new ServersListMessage(new GameServerInformations[]
            {
                new GameServerInformations(405, 3, 0, true, 1, 1583348790936, "Bolgrot", 0)
            }));
        }
    }
}