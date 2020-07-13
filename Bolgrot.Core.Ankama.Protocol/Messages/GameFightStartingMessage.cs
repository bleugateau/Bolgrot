using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class GameFightStartingMessage : NetworkMessage
    {

	    public int fightType;


        public GameFightStartingMessage()
        {
        }

        public GameFightStartingMessage(int fightType)
        {
            this.fightType = fightType;

        }
    }
}