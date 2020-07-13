using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolgrot.Core.Ankama.Protocol.Types;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class GameFightUpdateTeamMessage : NetworkMessage
    {

	    public int fightId;
	    public FightTeamInformations team;


        public GameFightUpdateTeamMessage()
        {
        }

        public GameFightUpdateTeamMessage(int fightId, FightTeamInformations team)
        {
            this.fightId = fightId;
            this.team = team;

        }
    }
}