using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class GameActionFightLifePointsLostMessage : NetworkMessage
    {

	    public int actionId;
	    public int sourceId;
	    public int targetId;
	    public int loss;
	    public int permanentDamages;


        public GameActionFightLifePointsLostMessage()
        {
        }

        public GameActionFightLifePointsLostMessage(int actionId, int sourceId, int targetId, int loss, int permanentDamages)
        {
            this.actionId = actionId;
            this.sourceId = sourceId;
            this.targetId = targetId;
            this.loss = loss;
            this.permanentDamages = permanentDamages;

        }
    }
}