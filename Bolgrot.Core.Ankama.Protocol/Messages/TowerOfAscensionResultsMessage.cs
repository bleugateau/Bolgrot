using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class TowerOfAscensionResultsMessage : NetworkMessage
    {

	    public int[] steps;


        public TowerOfAscensionResultsMessage()
        {
        }

        public TowerOfAscensionResultsMessage(int[] steps)
        {
            this.steps = steps;

        }
    }
}