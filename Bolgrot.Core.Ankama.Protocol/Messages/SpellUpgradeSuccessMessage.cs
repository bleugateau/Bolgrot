using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class SpellUpgradeSuccessMessage : NetworkMessage
    {

	    public int spellId;
	    public int spellLevel;


        public SpellUpgradeSuccessMessage()
        {
        }

        public SpellUpgradeSuccessMessage(int spellId, int spellLevel)
        {
            this.spellId = spellId;
            this.spellLevel = spellLevel;

        }
    }
}