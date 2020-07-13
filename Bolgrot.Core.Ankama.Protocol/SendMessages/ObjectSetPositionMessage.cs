using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.SendMessages
{
    public class ObjectSetPositionMessage : CallNetworkMessage
    {

	    public int objectUID;
	    public int position;
	    public int quantity;


        public ObjectSetPositionMessage()
        {
        }

        public ObjectSetPositionMessage(int objectUID, int position, int quantity)
        {
            this.objectUID = objectUID;
            this.position = position;
            this.quantity = quantity;

        }
    }
}