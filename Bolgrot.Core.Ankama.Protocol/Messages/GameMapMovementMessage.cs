using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class GameMapMovementMessage : NetworkMessage
    {

	    public int[] keyMovements;
	    public int actorId;


        public GameMapMovementMessage()
        {
        }

        public GameMapMovementMessage(int[] keyMovements, int actorId)
        {
            this.keyMovements = keyMovements;
            this.actorId = actorId;

        }
    }
}