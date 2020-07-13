using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class ChallengeInfoMessage : NetworkMessage
    {

	    public int challengeId;
	    public int targetId;
	    public int xpBonus;
	    public int dropBonus;
	    public string _name;
	    public string _description;
	    public int _points;


        public ChallengeInfoMessage()
        {
        }

        public ChallengeInfoMessage(int challengeId, int targetId, int xpBonus, int dropBonus, string _name, string _description, int _points)
        {
            this.challengeId = challengeId;
            this.targetId = targetId;
            this.xpBonus = xpBonus;
            this.dropBonus = dropBonus;
            this._name = _name;
            this._description = _description;
            this._points = _points;

        }
    }
}