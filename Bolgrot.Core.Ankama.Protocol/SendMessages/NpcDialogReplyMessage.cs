using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.SendMessages
{
    public class NpcDialogReplyMessage : CallNetworkMessage
    {

	    public int replyId;


        public NpcDialogReplyMessage()
        {
        }

        public NpcDialogReplyMessage(int replyId)
        {
            this.replyId = replyId;

        }
    }
}