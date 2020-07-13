using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.SendMessages
{
    public class ChangeMapMessage : CallNetworkMessage
    {

	    public int mapId;


        public ChangeMapMessage()
        {
        }

        public ChangeMapMessage(int mapId)
        {
            this.mapId = mapId;

        }
    }
}