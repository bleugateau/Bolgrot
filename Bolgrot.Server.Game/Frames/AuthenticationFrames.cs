using Bolgrot.Core.Ankama.Protocol.Messages;
using Bolgrot.Core.Ankama.Protocol.SendMessages;
using Bolgrot.Core.Ankama.Protocol.Types;
using Bolgrot.Core.Common.Managers.Frames;
using Bolgrot.Core.Common.Network;
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

        [InterceptFrame("AuthenticationTicketMessage")]
        public void AuthenticationTicketMessageFrame(Client client, AuthenticationTicketMessage authenticationTicketMessage)
        {
            client.Send(new AuthenticationTicketAcceptedMessage());
            client.Send(new AccountCapabilitiesMessage(141748286, true, 32767, 32767, 0, new int[] {}, new object()));
            client.Send(new TrustStatusMessage(true));
        }

        [InterceptFrame("CharactersListRequestMessage")]
        public void CharactersListRequestMessageFrame(Client client,
            CharactersListRequestMessage charactersListRequestMessage)
        {
            client.Send(new CharactersListMessage(true, new CharacterBaseInformations[]
            {
                new CharacterBaseInformations(1, 200, "Ten", new EntityLook(1, new int[]{20, 2030}, new int[]{33536592, 50331596, 53058242, 69935891, 86612674}, new int[]{130}, new SubEntity[] {}), 2, false), 
            }));
        }
    }
}