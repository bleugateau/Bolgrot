using Autofac;
using Bolgrot.Core.Ankama.Protocol.SendMessages;
using Bolgrot.Core.Common.Managers.Frames;
using Bolgrot.Server.Game.Managers;
using Bolgrot.Server.Game.Network;

namespace Bolgrot.Server.Game.Frames
{
    public class ApproachFrames
    {
        //CharacterCreationRequestMessage
        [InterceptFrame("CharacterCreationRequestMessage")]
        public void CharactersListRequestMessageFrame(GameClient client, CharacterCreationRequestMessage characterCreationRequestMessage)
        {
            Container.Instance().Resolve<ICharacterManager>().CreateCharacter(client, characterCreationRequestMessage);
        }
    }
}