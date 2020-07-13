using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.SendMessages
{
    public class MapInformationsRequestMessage : CallNetworkMessage
    {

	    public int mapId;


        public MapInformationsRequestMessage()
        {
        }

        public MapInformationsRequestMessage(int mapId)
        {
            this.mapId = mapId;

        }
    }
}