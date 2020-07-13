using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class GameActionFightPointsVariationMessage : NetworkMessage
    {

	    public int actionId;
	    public int sourceId;
	    public int targetId;
	    public int delta;


        public GameActionFightPointsVariationMessage()
        {
        }

        public GameActionFightPointsVariationMessage(int actionId, int sourceId, int targetId, int delta)
        {
            this.actionId = actionId;
            this.sourceId = sourceId;
            this.targetId = targetId;
            this.delta = delta;

        }
    }
}