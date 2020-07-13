using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class ServerOptionalFeaturesMessage : NetworkMessage
    {

	    public int[] features;


        public ServerOptionalFeaturesMessage()
        {
        }

        public ServerOptionalFeaturesMessage(int[] features)
        {
            this.features = features;

        }
    }
}