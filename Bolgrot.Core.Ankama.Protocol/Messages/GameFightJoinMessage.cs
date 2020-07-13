using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class GameFightJoinMessage : NetworkMessage
    {

	    public bool canBeCancelled;
	    public bool canSayReady;
	    public bool isSpectator;
	    public bool isFightStarted;
	    public int timeMaxBeforeFightStart;
	    public int fightType;


        public GameFightJoinMessage()
        {
        }

        public GameFightJoinMessage(bool canBeCancelled, bool canSayReady, bool isSpectator, bool isFightStarted, int timeMaxBeforeFightStart, int fightType)
        {
            this.canBeCancelled = canBeCancelled;
            this.canSayReady = canSayReady;
            this.isSpectator = isSpectator;
            this.isFightStarted = isFightStarted;
            this.timeMaxBeforeFightStart = timeMaxBeforeFightStart;
            this.fightType = fightType;

        }
    }
}