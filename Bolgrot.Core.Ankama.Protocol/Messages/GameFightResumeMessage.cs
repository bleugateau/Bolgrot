using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class GameFightResumeMessage : NetworkMessage
    {

	    public int[] effects;
	    public int[] marks;
	    public int gameTurn;
	    public int[] spellCooldowns;
	    public int summonCount;
	    public int bombCount;


        public GameFightResumeMessage()
        {
        }

        public GameFightResumeMessage(int[] effects, int[] marks, int gameTurn, int[] spellCooldowns, int summonCount, int bombCount)
        {
            this.effects = effects;
            this.marks = marks;
            this.gameTurn = gameTurn;
            this.spellCooldowns = spellCooldowns;
            this.summonCount = summonCount;
            this.bombCount = bombCount;

        }
    }
}