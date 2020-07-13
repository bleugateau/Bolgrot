using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class GameFightHumanReadyStateMessage : NetworkMessage
    {

	    public int characterId;
	    public bool isReady;


        public GameFightHumanReadyStateMessage()
        {
        }

        public GameFightHumanReadyStateMessage(int characterId, bool isReady)
        {
            this.characterId = characterId;
            this.isReady = isReady;

        }
    }
}