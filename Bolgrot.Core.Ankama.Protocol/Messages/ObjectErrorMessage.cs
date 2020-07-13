using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class ObjectErrorMessage : NetworkMessage
    {

	    public int reason;


        public ObjectErrorMessage()
        {
        }

        public ObjectErrorMessage(int reason)
        {
            this.reason = reason;

        }
    }
}