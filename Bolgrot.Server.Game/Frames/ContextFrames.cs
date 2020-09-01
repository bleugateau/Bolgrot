using System;
using Autofac;
using Bolgrot.Core.Ankama.Protocol.Messages;
using Bolgrot.Core.Ankama.Protocol.SendMessages;
using Bolgrot.Core.Ankama.Protocol.Types;
using Bolgrot.Core.Common.Managers.Frames;
using Bolgrot.Server.Game.Managers;
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
            client.Send(new CurrentMapMessage(client.Character.MapId, "649ae451ca33ec53bbcbcc33becf15f4"));
        }

        [InterceptFrame("MapInformationsRequestMessage")]
        public void MapInformationsRequestMessageFrame(GameClient client, MapInformationsRequestMessage mapInformationsRequestMessage)
        {

            var map = Container.Instance().Resolve<IMapManager>().GetMapById(mapInformationsRequestMessage.mapId).Result;

            if (map == null)
            {
                client.Disconnect();
                return;
            }
            
            
            client.Send(new MapComplementaryInformationsDataMessage(440, map.Id, new int[] {},  new GameRolePlayCharacterInformations[]
            {
                new GameRolePlayCharacterInformations(client.Character.Id, client.Character.EntityLook, new EntityDispositionInformations(client.Character.CellId,1), client.Character.Name, new HumanInformations(), 1, new ActorAlignmentInformations(0,0,0,3956606) ), 
            }, new int[] {},  new int[] {}, new int[] {},new int[]{}));
        }

        [InterceptFrame("GameMapMovementRequestMessage")]
        public void GameMapMovementRequestMessage(GameClient client, GameMapMovementRequestMessage gameMapMovementRequestMessage)
        {
            //fix reconnection
            Container.Instance().Resolve<IMapManager>().GameMapMovement(client, gameMapMovementRequestMessage);
        }


        [InterceptFrame("ChangeMapMessage")]
        public void ChangeMapMessage(GameClient client, GameMapMovementMessage gameMapMovementMessage)
        {
            //@TODO
        }
    }
}