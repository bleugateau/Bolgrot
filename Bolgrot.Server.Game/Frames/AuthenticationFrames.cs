using System.Collections.Generic;
using System.Linq;
using Autofac;
using Bolgrot.Core.Ankama.Protocol.Messages;
using Bolgrot.Core.Ankama.Protocol.SendMessages;
using Bolgrot.Core.Ankama.Protocol.Types;
using Bolgrot.Core.Common.Managers.Frames;
using Bolgrot.Core.Common.Network;
using Bolgrot.Core.Common.Repository;
using Bolgrot.Server.Game.Network;
using Newtonsoft.Json.Linq;

namespace Bolgrot.Server.Game.Frames
{
    public class AuthenticationFrames
    {
        [InterceptCall("connecting")]
        public void ConnectingCallFrame(Client client, JObject message)
        {
            client.Send(new ProtocolRequired(1594, 1594));
            client.Send(new HelloGameMessage());
        }

        [InterceptFrame("BasicPingMessage")]
        public void BasicPingMessageFrame(GameClient client, BasicPingMessage basicPingMessage)
        {
            client.Send(new BasicPongMessage(false));
        }

        [InterceptFrame("AuthenticationTicketMessage")]
        public void AuthenticationTicketMessageFrame(Client client, AuthenticationTicketMessage authenticationTicketMessage)
        {
            
            //verif du compte via IPC
            
            client.Send(new AuthenticationTicketAcceptedMessage());
            client.Send(new AccountCapabilitiesMessage(141748286, true, 32767, 32767, 0, new int[] {}, new object()));
            client.Send(new TrustStatusMessage(true));
        }
    }
}