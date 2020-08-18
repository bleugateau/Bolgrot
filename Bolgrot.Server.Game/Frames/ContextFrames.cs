using Bolgrot.Core.Ankama.Protocol.Messages;
using Bolgrot.Core.Ankama.Protocol.SendMessages;
using Bolgrot.Core.Ankama.Protocol.Types;
using Bolgrot.Core.Common.Managers.Frames;
using Bolgrot.Server.Game.Network;

namespace Bolgrot.Server.Game.Frames
{
    public class ContextFrames
    {
        [InterceptFrame("GameContextCreateRequestMessage")]
        public void GameContextCreateRequestMessageFrame(GameClient client, GameContextCreateRequestMessage gameContextCreateRequestMessage)
        {
            client.Send(new GameContextDestroyMessage());
            client.Send(new GameContextCreateMessage(1)); //1 ??
            client.Send(new CurrentMapMessage(81266690, "649ae451ca33ec53bbcbcc33becf15f4"));
        }

        [InterceptFrame("MapInformationsRequestMessage")]
        public void MapInformationsRequestMessageFrame(GameClient client, MapInformationsRequestMessage mapInformationsRequestMessage)
        {
            client.Send(new MapComplementaryInformationsDataMessage(440, mapInformationsRequestMessage.mapId, new int[] {},  new GameRolePlayCharacterInformations[]
            {
                new GameRolePlayCharacterInformations(client.Character.Id, client.Character.EntityLook, new EntityDispositionInformations(298,1), client.Character.Name, new HumanInformations(), 1, new ActorAlignmentInformations(0,0,0,3956606) ), 
            }, new int[] {},  new int[] {}, new int[] {},new int[]{}));
        }
    }
}