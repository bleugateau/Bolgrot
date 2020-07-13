using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.Messages
{
    public class ExchangeLeaveMessage : NetworkMessage
    {

	    public int dialogType;
	    public bool success;


        public ExchangeLeaveMessage()
        {
        }

        public ExchangeLeaveMessage(int dialogType, bool success)
        {
            this.dialogType = dialogType;
            this.success = success;

        }
    }
}