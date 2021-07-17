using Autofac;
using Bolgrot.Core.Ankama.Protocol.Messages;
using Bolgrot.Core.Ankama.Protocol.SendMessages;
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
            //LifePointsRegenBeginMessage regen rate:5 
            client.Send(new CurrentMapMessage(client.Character.MapId, "649ae451ca33ec53bbcbcc33becf15f4"));
            client.Send(new BasicTimeMessage(1606023934,60));// time which yet it
            //CharacterStatsListMessage          
        }

        [InterceptFrame("MapInformationsRequestMessage")]
        public void MapInformationsRequestMessageFrame(GameClient client, MapInformationsRequestMessage mapInformationsRequestMessage)
        {
            Container.Instance().Resolve<IMapManager>().SendMapInformationsRequest(client, mapInformationsRequestMessage);
        }

        [InterceptFrame("GameMapMovementRequestMessage")]
        public void GameMapMovementRequestMessage(GameClient client, GameMapMovementRequestMessage gameMapMovementRequestMessage)
        {
            Container.Instance().Resolve<IMapManager>().GameMapMovement(client, gameMapMovementRequestMessage);
        }
        
        [InterceptFrame("ChangeMapMessage")]
        public void ChangeMapMessage(GameClient client, ChangeMapMessage changeMapMessage)
        {
            Container.Instance().Resolve<IMapManager>().ChangeMap(client, changeMapMessage);
        }
    }
}