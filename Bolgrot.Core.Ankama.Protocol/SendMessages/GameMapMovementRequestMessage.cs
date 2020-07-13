using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.SendMessages
{
    public class GameMapMovementRequestMessage : CallNetworkMessage
    {

	    public int[] keyMovements;
	    public int mapId;


        public GameMapMovementRequestMessage()
        {
        }

        public GameMapMovementRequestMessage(int[] keyMovements, int mapId)
        {
            this.keyMovements = keyMovements;
            this.mapId = mapId;

        }
    }
}