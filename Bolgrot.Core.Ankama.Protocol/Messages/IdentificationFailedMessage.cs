using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class IdentificationFailedMessage : NetworkMessage
    {

	    public int reason;


        public IdentificationFailedMessage()
        {
        }

        public IdentificationFailedMessage(int reason)
        {
            this.reason = reason;

        }
    }
}