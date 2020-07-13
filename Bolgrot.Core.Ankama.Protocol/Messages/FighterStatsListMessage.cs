using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolgrot.Core.Ankama.Protocol.Types;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class FighterStatsListMessage : NetworkMessage
    {

	    public CharacterCharacteristicsInformations stats;


        public FighterStatsListMessage()
        {
        }

        public FighterStatsListMessage(CharacterCharacteristicsInformations stats)
        {
            this.stats = stats;

        }
    }
}