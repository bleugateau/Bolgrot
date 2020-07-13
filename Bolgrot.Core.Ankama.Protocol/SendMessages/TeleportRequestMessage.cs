using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.SendMessages
{
    public class TeleportRequestMessage : CallNetworkMessage
    {

	    public int teleporterType;
	    public int mapId;


        public TeleportRequestMessage()
        {
        }

        public TeleportRequestMessage(int teleporterType, int mapId)
        {
            this.teleporterType = teleporterType;
            this.mapId = mapId;

        }
    }
}