using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class SelectedServerDataMessage : NetworkMessage
    {

	    public int serverId;
	    public string address;
	    public int port;
	    public bool canCreateNewCharacter;
	    public string ticket;
	    public string _access;


        public SelectedServerDataMessage()
        {
        }

        public SelectedServerDataMessage(int serverId, string address, int port, bool canCreateNewCharacter, string ticket, string _access)
        {
            this.serverId = serverId;
            this.address = address;
            this.port = port;
            this.canCreateNewCharacter = canCreateNewCharacter;
            this.ticket = ticket;
            this._access = _access;

        }
    }
}