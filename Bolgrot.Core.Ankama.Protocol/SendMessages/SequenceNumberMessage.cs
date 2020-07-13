using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolgrot.Core.Ankama.Protocol.SendMessages
{
    public class SequenceNumberMessage : CallNetworkMessage
    {

	    public int number;


        public SequenceNumberMessage()
        {
        }

        public SequenceNumberMessage(int number)
        {
            this.number = number;

        }
    }
}