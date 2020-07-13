using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class GameFightTurnListMessage : NetworkMessage
    {

	    public int[] ids;
	    public int[] deadsIds;


        public GameFightTurnListMessage()
        {
        }

        public GameFightTurnListMessage(int[] ids, int[] deadsIds)
        {
            this.ids = ids;
            this.deadsIds = deadsIds;

        }
    }
}