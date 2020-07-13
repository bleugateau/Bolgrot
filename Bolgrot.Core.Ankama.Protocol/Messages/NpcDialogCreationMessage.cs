using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class NpcDialogCreationMessage : NetworkMessage
    {

	    public int mapId;
	    public int npcId;


        public NpcDialogCreationMessage()
        {
        }

        public NpcDialogCreationMessage(int mapId, int npcId)
        {
            this.mapId = mapId;
            this.npcId = npcId;

        }
    }
}