using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class GameFightTurnResumeMessage : NetworkMessage
    {

	    public int id;
	    public int waitTime;


        public GameFightTurnResumeMessage()
        {
        }

        public GameFightTurnResumeMessage(int id, int waitTime)
        {
            this.id = id;
            this.waitTime = waitTime;

        }
    }
}