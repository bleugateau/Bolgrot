using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class GameActionFightSpellCastMessage : NetworkMessage
    {

	    public int actionId;
	    public int sourceId;
	    public int targetId;
	    public int destinationCellId;
	    public int critical;
	    public bool silentCast;
	    public int spellId;
	    public int spellLevel;
	    public object _scriptParams;


        public GameActionFightSpellCastMessage()
        {
        }

        public GameActionFightSpellCastMessage(int actionId, int sourceId, int targetId, int destinationCellId, int critical, bool silentCast, int spellId, int spellLevel, object _scriptParams)
        {
            this.actionId = actionId;
            this.sourceId = sourceId;
            this.targetId = targetId;
            this.destinationCellId = destinationCellId;
            this.critical = critical;
            this.silentCast = silentCast;
            this.spellId = spellId;
            this.spellLevel = spellLevel;
            this._scriptParams = _scriptParams;

        }
    }
}