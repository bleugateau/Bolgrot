using Bolgrot.Core.Ankama.Protocol.Messages;
using Bolgrot.Core.Ankama.Protocol.SendMessages;
using Bolgrot.Core.Common.Managers.Frames;
using Bolgrot.Server.Game.Network;

namespace Bolgrot.Server.Game.Frames
{
    public class CharacterFrames
    {
        [InterceptFrame("FriendsGetListMessage")]
        public void FriendsGetListMessageFrame(GameClient client, FriendsGetListMessage friendsGetListMessage)
        {
            client.Send(new FriendsListMessage(new int[] {}));
        }
        
        [InterceptFrame("IgnoredGetListMessage")]
        public void IgnoredGetListMessageFrame(GameClient client, IgnoredGetListMessage ignoredGetListMessage)
        {
            client.Send(new IgnoredListMessage(new int[] {}));
        }
        
        [InterceptFrame("SpouseGetInformationsMessage")]
        public void SpouseGetInformationsMessageFrame(GameClient client, SpouseGetInformationsMessage spouseGetInformationsMessage)
        {
            //
        }
        
        //SpouseGetInformationsMessage
    }
}