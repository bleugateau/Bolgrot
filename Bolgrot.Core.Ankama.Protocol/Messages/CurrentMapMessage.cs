using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class CurrentMapMessage : NetworkMessage
    {

	    public long mapId;
	    public string mapKey;


        public CurrentMapMessage()
        {
        }

        public CurrentMapMessage(long mapId, string mapKey)
        {
            this.mapId = mapId;
            this.mapKey = mapKey;

        }
    }
}