using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class LifePointsRegenEndMessage : NetworkMessage
    {

	    public int lifePoints;
	    public int maxLifePoints;
	    public int lifePointsGained;


        public LifePointsRegenEndMessage()
        {
        }

        public LifePointsRegenEndMessage(int lifePoints, int maxLifePoints, int lifePointsGained)
        {
            this.lifePoints = lifePoints;
            this.maxLifePoints = maxLifePoints;
            this.lifePointsGained = lifePointsGained;

        }
    }
}