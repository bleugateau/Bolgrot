using Bolgrot.Core.Ankama.Protocol.Messages;
using Bolgrot.Core.Common.Managers.Frames;
using Bolgrot.Core.Common.Network;
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
        
        [InterceptCall("login")]
        public void LoginCallFrame(Client client, JObject message)
        {
            if (!message.ContainsKey("data"))
                return;

            // var loginMessage = JsonConvert.DeserializeObject<LoginMessage>(message["data"].ToString());
            //
            //
            // //find user in database and check
            //
            // //check token
            // //client.Send(new IdentificationFailedMessage(0));
            //
            //
            // //valid user
            // client.Send(new CredentialsAcknowledgementMessage());
            // client.Send(new IdentificationSuccessMessage("4638024884374416908", "Test", 141231, 0, true, "DELETE ?", 0, false, 1577995402000, true, "", ""));
            //
            // //IPC to world
            // client.Send(new ServersListMessage(new GameServerInformations[]
            // {
            //     new GameServerInformations(128, 3, 0, true, 1, 1583348790936, "Arkanic PvP", 3)
            // }));
            //
            // client.Dispose();
        }
    }
}