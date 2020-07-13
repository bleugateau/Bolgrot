using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class GameFightTurnStartMessage : NetworkMessage
    {

	    public int id;
	    public int waitTime;


        public GameFightTurnStartMessage()
        {
        }

        public GameFightTurnStartMessage(int id, int waitTime)
        {
            this.id = id;
            this.waitTime = waitTime;

        }
    }
}