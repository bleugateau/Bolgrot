using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.SendMessages
{
    public class AuthenticationTicketMessage : CallNetworkMessage
    {

	    public string ticket;
	    public string lang;


        public AuthenticationTicketMessage()
        {
        }

        public AuthenticationTicketMessage(string ticket, string lang)
        {
            this.ticket = ticket;
            this.lang = lang;

        }
    }
}