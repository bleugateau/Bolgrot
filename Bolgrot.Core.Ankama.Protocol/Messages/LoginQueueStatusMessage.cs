using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class LoginQueueStatusMessage : NetworkMessage
    {

	    public int position;
	    public int total;


        public LoginQueueStatusMessage()
        {
        }

        public LoginQueueStatusMessage(int position, int total)
        {
            this.position = position;
            this.total = total;

        }
    }
}