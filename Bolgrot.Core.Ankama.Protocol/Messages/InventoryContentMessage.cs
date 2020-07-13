using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolgrot.Core.Ankama.Protocol.Types;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class InventoryContentMessage : NetworkMessage
    {

	    public ObjectItem[] objects;
	    public int kamas;


        public InventoryContentMessage()
        {
        }

        public InventoryContentMessage(ObjectItem[] objects, int kamas)
        {
            this.objects = objects;
            this.kamas = kamas;

        }
    }
}