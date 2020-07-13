using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class serverDisconnecting : NetworkMessage
    {

	    public string reason;


        public serverDisconnecting()
        {
        }

        public serverDisconnecting(string reason)
        {
            this.reason = reason;

        }
    }
}