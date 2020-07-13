using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class GameRolePlayArenaUpdatePlayerInfosMessage : NetworkMessage
    {

	    public int rank;
	    public int bestDailyRank;
	    public int bestRank;
	    public int victoryCount;
	    public int arenaFightcount;


        public GameRolePlayArenaUpdatePlayerInfosMessage()
        {
        }

        public GameRolePlayArenaUpdatePlayerInfosMessage(int rank, int bestDailyRank, int bestRank, int victoryCount, int arenaFightcount)
        {
            this.rank = rank;
            this.bestDailyRank = bestDailyRank;
            this.bestRank = bestRank;
            this.victoryCount = victoryCount;
            this.arenaFightcount = arenaFightcount;

        }
    }
}