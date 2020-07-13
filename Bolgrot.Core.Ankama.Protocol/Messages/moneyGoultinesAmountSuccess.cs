using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class moneyGoultinesAmountSuccess : NetworkMessage
    {

	    public int goultinesAmount;


        public moneyGoultinesAmountSuccess()
        {
        }

        public moneyGoultinesAmountSuccess(int goultinesAmount)
        {
            this.goultinesAmount = goultinesAmount;

        }
    }
}