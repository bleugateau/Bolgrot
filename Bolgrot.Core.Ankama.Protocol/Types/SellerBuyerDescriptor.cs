using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class SellerBuyerDescriptor
    {

	    public int[] quantities;
	    public int[] types;
	    public int taxPercentage;
	    public int maxItemLevel;
	    public int maxItemPerAccount;
	    public int npcContextualId;
	    public int unsoldDelay;


	    public string _type = "SellerBuyerDescriptor";

        public SellerBuyerDescriptor()
        {
        }

        public SellerBuyerDescriptor(int[] quantities, int[] types, int taxPercentage, int maxItemLevel, int maxItemPerAccount, int npcContextualId, int unsoldDelay)
        {
            this.quantities = quantities;
            this.types = types;
            this.taxPercentage = taxPercentage;
            this.maxItemLevel = maxItemLevel;
            this.maxItemPerAccount = maxItemPerAccount;
            this.npcContextualId = npcContextualId;
            this.unsoldDelay = unsoldDelay;

        }
    }
}