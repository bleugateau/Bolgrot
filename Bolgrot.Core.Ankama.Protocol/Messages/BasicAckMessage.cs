using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class BasicAckMessage : NetworkMessage
    {

	    public int seq;
	    public int lastPacketId;


        public BasicAckMessage()
        {
        }

        public BasicAckMessage(int seq, int lastPacketId)
        {
            this.seq = seq;
            this.lastPacketId = lastPacketId;

        }
    }
}