using System;
using System.Linq;
using Autofac;
using Bolgrot.Core.Ankama.Protocol.Messages;
using Bolgrot.Core.Ankama.Protocol.SendMessages;
using Bolgrot.Core.Common.Managers.Frames;
using Bolgrot.Server.Game.Managers;
using Bolgrot.Server.Game.Network;

namespace Bolgrot.Server.Game.Frames
{
    public class NpcInteractionsFrames
    {
        [InterceptFrame("NpcGenericActionRequestMessage")]
        public void NpcGenericActionRequestMessageFrame(GameClient client, NpcGenericActionRequestMessage npcGenericActionRequestMessage)
        {
            int npcId = npcGenericActionRequestMessage.npcId * -1;
            
            var map = Container.Instance().Resolve<IMapManager>().GetMapById(client.Character.MapId).Result;
            if (map == null)
            {
                client.Disconnect();
                return;
            }

            var npcSpawn = map.NpcSpawns.FirstOrDefault(x => x.Id == npcId);
            if (npcSpawn == null)
            {
                return;
            }
            
            client.Send(new NpcDialogCreationMessage(npcGenericActionRequestMessage.npcMapId, npcGenericActionRequestMessage.npcId));
            client.Send(new NpcDialogQuestionMessage((int)npcSpawn.Npc.DialogMessages[0][0], new int[] {}, new int[] {10434, 10450, 10456}));
            client.Send(new BasicNoOperationMessage());
            
        }
    }
}