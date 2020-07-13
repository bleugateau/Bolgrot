using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolgrot.Core.Ankama.Protocol.Types;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class GameFightEndMessage : NetworkMessage
    {

	    public int duration;
	    public int ageBonus;
	    public int lootShareLimitMalus;
	    public FightResultPlayerListEntry[] results;
	    public int score;


        public GameFightEndMessage()
        {
        }

        public GameFightEndMessage(int duration, int ageBonus, int lootShareLimitMalus, FightResultPlayerListEntry[] results, int score)
        {
            this.duration = duration;
            this.ageBonus = ageBonus;
            this.lootShareLimitMalus = lootShareLimitMalus;
            this.results = results;
            this.score = score;

        }
    }
}