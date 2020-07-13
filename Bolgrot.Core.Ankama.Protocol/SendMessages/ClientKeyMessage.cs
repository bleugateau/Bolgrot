using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.SendMessages
{
    public class ClientKeyMessage : CallNetworkMessage
    {

	    public string key;


        public ClientKeyMessage()
        {
        }

        public ClientKeyMessage(string key)
        {
            this.key = key;

        }
    }
}