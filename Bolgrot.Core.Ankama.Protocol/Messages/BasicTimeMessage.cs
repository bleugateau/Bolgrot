using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class BasicTimeMessage : NetworkMessage
    {

	    public int timestamp;
	    public int timezoneOffset;


        public BasicTimeMessage()
        {
        }

        public BasicTimeMessage(int timestamp, int timezoneOffset)
        {
            this.timestamp = timestamp;
            this.timezoneOffset = timezoneOffset;

        }
    }
}