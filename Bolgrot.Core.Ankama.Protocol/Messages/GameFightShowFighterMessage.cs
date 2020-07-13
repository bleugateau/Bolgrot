using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolgrot.Core.Ankama.Protocol.Types;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class GameFightShowFighterMessage : NetworkMessage
    {

	    public GameFightCharacterInformations informations;


        public GameFightShowFighterMessage()
        {
        }

        public GameFightShowFighterMessage(GameFightCharacterInformations informations)
        {
            this.informations = informations;

        }
    }
}