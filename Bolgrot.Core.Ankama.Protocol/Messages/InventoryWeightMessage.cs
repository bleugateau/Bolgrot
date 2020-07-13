using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class InventoryWeightMessage : NetworkMessage
    {

	    public int weight;
	    public int weightMax;


        public InventoryWeightMessage()
        {
        }

        public InventoryWeightMessage(int weight, int weightMax)
        {
            this.weight = weight;
            this.weightMax = weightMax;

        }
    }
}