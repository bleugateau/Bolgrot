using Bolgrot.Core.Ankama.Protocol.Messages;
using Bolgrot.Core.Ankama.Protocol.SendMessages;
using Bolgrot.Core.Common.Managers.Frames;
using Bolgrot.Server.Game.Network;

namespace Bolgrot.Server.Game.Frames
{
    public class QuestFrames
    {
        //QuestListRequestMessage
        [InterceptFrame("QuestListRequestMessage")]
        public void QuestListRequestMessageFrame(GameClient client, QuestListRequestMessage questListRequestMessage)
        {
            client.Send(new QuestListMessage(new int[] {}, new int[] {}, new int[] {}));
        }
    }
}