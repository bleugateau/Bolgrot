using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class GameActionFightNoSpellCastMessage : NetworkMessage
    {

	    public int spellLevelId;


        public GameActionFightNoSpellCastMessage()
        {
        }

        public GameActionFightNoSpellCastMessage(int spellLevelId)
        {
            this.spellLevelId = spellLevelId;

        }
    }
}