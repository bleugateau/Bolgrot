using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class GameFightTurnEndMessage : NetworkMessage
    {

	    public int id;


        public GameFightTurnEndMessage()
        {
        }

        public GameFightTurnEndMessage(int id)
        {
            this.id = id;

        }
    }
}