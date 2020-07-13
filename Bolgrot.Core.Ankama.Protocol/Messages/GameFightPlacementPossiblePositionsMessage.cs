using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class GameFightPlacementPossiblePositionsMessage : NetworkMessage
    {

	    public int[] positionsForChallengers;
	    public int[] positionsForDefenders;
	    public int teamNumber;


        public GameFightPlacementPossiblePositionsMessage()
        {
        }

        public GameFightPlacementPossiblePositionsMessage(int[] positionsForChallengers, int[] positionsForDefenders, int teamNumber)
        {
            this.positionsForChallengers = positionsForChallengers;
            this.positionsForDefenders = positionsForDefenders;
            this.teamNumber = teamNumber;

        }
    }
}