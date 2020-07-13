using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.SendMessages
{
    public class SpellUpgradeRequestMessage : CallNetworkMessage
    {

	    public int spellId;
	    public int spellLevel;


        public SpellUpgradeRequestMessage()
        {
        }

        public SpellUpgradeRequestMessage(int spellId, int spellLevel)
        {
            this.spellId = spellId;
            this.spellLevel = spellLevel;

        }
    }
}