using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.SendMessages
{
    public class GameMapMovementCancelMessage : CallNetworkMessage
    {

	    public int cellId;


        public GameMapMovementCancelMessage()
        {
        }

        public GameMapMovementCancelMessage(int cellId)
        {
            this.cellId = cellId;

        }
    }
}