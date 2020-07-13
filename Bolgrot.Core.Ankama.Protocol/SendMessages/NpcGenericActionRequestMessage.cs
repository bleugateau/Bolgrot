using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.SendMessages
{
    public class NpcGenericActionRequestMessage : CallNetworkMessage
    {

	    public int npcId;
	    public int npcActionId;
	    public int npcMapId;


        public NpcGenericActionRequestMessage()
        {
        }

        public NpcGenericActionRequestMessage(int npcId, int npcActionId, int npcMapId)
        {
            this.npcId = npcId;
            this.npcActionId = npcActionId;
            this.npcMapId = npcMapId;

        }
    }
}