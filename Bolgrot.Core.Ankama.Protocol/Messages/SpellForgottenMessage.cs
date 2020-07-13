using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class SpellForgottenMessage : NetworkMessage
    {

	    public int[] spellsId;
	    public int boostPoint;


        public SpellForgottenMessage()
        {
        }

        public SpellForgottenMessage(int[] spellsId, int boostPoint)
        {
            this.spellsId = spellsId;
            this.boostPoint = boostPoint;

        }
    }
}