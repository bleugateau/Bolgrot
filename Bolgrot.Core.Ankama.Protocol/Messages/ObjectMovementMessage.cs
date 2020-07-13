using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class ObjectMovementMessage : NetworkMessage
    {

	    public int objectUID;
	    public int position;


        public ObjectMovementMessage()
        {
        }

        public ObjectMovementMessage(int objectUID, int position)
        {
            this.objectUID = objectUID;
            this.position = position;

        }
    }
}