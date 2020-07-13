using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class UpdateMapPlayersAgressableStatusMessage : NetworkMessage
    {

	    public int[] playerIds;
	    public int[] enable;


        public UpdateMapPlayersAgressableStatusMessage()
        {
        }

        public UpdateMapPlayersAgressableStatusMessage(int[] playerIds, int[] enable)
        {
            this.playerIds = playerIds;
            this.enable = enable;

        }
    }
}