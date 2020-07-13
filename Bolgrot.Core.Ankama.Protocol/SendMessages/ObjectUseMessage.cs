using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.SendMessages
{
    public class ObjectUseMessage : CallNetworkMessage
    {

	    public int objectUID;


        public ObjectUseMessage()
        {
        }

        public ObjectUseMessage(int objectUID)
        {
            this.objectUID = objectUID;

        }
    }
}