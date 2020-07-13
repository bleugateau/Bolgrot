using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class GameActionFightDeathMessage : NetworkMessage
    {

	    public int actionId;
	    public int sourceId;
	    public int targetId;


        public GameActionFightDeathMessage()
        {
        }

        public GameActionFightDeathMessage(int actionId, int sourceId, int targetId)
        {
            this.actionId = actionId;
            this.sourceId = sourceId;
            this.targetId = targetId;

        }
    }
}