using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolgrot.Core.Ankama.Protocol.Types;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class PrismsListMessage : NetworkMessage
    {

	    public PrismGeolocalizedInformation[] prisms;


        public PrismsListMessage()
        {
        }

        public PrismsListMessage(PrismGeolocalizedInformation[] prisms)
        {
            this.prisms = prisms;

        }
    }
}