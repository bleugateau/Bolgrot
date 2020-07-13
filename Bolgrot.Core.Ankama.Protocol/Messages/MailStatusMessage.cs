using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class MailStatusMessage : NetworkMessage
    {

	    public int unread;
	    public int total;


        public MailStatusMessage()
        {
        }

        public MailStatusMessage(int unread, int total)
        {
            this.unread = unread;
            this.total = total;

        }
    }
}