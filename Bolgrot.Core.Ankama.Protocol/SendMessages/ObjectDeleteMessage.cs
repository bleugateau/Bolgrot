using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.SendMessages
{
    public class ObjectDeleteMessage : CallNetworkMessage
    {

	    public int objectUID;
	    public int quantity;


        public ObjectDeleteMessage()
        {
        }

        public ObjectDeleteMessage(int objectUID, int quantity)
        {
            this.objectUID = objectUID;
            this.quantity = quantity;

        }
    }
}