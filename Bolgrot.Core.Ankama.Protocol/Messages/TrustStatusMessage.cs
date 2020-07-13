using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class TrustStatusMessage : NetworkMessage
    {

	    public bool trusted;


        public TrustStatusMessage()
        {
        }

        public TrustStatusMessage(bool trusted)
        {
            this.trusted = trusted;

        }
    }
}