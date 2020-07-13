using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class GameActionFightDodgePointLossMessage : NetworkMessage
    {

	    public int actionId;
	    public int sourceId;
	    public int targetId;
	    public int amount;


        public GameActionFightDodgePointLossMessage()
        {
        }

        public GameActionFightDodgePointLossMessage(int actionId, int sourceId, int targetId, int amount)
        {
            this.actionId = actionId;
            this.sourceId = sourceId;
            this.targetId = targetId;
            this.amount = amount;

        }
    }
}