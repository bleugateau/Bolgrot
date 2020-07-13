using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class FriendWarnOnConnectionStateMessage : NetworkMessage
    {

	    public bool enable;


        public FriendWarnOnConnectionStateMessage()
        {
        }

        public FriendWarnOnConnectionStateMessage(bool enable)
        {
            this.enable = enable;

        }
    }
}