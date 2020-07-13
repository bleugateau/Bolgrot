using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class setShopDetailsSuccess : NetworkMessage
    {

	    public object shopDetails;


        public setShopDetailsSuccess()
        {
        }

        public setShopDetailsSuccess(object shopDetails)
        {
            this.shopDetails = shopDetails;

        }
    }
}