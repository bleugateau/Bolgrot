using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class GameFightOptionStateUpdateMessage : NetworkMessage
    {

	    public int fightId;
	    public int teamId;
	    public int option;
	    public bool state;


        public GameFightOptionStateUpdateMessage()
        {
        }

        public GameFightOptionStateUpdateMessage(int fightId, int teamId, int option, bool state)
        {
            this.fightId = fightId;
            this.teamId = teamId;
            this.option = option;
            this.state = state;

        }
    }
}